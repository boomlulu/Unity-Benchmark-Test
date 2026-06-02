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

# Kill a process tree: children first, then the process itself.
# TERM with a short grace window, then KILL anything still alive.
# Used to reap Unity once results are on disk (it would otherwise hang in teardown).
kill_tree() {
  local pid="$1"
  pkill -TERM -P "$pid" 2>/dev/null   # children of Unity
  kill -TERM "$pid"     2>/dev/null   # Unity itself
  # grace: poll up to 5s for a clean exit
  local g=0
  while [ "$g" -lt 5 ] && kill -0 "$pid" 2>/dev/null; do
    sleep 1
    g=$((g + 1))
  done
  # still alive -> hard kill
  if kill -0 "$pid" 2>/dev/null; then
    pkill -KILL -P "$pid" 2>/dev/null
    kill -KILL "$pid"     2>/dev/null
  fi
}

# Run one Unity test category headless. $1=category $2=label (used for output files).
#
# Unity 2022.3 on Apple Silicon writes the result XML + perf json, then hangs in
# teardown for ~13min before exiting. Waiting for the process is pointless: the
# data we need is already on disk. So we launch Unity in the BACKGROUND, poll for
# the XML, and KILL Unity the moment the XML is complete (</test-run>). Killing at
# this point is safe -- Stage-1 proved the files are flushed before the hang.
#
# Exit code from Unity is unreliable (we kill it / it hangs) -> verdict comes from
# the XML, never from $?. TIMEOUT_SECS is only a safety backstop; the normal path
# kills Unity within a few minutes.
run_category() {
  local category="$1"
  local label="${2:-$category}"
  local xml="$RESULTS/$label.xml"
  local log="$RESULTS/$label.log"

  # ensure we never read THIS run's verdict/perf from a stale file
  rm -f "$xml" "$PERF_JSON" "$RESULTS/${label}.perf.json"

  echo ">>> Running category '$category' (XML-complete kill; safety timeout ${TIMEOUT_SECS}s)"

  # launch Unity in the background; same args as before
  "$UNITY" \
    -runTests \
    -batchmode \
    -nographics \
    -projectPath "$PROJ" \
    -testPlatform EditMode \
    -testCategory "$category" \
    -testResults "$xml" \
    -logFile "$log" &
  local upid=$!

  local interval=3
  local elapsed=0
  local done=0
  while [ "$elapsed" -lt "$TIMEOUT_SECS" ]; do
    # Unity exited on its own (rare on Apple Silicon) -> nothing left to do
    if ! kill -0 "$upid" 2>/dev/null; then
      echo "    Unity exited on its own after ~${elapsed}s"
      done=1
      break
    fi
    # XML complete -> results are on disk; kill Unity to skip the teardown hang
    if [ -f "$xml" ] && grep -q '</test-run>' "$xml" 2>/dev/null; then
      echo "    XML done after ~${elapsed}s, killing Unity"
      # small grace for the perf json to flush (<=10s)
      local g=0
      while [ ! -f "$PERF_JSON" ] && [ "$g" -lt 10 ]; do
        sleep 1
        g=$((g + 1))
      done
      kill_tree "$upid"
      done=1
      break
    fi
    sleep "$interval"
    elapsed=$((elapsed + interval))
  done

  # safety backstop: XML never completed within TIMEOUT_SECS
  if [ "$done" -eq 0 ]; then
    echo "    SAFETY TIMEOUT after ${TIMEOUT_SECS}s, killing Unity"
    kill_tree "$upid"
  fi

  wait "$upid" 2>/dev/null   # reap the (now dead) background process

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
