#!/usr/bin/env python3
"""
gen_report.py — Collection Benchmark report generator (SPEC §8).

Parses Unity Performance Testing perf JSON (a `Run` object: Results[].SampleGroups[]),
splits each test Name into <Collection>/<Op>/<Elem>/N, pulls Time median(ms) +
"GC Allocated" median(bytes), merges Tools/complexity.json (Big-O time/space), and
writes Results/CollectionBenchmark.md + .csv.

Test-name convention (from BenchmarkSupport.cs):
    <Collection>_<Op>_<Elem>_N<size>     e.g. List_Add_int_N1000
NUnit may wrap it as Namespace.Class.Method or Method with a category suffix; we
parse the last dotted token and strip any "(...)" arg tail.

Usage:
    python3 gen_report.py [perf_json ...]
If no path given, auto-discovers:
    1. Results/*.json (and Results/PerformanceTestResults*.json)
    2. ~/Library/Application Support/<company>/<product>/PerformanceTestResults.json (persistentDataPath)
"""

import csv
import glob
import json
import os
import re
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
PROJ = os.path.dirname(HERE)
RESULTS = os.path.join(PROJ, "Results")
COMPLEXITY = os.path.join(HERE, "complexity.json")

TIME_GROUP = "Time"
GC_GROUP = "GC Allocated"

# SampleUnit enum -> multiplier to milliseconds (JsonUtility serializes enum as int).
UNIT_INT_TO_MS = {0: 1e-6, 1: 1e-3, 2: 1.0, 3: 1000.0}  # ns, us, ms, s
UNIT_STR_TO_MS = {"Nanosecond": 1e-6, "Microsecond": 1e-3, "Millisecond": 1.0, "Second": 1000.0,
                  "ns": 1e-6, "us": 1e-3, "μs": 1e-3, "ms": 1.0, "s": 1000.0}


def to_ms(median, unit):
    if unit is None:
        return median
    if isinstance(unit, (int, float)):
        return median * UNIT_INT_TO_MS.get(int(unit), 1.0)
    return median * UNIT_STR_TO_MS.get(str(unit), 1.0)


def parse_test_name(raw):
    """Return (collection, op, elem, n, method_token).

    Supports BOTH naming conventions that now coexist:
      - explicit (Immutable):       Coll_Op_Elem_N100
      - parameterized ([Values]):   Coll_Op_Elem(100)   (NUnit appends "(100)")

    N is extracted from EITHER source: a trailing "(<digits>)" arg tail, OR an
    in-name "_N<digits>" marker. Whichever matches wins. The collection/op/elem
    stem is then taken after stripping BOTH size markers and split on "_".
    """
    token = raw.strip()
    # take last dotted segment (Namespace.Class.Method -> Method); keep any arg tail
    method = token.split(".")[-1]

    n = None
    # 1) trailing NUnit arg tail like Method(100) used by [Values] parameterized tests
    m_tail = re.search(r"\((\d+)\)\s*$", method)
    if m_tail:
        n = int(m_tail.group(1))
    # strip any "(...)" arg tail (handles (100), (), ("x") etc.) to get the stem
    stem = re.sub(r"\(.*\)\s*$", "", method).strip()

    # 2) in-name _N<digits> marker used by explicit-style tests (Immutable)
    m_name = re.search(r"_N(\d+)$", stem)
    if m_name:
        if n is None:
            n = int(m_name.group(1))
        # remove the _N<size> marker from the stem
        stem = stem[:m_name.start()]

    parts = stem.split("_")
    coll = parts[0] if parts else stem
    op = parts[1] if len(parts) > 1 else ""
    elem = parts[2] if len(parts) > 2 else ""
    return coll, op, elem, n, method


def load_complexity():
    """Merge ALL Tools/complexity*.json (complexity.json + complexity.<Family>.json).

    Big-O reference is now split per family; we union them into one dict keyed by
    <Collection>_<Op>. Keys are family-unique in practice; on the off chance of a
    duplicate key, later file wins (harmless — same Coll_Op => same Big-O). The
    "_comment" meta key is dropped so it never leaks into lookups.
    """
    merged = {}
    for path in sorted(glob.glob(os.path.join(HERE, "complexity*.json"))):
        try:
            with open(path) as f:
                data = json.load(f)
        except Exception as e:
            print(f"WARN: skip complexity {path}: {e}", file=sys.stderr)
            continue
        if isinstance(data, dict):
            merged.update(data)
    merged.pop("_comment", None)
    return merged


def discover_inputs():
    found = []
    for pat in ("*.json",):
        found += glob.glob(os.path.join(RESULTS, pat))
    if found:
        return found
    # fall back to persistentDataPath copies
    base = os.path.expanduser("~/Library/Application Support")
    hits = glob.glob(os.path.join(base, "*", "*", "PerformanceTestResults.json"))
    return hits


