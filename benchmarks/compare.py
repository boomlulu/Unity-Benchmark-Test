#!/usr/bin/env python3
"""
compare.py — diff two archived CollectionBenchmark snapshots.

    python3 compare.py <A> <B> [--metric time|gc|both] [--threshold 10] [--top 30]
                       [--md PATH]

A and B are either entry names under benchmarks/history/ (e.g.
"20260603-0312__7a30802__baseline") or direct paths to such a directory.
Each must contain CollectionBenchmark.csv and (optionally) meta.json.

A == "before/baseline", B == "after/candidate". Regression = B is worse than A.

CSV schema (the REAL header, verified against Results/CollectionBenchmark.csv —
columns are ENGLISH; the Chinese names only appear in the .md table):

    family,collection,op,elem,n,time_ms,gc_bytes,bigo_time,bigo_space,note

Row key = (family, collection, op, elem, n).
Measured values = time_ms (float), gc_bytes (float).

  metric time : compare time_ms
  metric gc   : compare gc_bytes
  metric both : compare both (default)

A row is a REGRESSION when, for a compared metric, B exceeds A by more than
--threshold percent (slower / more GC). An IMPROVEMENT is the symmetric case.
Keys present on only one side are reported as added (B-only) / removed (A-only).

Exit code: non-zero when at least one regression beyond threshold exists (so the
script can gate CI); zero otherwise. stdlib only (csv/json/argparse).

--md PATH writes the full comparison as a Markdown report to PATH (header from
both meta.json, summary counts table, top-regression / top-improvement tables,
and added/removed key lists). Without --md the original stdout report is
unchanged; with --md stdout prints a brief summary instead. The exit-code
semantics are identical in both modes.
"""

import argparse
import csv
import json
import os
import sys

# Real CSV header (English). Used to locate columns by name, not by position.
COL_FAMILY = "family"
COL_COLLECTION = "collection"
COL_OP = "op"
COL_ELEM = "elem"
COL_N = "n"
COL_TIME = "time_ms"
COL_GC = "gc_bytes"

KEY_COLS = (COL_FAMILY, COL_COLLECTION, COL_OP, COL_ELEM, COL_N)

HISTORY_DIR = os.path.join(os.path.dirname(os.path.abspath(__file__)), "history")


def resolve_dir(arg):
    """Accept an entry name under history/ or a direct path; return a dir."""
    if os.path.isdir(arg):
        return arg
    cand = os.path.join(HISTORY_DIR, arg)
    if os.path.isdir(cand):
        return cand
    # also tolerate a path to the csv/meta file itself
    if os.path.isfile(arg):
        return os.path.dirname(arg)
    sys.exit("ERROR: not a history entry or directory: %s" % arg)


def to_float(s):
    if s is None:
        return None
    s = s.strip()
    if s == "":
        return None
    try:
        return float(s)
    except ValueError:
        return None


def load_csv(d):
    """Return {key_tuple: {'time': float|None, 'gc': float|None}} keyed by the
    real CSV columns."""
    path = os.path.join(d, "CollectionBenchmark.csv")
    if not os.path.isfile(path):
        sys.exit("ERROR: missing CollectionBenchmark.csv in %s" % d)
    out = {}
    with open(path, newline="") as f:
        reader = csv.DictReader(f)
        missing = [c for c in KEY_COLS + (COL_TIME, COL_GC)
                   if c not in (reader.fieldnames or [])]
        if missing:
            sys.exit("ERROR: %s header missing columns %s; got %s"
                     % (path, missing, reader.fieldnames))
        for row in reader:
            key = tuple(str(row.get(c, "")).strip() for c in KEY_COLS)
            out[key] = {
                "time": to_float(row.get(COL_TIME)),
                "gc": to_float(row.get(COL_GC)),
            }
    return out


def load_meta(d):
    path = os.path.join(d, "meta.json")
    if os.path.isfile(path):
        try:
            with open(path) as f:
                return json.load(f)
        except Exception:
            return {}
    return {}


def pct_change(a, b):
    """Percent change from a -> b. Returns float, or None for n/a, or +inf."""
    if a is None or b is None:
        return None
    if a == 0:
        if b == 0:
            return 0.0
        return float("inf")  # grew from zero
    return (b - a) / abs(a) * 100.0


def classify(a, b, threshold):
    """Return 'regression' | 'improvement' | 'unchanged' | None for one metric.
    Higher value = worse (time slower / more GC). None when not comparable."""
    if a is None or b is None:
        return None
    pc = pct_change(a, b)
    if pc is None:
        return None
    if pc == float("inf"):
        return "regression"  # 0 -> positive
    if pc > threshold:
        return "regression"
    if pc < -threshold:
        return "improvement"
    return "unchanged"


def fmt_pct(pc):
    if pc is None:
        return "n/a"
    if pc == float("inf"):
        return "+inf"
    return "%+.1f%%" % pc


