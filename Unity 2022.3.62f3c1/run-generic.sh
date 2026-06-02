#!/usr/bin/env bash
# Run the Generic collection-benchmark family headless.
set -uo pipefail
source "$(dirname "${BASH_SOURCE[0]}")/run-common.sh"
run_category "Generic" "Generic"
exit $?
