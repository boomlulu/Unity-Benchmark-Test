# Benchmark Archive

A git-tracked archive of `CollectionBenchmark` runs, so results from different
commits / Unity versions can be compared over time.

## Directory layout

```
benchmarks/
├── README.md            ← this file
├── archive-report.sh    ← snapshot current Results/ into history/<id>/
├── compare.py           ← diff two snapshots (CI-gateable)
└── history/
    ├── .gitkeep         ← keeps the empty dir in git
    └── <id>/            ← one snapshot per run
        ├── CollectionBenchmark.md
        ├── CollectionBenchmark.csv
        └── meta.json
```

A snapshot `<id>` looks like:

```
20260603-0312__7a30802             # no label
20260603-0312__7a30802__baseline   # label "baseline"
```

i.e. `<YYYYMMDD-HHMM>__<git-short-sha>[__<label>]`.

## Workflow

```bash
# 1. produce a fresh report  (run the benchmarks, then the report generator)
#    -> writes "Unity 2022.3.62f3c1/Results/CollectionBenchmark.{md,csv}"
"Unity 2022.3.62f3c1/run-all.sh"          # (or however the suite is run)

# 2. archive that report into history/, tagging it with a label
benchmarks/archive-report.sh baseline

#    ... make changes, re-run, archive again ...
benchmarks/archive-report.sh candidate

# 3. compare two archived snapshots (A = before, B = after)
python3 benchmarks/compare.py \
    20260603-0312__7a30802__baseline \
    20260603-0420__9f1c2d3__candidate
```

`archive-report.sh` reads from the live `Results/` dir and **copies** the md+csv
into `history/<id>/` — it never mutates `Results/`.

## `meta.json` fields

| field           | meaning                                                            |
|-----------------|-------------------------------------------------------------------|
| `ts`            | ISO-8601 timestamp (local tz) when the snapshot was taken         |
| `git_sha`       | short git SHA of the repo at snapshot time                        |
| `git_dirty`     | `true` if `git status --porcelain` was non-empty (uncommitted)    |
| `unity_version` | `m_EditorVersion` from `ProjectSettings/ProjectVersion.txt`       |
| `label`         | the optional arg1 label (empty string if none)                    |
| `rows`          | data rows in the snapshotted CSV (header excluded)                 |
| `total`         | sum of `<test-run total=…>` across `Results/*.xml`                 |
| `passed`        | sum of `<test-run passed=…>` across `Results/*.xml`               |
| `failed`        | sum of `<test-run failed=…>` across `Results/*.xml`               |

### Version identity

A run is identified by **`git_sha` + `unity_version` + `label`** together. The
git SHA pins the source/benchmark code, the Unity version pins the engine/runtime,
and the label is the human-readable intent ("baseline", "after-pooling", etc.).
`git_dirty=true` warns that the SHA does not fully capture the tree.

### `PROJ_DIR` env (future multi-Unity-version support)

`archive-report.sh` reads the Unity project dir from `PROJ_DIR`, defaulting to
`Unity 2022.3.62f3c1`. When a second Unity version is added as a sibling project
dir, archive each one by overriding `PROJ_DIR`:

```bash
PROJ_DIR="Unity 2022.3.62f3c1" benchmarks/archive-report.sh u2022
PROJ_DIR="Unity 6000.0.30f1"   benchmarks/archive-report.sh u6000
```

The resulting `unity_version` in each `meta.json` then distinguishes them, and
`compare.py` will surface the engine version in its header.

## `compare.py`

```
python3 compare.py <A> <B> [--metric time|gc|both] [--threshold 10] [--top 30]
```

- `<A>` / `<B>`: a `history/` entry name **or** a path to a snapshot dir.
  `A` is the baseline (before), `B` is the candidate (after).
- `--metric`: which measure to diff — `time` (`time_ms`), `gc` (`gc_bytes`), or
  `both` (default).
- `--threshold`: percent worse/better required to count as a
  regression / improvement (default `10`).
- `--top`: max rows printed per table (default `30`).

It reads each snapshot's `CollectionBenchmark.csv` (parsed by the **real English
CSV header** — `family,collection,op,elem,n,time_ms,gc_bytes,bigo_time,bigo_space,note`;
note the `.md` table uses Chinese column names but the CSV does not) and `meta.json`.

- **Key** = `(family, collection, op, elem, n)`.
- **Regression**: for a compared metric, B exceeds A by more than `threshold`%
  (slower time / more GC). A value going from `0` to positive is reported as
  `+inf` and counts as a regression.
- **Improvement**: the symmetric case (B better than A by more than threshold%).
- Keys only in B are **added**; keys only in A are **removed**.
- When A is `0` and B is `0`, the change is `0%` (unchanged); when a value is
  missing the metric is skipped (shown as `n/a`).

Output: a header (each side's label / sha / unity_version / passed-total), a
summary count line (improved / regressed / unchanged / added / removed), then a
top-regressions table and a top-improvements table sorted by percent change,
plus added/removed key lists.

### Exit codes (CI gate)

| code | meaning                                                |
|------|--------------------------------------------------------|
| `0`  | no regression beyond `--threshold`                     |
| `1`  | at least one regression beyond `--threshold` (fail CI) |
| `2`  | usage / argparse error                                 |

Example CI usage — fail the build if the candidate regresses time by >5%:

```bash
python3 benchmarks/compare.py baseline candidate --metric time --threshold 5 || {
  echo "performance regression detected"; exit 1;
}
```
