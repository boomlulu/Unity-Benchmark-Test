# Collection Benchmark Spec (frozen)

C# 集合 增删改查遍历 性能基准。Unity 2022.3.62f3c1 + Unity Performance Testing 3.0.3，batchmode 跑。

## 1. 规模档位（统一）
- **所有组合一律 N ∈ {1, 100, 10000}**（用户决定：全部降到此档，≤10k 下连 O(n²) 也可行，跑得快、可手动排期跑）。
- harness 复用现有常量 `Sizes.Quad = {1,100,10000}` 作为**唯一档位**；`Sizes.Normal{10,1000,1000000}` 弃用。
- 第 3/5 节里的 `[Q]` 标记、Normal/Quad 之分、builder-vs-naive 强制区分**全部作废**——所有 op 按惯用语义直接测，统一档位。

## 2. 元素类型（3 种）
| 名 | 定义 | 说明 |
|---|---|---|
| `int` | 内建值类型 | 泛型零装箱；legacy 必装箱 |
| `ValStruct` | `struct{ int A,B; float C; double D; }` ~24B，`IEquatable<ValStruct>` + `GetHashCode=>A` | 看值类型大拷贝 |
| `RefElem` | `sealed class{ int A,B; }` `IEquatable<RefElem>` + `GetHashCode=>A` | 看引用语义 |

- 元素对象**每个 (N, 类型) 预建一份源数组复用**，不重复分配。
- **Native\* 仅 unmanaged → 只跑 int + ValStruct，跳过 RefElem**。
- 键约定：dict-like 一律 `key=int, value=elem`；set-like `元素即键`；list-like 存 elem。

## 3. 操作语义（按类别）
| 操作 | 索引线性 | 字典 | 集合 | 队列/栈/链表 |
|---|---|---|---|---|
| **增** | append 建到 N | `Add(k,v)` 建到 N | `Add` 建到 N | `Enqueue/Push/AddLast` 建到 N |
| **增-头插** `[Q]` | `Insert(0)` 建到 N | — | — | `AddFirst`(链表 O(1) → Normal) |
| **删** | `RemoveAt(尾)` 排空 | `Remove(k)`×M | `Remove`×M | `Dequeue/Pop/RemoveFirst` 排空 |
| **改** | `this[i]=v` ×M | `this[k]=v2` ×M | — (集合无改) | — (无随机改) |
| **查** | 索引 O(1) + `Contains` O(n) | `TryGetValue`×M | `Contains`×M | `Peek` + `Contains` O(n) |
| **遍历** | foreach 全量 | foreach KVP | foreach | foreach |

- 不可变类型「增」= 惯用建表：`ImmutableArray/List` 用 `CreateBuilder`（Normal）；另测「单次 Add 成本」在 size-N 上（`ImmutableArray` 单次 Add `[Q]`）。
- M（子操作次数）= `clamp(N, 1, 1000)`；线性查找类（list Contains / linked Contains）M 再降到 `clamp(N,1,100)`，避免 1m×1000 爆。
- 破坏性 op（增/删/改）每次 measurement 在 `.SetUp()` 重建目标，**不计入测量**。

## 4. 测量与 GC 字节
- 用 `Measure.Method(...).WarmupCount(w).MeasurementCount(m).IterationsPerMeasurement(it).SetUp(...).CleanUp(...).Run()`。
- iteration 随 N 缩放：N≤100→it 大、measurement 多；N=1m→it=1、measurement 少（5~10）。
- **GC 字节**：Performance 包 `.GC()` 只记 GC.Collect 次数，不是字节。要字节 → 自定义 SampleGroup `GC Allocated`（单位 Bytes），用 `GC.GetAllocatedBytesForCurrentThread()` 前后差值（回退 `GC.GetTotalAllocatedBytes(true)` → `GC.GetTotalMemory(false)` 差值）。**Stage-1 必须验证该法在「List<int> append 显示数组增长字节 / 泛型查 ≈0 / legacy 装箱 ≈N×24B」上读数合理。**

## 5. 集合清单（按家族 / 类别 / 档位）
> `[Q]` = 该格走 Quadratic 档 {1,100,10000}

