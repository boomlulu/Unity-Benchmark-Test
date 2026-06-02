using System;
using NUnit.Framework;
using Unity.Collections;
using Unity.PerformanceTesting;

// ============================================================================
// Native family (Unity.Collections, com.unity.collections 2.1.4).
// SPEC §5.F. Elements: int / ValStruct ONLY (unmanaged; RefElem skipped — Native
// containers cannot hold managed references).
//
// Sizes:  Sizes.Quad = {1,100,10000}  (single ladder, see SPEC §1).
// Naming: <Collection>_<Op>_<Elem>  + [Values(1,100,10000)] int n.
//
// Measurement: Native containers are structs that own UNMANAGED heap memory; the
// producing(object) helper would box+leak them, so every test uses
// Bench.MeasureTimeAndGc(action, setup, cleanup, n). The container is allocated
// (Allocator.Persistent) inside setup (or inside action for build ops) and ALWAYS
// disposed in cleanup. GC Allocated is expected ~0 (no managed heap) = the headline.
//
// DISPOSE LAW: every Native container MUST be Disposed. setup/cleanup are paired;
// build ops (增) self-allocate per measurement and dispose the PREVIOUS instance at
// the head of the next action + final instance in cleanup, so nothing leaks across
// the many iterations of a measurement.
//
// API names actually used in 2.1.4 (verified against package source):
//   NativeArray<T>, NativeList<T>, NativeHashMap<K,V>, NativeHashSet<T>, NativeQueue<T>.
//   (NativeParallelHashMap/Set also exist but are the *parallel* variants; the plain
//    NativeHashMap/NativeHashSet are the right single-threaded analogues to BCL
//    Dictionary/HashSet, so those are used.)
//   NativeList.Add(in T) / RemoveAtSwapBack(int) / Contains<T,U>(ext, needs IEquatable<U>).
//   NativeHashMap.Add(k,v) / Remove(k) / this[k] / TryGetValue / GetEnumerator->KVPair.Key/.Value.
//   NativeHashSet.Add / Remove / Contains / GetEnumerator->Current.
//   NativeQueue.Enqueue / Dequeue / Count / ToArray(Allocator.Temp) (no direct enumerator).
// ============================================================================

