#!/usr/bin/env bash
# Run the Concurrent collection-benchmark family headless.
set -uo pipefail
source "$(dirname "${BASH_SOURCE[0]}")/run-common.sh"
run_category "Concurrent" "Concurrent"
exit $?
