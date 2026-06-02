#!/usr/bin/env bash
# Run the Native collection-benchmark family headless.
set -uo pipefail
source "$(dirname "${BASH_SOURCE[0]}")/run-common.sh"
run_category "Native" "Native"
exit $?