namespace CollectionBenchmarks
{
    // -------------------------------------------------------------------------
    // Generic unmanaged cores. Thin per-(collection,op,elem) wrappers below call
    // these so each measured op body lives in exactly one place (where T:unmanaged).
    // -------------------------------------------------------------------------
    internal static class NativeCore
    {
        // ===== NativeArray<T> ================================================
        // setup: build N-array (Persistent), seed from src. cleanup: Dispose.
        public static void Array_Set<T>(int n, T[] src) where T : unmanaged
        {
            var arr = default(NativeArray<T>);
            int m = Bench.SubOpCount(n);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) arr[i] = src[i % n]; },
                setup: () =>
                {
                    arr = new NativeArray<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) arr[i] = src[i];
                },
                cleanup: () => { if (arr.IsCreated) arr.Dispose(); },
                n: n);
        }

        public static void Array_Get<T>(int n, T[] src) where T : unmanaged
        {
            var arr = default(NativeArray<T>);
            int m = Bench.SubOpCount(n);
            var sink = default(T);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sink = arr[i % n]; },
                setup: () =>
                {
                    arr = new NativeArray<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) arr[i] = src[i];
                },
                cleanup: () => { if (arr.IsCreated) arr.Dispose(); KeepAlive(sink); },
                n: n);
        }

        public static void Array_Iterate<T>(int n, T[] src) where T : unmanaged
        {
            var arr = default(NativeArray<T>);
            var sink = default(T);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < arr.Length; i++) sink = arr[i]; },
                setup: () =>
                {
                    arr = new NativeArray<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) arr[i] = src[i];
                },
                cleanup: () => { if (arr.IsCreated) arr.Dispose(); KeepAlive(sink); },
                n: n);
        }

        // ===== NativeList<T> =================================================
        // 增: build N-list by Add. self-alloc per measurement; dispose prev at head.
        public static void List_Add<T>(int n, T[] src) where T : unmanaged
        {
            var list = default(NativeList<T>);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    if (list.IsCreated) list.Dispose();      // drop previous iteration's instance
                    list = new NativeList<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) list.Add(src[i]);
                },
                setup: null,
                cleanup: () => { if (list.IsCreated) list.Dispose(); },
                n: n);
        }

        // 删: RemoveAtSwapBack from tail until empty. setup rebuilds full list.
        public static void List_Remove<T>(int n, T[] src) where T : unmanaged
        {
            var list = default(NativeList<T>);
            Bench.MeasureTimeAndGc(
                action: () => { while (list.Length > 0) list.RemoveAtSwapBack(list.Length - 1); },
                setup: () =>
                {
                    list = new NativeList<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) list.Add(src[i]);
                },
                cleanup: () => { if (list.IsCreated) list.Dispose(); },
                n: n);
        }

        public static void List_Set<T>(int n, T[] src) where T : unmanaged
        {
            var list = default(NativeList<T>);
            int m = Bench.SubOpCount(n);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) list[i % n] = src[i % n]; },
                setup: () =>
                {
                    list = new NativeList<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) list.Add(src[i]);
                },
                cleanup: () => { if (list.IsCreated) list.Dispose(); },
                n: n);
        }

        public static void List_Get<T>(int n, T[] src) where T : unmanaged
        {
            var list = default(NativeList<T>);
            int m = Bench.SubOpCount(n);
            var sink = default(T);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sink = list[i % n]; },
                setup: () =>
                {
                    list = new NativeList<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) list.Add(src[i]);
                },
                cleanup: () => { if (list.IsCreated) list.Dispose(); KeepAlive(sink); },
                n: n);
        }

        // 查-线性: NativeList.Contains<T,U> extension (needs T:IEquatable<U>). M capped to LinearScan.
        public static void List_Contains<T>(int n, T[] src) where T : unmanaged, IEquatable<T>
        {
            var list = default(NativeList<T>);
            int m = Bench.LinearScanCount(n);
            bool sink = false;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sink ^= list.Contains(src[i % n]); },
                setup: () =>
                {
                    list = new NativeList<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) list.Add(src[i]);
                },
                cleanup: () => { if (list.IsCreated) list.Dispose(); KeepAlive(sink); },
                n: n);
        }

        public static void List_Iterate<T>(int n, T[] src) where T : unmanaged
        {
            var list = default(NativeList<T>);
            var sink = default(T);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < list.Length; i++) sink = list[i]; },
                setup: () =>
                {
                    list = new NativeList<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) list.Add(src[i]);
                },
                cleanup: () => { if (list.IsCreated) list.Dispose(); KeepAlive(sink); },
                n: n);
        }

        // ===== NativeHashMap<int,T> =========================================
        // 增: build N-map by Add(key=i, value=src[i]).
        public static void Map_Add<T>(int n, T[] src) where T : unmanaged
        {
            var map = default(NativeHashMap<int, T>);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    if (map.IsCreated) map.Dispose();
                    map = new NativeHashMap<int, T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) map.Add(i, src[i]);
                },
                setup: null,
                cleanup: () => { if (map.IsCreated) map.Dispose(); },
                n: n);
        }

        // 删: Remove(key)×M.
        public static void Map_Remove<T>(int n, T[] src) where T : unmanaged
        {
            var map = default(NativeHashMap<int, T>);
            int m = Bench.SubOpCount(n);
            bool sink = false;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sink ^= map.Remove(i % n); },
                setup: () =>
                {
                    map = new NativeHashMap<int, T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) map.Add(i, src[i]);
                },
                cleanup: () => { if (map.IsCreated) map.Dispose(); KeepAlive(sink); },
                n: n);
        }

        // 改: this[key]=v ×M.
        public static void Map_Set<T>(int n, T[] src) where T : unmanaged
        {
            var map = default(NativeHashMap<int, T>);
            int m = Bench.SubOpCount(n);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) map[i % n] = src[i % n]; },
                setup: () =>
                {
                    map = new NativeHashMap<int, T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) map.Add(i, src[i]);
                },
                cleanup: () => { if (map.IsCreated) map.Dispose(); },
                n: n);
        }

        // 查: TryGetValue×M.
        public static void Map_Get<T>(int n, T[] src) where T : unmanaged
        {
            var map = default(NativeHashMap<int, T>);
            int m = Bench.SubOpCount(n);
            var sink = default(T);
            bool ok = false;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) { ok ^= map.TryGetValue(i % n, out var v); sink = v; } },
                setup: () =>
                {
                    map = new NativeHashMap<int, T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) map.Add(i, src[i]);
                },
                cleanup: () => { if (map.IsCreated) map.Dispose(); KeepAlive(sink); KeepAlive(ok); },
                n: n);
        }

        // 遍历: enumerator over KVPair (Key/Value). No managed temp allocated.
        public static void Map_Iterate<T>(int n, T[] src) where T : unmanaged
        {
            var map = default(NativeHashMap<int, T>);
            int ksink = 0;
            var vsink = default(T);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    var e = map.GetEnumerator();
                    while (e.MoveNext()) { ksink += e.Current.Key; vsink = e.Current.Value; }
                },
                setup: () =>
                {
                    map = new NativeHashMap<int, T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) map.Add(i, src[i]);
                },
                cleanup: () => { if (map.IsCreated) map.Dispose(); KeepAlive(ksink); KeepAlive(vsink); },
                n: n);
        }

        // ===== NativeHashSet<T> =============================================
        // 增: build N-set by Add. element is the key.
        public static void Set_Add<T>(int n, T[] src) where T : unmanaged, IEquatable<T>
        {
            var set = default(NativeHashSet<T>);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    if (set.IsCreated) set.Dispose();
                    set = new NativeHashSet<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) set.Add(src[i]);
                },
                setup: null,
                cleanup: () => { if (set.IsCreated) set.Dispose(); },
                n: n);
        }

        // 删: Remove×M.
        public static void Set_Remove<T>(int n, T[] src) where T : unmanaged, IEquatable<T>
        {
            var set = default(NativeHashSet<T>);
            int m = Bench.SubOpCount(n);
            bool sink = false;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sink ^= set.Remove(src[i % n]); },
                setup: () =>
                {
                    set = new NativeHashSet<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) set.Add(src[i]);
                },
                cleanup: () => { if (set.IsCreated) set.Dispose(); KeepAlive(sink); },
                n: n);
        }

        // 查: Contains×M.
        public static void Set_Contains<T>(int n, T[] src) where T : unmanaged, IEquatable<T>
        {
            var set = default(NativeHashSet<T>);
            int m = Bench.SubOpCount(n);
            bool sink = false;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sink ^= set.Contains(src[i % n]); },
                setup: () =>
                {
                    set = new NativeHashSet<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) set.Add(src[i]);
                },
                cleanup: () => { if (set.IsCreated) set.Dispose(); KeepAlive(sink); },
                n: n);
        }

        // 遍历: enumerator over Current.
        public static void Set_Iterate<T>(int n, T[] src) where T : unmanaged, IEquatable<T>
        {
            var set = default(NativeHashSet<T>);
            var sink = default(T);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    var e = set.GetEnumerator();
                    while (e.MoveNext()) sink = e.Current;
                },
                setup: () =>
                {
                    set = new NativeHashSet<T>(n, Allocator.Persistent);
                    for (int i = 0; i < n; i++) set.Add(src[i]);
                },
                cleanup: () => { if (set.IsCreated) set.Dispose(); KeepAlive(sink); },
                n: n);
        }

        // ===== NativeQueue<T> ===============================================
        // 增: build N-queue by Enqueue.
        public static void Queue_Add<T>(int n, T[] src) where T : unmanaged
        {
            var q = default(NativeQueue<T>);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    if (q.IsCreated) q.Dispose();
                    q = new NativeQueue<T>(Allocator.Persistent);
                    for (int i = 0; i < n; i++) q.Enqueue(src[i]);
                },
                setup: null,
                cleanup: () => { if (q.IsCreated) q.Dispose(); },
                n: n);
        }

        // 删: Dequeue until empty.
        public static void Queue_Remove<T>(int n, T[] src) where T : unmanaged
        {
            var q = default(NativeQueue<T>);
            var sink = default(T);
            Bench.MeasureTimeAndGc(
                action: () => { while (q.Count > 0) sink = q.Dequeue(); },
                setup: () =>
                {
                    q = new NativeQueue<T>(Allocator.Persistent);
                    for (int i = 0; i < n; i++) q.Enqueue(src[i]);
                },
                cleanup: () => { if (q.IsCreated) q.Dispose(); KeepAlive(sink); },
                n: n);
        }

        // 遍历: NativeQueue has no direct enumerator -> ToArray(Allocator.Temp), foreach, Dispose temp.
        // The Temp array is itself a Native (unmanaged) buffer disposed inside the action, so GC ~0.
        public static void Queue_Iterate<T>(int n, T[] src) where T : unmanaged
        {
            var q = default(NativeQueue<T>);
            var sink = default(T);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    var tmp = q.ToArray(Allocator.Temp);
                    for (int i = 0; i < tmp.Length; i++) sink = tmp[i];
                    tmp.Dispose();
                },
                setup: () =>
                {
                    q = new NativeQueue<T>(Allocator.Persistent);
                    for (int i = 0; i < n; i++) q.Enqueue(src[i]);
                },
                cleanup: () => { if (q.IsCreated) q.Dispose(); KeepAlive(sink); },
                n: n);
        }

        // Prevent dead-code elimination of read sinks without allocating.
        static void KeepAlive<T>(T v)
        {
            if (v == null) UnityEngine.Debug.Log(v);
        }
    }

    // -------------------------------------------------------------------------
    // NativeArray<T> : 改 / 查 / 遍历 (no add/remove — fixed length).
    // -------------------------------------------------------------------------
    [Category("Native")]
    public class NativeArrayBenchmarks
    {
        [Test, Performance] public void NativeArray_Set_int([Values(1, 100, 10000)] int n)
            => NativeCore.Array_Set(n, Src.Ints(n));
        [Test, Performance] public void NativeArray_Set_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Array_Set(n, Src.Vals(n));

        [Test, Performance] public void NativeArray_Get_int([Values(1, 100, 10000)] int n)
            => NativeCore.Array_Get(n, Src.Ints(n));
        [Test, Performance] public void NativeArray_Get_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Array_Get(n, Src.Vals(n));

        [Test, Performance] public void NativeArray_Iterate_int([Values(1, 100, 10000)] int n)
            => NativeCore.Array_Iterate(n, Src.Ints(n));
        [Test, Performance] public void NativeArray_Iterate_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Array_Iterate(n, Src.Vals(n));
    }

    // -------------------------------------------------------------------------
    // NativeList<T> : 增 / 删 / 改 / 查(index + 线性Contains) / 遍历.
    // -------------------------------------------------------------------------
    [Category("Native")]
    public class NativeListBenchmarks
    {
        [Test, Performance] public void NativeList_Add_int([Values(1, 100, 10000)] int n)
            => NativeCore.List_Add(n, Src.Ints(n));
        [Test, Performance] public void NativeList_Add_struct([Values(1, 100, 10000)] int n)
            => NativeCore.List_Add(n, Src.Vals(n));

        [Test, Performance] public void NativeList_Remove_int([Values(1, 100, 10000)] int n)
            => NativeCore.List_Remove(n, Src.Ints(n));
        [Test, Performance] public void NativeList_Remove_struct([Values(1, 100, 10000)] int n)
            => NativeCore.List_Remove(n, Src.Vals(n));

        [Test, Performance] public void NativeList_Set_int([Values(1, 100, 10000)] int n)
            => NativeCore.List_Set(n, Src.Ints(n));
        [Test, Performance] public void NativeList_Set_struct([Values(1, 100, 10000)] int n)
            => NativeCore.List_Set(n, Src.Vals(n));

        [Test, Performance] public void NativeList_Get_int([Values(1, 100, 10000)] int n)
            => NativeCore.List_Get(n, Src.Ints(n));
        [Test, Performance] public void NativeList_Get_struct([Values(1, 100, 10000)] int n)
            => NativeCore.List_Get(n, Src.Vals(n));

        [Test, Performance] public void NativeList_Contains_int([Values(1, 100, 10000)] int n)
            => NativeCore.List_Contains(n, Src.Ints(n));
        [Test, Performance] public void NativeList_Contains_struct([Values(1, 100, 10000)] int n)
            => NativeCore.List_Contains(n, Src.Vals(n));

        [Test, Performance] public void NativeList_Iterate_int([Values(1, 100, 10000)] int n)
            => NativeCore.List_Iterate(n, Src.Ints(n));
        [Test, Performance] public void NativeList_Iterate_struct([Values(1, 100, 10000)] int n)
            => NativeCore.List_Iterate(n, Src.Vals(n));
    }

    // -------------------------------------------------------------------------
    // NativeHashMap<int,T> : 增 / 删 / 改 / 查 / 遍历.
    // -------------------------------------------------------------------------
    [Category("Native")]
    public class NativeHashMapBenchmarks
    {
        [Test, Performance] public void NativeHashMap_Add_int([Values(1, 100, 10000)] int n)
            => NativeCore.Map_Add(n, Src.Ints(n));
        [Test, Performance] public void NativeHashMap_Add_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Map_Add(n, Src.Vals(n));

        [Test, Performance] public void NativeHashMap_Remove_int([Values(1, 100, 10000)] int n)
            => NativeCore.Map_Remove(n, Src.Ints(n));
        [Test, Performance] public void NativeHashMap_Remove_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Map_Remove(n, Src.Vals(n));

        [Test, Performance] public void NativeHashMap_Set_int([Values(1, 100, 10000)] int n)
            => NativeCore.Map_Set(n, Src.Ints(n));
        [Test, Performance] public void NativeHashMap_Set_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Map_Set(n, Src.Vals(n));

        [Test, Performance] public void NativeHashMap_Get_int([Values(1, 100, 10000)] int n)
            => NativeCore.Map_Get(n, Src.Ints(n));
        [Test, Performance] public void NativeHashMap_Get_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Map_Get(n, Src.Vals(n));

        [Test, Performance] public void NativeHashMap_Iterate_int([Values(1, 100, 10000)] int n)
            => NativeCore.Map_Iterate(n, Src.Ints(n));
        [Test, Performance] public void NativeHashMap_Iterate_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Map_Iterate(n, Src.Vals(n));
    }

    // -------------------------------------------------------------------------
    // NativeHashSet<T> : 增 / 删 / 查 / 遍历 (element is key; no 改).
    // -------------------------------------------------------------------------
    [Category("Native")]
    public class NativeHashSetBenchmarks
    {
        [Test, Performance] public void NativeHashSet_Add_int([Values(1, 100, 10000)] int n)
            => NativeCore.Set_Add(n, Src.Ints(n));
        [Test, Performance] public void NativeHashSet_Add_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Set_Add(n, Src.Vals(n));

        [Test, Performance] public void NativeHashSet_Remove_int([Values(1, 100, 10000)] int n)
            => NativeCore.Set_Remove(n, Src.Ints(n));
        [Test, Performance] public void NativeHashSet_Remove_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Set_Remove(n, Src.Vals(n));

        [Test, Performance] public void NativeHashSet_Contains_int([Values(1, 100, 10000)] int n)
            => NativeCore.Set_Contains(n, Src.Ints(n));
        [Test, Performance] public void NativeHashSet_Contains_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Set_Contains(n, Src.Vals(n));

        [Test, Performance] public void NativeHashSet_Iterate_int([Values(1, 100, 10000)] int n)
            => NativeCore.Set_Iterate(n, Src.Ints(n));
        [Test, Performance] public void NativeHashSet_Iterate_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Set_Iterate(n, Src.Vals(n));
    }

    // -------------------------------------------------------------------------
    // NativeQueue<T> : 增 / 删 / 遍历 (FIFO; no random 改/查; iterate via ToArray(Temp)).
    // -------------------------------------------------------------------------
    [Category("Native")]
    public class NativeQueueBenchmarks
    {
        [Test, Performance] public void NativeQueue_Add_int([Values(1, 100, 10000)] int n)
            => NativeCore.Queue_Add(n, Src.Ints(n));
        [Test, Performance] public void NativeQueue_Add_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Queue_Add(n, Src.Vals(n));

        [Test, Performance] public void NativeQueue_Remove_int([Values(1, 100, 10000)] int n)
            => NativeCore.Queue_Remove(n, Src.Ints(n));
        [Test, Performance] public void NativeQueue_Remove_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Queue_Remove(n, Src.Vals(n));

        [Test, Performance] public void NativeQueue_Iterate_int([Values(1, 100, 10000)] int n)
            => NativeCore.Queue_Iterate(n, Src.Ints(n));
        [Test, Performance] public void NativeQueue_Iterate_struct([Values(1, 100, 10000)] int n)
            => NativeCore.Queue_Iterate(n, Src.Vals(n));
    }
}
