#!/usr/bin/env bash
# Run the Legacy collection-benchmark family headless.
set -uo pipefail
source "$(dirname "${BASH_SOURCE[0]}")/run-common.sh"
run_category "Legacy" "Legacy"
exit $?
