using System.Collections.Immutable;
using NUnit.Framework;
using Unity.PerformanceTesting;

// ============================================================================
// Immutable family (SPEC §5.E). System.Collections.Immutable.dll plugin.
//
// IMMUTABLE SEMANTICS (key): Add / Remove / SetItem all return a NEW instance
// (structural sharing / path-copy). So 增/删/改 are ALL "producing" ops measured
// with MeasureTimeAndGcProducing. 查/遍历 (read/iterate) are IN-PLACE -> MeasureTimeAndGc.
//
// Two flavours of "增":
//   增   (Op=Build / BuilderAdd)  = idiomatic CreateBuilder + loop Add + ToImmutable
//                                   (build whole size-N collection).
//   增单次 (Op=AddOne)            = ONE .Add on a pre-built size-N immutable
//                                   -> producing; measures single path-copy cost.
// Queue/Stack have no random index/key, so:
//   增 = Enqueue/Push loop, each returning a new instance (producing chain build).
//   删 = Dequeue/Pop drain to empty (producing chain).
//
// GC NOTE (read BenchmarkSupport.cs §): build / path-copy ops are the GC heavy
// hitters of this family, but GetTotalMemory (the only working byte counter in
// this Mono) UNDER-RESOLVES allocation-heavy builds whose transient small objects
// are compacted mid-window. A 0 on a *build* / *AddOne* / *Remove* / *SetItem*
// producing op means "below the GetTotalMemory floor", NOT proven-zero allocation.
// complexity.Immutable.json space column documents the real path-copy/persistent cost.
//
// Naming: <Collection>_<Op>_<Elem>_N<size>  (report parser keys off _N<size>).
// Elements: int / val(ValStruct) / ref(RefElem). dict key=int, value=elem.
// Sizes: {1, 100, 10000} = Sizes.Quad.
// ============================================================================

namespace CollectionBenchmarks
{
    [Category("Immutable")]
    public class ImmutableBenchmarks
    {
        // ====================================================================
        // Generic cores: one parametric body per (collection, op), thin per-(elem,size)
        // wrappers below call them. Keeps measured allocation = collection-only.
        // ====================================================================

        // ---- ImmutableArray<T> ----
        static object ArrayBuild<T>(T[] src, int n)
        {
            var b = ImmutableArray.CreateBuilder<T>(n);
            for (int i = 0; i < n; i++) b.Add(src[i]);
            return b.ToImmutable();
        }
        static object ArrayAddOne<T>(ImmutableArray<T> baseArr, T extra) => baseArr.Add(extra);
        static object ArrayRemoveAt<T>(ImmutableArray<T> baseArr, int idx) => baseArr.RemoveAt(idx);
        static object ArraySetItem<T>(ImmutableArray<T> baseArr, int idx, T v) => baseArr.SetItem(idx, v);
        static int ArrayIndexScan<T>(ImmutableArray<T> arr, int m)
        {
            int sink = 0;
            for (int i = 0; i < m; i++) sink += arr[i % arr.Length].GetHashCode();
            return sink;
        }
        static int ArrayContainsScan<T>(ImmutableArray<T> arr, T[] src, int m)
        {
            int sink = 0;
            for (int i = 0; i < m; i++) if (arr.Contains(src[i % src.Length])) sink++;
            return sink;
        }
        static long ArrayIterate<T>(ImmutableArray<T> arr)
        {
            long sink = 0;
            foreach (var _ in arr) sink++;
            return sink;
        }

        // ---- ImmutableList<T> ----
        static object ListBuild<T>(T[] src, int n)
        {
            var b = ImmutableList.CreateBuilder<T>();
            for (int i = 0; i < n; i++) b.Add(src[i]);
            return b.ToImmutable();
        }
        static object ListAddOne<T>(ImmutableList<T> baseList, T extra) => baseList.Add(extra);
        static object ListRemove<T>(ImmutableList<T> baseList, T v) => baseList.Remove(v);
        static object ListSetItem<T>(ImmutableList<T> baseList, int idx, T v) => baseList.SetItem(idx, v);
        static int ListIndexScan<T>(ImmutableList<T> list, int m)
        {
            int sink = 0;
            for (int i = 0; i < m; i++) sink += list[i % list.Count].GetHashCode();
            return sink;
        }
        static int ListContainsScan<T>(ImmutableList<T> list, T[] src, int m)
        {
            int sink = 0;
            for (int i = 0; i < m; i++) if (list.Contains(src[i % src.Length])) sink++;
            return sink;
        }
        static long ListIterate<T>(ImmutableList<T> list)
        {
            long sink = 0;
            foreach (var _ in list) sink++;
            return sink;
        }

        // ---- ImmutableDictionary<int,T> ----
        static object DictBuild<T>(T[] src, int n)
        {
            var b = ImmutableDictionary.CreateBuilder<int, T>();
            for (int i = 0; i < n; i++) b[i] = src[i];
            return b.ToImmutable();
        }
        static object DictSetOne<T>(ImmutableDictionary<int, T> baseDict, int key, T v) => baseDict.SetItem(key, v);
        static object DictRemove<T>(ImmutableDictionary<int, T> baseDict, int key) => baseDict.Remove(key);
        static int DictGetScan<T>(ImmutableDictionary<int, T> dict, int n, int m)
        {
            int sink = 0;
            for (int i = 0; i < m; i++) if (dict.TryGetValue(i % n, out _)) sink++;
            return sink;
        }
        static long DictIterate<T>(ImmutableDictionary<int, T> dict)
        {
            long sink = 0;
            foreach (var kv in dict) sink += kv.Key;
            return sink;
        }

        // ---- ImmutableSortedDictionary<int,T> ----
        static object SDictBuild<T>(T[] src, int n)
        {
            var b = ImmutableSortedDictionary.CreateBuilder<int, T>();
            for (int i = 0; i < n; i++) b[i] = src[i];
            return b.ToImmutable();
        }
        static object SDictSetOne<T>(ImmutableSortedDictionary<int, T> baseDict, int key, T v) => baseDict.SetItem(key, v);
        static object SDictRemove<T>(ImmutableSortedDictionary<int, T> baseDict, int key) => baseDict.Remove(key);
        static int SDictGetScan<T>(ImmutableSortedDictionary<int, T> dict, int n, int m)
        {
            int sink = 0;
            for (int i = 0; i < m; i++) if (dict.TryGetValue(i % n, out _)) sink++;
            return sink;
        }
        static long SDictIterate<T>(ImmutableSortedDictionary<int, T> dict)
        {
            long sink = 0;
            foreach (var kv in dict) sink += kv.Key;
            return sink;
        }

        // ---- ImmutableHashSet<T> ----
        static object HashSetBuild<T>(T[] src, int n)
        {
            var b = ImmutableHashSet.CreateBuilder<T>();
            for (int i = 0; i < n; i++) b.Add(src[i]);
            return b.ToImmutable();
        }
        static object HashSetAddOne<T>(ImmutableHashSet<T> baseSet, T extra) => baseSet.Add(extra);
        static object HashSetRemove<T>(ImmutableHashSet<T> baseSet, T v) => baseSet.Remove(v);
        static int HashSetContainsScan<T>(ImmutableHashSet<T> set, T[] src, int m)
        {
            int sink = 0;
            for (int i = 0; i < m; i++) if (set.Contains(src[i % src.Length])) sink++;
            return sink;
        }
        static long HashSetIterate<T>(ImmutableHashSet<T> set)
        {
            long sink = 0;
            foreach (var _ in set) sink++;
            return sink;
        }

        // ---- ImmutableSortedSet<T> ----
        static object SortedSetBuild<T>(T[] src, int n)
        {
            var b = ImmutableSortedSet.CreateBuilder<T>();
            for (int i = 0; i < n; i++) b.Add(src[i]);
            return b.ToImmutable();
        }
        static object SortedSetAddOne<T>(ImmutableSortedSet<T> baseSet, T extra) => baseSet.Add(extra);
        static object SortedSetRemove<T>(ImmutableSortedSet<T> baseSet, T v) => baseSet.Remove(v);
        static int SortedSetContainsScan<T>(ImmutableSortedSet<T> set, T[] src, int m)
        {
            int sink = 0;
            for (int i = 0; i < m; i++) if (set.Contains(src[i % src.Length])) sink++;
            return sink;
        }
        static long SortedSetIterate<T>(ImmutableSortedSet<T> set)
        {
            long sink = 0;
            foreach (var _ in set) sink++;
            return sink;
        }

