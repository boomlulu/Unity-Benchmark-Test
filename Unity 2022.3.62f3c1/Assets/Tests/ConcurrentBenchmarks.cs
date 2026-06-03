using System.Collections.Concurrent;
using NUnit.Framework;
using Unity.PerformanceTesting;

// ============================================================================
// Concurrent family benchmarks (SPEC §5.C, Category="Concurrent").
//
// Collections (System.Collections.Concurrent), key=int / value=elem for dict-like:
//   ConcurrentDictionary<int,T> : 增(TryAdd build) 删(TryRemove×SubOp) 改(this[k]=×SubOp)
//                                  查(TryGetValue×SubOp) 遍历(foreach KVP)
//   ConcurrentQueue<T>          : 增(Enqueue build) 删(TryDequeue drain)
//                                  查(TryPeek + foreach Contains-scan×LinearScan) 遍历
//   ConcurrentStack<T>          : 增(Push build) 删(TryPop drain) 查(TryPeek) 遍历
//   ConcurrentBag<T>            : 增(Add build) 删(TryTake drain) 遍历   (unordered; no 改/random 查)
//   BlockingCollection<T>       : 增(Add build) 删(Take drain) 遍历      (default backing ConcurrentQueue)
//
// Element types: int / ValStruct / RefElem (all three for every op).
//
// MEASUREMENT NOTE (single-threaded by design): these benchmarks exercise ONE thread
// so they measure the *structural* overhead of each concurrent collection (lock / CAS /
// striping fixed cost, partition allocation, enumerator snapshotting), NOT contention
// under real parallelism. Lock/CAS fixed cost still shows up vs the non-concurrent peers.
//
// Naming convention (SPEC §8 / harness): <Collection>_<Op>_<Elem>, parameterized by
//   [Values(1,100,10000)] int n. Each test -> Time(ms) + "GC Allocated"(Bytes).
//
// Volume control: each op has ONE generic core (works for int/ValStruct/RefElem) and a
// thin per-element wrapper that just forwards the source array + n.
// ============================================================================

namespace CollectionBenchmarks
{
    [Category("Concurrent")]
    public class ConcurrentBenchmarks
    {
        // =====================================================================
        // ConcurrentDictionary<int,T>
        // =====================================================================

        // ---- 增: TryAdd build to N. key=int, value=elem. Allocates buckets/nodes -> GC > 0 ----
        static object Dict_Add_Core<T>(T[] src, int n)
        {
            var dict = new ConcurrentDictionary<int, T>();
            for (int i = 0; i < n; i++) dict.TryAdd(i, src[i]);
            return dict;
        }