def extract_rows(run_json, complexity):
    rows = []
    results = run_json.get("Results", []) if isinstance(run_json, dict) else []
    for res in results:
        name = res.get("Name") or res.get("MethodName") or ""
        cats = res.get("Categories") or []
        family = cats[0] if cats else ""
        coll, op, elem, n, method = parse_test_name(name)

        time_ms = None
        gc_bytes = None
        for sg in res.get("SampleGroups", []):
            gname = sg.get("Name", "")
            median = sg.get("Median")
            if median is None and sg.get("Samples"):
                s = sorted(sg["Samples"])
                median = s[len(s) // 2]
            if gname == GC_GROUP:
                gc_bytes = median
            elif gname == TIME_GROUP or sg.get("Unit") in (0, 1, 2, 3,
                    "Nanosecond", "Microsecond", "Millisecond", "Second"):
                # the time group from Measure.Method is named "Time"
                if gname == TIME_GROUP or time_ms is None:
                    time_ms = to_ms(median, sg.get("Unit"))

        key = f"{coll}_{op}"
        cx = complexity.get(key, {})
        big_o_time = cx.get("time", "")
        big_o_space = cx.get("space", "")

        note = []
        if elem in ("int",) and family == "Legacy":
            note.append("boxing")
        if "Builder" in op:
            note.append("builder")
        notes = " ".join(note)

        rows.append({
            "family": family,
            "collection": coll,
            "op": op,
            "elem": elem,
            "n": n if n is not None else "",
            "time_ms": time_ms,
            "gc_bytes": gc_bytes,
            "bigo_time": big_o_time,
            "bigo_space": big_o_space,
            "note": notes,
        })
    return rows


def fmt_num(x, digits=4):
    if x is None:
        return ""
    if isinstance(x, float):
        return f"{x:.{digits}g}"
    return str(x)


def write_md(rows, path):
    cols = ["家族", "集合", "操作", "元素类型", "N", "时间中位(ms)", "GC(bytes)",
            "Big-O 时间", "Big-O 空间", "备注"]
    lines = ["# Collection Benchmark Results", "",
             f"Rows: {len(rows)}  (Stage-1 sample run)", "",
             "| " + " | ".join(cols) + " |",
             "|" + "|".join(["---"] * len(cols)) + "|"]
    for r in rows:
        lines.append("| " + " | ".join([
            str(r["family"]), str(r["collection"]), str(r["op"]), str(r["elem"]),
            str(r["n"]), fmt_num(r["time_ms"]), fmt_num(r["gc_bytes"], 6),
            r["bigo_time"], r["bigo_space"], r["note"],
        ]) + " |")
    with open(path, "w") as f:
        f.write("\n".join(lines) + "\n")


def write_csv(rows, path):
    cols = ["family", "collection", "op", "elem", "n", "time_ms", "gc_bytes",
            "bigo_time", "bigo_space", "note"]
    with open(path, "w", newline="") as f:
        w = csv.DictWriter(f, fieldnames=cols)
        w.writeheader()
        for r in rows:
            w.writerow(r)


def main():
    os.makedirs(RESULTS, exist_ok=True)
    inputs = sys.argv[1:] or discover_inputs()
    inputs = [p for p in inputs
              if os.path.basename(p) not in ("CollectionBenchmark.json",)]
    if not inputs:
        print("ERROR: no perf JSON found. Pass a path or copy PerformanceTestResults.json into Results/.",
              file=sys.stderr)
        sys.exit(2)

    complexity = load_complexity()
    all_rows = []
    seen = set()
    for path in inputs:
        try:
            with open(path) as f:
                data = json.load(f)
        except Exception as e:
            print(f"WARN: skip {path}: {e}", file=sys.stderr)
            continue
        rows = extract_rows(data, complexity)
        for r in rows:
            k = (r["family"], r["collection"], r["op"], r["elem"], r["n"])
            if k in seen:
                continue
            seen.add(k)
            all_rows.append(r)
        print(f"parsed {len(rows):3d} results from {path}")

    all_rows.sort(key=lambda r: (str(r["family"]), str(r["collection"]),
                                 str(r["op"]), str(r["elem"]),
                                 r["n"] if isinstance(r["n"], int) else 0))

    md = os.path.join(RESULTS, "CollectionBenchmark.md")
    csvp = os.path.join(RESULTS, "CollectionBenchmark.csv")
    write_md(all_rows, md)
    write_csv(all_rows, csvp)
    print(f"wrote {md}")
    print(f"wrote {csvp}")
    print(f"total rows: {len(all_rows)}")


if __name__ == "__main__":
    main()