        // ---- ImmutableQueue<T> (no builder; each Enqueue returns new instance) ----
        static object QueueBuild<T>(T[] src, int n)
        {
            var q = ImmutableQueue<T>.Empty;
            for (int i = 0; i < n; i++) q = q.Enqueue(src[i]); // producing chain
            return q;
        }
        static object QueueDrain<T>(ImmutableQueue<T> baseQueue)
        {
            var q = baseQueue;
            while (!q.IsEmpty) q = q.Dequeue(); // producing chain to empty
            return q;
        }
        static long QueuePeek<T>(ImmutableQueue<T> q)
        {
            long sink = 0;
            if (!q.IsEmpty) sink += q.Peek().GetHashCode();
            return sink;
        }
        static long QueueIterate<T>(ImmutableQueue<T> q)
        {
            long sink = 0;
            foreach (var _ in q) sink++;
            return sink;
        }

        // ---- ImmutableStack<T> (no builder; each Push returns new instance) ----
        static object StackBuild<T>(T[] src, int n)
        {
            var s = ImmutableStack<T>.Empty;
            for (int i = 0; i < n; i++) s = s.Push(src[i]); // producing chain
            return s;
        }
        static object StackDrain<T>(ImmutableStack<T> baseStack)
        {
            var s = baseStack;
            while (!s.IsEmpty) s = s.Pop(); // producing chain to empty
            return s;
        }
        static long StackPeek<T>(ImmutableStack<T> s)
        {
            long sink = 0;
            if (!s.IsEmpty) sink += s.Peek().GetHashCode();
            return sink;
        }
        static long StackIterate<T>(ImmutableStack<T> s)
        {
            long sink = 0;
            foreach (var _ in s) sink++;
            return sink;
        }

        static void Sink(long s) { if (s < 0) UnityEngine.Debug.Log(s); }

        // ====================================================================
        // ImmutableArray<T>
        //   增=Build(Builder) / 增单次=AddOne / 删=RemoveAt(single,producing)
        //   改=SetItem(single,producing) / 查=this[i]xSubOp + ContainsxLinearScan / 遍历
        // ====================================================================