        [Test, Performance]
        public void ConcurrentDictionary_Add_int([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Dict_Add_Core(Src.Ints(n), n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Add_val([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Dict_Add_Core(Src.Vals(n), n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Add_ref([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Dict_Add_Core(Src.Refs(n), n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Add_bool([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Dict_Add_Core(Src.Bools(n), n), n);

        // ---- 删: TryRemove ×SubOp. Destructive -> rebuild full dict each measurement (not counted) ----
        static void Dict_Remove_Core<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            var dict = new ConcurrentDictionary<int, T>();
            void Build()
            {
                dict.Clear();
                for (int i = 0; i < n; i++) dict.TryAdd(i, src[i]);
            }
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++)
                        if (dict.TryRemove(i, out _)) sink++;
                },
                setup: Build,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ConcurrentDictionary_Remove_int([Values(1, 100, 10000)] int n)
            => Dict_Remove_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Remove_val([Values(1, 100, 10000)] int n)
            => Dict_Remove_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Remove_ref([Values(1, 100, 10000)] int n)
            => Dict_Remove_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Remove_bool([Values(1, 100, 10000)] int n)
            => Dict_Remove_Core(Src.Bools(n), n);

        // ---- 改: this[k]=v ×SubOp (overwrite existing keys). In-place, no growth -> GC ~= 0 ----
        static void Dict_Update_Core<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            var dict = new ConcurrentDictionary<int, T>();
            for (int i = 0; i < n; i++) dict.TryAdd(i, src[i]);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) dict[i] = src[i];
                },
                setup: null,
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void ConcurrentDictionary_Update_int([Values(1, 100, 10000)] int n)
            => Dict_Update_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Update_val([Values(1, 100, 10000)] int n)
            => Dict_Update_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Update_ref([Values(1, 100, 10000)] int n)
            => Dict_Update_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Update_bool([Values(1, 100, 10000)] int n)
            => Dict_Update_Core(Src.Bools(n), n);

        // ---- 查: TryGetValue ×SubOp. Pure lookups -> GC ~= 0 ----
        static void Dict_Get_Core<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            var dict = new ConcurrentDictionary<int, T>();
            for (int i = 0; i < n; i++) dict.TryAdd(i, src[i]);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++)
                        if (dict.TryGetValue(i, out _)) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ConcurrentDictionary_Get_int([Values(1, 100, 10000)] int n)
            => Dict_Get_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Get_val([Values(1, 100, 10000)] int n)
            => Dict_Get_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Get_ref([Values(1, 100, 10000)] int n)
            => Dict_Get_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Get_bool([Values(1, 100, 10000)] int n)
            => Dict_Get_Core(Src.Bools(n), n);

        // ---- 遍历: foreach KVP full scan. ConcurrentDictionary enumerator is a snapshot-free
        //      struct walk -> GC ~= 0 ----
        static void Dict_Iterate_Core<T>(T[] src, int n)
        {
            var dict = new ConcurrentDictionary<int, T>();
            for (int i = 0; i < n; i++) dict.TryAdd(i, src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var kv in dict) sink += kv.Key;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ConcurrentDictionary_Iterate_int([Values(1, 100, 10000)] int n)
            => Dict_Iterate_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Iterate_val([Values(1, 100, 10000)] int n)
            => Dict_Iterate_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Iterate_ref([Values(1, 100, 10000)] int n)
            => Dict_Iterate_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentDictionary_Iterate_bool([Values(1, 100, 10000)] int n)
            => Dict_Iterate_Core(Src.Bools(n), n);

        // =====================================================================
        // ConcurrentQueue<T>
        // =====================================================================

        // ---- 增: Enqueue build to N. Segment array allocation -> GC > 0 ----
        static object Queue_Add_Core<T>(T[] src, int n)
        {
            var q = new ConcurrentQueue<T>();
            for (int i = 0; i < n; i++) q.Enqueue(src[i]);
            return q;
        }

        [Test, Performance]
        public void ConcurrentQueue_Add_int([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Queue_Add_Core(Src.Ints(n), n), n);

        [Test, Performance]
        public void ConcurrentQueue_Add_val([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Queue_Add_Core(Src.Vals(n), n), n);

        [Test, Performance]
        public void ConcurrentQueue_Add_ref([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Queue_Add_Core(Src.Refs(n), n), n);

        [Test, Performance]
        public void ConcurrentQueue_Add_bool([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Queue_Add_Core(Src.Bools(n), n), n);

        // ---- 删: TryDequeue drain to empty. Destructive -> rebuild full queue each measurement ----
        static void Queue_Remove_Core<T>(T[] src, int n)
        {
            ConcurrentQueue<T> q = null;
            void Build()
            {
                q = new ConcurrentQueue<T>();
                for (int i = 0; i < n; i++) q.Enqueue(src[i]);
            }
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    while (q.TryDequeue(out _)) sink++;
                },
                setup: Build,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ConcurrentQueue_Remove_int([Values(1, 100, 10000)] int n)
            => Queue_Remove_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentQueue_Remove_val([Values(1, 100, 10000)] int n)
            => Queue_Remove_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentQueue_Remove_ref([Values(1, 100, 10000)] int n)
            => Queue_Remove_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentQueue_Remove_bool([Values(1, 100, 10000)] int n)
            => Queue_Remove_Core(Src.Bools(n), n);

        // ---- 查: TryPeek (head, O(1)) + foreach Contains-scan ×LinearScan (no random access on a
        //      queue, so membership is a linear walk; capped by LinearScanCount). GC ~= 0 ----
        static void Queue_Contains_Core<T>(T[] src, int n)
        {
            int m = Bench.LinearScanCount(n);
            var q = new ConcurrentQueue<T>();
            for (int i = 0; i < n; i++) q.Enqueue(src[i]);
            var cmp = System.Collections.Generic.EqualityComparer<T>.Default;
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    if (q.TryPeek(out _)) sink++;
                    for (int i = 0; i < m; i++)
                    {
                        T target = src[i];
                        foreach (var v in q)
                        {
                            if (cmp.Equals(v, target)) { sink++; break; }
                        }
                    }
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ConcurrentQueue_Contains_int([Values(1, 100, 10000)] int n)
            => Queue_Contains_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentQueue_Contains_val([Values(1, 100, 10000)] int n)
            => Queue_Contains_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentQueue_Contains_ref([Values(1, 100, 10000)] int n)
            => Queue_Contains_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentQueue_Contains_bool([Values(1, 100, 10000)] int n)
            => Queue_Contains_Core(Src.Bools(n), n);

        // ---- 遍历: foreach full scan (moment-in-time snapshot enumerator). GC ~= 0 in steady state ----
        static void Queue_Iterate_Core<T>(T[] src, int n)
        {
            var q = new ConcurrentQueue<T>();
            for (int i = 0; i < n; i++) q.Enqueue(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var v in q) sink += v.GetHashCode();
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ConcurrentQueue_Iterate_int([Values(1, 100, 10000)] int n)
            => Queue_Iterate_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentQueue_Iterate_val([Values(1, 100, 10000)] int n)
            => Queue_Iterate_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentQueue_Iterate_ref([Values(1, 100, 10000)] int n)
            => Queue_Iterate_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentQueue_Iterate_bool([Values(1, 100, 10000)] int n)
            => Queue_Iterate_Core(Src.Bools(n), n);

        // =====================================================================
        // ConcurrentStack<T>
        // =====================================================================

        // ---- 增: Push build to N. Each Push allocates a linked node -> GC > 0 (node per elem) ----
        static object Stack_Add_Core<T>(T[] src, int n)
        {
            var s = new ConcurrentStack<T>();
            for (int i = 0; i < n; i++) s.Push(src[i]);
            return s;
        }

        [Test, Performance]
        public void ConcurrentStack_Add_int([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Stack_Add_Core(Src.Ints(n), n), n);

        [Test, Performance]
        public void ConcurrentStack_Add_val([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Stack_Add_Core(Src.Vals(n), n), n);

        [Test, Performance]
        public void ConcurrentStack_Add_ref([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Stack_Add_Core(Src.Refs(n), n), n);

        [Test, Performance]
        public void ConcurrentStack_Add_bool([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Stack_Add_Core(Src.Bools(n), n), n);

        // ---- 删: TryPop drain to empty. Destructive -> rebuild full stack each measurement ----
        static void Stack_Remove_Core<T>(T[] src, int n)
        {
            ConcurrentStack<T> s = null;
            void Build()
            {
                s = new ConcurrentStack<T>();
                for (int i = 0; i < n; i++) s.Push(src[i]);
            }
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    while (s.TryPop(out _)) sink++;
                },
                setup: Build,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ConcurrentStack_Remove_int([Values(1, 100, 10000)] int n)
            => Stack_Remove_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentStack_Remove_val([Values(1, 100, 10000)] int n)
            => Stack_Remove_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentStack_Remove_ref([Values(1, 100, 10000)] int n)
            => Stack_Remove_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentStack_Remove_bool([Values(1, 100, 10000)] int n)
            => Stack_Remove_Core(Src.Bools(n), n);

        // ---- 查: TryPeek (top, O(1)). Pure lookup -> GC ~= 0 ----
        static void Stack_Peek_Core<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            var s = new ConcurrentStack<T>();
            for (int i = 0; i < n; i++) s.Push(src[i]);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++)
                        if (s.TryPeek(out _)) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ConcurrentStack_Peek_int([Values(1, 100, 10000)] int n)
            => Stack_Peek_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentStack_Peek_val([Values(1, 100, 10000)] int n)
            => Stack_Peek_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentStack_Peek_ref([Values(1, 100, 10000)] int n)
            => Stack_Peek_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentStack_Peek_bool([Values(1, 100, 10000)] int n)
            => Stack_Peek_Core(Src.Bools(n), n);

        // ---- 遍历: foreach full scan (snapshot enumerator). GC ~= 0 in steady state ----
        static void Stack_Iterate_Core<T>(T[] src, int n)
        {
            var s = new ConcurrentStack<T>();
            for (int i = 0; i < n; i++) s.Push(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var v in s) sink += v.GetHashCode();
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ConcurrentStack_Iterate_int([Values(1, 100, 10000)] int n)
            => Stack_Iterate_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentStack_Iterate_val([Values(1, 100, 10000)] int n)
            => Stack_Iterate_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentStack_Iterate_ref([Values(1, 100, 10000)] int n)
            => Stack_Iterate_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentStack_Iterate_bool([Values(1, 100, 10000)] int n)
            => Stack_Iterate_Core(Src.Bools(n), n);

        // =====================================================================
        // ConcurrentBag<T>  (unordered; no random 查, no 改)
        // =====================================================================

        // ---- 增: Add build to N. Per-thread local storage + nodes -> GC > 0 ----
        static object Bag_Add_Core<T>(T[] src, int n)
        {
            var bag = new ConcurrentBag<T>();
            for (int i = 0; i < n; i++) bag.Add(src[i]);
            return bag;
        }

        [Test, Performance]
        public void ConcurrentBag_Add_int([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Bag_Add_Core(Src.Ints(n), n), n);

        [Test, Performance]
        public void ConcurrentBag_Add_val([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Bag_Add_Core(Src.Vals(n), n), n);

        [Test, Performance]
        public void ConcurrentBag_Add_ref([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Bag_Add_Core(Src.Refs(n), n), n);

        [Test, Performance]
        public void ConcurrentBag_Add_bool([Values(1, 100, 10000)] int n)
            => Bench.MeasureTimeAndGcProducing(() => Bag_Add_Core(Src.Bools(n), n), n);

        // ---- 删: TryTake drain to empty. Destructive -> rebuild full bag each measurement ----
        static void Bag_Remove_Core<T>(T[] src, int n)
        {
            ConcurrentBag<T> bag = null;
            void Build()
            {
                bag = new ConcurrentBag<T>();
                for (int i = 0; i < n; i++) bag.Add(src[i]);
            }
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    while (bag.TryTake(out _)) sink++;
                },
                setup: Build,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ConcurrentBag_Remove_int([Values(1, 100, 10000)] int n)
            => Bag_Remove_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentBag_Remove_val([Values(1, 100, 10000)] int n)
            => Bag_Remove_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentBag_Remove_ref([Values(1, 100, 10000)] int n)
            => Bag_Remove_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentBag_Remove_bool([Values(1, 100, 10000)] int n)
            => Bag_Remove_Core(Src.Bools(n), n);

        // ---- 遍历: foreach full scan (snapshots all thread-local segments). GC ~= 0 in steady state ----
        static void Bag_Iterate_Core<T>(T[] src, int n)
        {
            var bag = new ConcurrentBag<T>();
            for (int i = 0; i < n; i++) bag.Add(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var v in bag) sink += v.GetHashCode();
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ConcurrentBag_Iterate_int([Values(1, 100, 10000)] int n)
            => Bag_Iterate_Core(Src.Ints(n), n);

        [Test, Performance]
        public void ConcurrentBag_Iterate_val([Values(1, 100, 10000)] int n)
            => Bag_Iterate_Core(Src.Vals(n), n);

        [Test, Performance]
        public void ConcurrentBag_Iterate_ref([Values(1, 100, 10000)] int n)
            => Bag_Iterate_Core(Src.Refs(n), n);

        [Test, Performance]
        public void ConcurrentBag_Iterate_bool([Values(1, 100, 10000)] int n)
            => Bag_Iterate_Core(Src.Bools(n), n);

        // =====================================================================
        // BlockingCollection<T>  (default backing = ConcurrentQueue)
        // =====================================================================

        // ---- 增: Add build to N. Wraps ConcurrentQueue + SemaphoreSlim bookkeeping -> GC > 0.
        //      Each measurement uses its OWN fresh instance: setup news an empty BC, action fills
        //      it to N, cleanup disposes it. Never reuse a disposed instance across iterations. ----
        static void Blocking_Add_Core<T>(T[] src, int n)
        {
            BlockingCollection<T> bc = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < n; i++) bc.Add(src[i]);
                },
                setup: () => { bc = new BlockingCollection<T>(); },
                cleanup: () => { bc?.Dispose(); bc = null; },
                n: n);
        }

        [Test, Performance]
        public void BlockingCollection_Add_int([Values(1, 100, 10000)] int n)
            => Blocking_Add_Core(Src.Ints(n), n);

        [Test, Performance]
        public void BlockingCollection_Add_val([Values(1, 100, 10000)] int n)
            => Blocking_Add_Core(Src.Vals(n), n);

        [Test, Performance]
        public void BlockingCollection_Add_ref([Values(1, 100, 10000)] int n)
            => Blocking_Add_Core(Src.Refs(n), n);

        [Test, Performance]
        public void BlockingCollection_Add_bool([Values(1, 100, 10000)] int n)
            => Blocking_Add_Core(Src.Bools(n), n);

        // ---- 删: Take drain to empty. Destructive -> setup rebuilds a fresh FULL collection each
        //      measurement, action drains exactly Count items (Take blocks at empty, so never past
        //      empty), cleanup disposes. setup always pairs with action so action never sees a
        //      disposed instance. ----
        static void Blocking_Remove_Core<T>(T[] src, int n)
        {
            BlockingCollection<T> bc = null;
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    int count = bc.Count;
                    for (int i = 0; i < count; i++) { bc.Take(); sink++; }
                },
                setup: () =>
                {
                    bc = new BlockingCollection<T>();
                    for (int i = 0; i < n; i++) bc.Add(src[i]);
                },
                cleanup: () => { bc?.Dispose(); bc = null; if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void BlockingCollection_Remove_int([Values(1, 100, 10000)] int n)
            => Blocking_Remove_Core(Src.Ints(n), n);

        [Test, Performance]
        public void BlockingCollection_Remove_val([Values(1, 100, 10000)] int n)
            => Blocking_Remove_Core(Src.Vals(n), n);

        [Test, Performance]
        public void BlockingCollection_Remove_ref([Values(1, 100, 10000)] int n)
            => Blocking_Remove_Core(Src.Refs(n), n);

        [Test, Performance]
        public void BlockingCollection_Remove_bool([Values(1, 100, 10000)] int n)
            => Blocking_Remove_Core(Src.Bools(n), n);

        // ---- 遍历: foreach over GetConsumingEnumerable? No — that drains. Use plain foreach which
        //      enumerates a snapshot without consuming. setup rebuilds a fresh FULL collection each
        //      measurement (so iterating never hits a disposed instance), action does a plain
        //      non-consuming foreach, cleanup disposes. GC ~= 0 in steady state. ----
        static void Blocking_Iterate_Core<T>(T[] src, int n)
        {
            BlockingCollection<T> bc = null;
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var v in bc) sink += v.GetHashCode();
                },
                setup: () =>
                {
                    bc = new BlockingCollection<T>();
                    for (int i = 0; i < n; i++) bc.Add(src[i]);
                },
                cleanup: () => { bc?.Dispose(); bc = null; if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void BlockingCollection_Iterate_int([Values(1, 100, 10000)] int n)
            => Blocking_Iterate_Core(Src.Ints(n), n);

        [Test, Performance]
        public void BlockingCollection_Iterate_val([Values(1, 100, 10000)] int n)
            => Blocking_Iterate_Core(Src.Vals(n), n);

        [Test, Performance]
        public void BlockingCollection_Iterate_ref([Values(1, 100, 10000)] int n)
            => Blocking_Iterate_Core(Src.Refs(n), n);

        [Test, Performance]
        public void BlockingCollection_Iterate_bool([Values(1, 100, 10000)] int n)
            => Blocking_Iterate_Core(Src.Bools(n), n);
    }
}
