# 集合选型决策指南

> 数据集: **baseline** (sha `e67da6e`, Unity 2022.3.62f3c1, 1968 行) — 由 `gen_web.py` 自动生成。
>
> 本文件内容与 `index.html` 的「选型指南」视图一致。结论分两部分：
> **(1) 实测自动派生** 每个规范操作桶在 N=10000 / elem=int 下最快的集合；
> **(2) 策展定性需求** 按使用场景推荐的集合。

## 1. 实测自动派生 — 每个操作桶最快集合 (N=10000, int 元素)

| 需求 | 推荐集合 | 实测 (代表 op) | Big-O 时间 |
|------|----------|----------------|------------|
| 需要快速**增** | **Stack** | 0.426 ms (`Add`) | O(1) amortized |
| 需要快速**删** | **ImmutableSortedSet** | 0.010 ms (`Remove`) | O(log n) |
| 需要快速**改** | **ImmutableSortedDictionary** | 0.0012 ms (`SetItem`) | O(log n) |
| 需要快速**查** | **Array** | 0.0094 ms (`Get`) | O(1) |
| 需要快速**遍历** | **ImmutableArray** | 0.342 ms (`Iterate`) | O(n) |

> 桶映射: 增=Add/Enqueue/Push/Build...; 删=Remove/Dequeue/Pop/Drain...; 改=Set/Update...; 查=Get/Contains/ContainsKey/Peek...; 遍历=Iterate。
>
> ⚠ **派生口径**：本表的「最快」只在**可比的批量/随 n 缩放**操作间比较，已排除单发操作 (Peek / Drain / SetItemOne / AddOne)——它们在不同集合里迭代次数不一致 (如 ImmutableQueue.Peek 只读 1 次、Generic.Peek 循环 n 次)。即便如此，Immutable 系的 Remove/Set 仍是**改/删单个元素返回新版本**，而 Generic 的 Remove/Set 可能作用于全部 n 个元素；请结合「代表 op」与 Big-O 列判断，不要脱离场景照搬。

## 2. 策展定性需求 — 按场景选型

| 需求场景 | 推荐集合 | 理由 |
|----------|----------|------|
| 去重存储 (集合语义) | **HashSet<T>** | 唯一性 + O(1) 平均 Contains/Add；元素无序。值类型用 struct 元素避免装箱。 |
| 有序遍历 / 范围查询 / 排序键 | **SortedDictionary / SortedSet** | 红黑树，键始终有序，O(log n) 增删查；要范围扫描或按序输出时用它，否则用 Dictionary/HashSet 更快。 |
| 有序但读多写少 / 内存紧凑 | **SortedList** | 底层数组，索引访问与遍历快、内存连续，但插入是 O(n)；适合一次构建、之后大量按序读。 |
| 线程安全并发读写 | **Concurrent* (ConcurrentDictionary / ConcurrentQueue / ConcurrentStack / ConcurrentBag)** | 无锁/细粒度锁并发安全；单线程场景不要用（比 Generic 版本慢且 GC 更多）。 |
| 生产者-消费者 / 阻塞队列 | **BlockingCollection<T>** | 封装 ConcurrentQueue + 容量/阻塞语义，适合管道式并发。 |
| 不可变 / 快照 / 安全共享 | **Immutable* (ImmutableArray / ImmutableList / ImmutableDictionary ...)** | 天然线程安全、可安全共享与做快照；⚠ 构建/逐元素修改成本高（每次写产生新版本），只读共享场景才划算。 |
| 低 GC / 值类型批量 / 与 Unity Job/Burst 互操作 | **Native* (NativeArray / NativeList / NativeHashMap / NativeHashSet / NativeQueue)** | 非托管内存、零托管 GC、可进 Job/Burst；需手动 Dispose，且仅支持 unmanaged struct 元素。 |
| 低 GC 通用顺序容器 | **数组 Array / List<struct>** | 连续内存、缓存友好、几乎零额外 GC；List 预设容量避免扩容拷贝。固定长度用 Array。 |
| 频繁头部插入 / 双向链表语义 | **LinkedList<T>** | AddFirst/AddLast/节点删除 O(1)；但无索引访问、缓存不友好、每节点一次堆分配，随机访问慢。 |
| FIFO 先进先出队列 | **Queue<T>** | Enqueue/Dequeue 摊销 O(1)、环形缓冲、内存连续；并发场景换 ConcurrentQueue。 |
| LIFO 后进先出栈 | **Stack<T>** | Push/Pop 摊销 O(1)、内存连续；并发场景换 ConcurrentStack。 |
| 只读视图 / 防御性封装 | **ReadOnlyCollection / ReadOnlyDictionary** | 包装现有集合暴露只读接口，无拷贝开销，但不阻止底层被改。 |
| 需要键且保留插入项的派生集合 | **KeyedCollection<TKey,TItem>** | List + 键索引的混合体，按键和按下标都能取；写少读多时方便。 |
| UI / 数据绑定通知变更 | **ObservableCollection<T>** | 增删触发 CollectionChanged 事件，配合数据绑定；性能不如 List，热路径勿用。 |
| 紧凑位标志 / 布尔大数组 | **BitArray** | 每元素 1 bit，内存极省，适合大量布尔标志位运算。 |

## ⚠ 读数警示

1. **跨 N 的原始 ms 非同口径**：`time_ms` 是单次 measurement 的耗时，而内部迭代次数随 N 缩放，所以 N=1 / 100 / 10000 之间的绝对 ms 不能直接横向比。**只在同一 (集合, 操作) 内沿 N 看趋势**，或在同一 N 内横向比集合。
2. **GC 字节是粗粒度**：分辨率约几十 KB；小档位 / 碎片化分配可能显示 0，这表示**未解析到 / 低于分辨率**，并非保证真零分配。
