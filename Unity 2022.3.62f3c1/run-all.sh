#!/usr/bin/env bash
# Run every collection-benchmark family in sequence, generate the report, then
# auto-archive the result via benchmarks/archive-report.sh.
#
# Usage:
#   ./run-all.sh [label]        # run all + archive snapshot (label optional)
#   NO_ARCHIVE=1 ./run-all.sh   # run all but skip the archive step
#
# The optional [label] is passed straight through to archive-report.sh, which
# tags the history entry (e.g. ...__baseline).
set -uo pipefail
source "$(dirname "${BASH_SOURCE[0]}")/run-common.sh"

LABEL="${1:-}"

FAMILIES=(Generic Legacy Concurrent ObjectModel Immutable Native)
declare -a FAILED=()

for fam in "${FAMILIES[@]}"; do
  if ! run_category "$fam" "$fam"; then
    FAILED+=("$fam")
  fi
  echo
done

echo "=== Generating report ==="
python3 "$PROJ/Tools/gen_report.py" "$RESULTS"/*.perf.json || echo "report gen failed"

echo
echo "=== Summary ==="
if [ "${#FAILED[@]}" -eq 0 ]; then
  echo "All families passed."
else
  echo "Families with failures/no-results: ${FAILED[*]}"
fi

echo
echo "=== Archiving report ==="
if [ -z "${NO_ARCHIVE:-}" ]; then
  "$(dirname "$PROJ")/benchmarks/archive-report.sh" "$LABEL"
else
  echo "NO_ARCHIVE set, skip archive"
fi
