#!/usr/bin/env bash
#
# archive-report.sh — snapshot the current CollectionBenchmark.{md,csv} into a
# git-tracked, versioned archive under benchmarks/history/<id>/.
#
# An <id> looks like:   20260603-0312__7a30802            (no label)
#                       20260603-0312__7a30802__baseline  (label "baseline")
#
# Usage:
#   benchmarks/archive-report.sh [label]
#
# Env overrides:
#   PROJ_DIR   Unity project dir name under repo root.
#              Default "Unity 2022.3.62f3c1". Set this when a second Unity
#              version is added so the archiver reads the right Results/ dir.
#
# Writes <id>/CollectionBenchmark.md, <id>/CollectionBenchmark.csv, <id>/meta.json
# then prints where it wrote + a one-line summary.
#
# bash 3.2 compatible. python3 (stdlib only) used for ISO timestamp, CSV row
# count, and XML test-run aggregation. All paths are quoted (project dir name
# contains a space).

set -euo pipefail

# --- resolve repo root from this script's location: benchmarks/ -> parent ---
SCRIPT_SOURCE="${BASH_SOURCE[0]}"
SCRIPT_DIR="$(cd "$(dirname "$SCRIPT_SOURCE")" && pwd)"   # .../benchmarks
REPO="$(cd "$SCRIPT_DIR/.." && pwd)"                      # repo root
HISTORY="$SCRIPT_DIR/history"

# --- project / results layout (env-overridable PROJ_DIR for future versions) ---
PROJ_DIR="${PROJ_DIR:-Unity 2022.3.62f3c1}"
RESULTS="$REPO/$PROJ_DIR/Results"
VERSION_TXT="$REPO/$PROJ_DIR/ProjectSettings/ProjectVersion.txt"

MD_SRC="$RESULTS/CollectionBenchmark.md"
CSV_SRC="$RESULTS/CollectionBenchmark.csv"

LABEL="${1:-}"

# --- preflight ---
if [ ! -f "$CSV_SRC" ]; then
  echo "ERROR: not found: $CSV_SRC" >&2
  echo "       (run the benchmark + report generator first, or set PROJ_DIR)" >&2
  exit 1
fi
if [ ! -f "$MD_SRC" ]; then
  echo "ERROR: not found: $MD_SRC" >&2
  exit 1
fi

# --- git identity (short sha + dirty flag) ---
GIT_SHA="$(git -C "$REPO" rev-parse --short HEAD 2>/dev/null || echo unknown)"
if [ -n "$(git -C "$REPO" status --porcelain 2>/dev/null)" ]; then
  GIT_DIRTY="true"
else
  GIT_DIRTY="false"
fi

# --- build the archive id ---
STAMP="$(date +%Y%m%d-%H%M)"
ID="${STAMP}__${GIT_SHA}"
if [ -n "$LABEL" ]; then
  ID="${ID}__${LABEL}"
fi

DEST="$HISTORY/$ID"
mkdir -p "$DEST"

cp "$MD_SRC" "$DEST/CollectionBenchmark.md"
cp "$CSV_SRC" "$DEST/CollectionBenchmark.csv"

# --- unity version from ProjectVersion.txt (m_EditorVersion) ---
UNITY_VERSION="unknown"
if [ -f "$VERSION_TXT" ]; then
  # line: "m_EditorVersion: 2022.3.62f3c1"
  UNITY_VERSION="$(grep '^m_EditorVersion:' "$VERSION_TXT" | head -1 | sed 's/^m_EditorVersion:[[:space:]]*//' || true)"
  [ -z "$UNITY_VERSION" ] && UNITY_VERSION="unknown"
fi

# --- write meta.json (python3: ISO ts, CSV rows, XML test-run totals) ---
META="$DEST/meta.json"
RESULTS_DIR="$RESULTS" \
CSV_PATH="$DEST/CollectionBenchmark.csv" \
META_PATH="$META" \
GIT_SHA="$GIT_SHA" \
GIT_DIRTY="$GIT_DIRTY" \
UNITY_VERSION="$UNITY_VERSION" \
LABEL="$LABEL" \
python3 - <<'PY'
import csv, glob, json, os, datetime
import xml.etree.ElementTree as ET

results_dir = os.environ["RESULTS_DIR"]
csv_path    = os.environ["CSV_PATH"]
meta_path   = os.environ["META_PATH"]

# rows = data lines in the snapshotted CSV (excluding header)
rows = 0
try:
    with open(csv_path, newline="") as f:
        n = sum(1 for _ in csv.reader(f))
    rows = max(n - 1, 0)
except Exception:
    rows = 0

# total/passed/failed: sum over each Results/*.xml <test-run> element.
total = passed = failed = 0
for xml in sorted(glob.glob(os.path.join(results_dir, "*.xml"))):
    try:
        root = ET.parse(xml).getroot()
    except Exception:
        continue
    tr = root if root.tag == "test-run" else root.find(".//test-run")
    if tr is None:
        continue
    def attr(name):
        try:
            return int(tr.get(name, "0") or "0")
        except (TypeError, ValueError):
            return 0
    total  += attr("total")
    passed += attr("passed")
    failed += attr("failed")

meta = {
    "ts": datetime.datetime.now().astimezone().replace(microsecond=0).isoformat(),
    "git_sha": os.environ["GIT_SHA"],
    "git_dirty": os.environ["GIT_DIRTY"] == "true",
    "unity_version": os.environ["UNITY_VERSION"],
    "label": os.environ["LABEL"],
    "rows": rows,
    "total": total,
    "passed": passed,
    "failed": failed,
}
with open(meta_path, "w") as f:
    json.dump(meta, f, indent=2, ensure_ascii=False)
    f.write("\n")

# emit a couple of values back to the shell for the summary line
print("ROWS=%d" % rows)
print("PASSED=%d" % passed)
print("TOTAL=%d" % total)
PY

# --- recover summary numbers from meta.json (single source of truth) ---
read_meta() {
  python3 - "$META" "$1" <<'PY'
import json, sys
with open(sys.argv[1]) as f:
    print(json.load(f).get(sys.argv[2], ""))
PY
}
ROWS="$(read_meta rows)"
PASSED="$(read_meta passed)"
TOTAL="$(read_meta total)"

echo "archived -> $DEST"
echo "  meta   -> $META"
echo "summary: id=$ID  rows=$ROWS  passed=$PASSED/$TOTAL  unity=$UNITY_VERSION  dirty=$GIT_DIRTY"
