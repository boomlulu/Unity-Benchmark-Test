#!/usr/bin/env bash
# Shared helpers for benchmark run scripts. Sourced by run-<family>.sh / run-all.sh.
# All paths quoted (project dir name contains a space).

UNITY="${UNITY:-/Applications/Unity/Hub/Editor/2022.3.62f3c1/Unity.app/Contents/MacOS/Unity}"
PROJ="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
RESULTS="$PROJ/Results"
# persistentDataPath: ~/Library/Application Support/<company>/<product with '.'->'_'>
PERSIST="$HOME/Library/Application Support/DefaultCompany/Unity 2022_3_62f3c1"
PERF_JSON="$PERSIST/PerformanceTestResults.json"
TIMEOUT_SECS="${TIMEOUT_SECS:-1800}"

mkdir -p "$RESULTS"

# Portable timeout: this env has no `timeout`/`gtimeout` binary.
# perl alarm + exec gives a reliable SIGALRM-based timeout (exit 142 on timeout).
run_with_timeout() {
  local secs="$1"; shift
  perl -e 'alarm shift; exec @ARGV' "$secs" "$@"
}

# Run one Unity test category headless. $1=category $2=label (used for output files).
# Exit code from Unity is unreliable (teardown hang) -> caller inspects the XML.
run_category() {
  local category="$1"
  local label="${2:-$category}"
  local xml="$RESULTS/$label.xml"
  local log="$RESULTS/$label.log"

  rm -f "$PERF_JSON"      # ensure we copy back THIS run's json, not a stale one
  echo ">>> Running category '$category' (timeout ${TIMEOUT_SECS}s)"
  run_with_timeout "$TIMEOUT_SECS" "$UNITY" \
    -runTests \
    -batchmode \
    -nographics \
    -projectPath "$PROJ" \
    -testPlatform EditMode \
    -testCategory "$category" \
    -testResults "$xml" \
    -logFile "$log"
  local code=$?
  echo "    Unity exit code: $code (ignored; verdict from XML)"

  # copy perf json back from persistentDataPath
  if [ -f "$PERF_JSON" ]; then
    cp "$PERF_JSON" "$RESULTS/${label}.perf.json"
    echo "    perf json -> $RESULTS/${label}.perf.json"
  else
    echo "    WARN: no perf json at '$PERF_JSON'"
  fi

  verdict_from_xml "$xml" "$label"
  return $?
}

# Parse NUnit XML: print pass/fail counts, return non-zero if any failed or file missing.
verdict_from_xml() {
  local xml="$1"; local label="$2"
  if [ ! -f "$xml" ]; then
    echo "    [$label] FAIL: no result XML at $xml"
    return 1
  fi
  python3 - "$xml" "$label" <<'PY'
import sys, xml.etree.ElementTree as ET
xml, label = sys.argv[1], sys.argv[2]
try:
    root = ET.parse(xml).getroot()
except Exception as e:
    print(f"    [{label}] FAIL: cannot parse xml: {e}"); sys.exit(1)
# NUnit3 <test-run total= passed= failed= ...>
total = root.get("total"); passed = root.get("passed"); failed = root.get("failed")
if total is None:  # fallback: count <test-case result=...>
    cases = root.iter("test-case")
    p = f = 0
    for c in cases:
        r = (c.get("result") or "").lower()
        if r == "passed": p += 1
        elif r in ("failed", "error"): f += 1
    total, passed, failed = str(p+f), str(p), str(f)
print(f"    [{label}] total={total} passed={passed} failed={failed}")
sys.exit(0 if (failed in (None,"0")) and (total not in (None,"0")) else 1)
PY
}