def fmt_val(v):
    if v is None:
        return "-"
    if v == int(v):
        return "%d" % int(v)
    return "%.4g" % v


def key_str(k):
    return "/".join(k)


def metric_label(m):
    return {"time": "time_ms", "gc": "gc_bytes"}[m]


def build_diffs(A, B, metric, threshold):
    """For each shared key + compared metric, produce a diff record. Returns
    (regressions, improvements, counts dict, added set, removed set)."""
    metrics = ["time", "gc"] if metric == "both" else [metric]
    a_keys, b_keys = set(A), set(B)
    shared = a_keys & b_keys
    added = b_keys - a_keys      # only in B
    removed = a_keys - b_keys    # only in A

    regressions = []
    improvements = []
    counts = {"improved": 0, "regressed": 0, "unchanged": 0,
              "added": len(added), "removed": len(removed)}

    for k in shared:
        for m in metrics:
            av = A[k][m]
            bv = B[k][m]
            verdict = classify(av, bv, threshold)
            if verdict is None:
                continue
            pc = pct_change(av, bv)
            rec = {
                "key": k,
                "metric": m,
                "a": av,
                "b": bv,
                "delta": (None if (av is None or bv is None) else bv - av),
                "pct": pc,
            }
            if verdict == "regression":
                counts["regressed"] += 1
                regressions.append(rec)
            elif verdict == "improvement":
                counts["improved"] += 1
                improvements.append(rec)
            else:
                counts["unchanged"] += 1

    # sort worst-first for regressions, best-first for improvements.
    def sort_pct(rec):
        pc = rec["pct"]
        return float("inf") if pc == float("inf") else (pc if pc is not None else 0.0)

    regressions.sort(key=sort_pct, reverse=True)
    improvements.sort(key=sort_pct)  # most negative first
    return regressions, improvements, counts, added, removed


def print_table(title, recs, top):
    print()
    print(title)
    if not recs:
        print("  (none)")
        return
    print("  %-9s %-7s %12s %12s %10s  %s"
          % ("metric", "", "A", "B", "Δ%", "key"))
    for rec in recs[:top]:
        print("  %-9s %-7s %12s %12s %10s  %s" % (
            metric_label(rec["metric"]),
            "",
            fmt_val(rec["a"]),
            fmt_val(rec["b"]),
            fmt_pct(rec["pct"]),
            key_str(rec["key"]),
        ))
    if len(recs) > top:
        print("  ... %d more" % (len(recs) - top))


def hdr_line(tag, d, meta):
    return ("%s: %s  label=%s  sha=%s  unity=%s  passed=%s/%s"
            % (tag,
               os.path.basename(os.path.normpath(d)),
               meta.get("label") or "-",
               meta.get("git_sha") or "-",
               meta.get("unity_version") or "-",
               meta.get("passed", "-"),
               meta.get("total", "-")))


# ---------------------------------------------------------------------------
# Markdown emitter. Consumes the SAME diff records produced by build_diffs();
# it does not re-run any comparison. Each regression/improvement record has the
# shape {key, metric, a, b, delta, pct}.
# ---------------------------------------------------------------------------

def md_escape(s):
    """Escape '|' and backslashes so a cell can't break the table layout."""
    return str(s).replace("\\", "\\\\").replace("|", "\\|")


def md_hdr_row(tag, d, meta):
    return ("| %s | %s | %s | %s | %s | %s/%s |"
            % (tag,
               md_escape(os.path.basename(os.path.normpath(d))),
               md_escape(meta.get("label") or "-"),
               md_escape(meta.get("git_sha") or "-"),
               md_escape(meta.get("unity_version") or "-"),
               md_escape(meta.get("passed", "-")),
               md_escape(meta.get("total", "-"))))


def md_diff_table(lines, title, recs, top):
    lines.append("")
    lines.append("### %s" % title)
    lines.append("")
    if not recs:
        lines.append("_(none)_")
        return
    lines.append("| family | collection | op | elem | N | A | B | Δ | Δ% | metric |")
    lines.append("|---|---|---|---|---|---:|---:|---:|---:|---|")
    for rec in recs[:top]:
        fam, coll, op, elem, n = rec["key"]
        lines.append("| %s | %s | %s | %s | %s | %s | %s | %s | %s | %s |" % (
            md_escape(fam), md_escape(coll), md_escape(op),
            md_escape(elem), md_escape(n),
            fmt_val(rec["a"]), fmt_val(rec["b"]),
            fmt_val(rec["delta"]), fmt_pct(rec["pct"]),
            metric_label(rec["metric"]),
        ))
    if len(recs) > top:
        lines.append("")
        lines.append("_... %d more_" % (len(recs) - top))


def md_key_list(lines, title, keys, sign, top):
    if not keys:
        return
    lines.append("")
    lines.append("### %s: %d" % (title, len(keys)))
    lines.append("")
    for k in sorted(keys)[:top]:
        lines.append("- `%s %s`" % (sign, key_str(k)))
    if len(keys) > top:
        lines.append("")
        lines.append("_... %d more_" % (len(keys) - top))


