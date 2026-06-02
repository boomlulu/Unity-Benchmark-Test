#!/usr/bin/env bash
# Run every collection-benchmark family in sequence, then generate the report.
set -uo pipefail
source "$(dirname "${BASH_SOURCE[0]}")/run-common.sh"

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