        // ---- 增 Build ----
        [Test, Performance] public void ImmutableArray_Build_int_N1() { const int n = 1; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => ArrayBuild(s, n), n); }
        [Test, Performance] public void ImmutableArray_Build_int_N100() { const int n = 100; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => ArrayBuild(s, n), n); }
        [Test, Performance] public void ImmutableArray_Build_int_N10000() { const int n = 10000; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => ArrayBuild(s, n), n); }
        [Test, Performance] public void ImmutableArray_Build_val_N1() { const int n = 1; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => ArrayBuild(s, n), n); }
        [Test, Performance] public void ImmutableArray_Build_val_N100() { const int n = 100; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => ArrayBuild(s, n), n); }
        [Test, Performance] public void ImmutableArray_Build_val_N10000() { const int n = 10000; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => ArrayBuild(s, n), n); }
        [Test, Performance] public void ImmutableArray_Build_ref_N1() { const int n = 1; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => ArrayBuild(s, n), n); }
        [Test, Performance] public void ImmutableArray_Build_ref_N100() { const int n = 100; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => ArrayBuild(s, n), n); }
        [Test, Performance] public void ImmutableArray_Build_ref_N10000() { const int n = 10000; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => ArrayBuild(s, n), n); }

        // ---- 增单次 AddOne (one .Add on size-N -> new instance; full O(n) array copy) ----
        [Test, Performance] public void ImmutableArray_AddOne_int_N1() { const int n = 1; var b = ImmutableArray.Create(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ArrayAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableArray_AddOne_int_N100() { const int n = 100; var b = ImmutableArray.Create(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ArrayAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableArray_AddOne_int_N10000() { const int n = 10000; var b = ImmutableArray.Create(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ArrayAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableArray_AddOne_val_N1() { const int n = 1; var b = ImmutableArray.Create(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ArrayAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableArray_AddOne_val_N100() { const int n = 100; var b = ImmutableArray.Create(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ArrayAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableArray_AddOne_val_N10000() { const int n = 10000; var b = ImmutableArray.Create(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ArrayAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableArray_AddOne_ref_N1() { const int n = 1; var b = ImmutableArray.Create(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ArrayAddOne(b, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableArray_AddOne_ref_N100() { const int n = 100; var b = ImmutableArray.Create(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ArrayAddOne(b, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableArray_AddOne_ref_N10000() { const int n = 10000; var b = ImmutableArray.Create(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ArrayAddOne(b, new RefElem(999999)), n); }

        // ---- 删 RemoveAt (single -> new instance; O(n) array copy) ----
        [Test, Performance] public void ImmutableArray_RemoveAt_int_N1() { const int n = 1; var b = ImmutableArray.Create(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ArrayRemoveAt(b, 0), n); }
        [Test, Performance] public void ImmutableArray_RemoveAt_int_N100() { const int n = 100; var b = ImmutableArray.Create(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ArrayRemoveAt(b, n / 2), n); }
        [Test, Performance] public void ImmutableArray_RemoveAt_int_N10000() { const int n = 10000; var b = ImmutableArray.Create(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ArrayRemoveAt(b, n / 2), n); }
        [Test, Performance] public void ImmutableArray_RemoveAt_val_N1() { const int n = 1; var b = ImmutableArray.Create(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ArrayRemoveAt(b, 0), n); }
        [Test, Performance] public void ImmutableArray_RemoveAt_val_N100() { const int n = 100; var b = ImmutableArray.Create(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ArrayRemoveAt(b, n / 2), n); }
        [Test, Performance] public void ImmutableArray_RemoveAt_val_N10000() { const int n = 10000; var b = ImmutableArray.Create(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ArrayRemoveAt(b, n / 2), n); }
        [Test, Performance] public void ImmutableArray_RemoveAt_ref_N1() { const int n = 1; var b = ImmutableArray.Create(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ArrayRemoveAt(b, 0), n); }
        [Test, Performance] public void ImmutableArray_RemoveAt_ref_N100() { const int n = 100; var b = ImmutableArray.Create(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ArrayRemoveAt(b, n / 2), n); }
        [Test, Performance] public void ImmutableArray_RemoveAt_ref_N10000() { const int n = 10000; var b = ImmutableArray.Create(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ArrayRemoveAt(b, n / 2), n); }

        // ---- 改 SetItem (single -> new instance; O(n) array copy) ----
        [Test, Performance] public void ImmutableArray_SetItem_int_N1() { const int n = 1; var b = ImmutableArray.Create(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ArraySetItem(b, 0, 777), n); }
        [Test, Performance] public void ImmutableArray_SetItem_int_N100() { const int n = 100; var b = ImmutableArray.Create(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ArraySetItem(b, n / 2, 777), n); }
        [Test, Performance] public void ImmutableArray_SetItem_int_N10000() { const int n = 10000; var b = ImmutableArray.Create(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ArraySetItem(b, n / 2, 777), n); }
        [Test, Performance] public void ImmutableArray_SetItem_val_N1() { const int n = 1; var b = ImmutableArray.Create(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ArraySetItem(b, 0, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableArray_SetItem_val_N100() { const int n = 100; var b = ImmutableArray.Create(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ArraySetItem(b, n / 2, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableArray_SetItem_val_N10000() { const int n = 10000; var b = ImmutableArray.Create(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ArraySetItem(b, n / 2, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableArray_SetItem_ref_N1() { const int n = 1; var b = ImmutableArray.Create(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ArraySetItem(b, 0, new RefElem(777)), n); }
        [Test, Performance] public void ImmutableArray_SetItem_ref_N100() { const int n = 100; var b = ImmutableArray.Create(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ArraySetItem(b, n / 2, new RefElem(777)), n); }
        [Test, Performance] public void ImmutableArray_SetItem_ref_N10000() { const int n = 10000; var b = ImmutableArray.Create(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ArraySetItem(b, n / 2, new RefElem(777)), n); }

        // ---- 查 Index (this[i] x SubOp; in-place, GC ~= 0) ----
        [Test, Performance] public void ImmutableArray_Index_int_N1() { const int n = 1; var a = ImmutableArray.Create(Src.Ints(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIndexScan(a, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Index_int_N100() { const int n = 100; var a = ImmutableArray.Create(Src.Ints(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIndexScan(a, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Index_int_N10000() { const int n = 10000; var a = ImmutableArray.Create(Src.Ints(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIndexScan(a, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Index_val_N1() { const int n = 1; var a = ImmutableArray.Create(Src.Vals(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIndexScan(a, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Index_val_N100() { const int n = 100; var a = ImmutableArray.Create(Src.Vals(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIndexScan(a, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Index_val_N10000() { const int n = 10000; var a = ImmutableArray.Create(Src.Vals(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIndexScan(a, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Index_ref_N1() { const int n = 1; var a = ImmutableArray.Create(Src.Refs(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIndexScan(a, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Index_ref_N100() { const int n = 100; var a = ImmutableArray.Create(Src.Refs(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIndexScan(a, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Index_ref_N10000() { const int n = 10000; var a = ImmutableArray.Create(Src.Refs(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIndexScan(a, m), null, () => Sink(sink), n); }

        // ---- 查 Contains (linear scan x LinearScanCount; in-place, GC ~= 0) ----
        [Test, Performance] public void ImmutableArray_Contains_int_N1() { const int n = 1; var s = Src.Ints(n); var a = ImmutableArray.Create(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayContainsScan(a, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Contains_int_N100() { const int n = 100; var s = Src.Ints(n); var a = ImmutableArray.Create(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayContainsScan(a, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Contains_int_N10000() { const int n = 10000; var s = Src.Ints(n); var a = ImmutableArray.Create(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayContainsScan(a, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Contains_val_N1() { const int n = 1; var s = Src.Vals(n); var a = ImmutableArray.Create(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayContainsScan(a, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Contains_val_N100() { const int n = 100; var s = Src.Vals(n); var a = ImmutableArray.Create(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayContainsScan(a, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Contains_val_N10000() { const int n = 10000; var s = Src.Vals(n); var a = ImmutableArray.Create(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayContainsScan(a, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Contains_ref_N1() { const int n = 1; var s = Src.Refs(n); var a = ImmutableArray.Create(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayContainsScan(a, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Contains_ref_N100() { const int n = 100; var s = Src.Refs(n); var a = ImmutableArray.Create(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayContainsScan(a, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Contains_ref_N10000() { const int n = 10000; var s = Src.Refs(n); var a = ImmutableArray.Create(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayContainsScan(a, s, m), null, () => Sink(sink), n); }

        // ---- 遍历 Iterate (foreach full; in-place, GC ~= 0) ----
        [Test, Performance] public void ImmutableArray_Iterate_int_N1() { const int n = 1; var a = ImmutableArray.Create(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIterate(a), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Iterate_int_N100() { const int n = 100; var a = ImmutableArray.Create(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIterate(a), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Iterate_int_N10000() { const int n = 10000; var a = ImmutableArray.Create(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIterate(a), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Iterate_val_N1() { const int n = 1; var a = ImmutableArray.Create(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIterate(a), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Iterate_val_N100() { const int n = 100; var a = ImmutableArray.Create(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIterate(a), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Iterate_val_N10000() { const int n = 10000; var a = ImmutableArray.Create(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIterate(a), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Iterate_ref_N1() { const int n = 1; var a = ImmutableArray.Create(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIterate(a), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Iterate_ref_N100() { const int n = 100; var a = ImmutableArray.Create(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIterate(a), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableArray_Iterate_ref_N10000() { const int n = 10000; var a = ImmutableArray.Create(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ArrayIterate(a), null, () => Sink(sink), n); }

        // ====================================================================
        // ImmutableList<T> (AVL tree)
        //   增=Build(Builder) / 增单次=AddOne / 删=Remove(single) / 改=SetItem(single)
        //   查=this[i]xSubOp + ContainsxLinearScan / 遍历
        // ====================================================================

        // ---- 增 Build ----
        [Test, Performance] public void ImmutableList_Build_int_N1() { const int n = 1; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => ListBuild(s, n), n); }
        [Test, Performance] public void ImmutableList_Build_int_N100() { const int n = 100; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => ListBuild(s, n), n); }
        [Test, Performance] public void ImmutableList_Build_int_N10000() { const int n = 10000; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => ListBuild(s, n), n); }
        [Test, Performance] public void ImmutableList_Build_val_N1() { const int n = 1; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => ListBuild(s, n), n); }
        [Test, Performance] public void ImmutableList_Build_val_N100() { const int n = 100; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => ListBuild(s, n), n); }
        [Test, Performance] public void ImmutableList_Build_val_N10000() { const int n = 10000; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => ListBuild(s, n), n); }
        [Test, Performance] public void ImmutableList_Build_ref_N1() { const int n = 1; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => ListBuild(s, n), n); }
        [Test, Performance] public void ImmutableList_Build_ref_N100() { const int n = 100; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => ListBuild(s, n), n); }
        [Test, Performance] public void ImmutableList_Build_ref_N10000() { const int n = 10000; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => ListBuild(s, n), n); }

        // ---- 增单次 AddOne (O(log n) path-copy of AVL spine) ----
        [Test, Performance] public void ImmutableList_AddOne_int_N1() { const int n = 1; var b = ImmutableList.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ListAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableList_AddOne_int_N100() { const int n = 100; var b = ImmutableList.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ListAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableList_AddOne_int_N10000() { const int n = 10000; var b = ImmutableList.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ListAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableList_AddOne_val_N1() { const int n = 1; var b = ImmutableList.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ListAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableList_AddOne_val_N100() { const int n = 100; var b = ImmutableList.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ListAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableList_AddOne_val_N10000() { const int n = 10000; var b = ImmutableList.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ListAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableList_AddOne_ref_N1() { const int n = 1; var b = ImmutableList.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ListAddOne(b, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableList_AddOne_ref_N100() { const int n = 100; var b = ImmutableList.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ListAddOne(b, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableList_AddOne_ref_N10000() { const int n = 10000; var b = ImmutableList.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ListAddOne(b, new RefElem(999999)), n); }

        // ---- 删 Remove (single value -> new instance; O(log n) path-copy) ----
        [Test, Performance] public void ImmutableList_Remove_int_N1() { const int n = 1; var src = Src.Ints(n); var b = ImmutableList.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => ListRemove(b, src[0]), n); }
        [Test, Performance] public void ImmutableList_Remove_int_N100() { const int n = 100; var src = Src.Ints(n); var b = ImmutableList.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => ListRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableList_Remove_int_N10000() { const int n = 10000; var src = Src.Ints(n); var b = ImmutableList.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => ListRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableList_Remove_val_N1() { const int n = 1; var src = Src.Vals(n); var b = ImmutableList.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => ListRemove(b, src[0]), n); }
        [Test, Performance] public void ImmutableList_Remove_val_N100() { const int n = 100; var src = Src.Vals(n); var b = ImmutableList.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => ListRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableList_Remove_val_N10000() { const int n = 10000; var src = Src.Vals(n); var b = ImmutableList.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => ListRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableList_Remove_ref_N1() { const int n = 1; var src = Src.Refs(n); var b = ImmutableList.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => ListRemove(b, src[0]), n); }
        [Test, Performance] public void ImmutableList_Remove_ref_N100() { const int n = 100; var src = Src.Refs(n); var b = ImmutableList.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => ListRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableList_Remove_ref_N10000() { const int n = 10000; var src = Src.Refs(n); var b = ImmutableList.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => ListRemove(b, src[n / 2]), n); }

        // ---- 改 SetItem (single -> new instance; O(log n) path-copy) ----
        [Test, Performance] public void ImmutableList_SetItem_int_N1() { const int n = 1; var b = ImmutableList.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ListSetItem(b, 0, 777), n); }
        [Test, Performance] public void ImmutableList_SetItem_int_N100() { const int n = 100; var b = ImmutableList.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ListSetItem(b, n / 2, 777), n); }
        [Test, Performance] public void ImmutableList_SetItem_int_N10000() { const int n = 10000; var b = ImmutableList.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => ListSetItem(b, n / 2, 777), n); }
        [Test, Performance] public void ImmutableList_SetItem_val_N1() { const int n = 1; var b = ImmutableList.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ListSetItem(b, 0, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableList_SetItem_val_N100() { const int n = 100; var b = ImmutableList.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ListSetItem(b, n / 2, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableList_SetItem_val_N10000() { const int n = 10000; var b = ImmutableList.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => ListSetItem(b, n / 2, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableList_SetItem_ref_N1() { const int n = 1; var b = ImmutableList.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ListSetItem(b, 0, new RefElem(777)), n); }
        [Test, Performance] public void ImmutableList_SetItem_ref_N100() { const int n = 100; var b = ImmutableList.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ListSetItem(b, n / 2, new RefElem(777)), n); }
        [Test, Performance] public void ImmutableList_SetItem_ref_N10000() { const int n = 10000; var b = ImmutableList.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => ListSetItem(b, n / 2, new RefElem(777)), n); }

        // ---- 查 Index (this[i] O(log n) x SubOp; in-place, GC ~= 0) ----
        [Test, Performance] public void ImmutableList_Index_int_N1() { const int n = 1; var l = ImmutableList.CreateRange(Src.Ints(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIndexScan(l, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Index_int_N100() { const int n = 100; var l = ImmutableList.CreateRange(Src.Ints(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIndexScan(l, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Index_int_N10000() { const int n = 10000; var l = ImmutableList.CreateRange(Src.Ints(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIndexScan(l, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Index_val_N1() { const int n = 1; var l = ImmutableList.CreateRange(Src.Vals(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIndexScan(l, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Index_val_N100() { const int n = 100; var l = ImmutableList.CreateRange(Src.Vals(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIndexScan(l, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Index_val_N10000() { const int n = 10000; var l = ImmutableList.CreateRange(Src.Vals(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIndexScan(l, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Index_ref_N1() { const int n = 1; var l = ImmutableList.CreateRange(Src.Refs(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIndexScan(l, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Index_ref_N100() { const int n = 100; var l = ImmutableList.CreateRange(Src.Refs(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIndexScan(l, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Index_ref_N10000() { const int n = 10000; var l = ImmutableList.CreateRange(Src.Refs(n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIndexScan(l, m), null, () => Sink(sink), n); }

        // ---- 查 Contains (O(n) linear scan x LinearScanCount; in-place, GC ~= 0) ----
        [Test, Performance] public void ImmutableList_Contains_int_N1() { const int n = 1; var s = Src.Ints(n); var l = ImmutableList.CreateRange(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListContainsScan(l, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Contains_int_N100() { const int n = 100; var s = Src.Ints(n); var l = ImmutableList.CreateRange(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListContainsScan(l, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Contains_int_N10000() { const int n = 10000; var s = Src.Ints(n); var l = ImmutableList.CreateRange(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListContainsScan(l, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Contains_val_N1() { const int n = 1; var s = Src.Vals(n); var l = ImmutableList.CreateRange(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListContainsScan(l, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Contains_val_N100() { const int n = 100; var s = Src.Vals(n); var l = ImmutableList.CreateRange(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListContainsScan(l, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Contains_val_N10000() { const int n = 10000; var s = Src.Vals(n); var l = ImmutableList.CreateRange(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListContainsScan(l, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Contains_ref_N1() { const int n = 1; var s = Src.Refs(n); var l = ImmutableList.CreateRange(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListContainsScan(l, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Contains_ref_N100() { const int n = 100; var s = Src.Refs(n); var l = ImmutableList.CreateRange(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListContainsScan(l, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Contains_ref_N10000() { const int n = 10000; var s = Src.Refs(n); var l = ImmutableList.CreateRange(s); int m = Bench.LinearScanCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += ListContainsScan(l, s, m), null, () => Sink(sink), n); }

        // ---- 遍历 Iterate ----
        [Test, Performance] public void ImmutableList_Iterate_int_N1() { const int n = 1; var l = ImmutableList.CreateRange(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIterate(l), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Iterate_int_N100() { const int n = 100; var l = ImmutableList.CreateRange(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIterate(l), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Iterate_int_N10000() { const int n = 10000; var l = ImmutableList.CreateRange(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIterate(l), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Iterate_val_N1() { const int n = 1; var l = ImmutableList.CreateRange(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIterate(l), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Iterate_val_N100() { const int n = 100; var l = ImmutableList.CreateRange(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIterate(l), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Iterate_val_N10000() { const int n = 10000; var l = ImmutableList.CreateRange(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIterate(l), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Iterate_ref_N1() { const int n = 1; var l = ImmutableList.CreateRange(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIterate(l), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Iterate_ref_N100() { const int n = 100; var l = ImmutableList.CreateRange(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIterate(l), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableList_Iterate_ref_N10000() { const int n = 10000; var l = ImmutableList.CreateRange(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += ListIterate(l), null, () => Sink(sink), n); }

        // ====================================================================
        // ImmutableDictionary<int,T> (hash AVL tree); key=int, value=elem
        //   增=Build(Builder) / 增单次=SetItemOne(new key) / 删=Remove(single)
        //   改=SetItem(existing key) / 查=TryGetValuexSubOp / 遍历
        // ====================================================================

        // ---- 增 Build ----
        [Test, Performance] public void ImmutableDictionary_Build_int_N1() { const int n = 1; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => DictBuild(s, n), n); }
        [Test, Performance] public void ImmutableDictionary_Build_int_N100() { const int n = 100; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => DictBuild(s, n), n); }
        [Test, Performance] public void ImmutableDictionary_Build_int_N10000() { const int n = 10000; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => DictBuild(s, n), n); }
        [Test, Performance] public void ImmutableDictionary_Build_val_N1() { const int n = 1; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => DictBuild(s, n), n); }
        [Test, Performance] public void ImmutableDictionary_Build_val_N100() { const int n = 100; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => DictBuild(s, n), n); }
        [Test, Performance] public void ImmutableDictionary_Build_val_N10000() { const int n = 10000; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => DictBuild(s, n), n); }
        [Test, Performance] public void ImmutableDictionary_Build_ref_N1() { const int n = 1; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => DictBuild(s, n), n); }
        [Test, Performance] public void ImmutableDictionary_Build_ref_N100() { const int n = 100; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => DictBuild(s, n), n); }
        [Test, Performance] public void ImmutableDictionary_Build_ref_N10000() { const int n = 10000; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => DictBuild(s, n), n); }

        // ---- 增单次 SetItemOne (new key -> O(log n) path-copy) ----
        [Test, Performance] public void ImmutableDictionary_SetItemOne_int_N1() { const int n = 1; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n + 1, 999999), n); }
        [Test, Performance] public void ImmutableDictionary_SetItemOne_int_N100() { const int n = 100; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n + 1, 999999), n); }
        [Test, Performance] public void ImmutableDictionary_SetItemOne_int_N10000() { const int n = 10000; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n + 1, 999999), n); }
        [Test, Performance] public void ImmutableDictionary_SetItemOne_val_N1() { const int n = 1; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n + 1, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableDictionary_SetItemOne_val_N100() { const int n = 100; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n + 1, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableDictionary_SetItemOne_val_N10000() { const int n = 10000; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n + 1, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableDictionary_SetItemOne_ref_N1() { const int n = 1; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n + 1, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableDictionary_SetItemOne_ref_N100() { const int n = 100; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n + 1, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableDictionary_SetItemOne_ref_N10000() { const int n = 10000; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n + 1, new RefElem(999999)), n); }

        // ---- 删 Remove (single key -> O(log n) path-copy) ----
        [Test, Performance] public void ImmutableDictionary_Remove_int_N1() { const int n = 1; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => DictRemove(b, 0), n); }
        [Test, Performance] public void ImmutableDictionary_Remove_int_N100() { const int n = 100; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => DictRemove(b, n / 2), n); }
        [Test, Performance] public void ImmutableDictionary_Remove_int_N10000() { const int n = 10000; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => DictRemove(b, n / 2), n); }
        [Test, Performance] public void ImmutableDictionary_Remove_val_N1() { const int n = 1; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => DictRemove(b, 0), n); }
        [Test, Performance] public void ImmutableDictionary_Remove_val_N100() { const int n = 100; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => DictRemove(b, n / 2), n); }
        [Test, Performance] public void ImmutableDictionary_Remove_val_N10000() { const int n = 10000; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => DictRemove(b, n / 2), n); }
        [Test, Performance] public void ImmutableDictionary_Remove_ref_N1() { const int n = 1; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => DictRemove(b, 0), n); }
        [Test, Performance] public void ImmutableDictionary_Remove_ref_N100() { const int n = 100; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => DictRemove(b, n / 2), n); }
        [Test, Performance] public void ImmutableDictionary_Remove_ref_N10000() { const int n = 10000; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => DictRemove(b, n / 2), n); }

        // ---- 改 SetItem (existing key -> new instance; O(log n) path-copy) ----
        [Test, Performance] public void ImmutableDictionary_SetItem_int_N1() { const int n = 1; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, 0, 777), n); }
        [Test, Performance] public void ImmutableDictionary_SetItem_int_N100() { const int n = 100; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n / 2, 777), n); }
        [Test, Performance] public void ImmutableDictionary_SetItem_int_N10000() { const int n = 10000; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n / 2, 777), n); }
        [Test, Performance] public void ImmutableDictionary_SetItem_val_N1() { const int n = 1; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, 0, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableDictionary_SetItem_val_N100() { const int n = 100; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n / 2, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableDictionary_SetItem_val_N10000() { const int n = 10000; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n / 2, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableDictionary_SetItem_ref_N1() { const int n = 1; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, 0, new RefElem(777)), n); }
        [Test, Performance] public void ImmutableDictionary_SetItem_ref_N100() { const int n = 100; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n / 2, new RefElem(777)), n); }
        [Test, Performance] public void ImmutableDictionary_SetItem_ref_N10000() { const int n = 10000; var b = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => DictSetOne(b, n / 2, new RefElem(777)), n); }

        // ---- 查 Get (TryGetValue O(log n) x SubOp; in-place, GC ~= 0) ----
        [Test, Performance] public void ImmutableDictionary_Get_int_N1() { const int n = 1; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += DictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Get_int_N100() { const int n = 100; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += DictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Get_int_N10000() { const int n = 10000; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += DictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Get_val_N1() { const int n = 1; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += DictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Get_val_N100() { const int n = 100; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += DictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Get_val_N10000() { const int n = 10000; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += DictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Get_ref_N1() { const int n = 1; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += DictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Get_ref_N100() { const int n = 100; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += DictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Get_ref_N10000() { const int n = 10000; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += DictGetScan(d, n, m), null, () => Sink(sink), n); }

        // ---- 遍历 Iterate ----
        [Test, Performance] public void ImmutableDictionary_Iterate_int_N1() { const int n = 1; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += DictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Iterate_int_N100() { const int n = 100; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += DictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Iterate_int_N10000() { const int n = 10000; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Ints(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += DictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Iterate_val_N1() { const int n = 1; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += DictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Iterate_val_N100() { const int n = 100; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += DictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Iterate_val_N10000() { const int n = 10000; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Vals(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += DictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Iterate_ref_N1() { const int n = 1; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += DictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Iterate_ref_N100() { const int n = 100; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += DictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableDictionary_Iterate_ref_N10000() { const int n = 10000; var d = ImmutableDictionary.CreateRange(ToKvp(Src.Refs(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += DictIterate(d), null, () => Sink(sink), n); }

        // ====================================================================
        // ImmutableSortedDictionary<int,T> (sorted AVL tree); key=int, value=elem
        //   增=Build / 增单次=SetItemOne / 删=Remove / 改=SetItem / 查=TryGetValuexSubOp / 遍历
        // ====================================================================

        // ---- 增 Build ----
        [Test, Performance] public void ImmutableSortedDictionary_Build_int_N1() { const int n = 1; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => SDictBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Build_int_N100() { const int n = 100; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => SDictBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Build_int_N10000() { const int n = 10000; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => SDictBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Build_val_N1() { const int n = 1; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => SDictBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Build_val_N100() { const int n = 100; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => SDictBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Build_val_N10000() { const int n = 10000; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => SDictBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Build_ref_N1() { const int n = 1; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => SDictBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Build_ref_N100() { const int n = 100; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => SDictBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Build_ref_N10000() { const int n = 10000; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => SDictBuild(s, n), n); }

        // ---- 增单次 SetItemOne (new key) ----
        [Test, Performance] public void ImmutableSortedDictionary_SetItemOne_int_N1() { const int n = 1; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n + 1, 999999), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItemOne_int_N100() { const int n = 100; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n + 1, 999999), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItemOne_int_N10000() { const int n = 10000; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n + 1, 999999), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItemOne_val_N1() { const int n = 1; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n + 1, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItemOne_val_N100() { const int n = 100; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n + 1, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItemOne_val_N10000() { const int n = 10000; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n + 1, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItemOne_ref_N1() { const int n = 1; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n + 1, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItemOne_ref_N100() { const int n = 100; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n + 1, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItemOne_ref_N10000() { const int n = 10000; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n + 1, new RefElem(999999)), n); }

        // ---- 删 Remove (single key) ----
        [Test, Performance] public void ImmutableSortedDictionary_Remove_int_N1() { const int n = 1; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictRemove(b, 0), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Remove_int_N100() { const int n = 100; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictRemove(b, n / 2), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Remove_int_N10000() { const int n = 10000; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictRemove(b, n / 2), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Remove_val_N1() { const int n = 1; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictRemove(b, 0), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Remove_val_N100() { const int n = 100; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictRemove(b, n / 2), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Remove_val_N10000() { const int n = 10000; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictRemove(b, n / 2), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Remove_ref_N1() { const int n = 1; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictRemove(b, 0), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Remove_ref_N100() { const int n = 100; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictRemove(b, n / 2), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Remove_ref_N10000() { const int n = 10000; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictRemove(b, n / 2), n); }

        // ---- 改 SetItem (existing key) ----
        [Test, Performance] public void ImmutableSortedDictionary_SetItem_int_N1() { const int n = 1; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, 0, 777), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItem_int_N100() { const int n = 100; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n / 2, 777), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItem_int_N10000() { const int n = 10000; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n / 2, 777), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItem_val_N1() { const int n = 1; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, 0, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItem_val_N100() { const int n = 100; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n / 2, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItem_val_N10000() { const int n = 10000; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n / 2, new ValStruct(777)), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItem_ref_N1() { const int n = 1; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, 0, new RefElem(777)), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItem_ref_N100() { const int n = 100; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n / 2, new RefElem(777)), n); }
        [Test, Performance] public void ImmutableSortedDictionary_SetItem_ref_N10000() { const int n = 10000; var b = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); Bench.MeasureTimeAndGcProducing(() => SDictSetOne(b, n / 2, new RefElem(777)), n); }

        // ---- 查 Get (TryGetValue O(log n) x SubOp) ----
        [Test, Performance] public void ImmutableSortedDictionary_Get_int_N1() { const int n = 1; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Get_int_N100() { const int n = 100; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Get_int_N10000() { const int n = 10000; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Get_val_N1() { const int n = 1; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Get_val_N100() { const int n = 100; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Get_val_N10000() { const int n = 10000; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Get_ref_N1() { const int n = 1; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Get_ref_N100() { const int n = 100; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictGetScan(d, n, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Get_ref_N10000() { const int n = 10000; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictGetScan(d, n, m), null, () => Sink(sink), n); }

        // ---- 遍历 Iterate ----
        [Test, Performance] public void ImmutableSortedDictionary_Iterate_int_N1() { const int n = 1; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Iterate_int_N100() { const int n = 100; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Iterate_int_N10000() { const int n = 10000; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Ints(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Iterate_val_N1() { const int n = 1; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Iterate_val_N100() { const int n = 100; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Iterate_val_N10000() { const int n = 10000; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Vals(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Iterate_ref_N1() { const int n = 1; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Iterate_ref_N100() { const int n = 100; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictIterate(d), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedDictionary_Iterate_ref_N10000() { const int n = 10000; var d = ImmutableSortedDictionary.CreateRange(ToKvp(Src.Refs(n), n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SDictIterate(d), null, () => Sink(sink), n); }

        // ====================================================================
        // ImmutableHashSet<T> (hash AVL tree); element is key
        //   增=Build / 增单次=AddOne / 删=Remove / 查=ContainsxSubOp / 遍历
        // ====================================================================

        // ---- 增 Build ----
        [Test, Performance] public void ImmutableHashSet_Build_int_N1() { const int n = 1; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => HashSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableHashSet_Build_int_N100() { const int n = 100; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => HashSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableHashSet_Build_int_N10000() { const int n = 10000; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => HashSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableHashSet_Build_val_N1() { const int n = 1; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => HashSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableHashSet_Build_val_N100() { const int n = 100; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => HashSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableHashSet_Build_val_N10000() { const int n = 10000; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => HashSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableHashSet_Build_ref_N1() { const int n = 1; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => HashSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableHashSet_Build_ref_N100() { const int n = 100; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => HashSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableHashSet_Build_ref_N10000() { const int n = 10000; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => HashSetBuild(s, n), n); }

        // ---- 增单次 AddOne (new element) ----
        [Test, Performance] public void ImmutableHashSet_AddOne_int_N1() { const int n = 1; var b = ImmutableHashSet.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => HashSetAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableHashSet_AddOne_int_N100() { const int n = 100; var b = ImmutableHashSet.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => HashSetAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableHashSet_AddOne_int_N10000() { const int n = 10000; var b = ImmutableHashSet.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => HashSetAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableHashSet_AddOne_val_N1() { const int n = 1; var b = ImmutableHashSet.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => HashSetAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableHashSet_AddOne_val_N100() { const int n = 100; var b = ImmutableHashSet.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => HashSetAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableHashSet_AddOne_val_N10000() { const int n = 10000; var b = ImmutableHashSet.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => HashSetAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableHashSet_AddOne_ref_N1() { const int n = 1; var b = ImmutableHashSet.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => HashSetAddOne(b, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableHashSet_AddOne_ref_N100() { const int n = 100; var b = ImmutableHashSet.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => HashSetAddOne(b, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableHashSet_AddOne_ref_N10000() { const int n = 10000; var b = ImmutableHashSet.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => HashSetAddOne(b, new RefElem(999999)), n); }

        // ---- 删 Remove (single element) ----
        [Test, Performance] public void ImmutableHashSet_Remove_int_N1() { const int n = 1; var src = Src.Ints(n); var b = ImmutableHashSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => HashSetRemove(b, src[0]), n); }
        [Test, Performance] public void ImmutableHashSet_Remove_int_N100() { const int n = 100; var src = Src.Ints(n); var b = ImmutableHashSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => HashSetRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableHashSet_Remove_int_N10000() { const int n = 10000; var src = Src.Ints(n); var b = ImmutableHashSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => HashSetRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableHashSet_Remove_val_N1() { const int n = 1; var src = Src.Vals(n); var b = ImmutableHashSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => HashSetRemove(b, src[0]), n); }
        [Test, Performance] public void ImmutableHashSet_Remove_val_N100() { const int n = 100; var src = Src.Vals(n); var b = ImmutableHashSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => HashSetRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableHashSet_Remove_val_N10000() { const int n = 10000; var src = Src.Vals(n); var b = ImmutableHashSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => HashSetRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableHashSet_Remove_ref_N1() { const int n = 1; var src = Src.Refs(n); var b = ImmutableHashSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => HashSetRemove(b, src[0]), n); }
        [Test, Performance] public void ImmutableHashSet_Remove_ref_N100() { const int n = 100; var src = Src.Refs(n); var b = ImmutableHashSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => HashSetRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableHashSet_Remove_ref_N10000() { const int n = 10000; var src = Src.Refs(n); var b = ImmutableHashSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => HashSetRemove(b, src[n / 2]), n); }

        // ---- 查 Contains (O(log n) x SubOp) ----
        [Test, Performance] public void ImmutableHashSet_Contains_int_N1() { const int n = 1; var s = Src.Ints(n); var set = ImmutableHashSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Contains_int_N100() { const int n = 100; var s = Src.Ints(n); var set = ImmutableHashSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Contains_int_N10000() { const int n = 10000; var s = Src.Ints(n); var set = ImmutableHashSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Contains_val_N1() { const int n = 1; var s = Src.Vals(n); var set = ImmutableHashSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Contains_val_N100() { const int n = 100; var s = Src.Vals(n); var set = ImmutableHashSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Contains_val_N10000() { const int n = 10000; var s = Src.Vals(n); var set = ImmutableHashSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Contains_ref_N1() { const int n = 1; var s = Src.Refs(n); var set = ImmutableHashSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Contains_ref_N100() { const int n = 100; var s = Src.Refs(n); var set = ImmutableHashSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Contains_ref_N10000() { const int n = 10000; var s = Src.Refs(n); var set = ImmutableHashSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetContainsScan(set, s, m), null, () => Sink(sink), n); }

        // ---- 遍历 Iterate ----
        [Test, Performance] public void ImmutableHashSet_Iterate_int_N1() { const int n = 1; var set = ImmutableHashSet.CreateRange(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Iterate_int_N100() { const int n = 100; var set = ImmutableHashSet.CreateRange(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Iterate_int_N10000() { const int n = 10000; var set = ImmutableHashSet.CreateRange(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Iterate_val_N1() { const int n = 1; var set = ImmutableHashSet.CreateRange(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Iterate_val_N100() { const int n = 100; var set = ImmutableHashSet.CreateRange(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Iterate_val_N10000() { const int n = 10000; var set = ImmutableHashSet.CreateRange(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Iterate_ref_N1() { const int n = 1; var set = ImmutableHashSet.CreateRange(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Iterate_ref_N100() { const int n = 100; var set = ImmutableHashSet.CreateRange(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableHashSet_Iterate_ref_N10000() { const int n = 10000; var set = ImmutableHashSet.CreateRange(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += HashSetIterate(set), null, () => Sink(sink), n); }

        // ====================================================================
        // ImmutableSortedSet<T> (sorted AVL tree); element is key
        //   增=Build / 增单次=AddOne / 删=Remove / 查=ContainsxSubOp / 遍历
        // ====================================================================

        // ---- 增 Build ----
        [Test, Performance] public void ImmutableSortedSet_Build_int_N1() { const int n = 1; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => SortedSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedSet_Build_int_N100() { const int n = 100; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => SortedSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedSet_Build_int_N10000() { const int n = 10000; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => SortedSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedSet_Build_val_N1() { const int n = 1; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => SortedSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedSet_Build_val_N100() { const int n = 100; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => SortedSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedSet_Build_val_N10000() { const int n = 10000; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => SortedSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedSet_Build_ref_N1() { const int n = 1; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => SortedSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedSet_Build_ref_N100() { const int n = 100; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => SortedSetBuild(s, n), n); }
        [Test, Performance] public void ImmutableSortedSet_Build_ref_N10000() { const int n = 10000; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => SortedSetBuild(s, n), n); }

        // ---- 增单次 AddOne (new element) ----
        [Test, Performance] public void ImmutableSortedSet_AddOne_int_N1() { const int n = 1; var b = ImmutableSortedSet.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => SortedSetAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableSortedSet_AddOne_int_N100() { const int n = 100; var b = ImmutableSortedSet.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => SortedSetAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableSortedSet_AddOne_int_N10000() { const int n = 10000; var b = ImmutableSortedSet.CreateRange(Src.Ints(n)); Bench.MeasureTimeAndGcProducing(() => SortedSetAddOne(b, 999999), n); }
        [Test, Performance] public void ImmutableSortedSet_AddOne_val_N1() { const int n = 1; var b = ImmutableSortedSet.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => SortedSetAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableSortedSet_AddOne_val_N100() { const int n = 100; var b = ImmutableSortedSet.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => SortedSetAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableSortedSet_AddOne_val_N10000() { const int n = 10000; var b = ImmutableSortedSet.CreateRange(Src.Vals(n)); Bench.MeasureTimeAndGcProducing(() => SortedSetAddOne(b, new ValStruct(999999)), n); }
        [Test, Performance] public void ImmutableSortedSet_AddOne_ref_N1() { const int n = 1; var b = ImmutableSortedSet.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => SortedSetAddOne(b, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableSortedSet_AddOne_ref_N100() { const int n = 100; var b = ImmutableSortedSet.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => SortedSetAddOne(b, new RefElem(999999)), n); }
        [Test, Performance] public void ImmutableSortedSet_AddOne_ref_N10000() { const int n = 10000; var b = ImmutableSortedSet.CreateRange(Src.Refs(n)); Bench.MeasureTimeAndGcProducing(() => SortedSetAddOne(b, new RefElem(999999)), n); }

        // ---- 删 Remove (single element) ----
        [Test, Performance] public void ImmutableSortedSet_Remove_int_N1() { const int n = 1; var src = Src.Ints(n); var b = ImmutableSortedSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => SortedSetRemove(b, src[0]), n); }
        [Test, Performance] public void ImmutableSortedSet_Remove_int_N100() { const int n = 100; var src = Src.Ints(n); var b = ImmutableSortedSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => SortedSetRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableSortedSet_Remove_int_N10000() { const int n = 10000; var src = Src.Ints(n); var b = ImmutableSortedSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => SortedSetRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableSortedSet_Remove_val_N1() { const int n = 1; var src = Src.Vals(n); var b = ImmutableSortedSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => SortedSetRemove(b, src[0]), n); }
        [Test, Performance] public void ImmutableSortedSet_Remove_val_N100() { const int n = 100; var src = Src.Vals(n); var b = ImmutableSortedSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => SortedSetRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableSortedSet_Remove_val_N10000() { const int n = 10000; var src = Src.Vals(n); var b = ImmutableSortedSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => SortedSetRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableSortedSet_Remove_ref_N1() { const int n = 1; var src = Src.Refs(n); var b = ImmutableSortedSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => SortedSetRemove(b, src[0]), n); }
        [Test, Performance] public void ImmutableSortedSet_Remove_ref_N100() { const int n = 100; var src = Src.Refs(n); var b = ImmutableSortedSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => SortedSetRemove(b, src[n / 2]), n); }
        [Test, Performance] public void ImmutableSortedSet_Remove_ref_N10000() { const int n = 10000; var src = Src.Refs(n); var b = ImmutableSortedSet.CreateRange(src); Bench.MeasureTimeAndGcProducing(() => SortedSetRemove(b, src[n / 2]), n); }

        // ---- 查 Contains (O(log n) x SubOp) ----
        [Test, Performance] public void ImmutableSortedSet_Contains_int_N1() { const int n = 1; var s = Src.Ints(n); var set = ImmutableSortedSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Contains_int_N100() { const int n = 100; var s = Src.Ints(n); var set = ImmutableSortedSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Contains_int_N10000() { const int n = 10000; var s = Src.Ints(n); var set = ImmutableSortedSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Contains_val_N1() { const int n = 1; var s = Src.Vals(n); var set = ImmutableSortedSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Contains_val_N100() { const int n = 100; var s = Src.Vals(n); var set = ImmutableSortedSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Contains_val_N10000() { const int n = 10000; var s = Src.Vals(n); var set = ImmutableSortedSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Contains_ref_N1() { const int n = 1; var s = Src.Refs(n); var set = ImmutableSortedSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Contains_ref_N100() { const int n = 100; var s = Src.Refs(n); var set = ImmutableSortedSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetContainsScan(set, s, m), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Contains_ref_N10000() { const int n = 10000; var s = Src.Refs(n); var set = ImmutableSortedSet.CreateRange(s); int m = Bench.SubOpCount(n); int sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetContainsScan(set, s, m), null, () => Sink(sink), n); }

        // ---- 遍历 Iterate ----
        [Test, Performance] public void ImmutableSortedSet_Iterate_int_N1() { const int n = 1; var set = ImmutableSortedSet.CreateRange(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Iterate_int_N100() { const int n = 100; var set = ImmutableSortedSet.CreateRange(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Iterate_int_N10000() { const int n = 10000; var set = ImmutableSortedSet.CreateRange(Src.Ints(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Iterate_val_N1() { const int n = 1; var set = ImmutableSortedSet.CreateRange(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Iterate_val_N100() { const int n = 100; var set = ImmutableSortedSet.CreateRange(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Iterate_val_N10000() { const int n = 10000; var set = ImmutableSortedSet.CreateRange(Src.Vals(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Iterate_ref_N1() { const int n = 1; var set = ImmutableSortedSet.CreateRange(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Iterate_ref_N100() { const int n = 100; var set = ImmutableSortedSet.CreateRange(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetIterate(set), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableSortedSet_Iterate_ref_N10000() { const int n = 10000; var set = ImmutableSortedSet.CreateRange(Src.Refs(n)); long sink = 0; Bench.MeasureTimeAndGc(() => sink += SortedSetIterate(set), null, () => Sink(sink), n); }

        // ====================================================================
        // ImmutableQueue<T> (singly-linked persistent; no builder)
        //   增=Enqueue build (producing chain) / 删=Dequeue drain (producing chain)
        //   查=Peek / 遍历
        // ====================================================================

        // ---- 增 Build (Enqueue loop, each returns new instance) ----
        [Test, Performance] public void ImmutableQueue_Build_int_N1() { const int n = 1; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => QueueBuild(s, n), n); }
        [Test, Performance] public void ImmutableQueue_Build_int_N100() { const int n = 100; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => QueueBuild(s, n), n); }
        [Test, Performance] public void ImmutableQueue_Build_int_N10000() { const int n = 10000; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => QueueBuild(s, n), n); }
        [Test, Performance] public void ImmutableQueue_Build_val_N1() { const int n = 1; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => QueueBuild(s, n), n); }
        [Test, Performance] public void ImmutableQueue_Build_val_N100() { const int n = 100; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => QueueBuild(s, n), n); }
        [Test, Performance] public void ImmutableQueue_Build_val_N10000() { const int n = 10000; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => QueueBuild(s, n), n); }
        [Test, Performance] public void ImmutableQueue_Build_ref_N1() { const int n = 1; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => QueueBuild(s, n), n); }
        [Test, Performance] public void ImmutableQueue_Build_ref_N100() { const int n = 100; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => QueueBuild(s, n), n); }
        [Test, Performance] public void ImmutableQueue_Build_ref_N10000() { const int n = 10000; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => QueueBuild(s, n), n); }

        // ---- 删 Drain (Dequeue to empty, producing chain) ----
        [Test, Performance] public void ImmutableQueue_Drain_int_N1() { const int n = 1; var b = QueueOf(Src.Ints(n), n); Bench.MeasureTimeAndGcProducing(() => QueueDrain(b), n); }
        [Test, Performance] public void ImmutableQueue_Drain_int_N100() { const int n = 100; var b = QueueOf(Src.Ints(n), n); Bench.MeasureTimeAndGcProducing(() => QueueDrain(b), n); }
        [Test, Performance] public void ImmutableQueue_Drain_int_N10000() { const int n = 10000; var b = QueueOf(Src.Ints(n), n); Bench.MeasureTimeAndGcProducing(() => QueueDrain(b), n); }
        [Test, Performance] public void ImmutableQueue_Drain_val_N1() { const int n = 1; var b = QueueOf(Src.Vals(n), n); Bench.MeasureTimeAndGcProducing(() => QueueDrain(b), n); }
        [Test, Performance] public void ImmutableQueue_Drain_val_N100() { const int n = 100; var b = QueueOf(Src.Vals(n), n); Bench.MeasureTimeAndGcProducing(() => QueueDrain(b), n); }
        [Test, Performance] public void ImmutableQueue_Drain_val_N10000() { const int n = 10000; var b = QueueOf(Src.Vals(n), n); Bench.MeasureTimeAndGcProducing(() => QueueDrain(b), n); }
        [Test, Performance] public void ImmutableQueue_Drain_ref_N1() { const int n = 1; var b = QueueOf(Src.Refs(n), n); Bench.MeasureTimeAndGcProducing(() => QueueDrain(b), n); }
        [Test, Performance] public void ImmutableQueue_Drain_ref_N100() { const int n = 100; var b = QueueOf(Src.Refs(n), n); Bench.MeasureTimeAndGcProducing(() => QueueDrain(b), n); }
        [Test, Performance] public void ImmutableQueue_Drain_ref_N10000() { const int n = 10000; var b = QueueOf(Src.Refs(n), n); Bench.MeasureTimeAndGcProducing(() => QueueDrain(b), n); }

        // ---- 查 Peek (front element; in-place, GC ~= 0) ----
        [Test, Performance] public void ImmutableQueue_Peek_int_N1() { const int n = 1; var q = QueueOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueuePeek(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Peek_int_N100() { const int n = 100; var q = QueueOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueuePeek(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Peek_int_N10000() { const int n = 10000; var q = QueueOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueuePeek(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Peek_val_N1() { const int n = 1; var q = QueueOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueuePeek(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Peek_val_N100() { const int n = 100; var q = QueueOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueuePeek(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Peek_val_N10000() { const int n = 10000; var q = QueueOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueuePeek(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Peek_ref_N1() { const int n = 1; var q = QueueOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueuePeek(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Peek_ref_N100() { const int n = 100; var q = QueueOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueuePeek(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Peek_ref_N10000() { const int n = 10000; var q = QueueOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueuePeek(q), null, () => Sink(sink), n); }

        // ---- 遍历 Iterate ----
        [Test, Performance] public void ImmutableQueue_Iterate_int_N1() { const int n = 1; var q = QueueOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueueIterate(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Iterate_int_N100() { const int n = 100; var q = QueueOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueueIterate(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Iterate_int_N10000() { const int n = 10000; var q = QueueOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueueIterate(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Iterate_val_N1() { const int n = 1; var q = QueueOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueueIterate(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Iterate_val_N100() { const int n = 100; var q = QueueOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueueIterate(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Iterate_val_N10000() { const int n = 10000; var q = QueueOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueueIterate(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Iterate_ref_N1() { const int n = 1; var q = QueueOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueueIterate(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Iterate_ref_N100() { const int n = 100; var q = QueueOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueueIterate(q), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableQueue_Iterate_ref_N10000() { const int n = 10000; var q = QueueOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += QueueIterate(q), null, () => Sink(sink), n); }

        // ====================================================================
        // ImmutableStack<T> (singly-linked persistent; no builder)
        //   增=Push build (producing chain) / 删=Pop drain (producing chain)
        //   查=Peek / 遍历
        // ====================================================================

        // ---- 增 Build (Push loop, each returns new instance) ----
        [Test, Performance] public void ImmutableStack_Build_int_N1() { const int n = 1; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => StackBuild(s, n), n); }
        [Test, Performance] public void ImmutableStack_Build_int_N100() { const int n = 100; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => StackBuild(s, n), n); }
        [Test, Performance] public void ImmutableStack_Build_int_N10000() { const int n = 10000; var s = Src.Ints(n); Bench.MeasureTimeAndGcProducing(() => StackBuild(s, n), n); }
        [Test, Performance] public void ImmutableStack_Build_val_N1() { const int n = 1; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => StackBuild(s, n), n); }
        [Test, Performance] public void ImmutableStack_Build_val_N100() { const int n = 100; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => StackBuild(s, n), n); }
        [Test, Performance] public void ImmutableStack_Build_val_N10000() { const int n = 10000; var s = Src.Vals(n); Bench.MeasureTimeAndGcProducing(() => StackBuild(s, n), n); }
        [Test, Performance] public void ImmutableStack_Build_ref_N1() { const int n = 1; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => StackBuild(s, n), n); }
        [Test, Performance] public void ImmutableStack_Build_ref_N100() { const int n = 100; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => StackBuild(s, n), n); }
        [Test, Performance] public void ImmutableStack_Build_ref_N10000() { const int n = 10000; var s = Src.Refs(n); Bench.MeasureTimeAndGcProducing(() => StackBuild(s, n), n); }

        // ---- 删 Drain (Pop to empty, producing chain) ----
        [Test, Performance] public void ImmutableStack_Drain_int_N1() { const int n = 1; var b = StackOf(Src.Ints(n), n); Bench.MeasureTimeAndGcProducing(() => StackDrain(b), n); }
        [Test, Performance] public void ImmutableStack_Drain_int_N100() { const int n = 100; var b = StackOf(Src.Ints(n), n); Bench.MeasureTimeAndGcProducing(() => StackDrain(b), n); }
        [Test, Performance] public void ImmutableStack_Drain_int_N10000() { const int n = 10000; var b = StackOf(Src.Ints(n), n); Bench.MeasureTimeAndGcProducing(() => StackDrain(b), n); }
        [Test, Performance] public void ImmutableStack_Drain_val_N1() { const int n = 1; var b = StackOf(Src.Vals(n), n); Bench.MeasureTimeAndGcProducing(() => StackDrain(b), n); }
        [Test, Performance] public void ImmutableStack_Drain_val_N100() { const int n = 100; var b = StackOf(Src.Vals(n), n); Bench.MeasureTimeAndGcProducing(() => StackDrain(b), n); }
        [Test, Performance] public void ImmutableStack_Drain_val_N10000() { const int n = 10000; var b = StackOf(Src.Vals(n), n); Bench.MeasureTimeAndGcProducing(() => StackDrain(b), n); }
        [Test, Performance] public void ImmutableStack_Drain_ref_N1() { const int n = 1; var b = StackOf(Src.Refs(n), n); Bench.MeasureTimeAndGcProducing(() => StackDrain(b), n); }
        [Test, Performance] public void ImmutableStack_Drain_ref_N100() { const int n = 100; var b = StackOf(Src.Refs(n), n); Bench.MeasureTimeAndGcProducing(() => StackDrain(b), n); }
        [Test, Performance] public void ImmutableStack_Drain_ref_N10000() { const int n = 10000; var b = StackOf(Src.Refs(n), n); Bench.MeasureTimeAndGcProducing(() => StackDrain(b), n); }

        // ---- 查 Peek (top element; in-place, GC ~= 0) ----
        [Test, Performance] public void ImmutableStack_Peek_int_N1() { const int n = 1; var st = StackOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackPeek(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Peek_int_N100() { const int n = 100; var st = StackOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackPeek(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Peek_int_N10000() { const int n = 10000; var st = StackOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackPeek(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Peek_val_N1() { const int n = 1; var st = StackOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackPeek(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Peek_val_N100() { const int n = 100; var st = StackOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackPeek(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Peek_val_N10000() { const int n = 10000; var st = StackOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackPeek(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Peek_ref_N1() { const int n = 1; var st = StackOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackPeek(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Peek_ref_N100() { const int n = 100; var st = StackOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackPeek(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Peek_ref_N10000() { const int n = 10000; var st = StackOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackPeek(st), null, () => Sink(sink), n); }

        // ---- 遍历 Iterate ----
        [Test, Performance] public void ImmutableStack_Iterate_int_N1() { const int n = 1; var st = StackOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackIterate(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Iterate_int_N100() { const int n = 100; var st = StackOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackIterate(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Iterate_int_N10000() { const int n = 10000; var st = StackOf(Src.Ints(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackIterate(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Iterate_val_N1() { const int n = 1; var st = StackOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackIterate(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Iterate_val_N100() { const int n = 100; var st = StackOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackIterate(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Iterate_val_N10000() { const int n = 10000; var st = StackOf(Src.Vals(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackIterate(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Iterate_ref_N1() { const int n = 1; var st = StackOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackIterate(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Iterate_ref_N100() { const int n = 100; var st = StackOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackIterate(st), null, () => Sink(sink), n); }
        [Test, Performance] public void ImmutableStack_Iterate_ref_N10000() { const int n = 10000; var st = StackOf(Src.Refs(n), n); long sink = 0; Bench.MeasureTimeAndGc(() => sink += StackIterate(st), null, () => Sink(sink), n); }

        // ====================================================================
        // Helpers: prebuilt instances (NOT measured) for read/drain ops.
        // ====================================================================

        static System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int, T>> ToKvp<T>(T[] src, int n)
        {
            var list = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<int, T>>(n);
            for (int i = 0; i < n; i++) list.Add(new System.Collections.Generic.KeyValuePair<int, T>(i, src[i]));
            return list;
        }

        static ImmutableQueue<T> QueueOf<T>(T[] src, int n)
        {
            var q = ImmutableQueue<T>.Empty;
            for (int i = 0; i < n; i++) q = q.Enqueue(src[i]);
            return q;
        }

        static ImmutableStack<T> StackOf<T>(T[] src, int n)
        {
            var s = ImmutableStack<T>.Empty;
            for (int i = 0; i < n; i++) s = s.Push(src[i]);
            return s;
        }
    }
}