**A. 泛型核心 (Category=Generic)**
List<T>(索引线性, 增-头插[Q]) · Dictionary(字典) · HashSet(集合) · SortedDictionary(字典,树) · SortedSet(集合,树) · SortedList(字典: 顺序键 Normal / 随机插 单次[Q]) · LinkedList(链表) · Queue · Stack · T[](仅 改/查 by index + 遍历)

**B. 非泛型 legacy (Category=Legacy, 值类型装箱)**
ArrayList(索引线性, Insert(0)[Q]) · Hashtable(字典) · Queue(非泛型) · Stack(非泛型) · SortedList(非泛型字典) · BitArray(仅 bool: 改/查 by index + 遍历)

**C. 并发 (Category=Concurrent)**
ConcurrentDictionary(字典) · ConcurrentQueue · ConcurrentStack · ConcurrentBag(增/删/遍历) · BlockingCollection(增/删/遍历)

**D. ObjectModel (Category=ObjectModel)**
Collection<T>(索引线性, Insert(0)[Q]) · ObservableCollection<T>(索引线性, Insert(0)[Q]) · ReadOnlyCollection<T>(只读: 查/遍历) · ReadOnlyDictionary(只读: 查/遍历) · KeyedCollection(字典-ish)

**E. Immutable (Category=Immutable, 需 dll)**
ImmutableArray(增=Builder Normal / 单次Add[Q]; 查/遍历) · ImmutableList · ImmutableDictionary · ImmutableHashSet · ImmutableSortedSet · ImmutableSortedDictionary · ImmutableQueue · ImmutableStack（这些 Add 返回新实例: 用 Builder 建表 Normal，单次 Add 成本另测）

**F. Native (Category=Native, 需 com.unity.collections, 仅 int/ValStruct)**
NativeArray<T>(改/查/遍历) · NativeList<T> · NativeHashMap<K,V> · NativeHashSet<T> · NativeQueue<T>（需 Allocator + Dispose）

## 6. 依赖集成（Stage-1 风险点）
- **Immutable**: `System.Collections.Immutable.dll`(+可能 `System.Runtime.CompilerServices.Unsafe.dll`) 放 `Assets/Plugins/`，netstandard2.0 版。若与 Unity 自带程序集冲突无法编译 → **降级：剔除 Immutable 家族并在报告标注**，别死磕。
- **Native**: 加包 `com.unity.collections`（2022.3 兼容版，连带 burst+mathematics）。解析失败 → **降级剔除 Native 家族并标注**。

## 7. 运行编排
- 每家族一个 `[Category("<Family>")]`，run 脚本 `run-<family>.sh` → Unity `-testCategory "<Family>"`，独立出 `Results/<family>.xml` + perf json。
- `run-all.sh` 顺序跑全部家族。
- 退出码不可靠（teardown hang）→ 脚本用 `timeout` 包 Unity + 跑后解析 xml 定成败。
- perf json 默认落 persistentDataPath → 脚本跑后拷回 `Results/`。

## 8. 报告产出
`Results/CollectionBenchmark.md`（+ `.csv`）。每行：
`家族 | 集合 | 操作 | 元素类型 | N | 时间中位(ms) | GC(bytes) | Big-O 时间 | Big-O 空间 | 备注`
- 实测：时间中位 ms + GC bytes（来自 perf json）。
- 静态：Big-O 时间/空间 来自 `complexity.json` 参考表（subsession 据本 SPEC 第 3/5 节常识填）。
- 备注列标 `[Q] capped` / `boxing` / `builder` / `skipped(降级)` 等。

## 9. 实施阶段
1. **Stage-1 地基** ✅ 已完成：元素类型+源数据builder+尺寸/类别框架 + Immutable dll & Native 包均集成成功 + 每家族样例 + GC字节测量验证(GetTotalMemory 差值法，GetAllocatedBytesForCurrentThread 在此 Mono 是 stub) + 报告器 + run 脚本。
2. **Stage-2 填充**（按家族并行 subsession，各写各文件）：各家族全部集合 × 适用op × 3元素(Native仅int/struct) × **{1,100,10000}** 写满。**只写代码、只做编译校验、不跑基准**（用户自行排期跑）。
3. **Stage-3（用户手动）**：用户安排时间 `run-all.sh` 全量跑 + `gen_report.py` 合并报告。