def render_md(dirA, dirB, metaA, metaB, A, B,
              metric, threshold, regressions, improvements,
              counts, added, removed, top):
    lines = []
    lines.append("# CollectionBenchmark comparison: A (baseline) vs B (candidate)")
    lines.append("")
    lines.append("| side | snapshot | label | sha | unity | passed |")
    lines.append("|---|---|---|---|---|---|")
    lines.append(md_hdr_row("A (baseline)", dirA, metaA))
    lines.append(md_hdr_row("B (candidate)", dirB, metaB))
    lines.append("")
    lines.append("metric=`%s`  threshold=`%.1f%%`  keys: A=%d B=%d shared=%d"
                 % (metric, threshold, len(A), len(B), len(set(A) & set(B))))
    lines.append("")
    lines.append("## Summary")
    lines.append("")
    lines.append("| improved | regressed | unchanged | added | removed |")
    lines.append("|---:|---:|---:|---:|---:|")
    lines.append("| %d | %d | %d | %d | %d |"
                 % (counts["improved"], counts["regressed"], counts["unchanged"],
                    counts["added"], counts["removed"]))
    lines.append("")
    lines.append("## Detail")
    md_diff_table(lines, "Top regressions (B worse than A)", regressions, top)
    md_diff_table(lines, "Top improvements (B better than A)", improvements, top)
    md_key_list(lines, "Added (B-only keys)", added, "+", top)
    md_key_list(lines, "Removed (A-only keys)", removed, "-", top)
    return "\n".join(lines) + "\n"


def main():
    ap = argparse.ArgumentParser(
        description="Compare two archived CollectionBenchmark snapshots (A=before, B=after).")
    ap.add_argument("A", help="history entry name or path (baseline)")
    ap.add_argument("B", help="history entry name or path (candidate)")
    ap.add_argument("--metric", choices=["time", "gc", "both"], default="both")
    ap.add_argument("--threshold", type=float, default=10.0,
                    help="percent worse/better to count as regression/improvement (default 10)")
    ap.add_argument("--top", type=int, default=30,
                    help="max rows per table (default 30)")
    ap.add_argument("--md", metavar="PATH", default=None,
                    help="write the full comparison as Markdown to PATH "
                         "(stdout then prints only a brief summary)")
    args = ap.parse_args()

    dirA = resolve_dir(args.A)
    dirB = resolve_dir(args.B)
    A = load_csv(dirA)
    B = load_csv(dirB)
    metaA = load_meta(dirA)
    metaB = load_meta(dirB)

    regressions, improvements, counts, added, removed = build_diffs(
        A, B, args.metric, args.threshold)

    if args.md:
        md = render_md(dirA, dirB, metaA, metaB, A, B,
                       args.metric, args.threshold,
                       regressions, improvements, counts, added, removed,
                       args.top)
        with open(args.md, "w") as f:
            f.write(md)
        # brief summary to stdout; full report lives in the .md file.
        print("wrote markdown report -> %s" % args.md)
        print("metric=%s  threshold=%.1f%%  keys: A=%d B=%d shared=%d"
              % (args.metric, args.threshold, len(A), len(B),
                 len(set(A) & set(B))))
        print("summary: improved=%d regressed=%d unchanged=%d added=%d removed=%d"
              % (counts["improved"], counts["regressed"], counts["unchanged"],
                 counts["added"], counts["removed"]))
        sys.exit(1 if counts["regressed"] > 0 else 0)

    print(hdr_line("A (baseline) ", dirA, metaA))
    print(hdr_line("B (candidate)", dirB, metaB))
    print()
    print("metric=%s  threshold=%.1f%%  keys: A=%d B=%d shared=%d"
          % (args.metric, args.threshold, len(A), len(B), len(set(A) & set(B))))
    print("summary: improved=%d regressed=%d unchanged=%d added=%d removed=%d"
          % (counts["improved"], counts["regressed"], counts["unchanged"],
             counts["added"], counts["removed"]))

    print_table("Top regressions (B worse than A):", regressions, args.top)
    print_table("Top improvements (B better than A):", improvements, args.top)

    if added:
        print()
        print("Added (B-only keys): %d" % len(added))
        for k in sorted(added)[:args.top]:
            print("  + %s" % key_str(k))
        if len(added) > args.top:
            print("  ... %d more" % (len(added) - args.top))
    if removed:
        print()
        print("Removed (A-only keys): %d" % len(removed))
        for k in sorted(removed)[:args.top]:
            print("  - %s" % key_str(k))
        if len(removed) > args.top:
            print("  ... %d more" % (len(removed) - args.top))

    # CI gate: any regression beyond threshold -> non-zero exit.
    sys.exit(1 if counts["regressed"] > 0 else 0)


if __name__ == "__main__":
    main()
