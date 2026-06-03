#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
gen_web.py — Collection benchmark web visualizer generator.

Usage:
    python3 gen_web.py                       # default committed baseline CSV
    python3 gen_web.py <snapshot-id>         # benchmarks/history/<id>/CollectionBenchmark.csv
    python3 gen_web.py /path/to/some.csv     # explicit CSV path

Pure python3 stdlib. Reads the real CollectionBenchmark CSV (English header:
family,collection,op,elem,n,time_ms,gc_bytes,bigo_time,bigo_space,note) plus the
sibling meta.json, then emits 3 files into this script's own directory:

    index.html          single-file, fully self-contained, offline-openable
                        (data inlined as JSON in a <script>, zero external deps)
    data.json           structured full data + derived facts, for agents
    SELECTION_GUIDE.md  selection decision guide (same content as the html "选型指南" view)

It does NOT run benchmarks, does NOT touch git, does NOT start any server.
"""

import csv
import glob
import json
import os
import sys

# --------------------------------------------------------------------------- #
# Paths
# --------------------------------------------------------------------------- #
WEB_DIR = os.path.dirname(os.path.abspath(__file__))
BENCH_DIR = os.path.dirname(WEB_DIR)                       # benchmarks/
HISTORY_DIR = os.path.join(BENCH_DIR, "history")
# Last-resort fallback when history/ has no snapshot at all.
FALLBACK_CSV = os.path.join(
    BENCH_DIR, "..", "Unity 2022.3.62f3c1", "Results", "CollectionBenchmark.csv")


def _latest_history_snapshot():
    """Return the absolute path of the latest snapshot dir under history/, or None.

    Snapshot ids are prefixed with a YYYYMMDD-HHMM timestamp, so lexicographic
    max == newest. Prefer dirs matching '*__baseline'; if none, fall back to the
    newest snapshot of any kind. Uses glob (stdlib) and is space-safe (we never
    shell out — all paths are plain python strings).
    """
    if not os.path.isdir(HISTORY_DIR):
        return None
    baselines = sorted(d for d in glob.glob(os.path.join(HISTORY_DIR, "*__baseline"))
                       if os.path.isdir(d))
    if baselines:
        return baselines[-1]
    # no *__baseline — take the newest snapshot dir of any kind
    snaps = sorted(d for d in glob.glob(os.path.join(HISTORY_DIR, "*"))
                   if os.path.isdir(d))
    return snaps[-1] if snaps else None


def resolve_csv(arg):
    """Resolve a CLI arg (none / snapshot-id / explicit path) to (csv_path, meta_path)."""
    if arg is None:
        snap = _latest_history_snapshot()
        if snap is not None:
            return (os.path.join(snap, "CollectionBenchmark.csv"),
                    os.path.join(snap, "meta.json"))
        # history/ empty -> last-resort committed Results CSV
        return (FALLBACK_CSV, os.path.join(os.path.dirname(FALLBACK_CSV), "meta.json"))
    # explicit path to a csv file
    if arg.endswith(".csv") and os.path.isfile(arg):
        return (arg, os.path.join(os.path.dirname(arg), "meta.json"))
    # explicit path to a snapshot dir
    if os.path.isdir(arg):
        return (os.path.join(arg, "CollectionBenchmark.csv"),
                os.path.join(arg, "meta.json"))
    # treat as snapshot id under history/
    snap = os.path.join(HISTORY_DIR, arg)
    return (os.path.join(snap, "CollectionBenchmark.csv"),
            os.path.join(snap, "meta.json"))


# --------------------------------------------------------------------------- #
# op -> canonical bucket mapping  (规范操作桶: 增/删/改/查/遍历)
# --------------------------------------------------------------------------- #
# Bucket order is the column order in the heat matrix.
BUCKETS = ["add", "remove", "update", "query", "iterate"]
BUCKET_LABEL = {
    "add": "增",
    "remove": "删",
    "update": "改",
    "query": "查",
    "iterate": "遍历",
}

OP_TO_BUCKET = {
    # 增 — append / build / insert
    "Add": "add", "Enqueue": "add", "Push": "add", "AddLast": "add",
    "Build": "add", "TryAdd": "add", "AddFirst": "add", "AddOne": "add",
    "Insert0": "add", "InsertHead": "add",
    # 删
    "Remove": "remove", "RemoveAt": "remove", "Dequeue": "remove",
    "Pop": "remove", "RemoveFirst": "remove", "TryRemove": "remove",
    "TryDequeue": "remove", "TryPop": "remove", "TryTake": "remove",
    "Take": "remove", "Drain": "remove",
    # 改
    "Set": "update", "SetItem": "update", "SetItemOne": "update",
    "Update": "update",
    # 查
    "Get": "query", "Index": "query", "Contains": "query",
    "ContainsKey": "query", "TryGetValue": "query", "Peek": "query",
    # 遍历
    "Iterate": "iterate",
}

# Representative-op preference WITHIN a bucket for a collection/elem/n cell.
# Lower rank = preferred canonical representative. Ops not listed get a large
# default rank, so explicitly-deprioritized variants (Insert0/AddFirst/AddOne/
# InsertHead/Build) lose to a plain Add when both exist in the same bucket.
REP_RANK = {
    # 增: plain append wins over head-insert / build / single-add variants
    "Add": 0, "Enqueue": 0, "Push": 0, "AddLast": 0, "TryAdd": 1,
    "Build": 5, "AddOne": 6, "AddFirst": 7, "InsertHead": 8, "Insert0": 9,
    # 删: plain remove / structural pop-dequeue wins over Drain
    "Remove": 0, "Dequeue": 0, "Pop": 0, "RemoveFirst": 0, "TryRemove": 1,
    "TryDequeue": 1, "TryPop": 1, "TryTake": 1, "Take": 1,
    "RemoveAt": 3, "Drain": 5,
    # 改
    "Set": 0, "SetItem": 0, "Update": 1, "SetItemOne": 5,
    # 查: dict Get/TryGetValue, set Contains, list Contains/Index/Peek
    "Get": 0, "TryGetValue": 0, "Contains": 0, "ContainsKey": 1,
    "Peek": 2, "Index": 3,
    # 遍历
    "Iterate": 0,
}
DEFAULT_RANK = 50

# Ops considered comparable for the SELECTION-GUIDE auto-derivation only.
# Rationale: the heat matrix / rank views show ALL raw ops (with the actual op
# named in the tooltip), but the guide makes explicit "use X" recommendations,
# so it must compare like-for-like *bulk, n-scaled* workloads. Single-shot ops
# whose iteration count does NOT scale with n across all families are excluded,
# otherwise they produce misleading "winners":
#   - Peek  : ImmutableQueue/Stack do a *single* peek (not looped m times like
#             Generic Queue/Stack) -> artificially ~0ms.
#   - Drain : structural single-pass teardown, not comparable to Remove-all-n.
#   - SetItemOne / AddOne : single-element variants of Set / Add.
# Note: Immutable Remove/SetItem still remove/set ONE element (returning a new
# version) whereas Generic Remove/Set touch all n; we keep them but the guide
# annotates the representative op + Big-O so the asymmetry is visible, and the
# read-me warning calls out cross-op 口径.
GUIDE_BUCKET_OPS = {
    "add":     {"Add", "Enqueue", "Push", "AddLast", "TryAdd", "Build"},
    "remove":  {"Remove", "RemoveAt", "Dequeue", "Pop", "RemoveFirst",
                "TryRemove", "TryDequeue", "TryPop", "TryTake", "Take"},
    "update":  {"Set", "SetItem", "Update"},
    "query":   {"Get", "TryGetValue", "Contains", "ContainsKey", "Index"},
    "iterate": {"Iterate"},
}


# --------------------------------------------------------------------------- #
# Parse CSV
# --------------------------------------------------------------------------- #
def parse_csv(csv_path):
    rows = []
    with open(csv_path, newline="", encoding="utf-8") as f:
        reader = csv.DictReader(f)
        for r in reader:
            try:
                n = int(r["n"])
            except (ValueError, KeyError):
                continue

            def fnum(key):
                v = (r.get(key) or "").strip()
                if v == "":
                    return None
                try:
                    return float(v)
                except ValueError:
                    return None

            rows.append({
                "family": r["family"].strip(),
                "collection": r["collection"].strip(),
                "op": r["op"].strip(),
                "elem": r["elem"].strip(),
                "n": n,
                "time_ms": fnum("time_ms"),
                "gc_bytes": fnum("gc_bytes"),
                "bigo_time": (r.get("bigo_time") or "").strip(),
                "bigo_space": (r.get("bigo_space") or "").strip(),
                "note": (r.get("note") or "").strip(),
            })
    return rows


def load_meta(meta_path):
    if os.path.isfile(meta_path):
        with open(meta_path, encoding="utf-8") as f:
            return json.load(f)
    return {}


# --------------------------------------------------------------------------- #
# Derived data
# --------------------------------------------------------------------------- #
def collection_key(r):
    return r["family"], r["collection"]


def build_derived(rows):
    families = sorted(set(r["family"] for r in rows))
    elems = sorted(set(r["elem"] for r in rows))
    ns = sorted(set(r["n"] for r in rows))
    ops = sorted(set(r["op"] for r in rows))
    # collections preserve family grouping then name
    coll_set = sorted(set((r["family"], r["collection"]) for r in rows))
    collections = [{"family": f, "collection": c, "key": f + ":" + c}
                   for (f, c) in coll_set]

    # ---- index every measurement by (family,coll,op,elem,n) ----
    by_full = {}
    for r in rows:
        by_full[(r["family"], r["collection"], r["op"], r["elem"], r["n"])] = r

    # ---- heat-matrix cells: choose representative op per
    #      (collection, bucket, elem, n) ----
    # group candidate rows
    bucket_cells = {}  # (collKey, bucket, elem, n) -> list of rows
    for r in rows:
        b = OP_TO_BUCKET.get(r["op"])
        if b is None:
            continue
        ck = r["family"] + ":" + r["collection"]
        bucket_cells.setdefault((ck, b, r["elem"], r["n"]), []).append(r)

    heat = {}  # "collKey|bucket|elem|n" -> cell dict (representative)
    for (ck, b, elem, n), cands in bucket_cells.items():
        # pick representative by (rank, time) — prefer canonical op, then fastest
        def sort_key(rr):
            rank = REP_RANK.get(rr["op"], DEFAULT_RANK)
            t = rr["time_ms"] if rr["time_ms"] is not None else float("inf")
            return (rank, t)
        rep = sorted(cands, key=sort_key)[0]
        heat["%s|%s|%s|%d" % (ck, b, elem, n)] = {
            "collKey": ck,
            "bucket": b,
            "elem": elem,
            "n": n,
            "op": rep["op"],
            "time_ms": rep["time_ms"],
            "gc_bytes": rep["gc_bytes"],
            "bigo_time": rep["bigo_time"],
            "bigo_space": rep["bigo_space"],
            "note": rep["note"],
        }

    # ---- fastest collection per (op, elem, n)  (raw op ranking, view B) ----
    fastest_op = {}  # "op|elem|n" -> {collKey, time_ms, bigo_time}
    by_op = {}
    for r in rows:
        if r["time_ms"] is None:
            continue
        by_op.setdefault((r["op"], r["elem"], r["n"]), []).append(r)
    for (op, elem, n), cands in by_op.items():
        best = min(cands, key=lambda rr: rr["time_ms"])
        fastest_op["%s|%s|%d" % (op, elem, n)] = {
            "collKey": best["family"] + ":" + best["collection"],
            "collection": best["collection"],
            "time_ms": best["time_ms"],
            "bigo_time": best["bigo_time"],
        }

    # ---- fastest collection per (bucket, elem, n)  — for selection guide ----
    # Restricted to GUIDE_BUCKET_OPS so the recommendation compares comparable
    # bulk / n-scaled workloads (see note on GUIDE_BUCKET_OPS).
    fastest_bucket = {}  # "bucket|elem|n" -> {collKey, time_ms, op, bigo_time}
    bkt = {}
    for k, cell in heat.items():
        if cell["time_ms"] is None:
            continue
        if cell["op"] not in GUIDE_BUCKET_OPS.get(cell["bucket"], set()):
            continue
        bkt.setdefault((cell["bucket"], cell["elem"], cell["n"]), []).append(cell)
    for (b, elem, n), cells in bkt.items():
        best = min(cells, key=lambda c: c["time_ms"])
        fastest_bucket["%s|%s|%d" % (b, elem, n)] = {
            "collKey": best["collKey"],
            "op": best["op"],
            "time_ms": best["time_ms"],
            "bigo_time": best["bigo_time"],
            "gc_bytes": best["gc_bytes"],
        }

    return {
        "families": families,
        "elems": elems,
        "ns": ns,
        "ops": ops,
        "buckets": BUCKETS,
        "bucketLabel": BUCKET_LABEL,
        "collections": collections,
        "heat": heat,
        "fastestOp": fastest_op,
        "fastestBucket": fastest_bucket,
    }


# --------------------------------------------------------------------------- #
# Curated qualitative selection requirements
# --------------------------------------------------------------------------- #
CURATED = [
    {"need": "去重存储 (集合语义)", "pick": "HashSet<T>",
     "why": "唯一性 + O(1) 平均 Contains/Add；元素无序。值类型用 struct 元素避免装箱。"},
    {"need": "有序遍历 / 范围查询 / 排序键", "pick": "SortedDictionary / SortedSet",
     "why": "红黑树，键始终有序，O(log n) 增删查；要范围扫描或按序输出时用它，否则用 Dictionary/HashSet 更快。"},
    {"need": "有序但读多写少 / 内存紧凑", "pick": "SortedList",
     "why": "底层数组，索引访问与遍历快、内存连续，但插入是 O(n)；适合一次构建、之后大量按序读。"},
    {"need": "线程安全并发读写", "pick": "Concurrent* (ConcurrentDictionary / ConcurrentQueue / ConcurrentStack / ConcurrentBag)",
     "why": "无锁/细粒度锁并发安全；单线程场景不要用（比 Generic 版本慢且 GC 更多）。"},
    {"need": "生产者-消费者 / 阻塞队列", "pick": "BlockingCollection<T>",
     "why": "封装 ConcurrentQueue + 容量/阻塞语义，适合管道式并发。"},
    {"need": "不可变 / 快照 / 安全共享", "pick": "Immutable* (ImmutableArray / ImmutableList / ImmutableDictionary ...)",
     "why": "天然线程安全、可安全共享与做快照；⚠ 构建/逐元素修改成本高（每次写产生新版本），只读共享场景才划算。"},
    {"need": "低 GC / 值类型批量 / 与 Unity Job/Burst 互操作", "pick": "Native* (NativeArray / NativeList / NativeHashMap / NativeHashSet / NativeQueue)",
     "why": "非托管内存、零托管 GC、可进 Job/Burst；需手动 Dispose，且仅支持 unmanaged struct 元素。"},
    {"need": "低 GC 通用顺序容器", "pick": "数组 Array / List<struct>",
     "why": "连续内存、缓存友好、几乎零额外 GC；List 预设容量避免扩容拷贝。固定长度用 Array。"},
    {"need": "频繁头部插入 / 双向链表语义", "pick": "LinkedList<T>",
     "why": "AddFirst/AddLast/节点删除 O(1)；但无索引访问、缓存不友好、每节点一次堆分配，随机访问慢。"},
    {"need": "FIFO 先进先出队列", "pick": "Queue<T>",
     "why": "Enqueue/Dequeue 摊销 O(1)、环形缓冲、内存连续；并发场景换 ConcurrentQueue。"},
    {"need": "LIFO 后进先出栈", "pick": "Stack<T>",
     "why": "Push/Pop 摊销 O(1)、内存连续；并发场景换 ConcurrentStack。"},
    {"need": "只读视图 / 防御性封装", "pick": "ReadOnlyCollection / ReadOnlyDictionary",
     "why": "包装现有集合暴露只读接口，无拷贝开销，但不阻止底层被改。"},
    {"need": "需要键且保留插入项的派生集合", "pick": "KeyedCollection<TKey,TItem>",
     "why": "List + 键索引的混合体，按键和按下标都能取；写少读多时方便。"},
    {"need": "UI / 数据绑定通知变更", "pick": "ObservableCollection<T>",
     "why": "增删触发 CollectionChanged 事件，配合数据绑定；性能不如 List，热路径勿用。"},
    {"need": "紧凑位标志 / 布尔大数组", "pick": "BitArray",
     "why": "每元素 1 bit，内存极省，适合大量布尔标志位运算。"},
]


# --------------------------------------------------------------------------- #
# Build SELECTION_GUIDE.md  +  guide data for the html view
# --------------------------------------------------------------------------- #
def fmt_ms(v):
    if v is None:
        return "—"
    if v < 0.01:
        return "%.4f ms" % v
    if v < 1:
        return "%.3f ms" % v
    return "%.2f ms" % v


def short_coll(collkey):
    return collkey.split(":", 1)[1] if ":" in collkey else collkey


def build_guide(derived, n_ref=10000, elem_ref="int"):
    """Auto-derive fastest-collection conclusions per bucket at N=n_ref/elem_ref."""
    derived_rows = []
    for b in BUCKETS:
        key = "%s|%s|%d" % (b, elem_ref, n_ref)
        fb = derived["fastestBucket"].get(key)
        if not fb:
            continue
        derived_rows.append({
            "bucket": b,
            "bucketLabel": BUCKET_LABEL[b],
            "collKey": fb["collKey"],
            "collection": short_coll(fb["collKey"]),
            "op": fb["op"],
            "time_ms": fb["time_ms"],
            "bigo_time": fb["bigo_time"],
        })
    return {
        "n_ref": n_ref,
        "elem_ref": elem_ref,
        "derived": derived_rows,
        "curated": CURATED,
    }


def render_guide_md(guide, meta):
    lines = []
    lines.append("# 集合选型决策指南")
    lines.append("")
    label = meta.get("label", "?")
    sha = meta.get("git_sha", "?")
    uv = meta.get("unity_version", "?")
    rows = meta.get("rows", "?")
    lines.append("> 数据集: **%s** (sha `%s`, Unity %s, %s 行) — 由 `gen_web.py` 自动生成。"
                 % (label, sha, uv, rows))
    lines.append(">")
    lines.append("> 本文件内容与 `index.html` 的「选型指南」视图一致。结论分两部分：")
    lines.append("> **(1) 实测自动派生** 每个规范操作桶在 N=%d / elem=%s 下最快的集合；"
                 % (guide["n_ref"], guide["elem_ref"]))
    lines.append("> **(2) 策展定性需求** 按使用场景推荐的集合。")
    lines.append("")

    # --- part 1: auto-derived ---
    lines.append("## 1. 实测自动派生 — 每个操作桶最快集合 (N=%d, %s 元素)"
                 % (guide["n_ref"], guide["elem_ref"]))
    lines.append("")
    lines.append("| 需求 | 推荐集合 | 实测 (代表 op) | Big-O 时间 |")
    lines.append("|------|----------|----------------|------------|")
    for d in guide["derived"]:
        lines.append("| 需要快速**%s** | **%s** | %s (`%s`) | %s |"
                     % (BUCKET_LABEL[d["bucket"]], d["collection"],
                        fmt_ms(d["time_ms"]), d["op"], d["bigo_time"] or "?"))
    lines.append("")
    lines.append("> 桶映射: 增=Add/Enqueue/Push/Build...; 删=Remove/Dequeue/Pop/Drain...; "
                 "改=Set/Update...; 查=Get/Contains/ContainsKey/Peek...; 遍历=Iterate。")
    lines.append(">")
    lines.append("> ⚠ **派生口径**：本表的「最快」只在**可比的批量/随 n 缩放**操作间比较，"
                 "已排除单发操作 (Peek / Drain / SetItemOne / AddOne)——它们在不同集合里迭代次数不一致 "
                 "(如 ImmutableQueue.Peek 只读 1 次、Generic.Peek 循环 n 次)。即便如此，"
                 "Immutable 系的 Remove/Set 仍是**改/删单个元素返回新版本**，而 Generic 的 Remove/Set "
                 "可能作用于全部 n 个元素；请结合「代表 op」与 Big-O 列判断，不要脱离场景照搬。")
    lines.append("")

    # --- part 2: curated qualitative ---
    lines.append("## 2. 策展定性需求 — 按场景选型")
    lines.append("")
    lines.append("| 需求场景 | 推荐集合 | 理由 |")
    lines.append("|----------|----------|------|")
    for c in guide["curated"]:
        why = c["why"].replace("\n", " ")
        lines.append("| %s | **%s** | %s |" % (c["need"], c["pick"], why))
    lines.append("")

    # --- warnings ---
    lines.append("## ⚠ 读数警示")
    lines.append("")
    lines.append("1. **跨 N 的原始 ms 非同口径**：`time_ms` 是单次 measurement 的耗时，"
                 "而内部迭代次数随 N 缩放，所以 N=1 / 100 / 10000 之间的绝对 ms 不能直接横向比。"
                 "**只在同一 (集合, 操作) 内沿 N 看趋势**，或在同一 N 内横向比集合。")
    lines.append("2. **GC 字节是粗粒度**：分辨率约几十 KB；小档位 / 碎片化分配可能显示 0，"
                 "这表示**未解析到 / 低于分辨率**，并非保证真零分配。")
    lines.append("")
    return "\n".join(lines)


# --------------------------------------------------------------------------- #
# HTML template — fully self-contained, data inlined.
# --------------------------------------------------------------------------- #
def render_html(payload, meta):
    data_js = json.dumps(payload, ensure_ascii=False, separators=(",", ":"))
    meta_js = json.dumps(meta, ensure_ascii=False)

    # NOTE: keep CSS/JS free of any {} f-string interpolation; we only inject the
    # two JSON blobs via .replace() to avoid brace-escaping headaches.
    html = HTML_TEMPLATE
    html = html.replace("/*__DATA__*/", data_js)
    html = html.replace("/*__META__*/", meta_js)
    return html


HTML_TEMPLATE = r"""<!DOCTYPE html>
<html lang="zh-CN">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>集合基准可视化 · Collection Benchmark</title>
<style>
  :root{
    --bg:#0f1115; --panel:#171a21; --panel2:#1d212b; --line:#2a2f3a;
    --txt:#e6e9ef; --muted:#9aa3b2; --accent:#5aa9ff; --accent2:#ffd166;
    --good:#2fbf71; --bad:#e5484d; --warn:#f5a524;
    /* sticky offsets — measured at runtime by JS (see setStickyOffsets).
       --head-h: rendered header height; --ctl-h: rendered control-bar height.
       Fallbacks below keep things usable before/without JS. */
    --head-h:120px; --ctl-h:54px;
  }
  *{box-sizing:border-box}
  body{margin:0;background:var(--bg);color:var(--txt);
    font-family:-apple-system,BlinkMacSystemFont,"PingFang SC","Microsoft YaHei",
    "Segoe UI",Roboto,Helvetica,Arial,sans-serif;font-size:14px;line-height:1.5}
  header{padding:14px 18px;background:linear-gradient(180deg,#1a1e27,#13161d);
    border-bottom:1px solid var(--line);position:sticky;top:0;z-index:20}
  h1{margin:0 0 4px;font-size:18px}
  .meta{color:var(--muted);font-size:12.5px;display:flex;flex-wrap:wrap;gap:14px}
  .meta b{color:var(--txt)}
  .tabs{display:flex;gap:6px;margin-top:12px;flex-wrap:wrap}
  .tab{padding:7px 14px;border:1px solid var(--line);border-radius:8px;
    background:var(--panel);cursor:pointer;color:var(--muted);font-weight:600}
  .tab:hover{border-color:var(--accent)}
  .tab.active{background:var(--accent);color:#06203f;border-color:var(--accent)}
  main{padding:16px 18px 60px;max-width:1500px;margin:0 auto}
  .view{display:none}
  .view.active{display:block}
  /* Control / filter bar (元素/N/Family/指标 selectors) stays pinned to the top
     while scrolling. Sits just under the sticky <header> (top = header height).
     Opaque background so table rows never bleed through. z-index below header
     (20) but above the matrix thead (5). */
  .controls{display:flex;flex-wrap:wrap;gap:14px;align-items:center;
    background:var(--panel);border:1px solid var(--line);border-radius:10px;
    padding:12px 14px;margin-bottom:14px;
    position:sticky;top:var(--head-h);z-index:15}
  .ctl{display:flex;align-items:center;gap:6px}
  .ctl label{color:var(--muted);font-size:12.5px}
  select{background:var(--panel2);color:var(--txt);border:1px solid var(--line);
    border-radius:7px;padding:5px 8px;font-size:13px}
  .seg{display:inline-flex;border:1px solid var(--line);border-radius:7px;overflow:hidden}
  .seg button{background:var(--panel2);color:var(--muted);border:0;padding:5px 11px;
    cursor:pointer;font-size:13px;font-weight:600;border-right:1px solid var(--line)}
  .seg button:last-child{border-right:0}
  .seg button.on{background:var(--accent);color:#06203f}
  table{border-collapse:collapse;width:100%}
  /* Intentionally NOT a scroll container. A non-visible horizontal overflow
     coerces overflow-y to auto (CSS spec), which would turn .matrix-wrap into a
     scroll box — making the sticky thead stick to THIS box's viewport (~174px
     down, floating into the data rows) instead of the page viewport. Keep
     overflow:visible so the thead's sticky offset is measured against the page;
     the table itself is width:100% so it fits without horizontal scrolling. */
  .matrix-wrap{overflow:visible;border:1px solid var(--line);border-radius:10px}
  /* Full-width so the 6-bucket matrix fits the page viewport without needing a
     horizontal scroll container (the cells are short numbers). */
  .matrix{width:100%}
  .matrix th,.matrix td{padding:6px 8px;text-align:center;border:1px solid var(--line);
    font-variant-numeric:tabular-nums;white-space:nowrap}
  /* Heat-matrix column-header row (增/删/改/查/遍历 buckets) stays pinned just
     below the (sticky) header + control bar, so the bucket labels never scroll
     away while comparing collections / switching family dropdowns. Offset =
     header height + control-bar height. Opaque bg + z-index above body cells. */
  .matrix thead th{position:sticky;top:calc(var(--head-h) + var(--ctl-h));
    background:var(--panel2);z-index:6}
  /* First column (collection name) sticks to the left for horizontal reading. */
  .matrix .rowhead{position:sticky;left:0;background:var(--panel2);text-align:left;
    z-index:4;font-weight:600}
  /* The top-left corner cell is BOTH a thead th and the rowhead — it must win
     over both the sticky column and the sticky header row, so bump it highest. */
  .matrix thead th.rowhead{z-index:7}
  .famrow td{background:#10131a;color:var(--accent);text-align:left;font-weight:700;
    letter-spacing:.5px;position:sticky;left:0}
  .cell{cursor:pointer;color:#0c0f14;font-weight:600;border-radius:0}
  .cell.na{background:#222732 !important;color:#5b6473;cursor:default}
  .cell.best{outline:2px solid var(--accent2);outline-offset:-2px}
  .star{color:#7a5a00;font-weight:800}
  .legend{display:flex;align-items:center;gap:10px;color:var(--muted);font-size:12px;
    margin:10px 2px}
  .grad{height:12px;width:160px;border-radius:6px;
    background:linear-gradient(90deg,#2fbf71,#e9e36b,#e5484d)}
  .bars{display:flex;flex-direction:column;gap:4px}
  .bar-row{display:grid;grid-template-columns:200px 1fr 150px;gap:10px;align-items:center}
  .bar-name{color:var(--txt);font-size:12.5px;text-align:right;white-space:nowrap;
    overflow:hidden;text-overflow:ellipsis}
  .bar-name.best{color:var(--accent2);font-weight:700}
  .bar-track{background:var(--panel2);border-radius:6px;height:20px;position:relative;
    border:1px solid var(--line)}
  .bar-fill{height:100%;border-radius:5px}
  .bar-val{font-size:12px;color:var(--muted);font-variant-numeric:tabular-nums}
  .cards{display:grid;grid-template-columns:repeat(auto-fill,minmax(320px,1fr));gap:12px}
  .card{background:var(--panel);border:1px solid var(--line);border-radius:10px;padding:12px 14px}
  .card h3{margin:0 0 6px;font-size:14px;color:var(--accent2)}
  .card .pick{font-weight:700;color:var(--good);font-size:15px}
  .card .why{color:var(--muted);font-size:12.5px;margin-top:5px}
  .card .meas{color:var(--accent);font-size:12px;margin-top:4px;font-variant-numeric:tabular-nums}
  .gtbl th,.gtbl td{padding:7px 9px;border:1px solid var(--line);text-align:left;vertical-align:top}
  .gtbl thead th{background:var(--panel2)}
  .profile th,.profile td{padding:6px 9px;border:1px solid var(--line);text-align:center;
    font-variant-numeric:tabular-nums}
  .profile thead th{background:var(--panel2)}
  .profile .opname{text-align:left;font-weight:600}
  .tag{display:inline-block;padding:1px 7px;border-radius:6px;font-size:11px;font-weight:700}
  .tag.long{background:#10331f;color:var(--good)}
  .tag.short{background:#3a1416;color:var(--bad)}
  .sec-title{font-size:15px;margin:18px 0 8px;color:var(--accent)}
  .warn-box{margin-top:24px;background:#1a1410;border:1px solid #5a3d12;border-radius:10px;
    padding:12px 14px;color:#f2d9a8;font-size:12.5px}
  .warn-box b{color:var(--warn)}
  .tooltip{position:fixed;z-index:99;pointer-events:none;background:#0a0c10;
    border:1px solid var(--accent);border-radius:8px;padding:8px 10px;font-size:12px;
    max-width:300px;box-shadow:0 6px 24px rgba(0,0,0,.5);display:none}
  .tooltip .k{color:var(--muted)}
  .tooltip b{color:var(--accent2)}
  .hint{color:var(--muted);font-size:12px;margin:2px 0 10px}
  .pill{font-size:11px;color:var(--muted);border:1px solid var(--line);border-radius:20px;
    padding:1px 8px}
</style>
</head>
<body>
<header>
  <h1>集合基准可视化 <span class="pill" id="hRows"></span></h1>
  <div class="meta" id="hMeta"></div>
  <div class="tabs">
    <div class="tab active" data-view="heat">A · 热力矩阵</div>
    <div class="tab" data-view="rank">B · 单操作排名</div>
    <div class="tab" data-view="guide">C · 选型指南</div>
    <div class="tab" data-view="profile">D · 集合画像</div>
  </div>
</header>
<main>

<!-- ============ A. HEAT MATRIX ============ -->
<section class="view active" id="view-heat">
  <div class="controls">
    <div class="ctl"><label>元素</label><div class="seg" id="heatElem"></div></div>
    <div class="ctl"><label>N</label><div class="seg" id="heatN"></div></div>
    <div class="ctl"><label>指标</label><div class="seg" id="heatMetric"></div></div>
    <div class="ctl"><label>Family</label><select id="heatFamily"></select></div>
  </div>
  <div class="hint">行 = 集合 (按 family 分组)，列 = 规范操作桶 增/删/改/查/遍历。每列按值着色 (绿=最快/最低，红=最慢/最高，log 刻度)，★/高亮 = 该列最优；灰 — = 不支持。悬停看实际 op / Big-O / GC / note。</div>
  <div class="legend"><span>快 / 低</span><div class="grad"></div><span>慢 / 高</span>
    <span style="margin-left:14px">★ 该列最优</span><span>— 不支持</span></div>
  <div class="matrix-wrap"><table class="matrix" id="heatTable"></table></div>
</section>

<!-- ============ B. RANK ============ -->
<section class="view" id="view-rank">
  <div class="controls">
    <div class="ctl"><label>操作</label><select id="rankOp"></select></div>
    <div class="ctl"><label>元素</label><div class="seg" id="rankElem"></div></div>
    <div class="ctl"><label>N</label><div class="seg" id="rankN"></div></div>
    <div class="ctl"><label>指标</label><div class="seg" id="rankMetric"></div></div>
  </div>
  <div class="hint">支持该 op 的集合按值升序 (快/低在上)，条长 ∝ 值 (log 刻度)，标值 + Big-O，金色高亮 = 最优。</div>
  <div class="bars" id="rankBars"></div>
</section>

<!-- ============ C. GUIDE ============ -->
<section class="view" id="view-guide">
  <h2 class="sec-title" id="guideDerivedTitle"></h2>
  <div class="hint">对每个规范操作桶，自动取参考档位下最快的集合。<b>派生口径</b>：仅在可比的批量 / 随 n 缩放操作间比较，已排除单发操作 (Peek / Drain / SetItemOne / AddOne)。注意 Immutable 的 Remove/Set 仍是改/删单个元素返回新版本，请结合「代表 op」+ Big-O 判断。</div>
  <div class="cards" id="guideDerived"></div>
  <h2 class="sec-title">策展定性需求 — 按场景选型</h2>
  <table class="gtbl"><thead><tr><th style="width:210px">需求场景</th><th style="width:230px">推荐集合</th><th>理由</th></tr></thead>
    <tbody id="guideCurated"></tbody></table>
</section>

<!-- ============ D. PROFILE ============ -->
<section class="view" id="view-profile">
  <div class="controls">
    <div class="ctl"><label>集合</label><select id="profColl"></select></div>
    <div class="ctl"><label>元素</label><div class="seg" id="profElem"></div></div>
    <div class="ctl"><label>指标</label><div class="seg" id="profMetric"></div></div>
  </div>
  <div class="hint">该集合各 op × N 的 time / GC / Big-O。<span class="tag long">长板</span> = 它最快的 op，<span class="tag short">短板</span> = 最慢 / O(n) 的 op。</div>
  <div id="profBody"></div>
</section>

<div class="warn-box">
  <b>⚠ 读数警示</b><br>
  ① <b>跨 N 原始 ms 非同口径</b>：time_ms 是单次 measurement 耗时，内部迭代数随 N 缩放 → N=1/100/10000 的绝对 ms 不可直接横比；只在同一 (集合, 操作) 内沿 N 看趋势，或在同一 N 内横比集合。<br>
  ② <b>GC 字节粗粒度</b>：分辨率约几十 KB；小档 / 碎片化可能读 0 = 未解析到 / 低于分辨率，<b>非保证真零分配</b>。
</div>
</main>

<div class="tooltip" id="tip"></div>

<script>
const DATA = /*__DATA__*/;
const META = /*__META__*/;

// ---------- helpers ----------
const $ = s => document.querySelector(s);
const elGet = id => document.getElementById(id);
function fmtMs(v){ if(v==null) return "—"; if(v<0.01) return v.toFixed(4); if(v<1) return v.toFixed(3); return v.toFixed(2); }
function fmtGc(v){ if(v==null) return "—"; if(v===0) return "0"; if(v>=1048576) return (v/1048576).toFixed(2)+"M"; if(v>=1024) return (v/1024).toFixed(1)+"K"; return String(v); }
function shortColl(k){ const i=k.indexOf(":"); return i<0?k:k.slice(i+1); }
function familyOf(k){ const i=k.indexOf(":"); return i<0?"":k.slice(0,i); }
function metricVal(o,metric){ return metric==="gc" ? o.gc_bytes : o.time_ms; }
// log-scaled 0..1 -> green..yellow..red
function colorFor(t){
  // t in [0,1]; 0 = best(green) 1 = worst(red)
  t=Math.max(0,Math.min(1,t));
  let r,g,b;
  if(t<0.5){ const u=t/0.5; r=Math.round(47+(233-47)*u); g=Math.round(191+(227-191)*u); b=Math.round(113+(107-113)*u); }
  else{ const u=(t-0.5)/0.5; r=Math.round(233+(229-233)*u); g=Math.round(227+(72-227)*u); b=Math.round(107+(77-107)*u); }
  return "rgb("+r+","+g+","+b+")";
}
function logNorm(v,min,max){
  if(min<=0) min=1e-6; if(v<=0) v=1e-6;
  if(max<=min) return 0;
  return (Math.log(v)-Math.log(min))/(Math.log(max)-Math.log(min));
}

// build a SEG control. items: [{val,label}]; returns get/set via callback
function buildSeg(host, items, initial, onChange){
  host.innerHTML="";
  items.forEach(it=>{
    const b=document.createElement("button");
    b.textContent=it.label; b.dataset.val=it.val;
    if(it.val===initial) b.classList.add("on");
    b.onclick=()=>{ host.querySelectorAll("button").forEach(x=>x.classList.remove("on")); b.classList.add("on"); onChange(it.val); };
    host.appendChild(b);
  });
}
function fillSelect(sel, items){
  sel.innerHTML="";
  items.forEach(it=>{ const o=document.createElement("option"); o.value=it.val; o.textContent=it.label; sel.appendChild(o); });
}

// ---------- header ----------
(function(){
  elGet("hRows").textContent = (META.rows||DATA.rowCount||"?")+" rows";
  const m=[];
  m.push("<span>快照 <b>"+(META.label||"?")+"</b></span>");
  m.push("<span>sha <b>"+(META.git_sha||"?")+"</b></span>");
  m.push("<span>Unity <b>"+(META.unity_version||"?")+"</b></span>");
  m.push("<span>测试 <b>"+(META.passed!=null?META.passed:"?")+"/"+(META.total!=null?META.total:"?")+"</b> 通过</span>");
  m.push("<span>数据行 <b>"+DATA.rowCount+"</b></span>");
  elGet("hMeta").innerHTML=m.join("");
})();

// ---------- tabs ----------
document.querySelectorAll(".tab").forEach(t=>{
  t.onclick=()=>{
    document.querySelectorAll(".tab").forEach(x=>x.classList.remove("active"));
    document.querySelectorAll(".view").forEach(x=>x.classList.remove("active"));
    t.classList.add("active");
    elGet("view-"+t.dataset.view).classList.add("active");
    setStickyOffsets();   // active view changed -> re-measure its control bar
  };
});

// ---------- tooltip ----------
const tip=elGet("tip");
function showTip(html,x,y){ tip.innerHTML=html; tip.style.display="block";
  let nx=x+14, ny=y+14;
  const w=tip.offsetWidth,h=tip.offsetHeight;
  if(nx+w>innerWidth) nx=x-w-14; if(ny+h>innerHeight) ny=y-h-14;
  tip.style.left=nx+"px"; tip.style.top=ny+"px"; }
function hideTip(){ tip.style.display="none"; }

// ---------- sticky offsets ----------
// The header and the per-view control bar are both position:sticky. The matrix
// thead pins below BOTH, so we measure their live rendered heights and feed them
// into CSS vars (--head-h / --ctl-h). Pure-CSS can't know these (header height
// varies with wrapped tabs/meta), so this tiny measurer keeps the offsets exact.
function setStickyOffsets(){
  const head=document.querySelector("header");
  if(head) document.documentElement.style.setProperty("--head-h", head.offsetHeight+"px");
  // measure the control bar of the currently-active view (heights differ slightly)
  const ctl=document.querySelector(".view.active .controls");
  if(ctl) document.documentElement.style.setProperty("--ctl-h", ctl.offsetHeight+"px");
}
window.addEventListener("resize", setStickyOffsets);

// =================================================================
//  A. HEAT MATRIX
// =================================================================
const HEAT={ elem:DATA.elems.includes("int")?"int":DATA.elems[0], n:10000, metric:"time", family:"__all__" };
function heatCell(collKey,bucket){ return DATA.heat[collKey+"|"+bucket+"|"+HEAT.elem+"|"+HEAT.n]||null; }

function renderHeat(){
  const tbl=elGet("heatTable");
  const buckets=DATA.buckets;
  // collections filtered by family
  let colls=DATA.collections;
  if(HEAT.family!=="__all__") colls=colls.filter(c=>c.family===HEAT.family);

  // per-column min/max over visible collections
  const colStats=buckets.map(b=>{
    let mn=Infinity,mx=-Infinity,any=false;
    colls.forEach(c=>{ const cell=heatCell(c.key,b); if(cell){ const v=metricVal(cell,HEAT.metric);
      if(v!=null){ any=true; if(v<mn)mn=v; if(v>mx)mx=v; } } });
    return {min:mn,max:mx,any};
  });
  // per-column best collKey
  const colBest=buckets.map((b,bi)=>{
    let best=null,bv=Infinity;
    colls.forEach(c=>{ const cell=heatCell(c.key,b); if(cell){ const v=metricVal(cell,HEAT.metric);
      if(v!=null && v<bv){ bv=v; best=c.key; } } });
    return best;
  });

  let h="<thead><tr><th class='rowhead'>集合 \\ 操作</th>";
  buckets.forEach(b=> h+="<th>"+DATA.bucketLabel[b]+"</th>");
  h+="</tr></thead><tbody>";

  let curFam=null;
  colls.forEach(c=>{
    if(c.family!==curFam){ curFam=c.family;
      h+="<tr class='famrow'><td colspan='"+(buckets.length+1)+"'>"+curFam+"</td></tr>"; }
    h+="<tr><td class='rowhead'>"+shortColl(c.key)+"</td>";
    buckets.forEach((b,bi)=>{
      const cell=heatCell(c.key,b);
      if(!cell){ h+="<td class='cell na'>—</td>"; return; }
      const v=metricVal(cell,HEAT.metric);
      if(v==null){ h+="<td class='cell na'>—</td>"; return; }
      const st=colStats[bi];
      const t=logNorm(v,st.min,st.max);
      const bg=colorFor(t);
      const isBest = colBest[bi]===c.key;
      const disp = HEAT.metric==="gc"? fmtGc(v) : fmtMs(v);
      const star = isBest? "<span class='star'>★</span> ":"";
      h+="<td class='cell"+(isBest?" best":"")+"' style='background:"+bg+"'"
        +" data-coll='"+c.key+"' data-bucket='"+b+"'>"+star+disp+"</td>";
    });
    h+="</tr>";
  });
  h+="</tbody>";
  tbl.innerHTML=h;

  tbl.querySelectorAll("td.cell:not(.na)").forEach(td=>{
    td.onmousemove=e=>{
      const cell=heatCell(td.dataset.coll,td.dataset.bucket);
      if(!cell) return;
      const html="<b>"+shortColl(td.dataset.coll)+"</b> · "+DATA.bucketLabel[td.dataset.bucket]
        +"<br><span class='k'>实际 op</span> "+cell.op
        +"<br><span class='k'>time</span> "+fmtMs(cell.time_ms)+" ms"
        +"<br><span class='k'>GC</span> "+fmtGc(cell.gc_bytes)+" B"
        +"<br><span class='k'>Big-O 时间</span> "+(cell.bigo_time||"?")
        +"<br><span class='k'>Big-O 空间</span> "+(cell.bigo_space||"?")
        +(cell.note?"<br><span class='k'>note</span> "+cell.note:"");
      showTip(html,e.clientX,e.clientY);
    };
    td.onmouseleave=hideTip;
    td.onclick=td.onmousemove;
  });
}

buildSeg(elGet("heatElem"), DATA.elems.map(e=>({val:e,label:e})), HEAT.elem, v=>{HEAT.elem=v;renderHeat();});
buildSeg(elGet("heatN"), DATA.ns.map(n=>({val:n,label:String(n)})), HEAT.n, v=>{HEAT.n=+v;renderHeat();});
buildSeg(elGet("heatMetric"), [{val:"time",label:"time"},{val:"gc",label:"GC"}], HEAT.metric, v=>{HEAT.metric=v;renderHeat();});
fillSelect(elGet("heatFamily"), [{val:"__all__",label:"全部"}].concat(DATA.families.map(f=>({val:f,label:f}))));
elGet("heatFamily").value=HEAT.family;
elGet("heatFamily").onchange=e=>{HEAT.family=e.target.value;renderHeat();};
renderHeat();

// =================================================================
//  B. RANK (per raw op)
// =================================================================
const RANK={ op:DATA.ops.includes("Add")?"Add":DATA.ops[0], elem:DATA.elems.includes("int")?"int":DATA.elems[0], n:10000, metric:"time" };

function renderRank(){
  const host=elGet("rankBars");
  const rows=DATA.rows.filter(r=>r.op===RANK.op && r.elem===RANK.elem && r.n===RANK.n);
  const vals=rows.map(r=>({coll:r.family+":"+r.collection, v:RANK.metric==="gc"?r.gc_bytes:r.time_ms,
      bigo:RANK.metric==="gc"?r.bigo_space:r.bigo_time}))
    .filter(r=>r.v!=null);
  if(!vals.length){ host.innerHTML="<div class='hint'>该 op / 元素 / N 无数据。</div>"; return; }
  vals.sort((a,b)=>a.v-b.v);
  const mn=vals[0].v, mx=vals[vals.length-1].v;
  const best=vals[0].coll;
  let h="";
  vals.forEach(r=>{
    // bar length ∝ value (log scale): fastest/lowest = shortest bar, slowest = full.
    const frac=Math.max(0.03, logNorm(r.v, mn>0?mn:1e-6, mx>0?mx:1));
    const isBest=r.coll===best;
    const disp=RANK.metric==="gc"?fmtGc(r.v)+" B":fmtMs(r.v)+" ms";
    h+="<div class='bar-row'>"
      +"<div class='bar-name"+(isBest?" best":"")+"'>"+(isBest?"★ ":"")+shortColl(r.coll)+"</div>"
      +"<div class='bar-track'><div class='bar-fill' style='width:"+(Math.max(3,frac*100))+"%;background:"+colorFor(frac)+"'></div></div>"
      +"<div class='bar-val'>"+disp+"  <span class='pill'>"+(r.bigo||"?")+"</span></div>"
      +"</div>";
  });
  host.innerHTML=h;
}
fillSelect(elGet("rankOp"), DATA.ops.map(o=>({val:o,label:o})));
elGet("rankOp").value=RANK.op;
elGet("rankOp").onchange=e=>{RANK.op=e.target.value;renderRank();};
buildSeg(elGet("rankElem"), DATA.elems.map(e=>({val:e,label:e})), RANK.elem, v=>{RANK.elem=v;renderRank();});
buildSeg(elGet("rankN"), DATA.ns.map(n=>({val:n,label:String(n)})), RANK.n, v=>{RANK.n=+v;renderRank();});
buildSeg(elGet("rankMetric"), [{val:"time",label:"time"},{val:"gc",label:"GC"}], RANK.metric, v=>{RANK.metric=v;renderRank();});
renderRank();

// =================================================================
//  C. GUIDE
// =================================================================
(function(){
  const g=DATA.guide;
  elGet("guideDerivedTitle").textContent="实测自动派生 — 每个操作桶最快集合 (N="+g.n_ref+", "+g.elem_ref+" 元素)";
  let h="";
  g.derived.forEach(d=>{
    h+="<div class='card'><h3>需要快速 "+DATA.bucketLabel[d.bucket]+"</h3>"
      +"<div class='pick'>"+d.collection+"</div>"
      +"<div class='meas'>实测 "+fmtMs(d.time_ms)+" ms · 代表 op <b>"+d.op+"</b> · "+(d.bigo_time||"?")+"</div>"
      +"</div>";
  });
  elGet("guideDerived").innerHTML=h;

  let t="";
  g.curated.forEach(c=>{
    t+="<tr><td>"+c.need+"</td><td class='pick'>"+c.pick+"</td><td class='why'>"+c.why+"</td></tr>";
  });
  elGet("guideCurated").innerHTML=t;
})();

// =================================================================
//  D. PROFILE
// =================================================================
const PROF={ coll:DATA.collections[0].key, elem:DATA.elems.includes("int")?"int":DATA.elems[0], metric:"time" };

function profElems(collKey){
  const set=new Set(DATA.rows.filter(r=>r.family+":"+r.collection===collKey).map(r=>r.elem));
  return DATA.elems.filter(e=>set.has(e));
}
function renderProf(){
  // ensure elem valid for this collection
  const elems=profElems(PROF.coll);
  if(!elems.includes(PROF.elem)) PROF.elem=elems[0];
  buildSeg(elGet("profElem"), elems.map(e=>({val:e,label:e})), PROF.elem, v=>{PROF.elem=v;renderProf();});

  const rows=DATA.rows.filter(r=>r.family+":"+r.collection===PROF.coll && r.elem===PROF.elem);
  if(!rows.length){ elGet("profBody").innerHTML="<div class='hint'>无数据。</div>"; return; }
  // group by op
  const ops=[...new Set(rows.map(r=>r.op))];
  // find this collection's fastest op and slowest op across all its (op,n) at N=max
  const nmax=Math.max(...DATA.ns);
  let opVals=[];
  ops.forEach(op=>{
    const r=rows.find(x=>x.op===op && x.n===nmax);
    if(r){ const v=PROF.metric==="gc"?r.gc_bytes:r.time_ms; if(v!=null) opVals.push({op,v,bigo:r.bigo_time}); }
  });
  let longOp=null,shortOp=null;
  if(opVals.length){ opVals.sort((a,b)=>a.v-b.v); longOp=opVals[0].op; shortOp=opVals[opVals.length-1].op; }
  // also flag O(n) ops as short-board candidates
  let h="<table class='profile'><thead><tr><th class='opname'>op</th><th>桶</th>";
  DATA.ns.forEach(n=> h+="<th>N="+n+(PROF.metric==="gc"?" GC":" ms")+"</th>");
  h+="<th>Big-O 时间</th><th>Big-O 空间</th><th></th></tr></thead><tbody>";
  ops.forEach(op=>{
    const bucket=DATA.opBucket[op]||"";
    const cells=DATA.ns.map(n=>{
      const r=rows.find(x=>x.op===op && x.n===n);
      if(!r) return {v:null};
      return {v: PROF.metric==="gc"?r.gc_bytes:r.time_ms, r};
    });
    const ref=rows.find(x=>x.op===op);
    const bigT=ref?ref.bigo_time:"", bigS=ref?ref.bigo_space:"";
    const isOn = bigT && /O\(n/i.test(bigT);
    let tag="";
    if(op===longOp) tag="<span class='tag long'>长板</span>";
    else if(op===shortOp || isOn) tag="<span class='tag short'>短板</span>";
    h+="<tr><td class='opname'>"+op+"</td><td>"+(DATA.bucketLabel[bucket]||"")+"</td>";
    cells.forEach(c=>{
      if(c.v==null){ h+="<td style='color:#5b6473'>—</td>"; return; }
      h+="<td>"+(PROF.metric==="gc"?fmtGc(c.v):fmtMs(c.v))+"</td>";
    });
    h+="<td style='text-align:left'>"+(bigT||"?")+"</td><td style='text-align:left'>"+(bigS||"?")+"</td><td>"+tag+"</td></tr>";
  });
  h+="</tbody></table>";
  elGet("profBody").innerHTML=h;
}
fillSelect(elGet("profColl"), DATA.collections.map(c=>({val:c.key,label:c.family+" · "+shortColl(c.key)})));
elGet("profColl").value=PROF.coll;
elGet("profColl").onchange=e=>{PROF.coll=e.target.value;renderProf();};
buildSeg(elGet("profMetric"), [{val:"time",label:"time"},{val:"gc",label:"GC"}], PROF.metric, v=>{PROF.metric=v;renderProf();});
renderProf();

// initial sticky-offset measure (after all views have rendered).
setStickyOffsets();
</script>
</body>
</html>
"""


# --------------------------------------------------------------------------- #
# Main
# --------------------------------------------------------------------------- #
def main():
    arg = sys.argv[1] if len(sys.argv) > 1 else None
    csv_path, meta_path = resolve_csv(arg)

    if not os.path.isfile(csv_path):
        sys.stderr.write("ERROR: CSV not found: %s\n" % csv_path)
        sys.exit(1)

    rows = parse_csv(csv_path)
    meta = load_meta(meta_path)
    derived = build_derived(rows)
    guide = build_guide(derived, n_ref=10000, elem_ref="int")

    # op -> bucket map (for profile view tagging)
    op_bucket = {op: OP_TO_BUCKET.get(op, "") for op in derived["ops"]}

    # ---- payload inlined into html + written to data.json ----
    payload = {
        "meta": meta,
        "rowCount": len(rows),
        "families": derived["families"],
        "elems": derived["elems"],
        "ns": derived["ns"],
        "ops": derived["ops"],
        "buckets": derived["buckets"],
        "bucketLabel": derived["bucketLabel"],
        "opBucket": op_bucket,
        "collections": derived["collections"],
        "rows": rows,
        "heat": derived["heat"],
        "fastestOp": derived["fastestOp"],
        "fastestBucket": derived["fastestBucket"],
        "guide": guide,
    }

    # ---- write index.html ----
    html = render_html(payload, meta)
    html_path = os.path.join(WEB_DIR, "index.html")
    with open(html_path, "w", encoding="utf-8") as f:
        f.write(html)

    # ---- write data.json (full + derived, agent-readable) ----
    json_path = os.path.join(WEB_DIR, "data.json")
    with open(json_path, "w", encoding="utf-8") as f:
        json.dump(payload, f, ensure_ascii=False, indent=2)

    # ---- write SELECTION_GUIDE.md ----
    md = render_guide_md(guide, meta)
    md_path = os.path.join(WEB_DIR, "SELECTION_GUIDE.md")
    with open(md_path, "w", encoding="utf-8") as f:
        f.write(md)

    # ---- report ----
    print("source CSV : %s" % csv_path)
    print("data rows  : %d" % len(rows))
    print("collections: %d  families: %d  ops: %d  elems: %s  Ns: %s"
          % (len(derived["collections"]), len(derived["families"]),
             len(derived["ops"]), derived["elems"], derived["ns"]))
    print("wrote      : %s" % html_path)
    print("wrote      : %s" % json_path)
    print("wrote      : %s" % md_path)
    print("\n-- derived fastest-by-bucket (N=%d, %s) --" % (guide["n_ref"], guide["elem_ref"]))
    for d in guide["derived"]:
        print("  %-4s -> %-22s %s ms (%s, %s)"
              % (BUCKET_LABEL[d["bucket"]], d["collection"],
                 fmt_ms(d["time_ms"]).replace(" ms", ""), d["op"], d["bigo_time"]))


if __name__ == "__main__":
    main()
