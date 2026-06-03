using System.Collections.Generic;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace CollectionBenchmarks
{
    // ============================================================================
    // Generic core family (SPEC §5.A). Category=Generic.
    //
    // Coverage: every applicable op × {int, ValStruct, RefElem} × N ∈ {1,100,10000}.
    // Structure: one generic private core per (Collection, Op); thin [Test] wrappers
    // per element type drive it. Size sweep via [Values(1,100,10000)] int n.
    //
    // Each test emits Time(ms) + GC Allocated(Bytes).
    //   BUILD ops (增)             -> Bench.MeasureTimeAndGcProducing
    //   IN-PLACE ops (查/改/遍历)  -> Bench.MeasureTimeAndGc
    //   DESTRUCTIVE ops (删)       -> Bench.MeasureTimeAndGc with setup-rebuild
    //
    // Key convention: dict-like key=int value=elem; set/list-like store elem.
    // ============================================================================

    [Category("Generic")]
    public class GenericBenchmarks
    {
        // =======================================================================
        // List<T>  — index/linear collection
        // =======================================================================

        // ---- List Add (append build to N): backing-array growth GC > 0 ----
        static void ListAddCore<T>(T[] src, int n)
        {
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var list = new List<T>();          // default cap -> grows
                    for (int i = 0; i < n; i++) list.Add(src[i]);
                    return list;
                },
                n: n);
        }

        [Test, Performance]
        public void List_Add_int([Values(1, 100, 10000)] int n) => ListAddCore(Src.Ints(n), n);
        [Test, Performance]
        public void List_Add_val([Values(1, 100, 10000)] int n) => ListAddCore(Src.Vals(n), n);
        [Test, Performance]
        public void List_Add_ref([Values(1, 100, 10000)] int n) => ListAddCore(Src.Refs(n), n);
        [Test, Performance]
        public void List_Add_bool([Values(1, 100, 10000)] int n) => ListAddCore(Src.Bools(n), n);

        // ---- List Insert(0) (head-insert build to N): O(n) shift per insert ----
        static void ListInsertHeadCore<T>(T[] src, int n)
        {
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var list = new List<T>();
                    for (int i = 0; i < n; i++) list.Insert(0, src[i]);
                    return list;
                },
                n: n);
        }

        [Test, Performance]
        public void List_InsertHead_int([Values(1, 100, 10000)] int n) => ListInsertHeadCore(Src.Ints(n), n);
        [Test, Performance]
        public void List_InsertHead_val([Values(1, 100, 10000)] int n) => ListInsertHeadCore(Src.Vals(n), n);
        [Test, Performance]
        public void List_InsertHead_ref([Values(1, 100, 10000)] int n) => ListInsertHeadCore(Src.Refs(n), n);
        [Test, Performance]
        public void List_InsertHead_bool([Values(1, 100, 10000)] int n) => ListInsertHeadCore(Src.Bools(n), n);

        // ---- List RemoveAt(last) (drain to empty): destructive, rebuild in setup ----
        static void ListRemoveCore<T>(T[] src, int n)
        {
            List<T> list = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = list.Count - 1; i >= 0; i--) list.RemoveAt(i);
                },
                setup: () => { list = new List<T>(src); },
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void List_Remove_int([Values(1, 100, 10000)] int n) => ListRemoveCore(Src.Ints(n), n);
        [Test, Performance]
        public void List_Remove_val([Values(1, 100, 10000)] int n) => ListRemoveCore(Src.Vals(n), n);
        [Test, Performance]
        public void List_Remove_ref([Values(1, 100, 10000)] int n) => ListRemoveCore(Src.Refs(n), n);
        [Test, Performance]
        public void List_Remove_bool([Values(1, 100, 10000)] int n) => ListRemoveCore(Src.Bools(n), n);

        // ---- List this[i]=v (indexer set × M): O(1) write, GC ~= 0 ----
        static void ListSetCore<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            var list = new List<T>(src);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) list[i] = src[i];
                },
                setup: null, cleanup: null, n: n);
        }

        [Test, Performance]
        public void List_Set_int([Values(1, 100, 10000)] int n) => ListSetCore(Src.Ints(n), n);
        [Test, Performance]
        public void List_Set_val([Values(1, 100, 10000)] int n) => ListSetCore(Src.Vals(n), n);
        [Test, Performance]
        public void List_Set_ref([Values(1, 100, 10000)] int n) => ListSetCore(Src.Refs(n), n);
        [Test, Performance]
        public void List_Set_bool([Values(1, 100, 10000)] int n) => ListSetCore(Src.Bools(n), n);

        // ---- List this[i] (indexer get × M): O(1) read, GC ~= 0 ----
        static void ListGetCore<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            var list = new List<T>(src);
            var sink = new T[1];
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink[0] = list[i];
                },
                setup: null,
                cleanup: () => { if (sink == null) UnityEngine.Debug.Log("x"); },
                n: n);
        }

        [Test, Performance]
        public void List_Get_int([Values(1, 100, 10000)] int n) => ListGetCore(Src.Ints(n), n);
        [Test, Performance]
        public void List_Get_val([Values(1, 100, 10000)] int n) => ListGetCore(Src.Vals(n), n);
        [Test, Performance]
        public void List_Get_ref([Values(1, 100, 10000)] int n) => ListGetCore(Src.Refs(n), n);
        [Test, Performance]
        public void List_Get_bool([Values(1, 100, 10000)] int n) => ListGetCore(Src.Bools(n), n);

        // ---- List Contains (linear O(n) scan × LinearScanCount): GC ~= 0 ----
        static void ListContainsCore<T>(T[] src, int n)
        {
            int m = Bench.LinearScanCount(n);
            var list = new List<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) if (list.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void List_Contains_int([Values(1, 100, 10000)] int n) => ListContainsCore(Src.Ints(n), n);
        [Test, Performance]
        public void List_Contains_val([Values(1, 100, 10000)] int n) => ListContainsCore(Src.Vals(n), n);
        [Test, Performance]
        public void List_Contains_ref([Values(1, 100, 10000)] int n) => ListContainsCore(Src.Refs(n), n);
        [Test, Performance]
        public void List_Contains_bool([Values(1, 100, 10000)] int n) => ListContainsCore(Src.Bools(n), n);

        // ---- List Iterate (foreach full): GC ~= 0 ----
        static void ListIterateCore<T>(T[] src, int n)
        {
            var list = new List<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var v in list) { if (v != null) sink++; }
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void List_Iterate_int([Values(1, 100, 10000)] int n) => ListIterateCore(Src.Ints(n), n);
        [Test, Performance]
        public void List_Iterate_val([Values(1, 100, 10000)] int n) => ListIterateCore(Src.Vals(n), n);
        [Test, Performance]
        public void List_Iterate_ref([Values(1, 100, 10000)] int n) => ListIterateCore(Src.Refs(n), n);
        [Test, Performance]
        public void List_Iterate_bool([Values(1, 100, 10000)] int n) => ListIterateCore(Src.Bools(n), n);

        // =======================================================================
        // Dictionary<int,T>  — hash map (key=int, value=elem)
        // =======================================================================

        // ---- Dictionary Add (build to N): bucket/entry array growth GC > 0 ----
        static void DictAddCore<T>(int[] keys, T[] vals, int n)
        {
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var d = new Dictionary<int, T>();
                    for (int i = 0; i < n; i++) d.Add(keys[i], vals[i]);
                    return d;
                },
                n: n);
        }

        [Test, Performance]
        public void Dictionary_Add_int([Values(1, 100, 10000)] int n) => DictAddCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void Dictionary_Add_val([Values(1, 100, 10000)] int n) => DictAddCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void Dictionary_Add_ref([Values(1, 100, 10000)] int n) => DictAddCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void Dictionary_Add_bool([Values(1, 100, 10000)] int n) => DictAddCore(Src.Ints(n), Src.Bools(n), n);

        // ---- Dictionary Remove(k) × M (destructive, rebuild in setup) ----
        static void DictRemoveCore<T>(int[] keys, T[] vals, int n)
        {
            int m = Bench.SubOpCount(n);
            Dictionary<int, T> d = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) d.Remove(keys[i]);
                },
                setup: () =>
                {
                    d = new Dictionary<int, T>(n);
                    for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
                },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void Dictionary_Remove_int([Values(1, 100, 10000)] int n) => DictRemoveCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void Dictionary_Remove_val([Values(1, 100, 10000)] int n) => DictRemoveCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void Dictionary_Remove_ref([Values(1, 100, 10000)] int n) => DictRemoveCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void Dictionary_Remove_bool([Values(1, 100, 10000)] int n) => DictRemoveCore(Src.Ints(n), Src.Bools(n), n);

        // ---- Dictionary this[k]=v (indexer set × M): O(1) avg, GC ~= 0 ----
        static void DictSetCore<T>(int[] keys, T[] vals, int n)
        {
            int m = Bench.SubOpCount(n);
            var d = new Dictionary<int, T>(n);
            for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) d[keys[i]] = vals[i];
                },
                setup: null, cleanup: null, n: n);
        }

        [Test, Performance]
        public void Dictionary_Set_int([Values(1, 100, 10000)] int n) => DictSetCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void Dictionary_Set_val([Values(1, 100, 10000)] int n) => DictSetCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void Dictionary_Set_ref([Values(1, 100, 10000)] int n) => DictSetCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void Dictionary_Set_bool([Values(1, 100, 10000)] int n) => DictSetCore(Src.Ints(n), Src.Bools(n), n);

        // ---- Dictionary TryGetValue × M: O(1) avg, GC ~= 0 ----
        static void DictGetCore<T>(int[] keys, T[] vals, int n)
        {
            int m = Bench.SubOpCount(n);
            var d = new Dictionary<int, T>(n);
            for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) if (d.TryGetValue(keys[i], out var v) && v != null) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Dictionary_Get_int([Values(1, 100, 10000)] int n) => DictGetCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void Dictionary_Get_val([Values(1, 100, 10000)] int n) => DictGetCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void Dictionary_Get_ref([Values(1, 100, 10000)] int n) => DictGetCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void Dictionary_Get_bool([Values(1, 100, 10000)] int n) => DictGetCore(Src.Ints(n), Src.Bools(n), n);

        // ---- Dictionary Iterate (foreach KVP): GC ~= 0 ----
        static void DictIterateCore<T>(int[] keys, T[] vals, int n)
        {
            var d = new Dictionary<int, T>(n);
            for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var kv in d) { if (kv.Key >= 0) sink++; }
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Dictionary_Iterate_int([Values(1, 100, 10000)] int n) => DictIterateCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void Dictionary_Iterate_val([Values(1, 100, 10000)] int n) => DictIterateCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void Dictionary_Iterate_ref([Values(1, 100, 10000)] int n) => DictIterateCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void Dictionary_Iterate_bool([Values(1, 100, 10000)] int n) => DictIterateCore(Src.Ints(n), Src.Bools(n), n);

        // =======================================================================
        // HashSet<T>  — hash set (element is key)
        // =======================================================================

        // ---- HashSet Add (build to N): bucket/slot array growth GC > 0 ----
        static void HashSetAddCore<T>(T[] src, int n)
        {
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var s = new HashSet<T>();
                    for (int i = 0; i < n; i++) s.Add(src[i]);
                    return s;
                },
                n: n);
        }

        [Test, Performance]
        public void HashSet_Add_int([Values(1, 100, 10000)] int n) => HashSetAddCore(Src.Ints(n), n);
        [Test, Performance]
        public void HashSet_Add_val([Values(1, 100, 10000)] int n) => HashSetAddCore(Src.Vals(n), n);
        [Test, Performance]
        public void HashSet_Add_ref([Values(1, 100, 10000)] int n) => HashSetAddCore(Src.Refs(n), n);

        // ---- HashSet Remove × M (destructive, rebuild in setup) ----
        static void HashSetRemoveCore<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            HashSet<T> s = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) s.Remove(src[i]);
                },
                setup: () => { s = new HashSet<T>(src); },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void HashSet_Remove_int([Values(1, 100, 10000)] int n) => HashSetRemoveCore(Src.Ints(n), n);
        [Test, Performance]
        public void HashSet_Remove_val([Values(1, 100, 10000)] int n) => HashSetRemoveCore(Src.Vals(n), n);
        [Test, Performance]
        public void HashSet_Remove_ref([Values(1, 100, 10000)] int n) => HashSetRemoveCore(Src.Refs(n), n);

        // ---- HashSet Contains × M: O(1) avg, GC ~= 0 ----
        static void HashSetContainsCore<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            var s = new HashSet<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) if (s.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void HashSet_Contains_int([Values(1, 100, 10000)] int n) => HashSetContainsCore(Src.Ints(n), n);
        [Test, Performance]
        public void HashSet_Contains_val([Values(1, 100, 10000)] int n) => HashSetContainsCore(Src.Vals(n), n);
        [Test, Performance]
        public void HashSet_Contains_ref([Values(1, 100, 10000)] int n) => HashSetContainsCore(Src.Refs(n), n);

        // ---- HashSet Iterate (foreach): GC ~= 0 ----
        static void HashSetIterateCore<T>(T[] src, int n)
        {
            var s = new HashSet<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var v in s) { if (v != null) sink++; }
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void HashSet_Iterate_int([Values(1, 100, 10000)] int n) => HashSetIterateCore(Src.Ints(n), n);
        [Test, Performance]
        public void HashSet_Iterate_val([Values(1, 100, 10000)] int n) => HashSetIterateCore(Src.Vals(n), n);
        [Test, Performance]
        public void HashSet_Iterate_ref([Values(1, 100, 10000)] int n) => HashSetIterateCore(Src.Refs(n), n);

        // =======================================================================
        // SortedDictionary<int,T>  — red-black tree map (key=int, value=elem)
        // =======================================================================

        // ---- SortedDictionary Add (build to N): O(n log n), tree node GC > 0 ----
        static void SortedDictAddCore<T>(int[] keys, T[] vals, int n)
        {
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var d = new SortedDictionary<int, T>();
                    for (int i = 0; i < n; i++) d.Add(keys[i], vals[i]);
                    return d;
                },
                n: n);
        }

        [Test, Performance]
        public void SortedDictionary_Add_int([Values(1, 100, 10000)] int n) => SortedDictAddCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void SortedDictionary_Add_val([Values(1, 100, 10000)] int n) => SortedDictAddCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void SortedDictionary_Add_ref([Values(1, 100, 10000)] int n) => SortedDictAddCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void SortedDictionary_Add_bool([Values(1, 100, 10000)] int n) => SortedDictAddCore(Src.Ints(n), Src.Bools(n), n);

        // ---- SortedDictionary Remove(k) × M (destructive, rebuild in setup) ----
        static void SortedDictRemoveCore<T>(int[] keys, T[] vals, int n)
        {
            int m = Bench.SubOpCount(n);
            SortedDictionary<int, T> d = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) d.Remove(keys[i]);
                },
                setup: () =>
                {
                    d = new SortedDictionary<int, T>();
                    for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
                },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void SortedDictionary_Remove_int([Values(1, 100, 10000)] int n) => SortedDictRemoveCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void SortedDictionary_Remove_val([Values(1, 100, 10000)] int n) => SortedDictRemoveCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void SortedDictionary_Remove_ref([Values(1, 100, 10000)] int n) => SortedDictRemoveCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void SortedDictionary_Remove_bool([Values(1, 100, 10000)] int n) => SortedDictRemoveCore(Src.Ints(n), Src.Bools(n), n);

        // ---- SortedDictionary this[k]=v (indexer set × M): O(log n), GC ~= 0 ----
        static void SortedDictSetCore<T>(int[] keys, T[] vals, int n)
        {
            int m = Bench.SubOpCount(n);
            var d = new SortedDictionary<int, T>();
            for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) d[keys[i]] = vals[i];
                },
                setup: null, cleanup: null, n: n);
        }

        [Test, Performance]
        public void SortedDictionary_Set_int([Values(1, 100, 10000)] int n) => SortedDictSetCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void SortedDictionary_Set_val([Values(1, 100, 10000)] int n) => SortedDictSetCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void SortedDictionary_Set_ref([Values(1, 100, 10000)] int n) => SortedDictSetCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void SortedDictionary_Set_bool([Values(1, 100, 10000)] int n) => SortedDictSetCore(Src.Ints(n), Src.Bools(n), n);

        // ---- SortedDictionary TryGetValue × M: O(log n), GC ~= 0 ----
        static void SortedDictGetCore<T>(int[] keys, T[] vals, int n)
        {
            int m = Bench.SubOpCount(n);
            var d = new SortedDictionary<int, T>();
            for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) if (d.TryGetValue(keys[i], out var v) && v != null) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void SortedDictionary_Get_int([Values(1, 100, 10000)] int n) => SortedDictGetCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void SortedDictionary_Get_val([Values(1, 100, 10000)] int n) => SortedDictGetCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void SortedDictionary_Get_ref([Values(1, 100, 10000)] int n) => SortedDictGetCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void SortedDictionary_Get_bool([Values(1, 100, 10000)] int n) => SortedDictGetCore(Src.Ints(n), Src.Bools(n), n);

        // ---- SortedDictionary Iterate (foreach KVP, sorted): GC ~= 0 ----
        static void SortedDictIterateCore<T>(int[] keys, T[] vals, int n)
        {
            var d = new SortedDictionary<int, T>();
            for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var kv in d) { if (kv.Key >= 0) sink++; }
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void SortedDictionary_Iterate_int([Values(1, 100, 10000)] int n) => SortedDictIterateCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void SortedDictionary_Iterate_val([Values(1, 100, 10000)] int n) => SortedDictIterateCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void SortedDictionary_Iterate_ref([Values(1, 100, 10000)] int n) => SortedDictIterateCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void SortedDictionary_Iterate_bool([Values(1, 100, 10000)] int n) => SortedDictIterateCore(Src.Ints(n), Src.Bools(n), n);

        // =======================================================================
        // SortedSet<T>  — red-black tree set (element is key)
        // =======================================================================

        // ---- SortedSet Add (build to N): O(n log n), tree node GC > 0 ----
        static void SortedSetAddCore<T>(T[] src, int n)
        {
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var s = new SortedSet<T>();
                    for (int i = 0; i < n; i++) s.Add(src[i]);
                    return s;
                },
                n: n);
        }

        [Test, Performance]
        public void SortedSet_Add_int([Values(1, 100, 10000)] int n) => SortedSetAddCore(Src.Ints(n), n);
        [Test, Performance]
        public void SortedSet_Add_val([Values(1, 100, 10000)] int n) => SortedSetAddCore(Src.Vals(n), n);
        [Test, Performance]
        public void SortedSet_Add_ref([Values(1, 100, 10000)] int n) => SortedSetAddCore(Src.Refs(n), n);

        // ---- SortedSet Remove × M (destructive, rebuild in setup) ----
        static void SortedSetRemoveCore<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            SortedSet<T> s = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) s.Remove(src[i]);
                },
                setup: () => { s = new SortedSet<T>(src); },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void SortedSet_Remove_int([Values(1, 100, 10000)] int n) => SortedSetRemoveCore(Src.Ints(n), n);
        [Test, Performance]
        public void SortedSet_Remove_val([Values(1, 100, 10000)] int n) => SortedSetRemoveCore(Src.Vals(n), n);
        [Test, Performance]
        public void SortedSet_Remove_ref([Values(1, 100, 10000)] int n) => SortedSetRemoveCore(Src.Refs(n), n);

        // ---- SortedSet Contains × M: O(log n), GC ~= 0 ----
        static void SortedSetContainsCore<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            var s = new SortedSet<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) if (s.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void SortedSet_Contains_int([Values(1, 100, 10000)] int n) => SortedSetContainsCore(Src.Ints(n), n);
        [Test, Performance]
        public void SortedSet_Contains_val([Values(1, 100, 10000)] int n) => SortedSetContainsCore(Src.Vals(n), n);
        [Test, Performance]
        public void SortedSet_Contains_ref([Values(1, 100, 10000)] int n) => SortedSetContainsCore(Src.Refs(n), n);

        // ---- SortedSet Iterate (foreach, sorted): GC ~= 0 ----
        static void SortedSetIterateCore<T>(T[] src, int n)
        {
            var s = new SortedSet<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var v in s) { if (v != null) sink++; }
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void SortedSet_Iterate_int([Values(1, 100, 10000)] int n) => SortedSetIterateCore(Src.Ints(n), n);
        [Test, Performance]
        public void SortedSet_Iterate_val([Values(1, 100, 10000)] int n) => SortedSetIterateCore(Src.Vals(n), n);
        [Test, Performance]
        public void SortedSet_Iterate_ref([Values(1, 100, 10000)] int n) => SortedSetIterateCore(Src.Refs(n), n);

        // =======================================================================
        // SortedList<int,T>  — sorted array-backed map (key=int, value=elem)
        // =======================================================================

        // ---- SortedList Add (sorted-key append build to N): O(n) shift worst, here keys ascending -> O(1) tail ----
        static void SortedListAddCore<T>(int[] keys, T[] vals, int n)
        {
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var d = new SortedList<int, T>();
                    for (int i = 0; i < n; i++) d.Add(keys[i], vals[i]); // keys[i]=i ascending
                    return d;
                },
                n: n);
        }

        [Test, Performance]
        public void SortedList_Add_int([Values(1, 100, 10000)] int n) => SortedListAddCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void SortedList_Add_val([Values(1, 100, 10000)] int n) => SortedListAddCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void SortedList_Add_ref([Values(1, 100, 10000)] int n) => SortedListAddCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void SortedList_Add_bool([Values(1, 100, 10000)] int n) => SortedListAddCore(Src.Ints(n), Src.Bools(n), n);

        // ---- SortedList Remove(k) × M (destructive, rebuild in setup) ----
        static void SortedListRemoveCore<T>(int[] keys, T[] vals, int n)
        {
            int m = Bench.SubOpCount(n);
            SortedList<int, T> d = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) d.Remove(keys[i]);
                },
                setup: () =>
                {
                    d = new SortedList<int, T>(n);
                    for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
                },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void SortedList_Remove_int([Values(1, 100, 10000)] int n) => SortedListRemoveCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void SortedList_Remove_val([Values(1, 100, 10000)] int n) => SortedListRemoveCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void SortedList_Remove_ref([Values(1, 100, 10000)] int n) => SortedListRemoveCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void SortedList_Remove_bool([Values(1, 100, 10000)] int n) => SortedListRemoveCore(Src.Ints(n), Src.Bools(n), n);

        // ---- SortedList this[k]=v (indexer set × M, existing keys): O(log n), GC ~= 0 ----
        static void SortedListSetCore<T>(int[] keys, T[] vals, int n)
        {
            int m = Bench.SubOpCount(n);
            var d = new SortedList<int, T>(n);
            for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) d[keys[i]] = vals[i];
                },
                setup: null, cleanup: null, n: n);
        }

        [Test, Performance]
        public void SortedList_Set_int([Values(1, 100, 10000)] int n) => SortedListSetCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void SortedList_Set_val([Values(1, 100, 10000)] int n) => SortedListSetCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void SortedList_Set_ref([Values(1, 100, 10000)] int n) => SortedListSetCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void SortedList_Set_bool([Values(1, 100, 10000)] int n) => SortedListSetCore(Src.Ints(n), Src.Bools(n), n);

        // ---- SortedList TryGetValue × M: O(log n) binary search, GC ~= 0 ----
        static void SortedListGetCore<T>(int[] keys, T[] vals, int n)
        {
            int m = Bench.SubOpCount(n);
            var d = new SortedList<int, T>(n);
            for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) if (d.TryGetValue(keys[i], out var v) && v != null) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void SortedList_Get_int([Values(1, 100, 10000)] int n) => SortedListGetCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void SortedList_Get_val([Values(1, 100, 10000)] int n) => SortedListGetCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void SortedList_Get_ref([Values(1, 100, 10000)] int n) => SortedListGetCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void SortedList_Get_bool([Values(1, 100, 10000)] int n) => SortedListGetCore(Src.Ints(n), Src.Bools(n), n);

        // ---- SortedList Iterate (foreach KVP, sorted): GC ~= 0 ----
        static void SortedListIterateCore<T>(int[] keys, T[] vals, int n)
        {
            var d = new SortedList<int, T>(n);
            for (int i = 0; i < n; i++) d[keys[i]] = vals[i];
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var kv in d) { if (kv.Key >= 0) sink++; }
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void SortedList_Iterate_int([Values(1, 100, 10000)] int n) => SortedListIterateCore(Src.Ints(n), Src.Ints(n), n);
        [Test, Performance]
        public void SortedList_Iterate_val([Values(1, 100, 10000)] int n) => SortedListIterateCore(Src.Ints(n), Src.Vals(n), n);
        [Test, Performance]
        public void SortedList_Iterate_ref([Values(1, 100, 10000)] int n) => SortedListIterateCore(Src.Ints(n), Src.Refs(n), n);
        [Test, Performance]
        public void SortedList_Iterate_bool([Values(1, 100, 10000)] int n) => SortedListIterateCore(Src.Ints(n), Src.Bools(n), n);

        // =======================================================================
        // LinkedList<T>  — doubly linked list
        // =======================================================================

        // ---- LinkedList AddLast (tail build to N): node alloc per add, GC > 0 ----
        static void LinkedListAddLastCore<T>(T[] src, int n)
        {
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var ll = new LinkedList<T>();
                    for (int i = 0; i < n; i++) ll.AddLast(src[i]);
                    return ll;
                },
                n: n);
        }

        [Test, Performance]
        public void LinkedList_Add_int([Values(1, 100, 10000)] int n) => LinkedListAddLastCore(Src.Ints(n), n);
        [Test, Performance]
        public void LinkedList_Add_val([Values(1, 100, 10000)] int n) => LinkedListAddLastCore(Src.Vals(n), n);
        [Test, Performance]
        public void LinkedList_Add_ref([Values(1, 100, 10000)] int n) => LinkedListAddLastCore(Src.Refs(n), n);
        [Test, Performance]
        public void LinkedList_Add_bool([Values(1, 100, 10000)] int n) => LinkedListAddLastCore(Src.Bools(n), n);

        // ---- LinkedList AddFirst (head build to N): O(1) per add, node alloc GC > 0 ----
        static void LinkedListAddFirstCore<T>(T[] src, int n)
        {
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var ll = new LinkedList<T>();
                    for (int i = 0; i < n; i++) ll.AddFirst(src[i]);
                    return ll;
                },
                n: n);
        }

        [Test, Performance]
        public void LinkedList_AddFirst_int([Values(1, 100, 10000)] int n) => LinkedListAddFirstCore(Src.Ints(n), n);
        [Test, Performance]
        public void LinkedList_AddFirst_val([Values(1, 100, 10000)] int n) => LinkedListAddFirstCore(Src.Vals(n), n);
        [Test, Performance]
        public void LinkedList_AddFirst_ref([Values(1, 100, 10000)] int n) => LinkedListAddFirstCore(Src.Refs(n), n);
        [Test, Performance]
        public void LinkedList_AddFirst_bool([Values(1, 100, 10000)] int n) => LinkedListAddFirstCore(Src.Bools(n), n);

        // ---- LinkedList RemoveFirst (drain to empty): destructive, rebuild in setup ----
        static void LinkedListRemoveCore<T>(T[] src, int n)
        {
            LinkedList<T> ll = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    while (ll.Count > 0) ll.RemoveFirst();
                },
                setup: () => { ll = new LinkedList<T>(src); },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void LinkedList_Remove_int([Values(1, 100, 10000)] int n) => LinkedListRemoveCore(Src.Ints(n), n);
        [Test, Performance]
        public void LinkedList_Remove_val([Values(1, 100, 10000)] int n) => LinkedListRemoveCore(Src.Vals(n), n);
        [Test, Performance]
        public void LinkedList_Remove_ref([Values(1, 100, 10000)] int n) => LinkedListRemoveCore(Src.Refs(n), n);
        [Test, Performance]
        public void LinkedList_Remove_bool([Values(1, 100, 10000)] int n) => LinkedListRemoveCore(Src.Bools(n), n);

        // ---- LinkedList Contains (linear O(n) scan × LinearScanCount): GC ~= 0 ----
        static void LinkedListContainsCore<T>(T[] src, int n)
        {
            int m = Bench.LinearScanCount(n);
            var ll = new LinkedList<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) if (ll.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void LinkedList_Contains_int([Values(1, 100, 10000)] int n) => LinkedListContainsCore(Src.Ints(n), n);
        [Test, Performance]
        public void LinkedList_Contains_val([Values(1, 100, 10000)] int n) => LinkedListContainsCore(Src.Vals(n), n);
        [Test, Performance]
        public void LinkedList_Contains_ref([Values(1, 100, 10000)] int n) => LinkedListContainsCore(Src.Refs(n), n);
        [Test, Performance]
        public void LinkedList_Contains_bool([Values(1, 100, 10000)] int n) => LinkedListContainsCore(Src.Bools(n), n);

        // ---- LinkedList Iterate (foreach full): GC ~= 0 ----
        static void LinkedListIterateCore<T>(T[] src, int n)
        {
            var ll = new LinkedList<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var v in ll) { if (v != null) sink++; }
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void LinkedList_Iterate_int([Values(1, 100, 10000)] int n) => LinkedListIterateCore(Src.Ints(n), n);
        [Test, Performance]
        public void LinkedList_Iterate_val([Values(1, 100, 10000)] int n) => LinkedListIterateCore(Src.Vals(n), n);
        [Test, Performance]
        public void LinkedList_Iterate_ref([Values(1, 100, 10000)] int n) => LinkedListIterateCore(Src.Refs(n), n);
        [Test, Performance]
        public void LinkedList_Iterate_bool([Values(1, 100, 10000)] int n) => LinkedListIterateCore(Src.Bools(n), n);

        // =======================================================================
        // Queue<T>  — FIFO
        // =======================================================================

        // ---- Queue Enqueue (build to N): backing-array growth GC > 0 ----
        static void QueueEnqueueCore<T>(T[] src, int n)
        {
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var q = new Queue<T>();
                    for (int i = 0; i < n; i++) q.Enqueue(src[i]);
                    return q;
                },
                n: n);
        }

        [Test, Performance]
        public void Queue_Add_int([Values(1, 100, 10000)] int n) => QueueEnqueueCore(Src.Ints(n), n);
        [Test, Performance]
        public void Queue_Add_val([Values(1, 100, 10000)] int n) => QueueEnqueueCore(Src.Vals(n), n);
        [Test, Performance]
        public void Queue_Add_ref([Values(1, 100, 10000)] int n) => QueueEnqueueCore(Src.Refs(n), n);
        [Test, Performance]
        public void Queue_Add_bool([Values(1, 100, 10000)] int n) => QueueEnqueueCore(Src.Bools(n), n);

        // ---- Queue Dequeue (drain to empty): destructive, rebuild in setup ----
        static void QueueDequeueCore<T>(T[] src, int n)
        {
            Queue<T> q = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    while (q.Count > 0) q.Dequeue();
                },
                setup: () => { q = new Queue<T>(src); },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void Queue_Remove_int([Values(1, 100, 10000)] int n) => QueueDequeueCore(Src.Ints(n), n);
        [Test, Performance]
        public void Queue_Remove_val([Values(1, 100, 10000)] int n) => QueueDequeueCore(Src.Vals(n), n);
        [Test, Performance]
        public void Queue_Remove_ref([Values(1, 100, 10000)] int n) => QueueDequeueCore(Src.Refs(n), n);
        [Test, Performance]
        public void Queue_Remove_bool([Values(1, 100, 10000)] int n) => QueueDequeueCore(Src.Bools(n), n);

        // ---- Queue Peek + Contains (linear scan × LinearScanCount): GC ~= 0 ----
        static void QueuePeekContainsCore<T>(T[] src, int n)
        {
            int m = Bench.LinearScanCount(n);
            var q = new Queue<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    var head = q.Peek();
                    if (head != null) sink++;
                    for (int i = 0; i < m; i++) if (q.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Queue_Contains_int([Values(1, 100, 10000)] int n) => QueuePeekContainsCore(Src.Ints(n), n);
        [Test, Performance]
        public void Queue_Contains_val([Values(1, 100, 10000)] int n) => QueuePeekContainsCore(Src.Vals(n), n);
        [Test, Performance]
        public void Queue_Contains_ref([Values(1, 100, 10000)] int n) => QueuePeekContainsCore(Src.Refs(n), n);
        [Test, Performance]
        public void Queue_Contains_bool([Values(1, 100, 10000)] int n) => QueuePeekContainsCore(Src.Bools(n), n);

        // ---- Queue Iterate (foreach full): GC ~= 0 ----
        static void QueueIterateCore<T>(T[] src, int n)
        {
            var q = new Queue<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var v in q) { if (v != null) sink++; }
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Queue_Iterate_int([Values(1, 100, 10000)] int n) => QueueIterateCore(Src.Ints(n), n);
        [Test, Performance]
        public void Queue_Iterate_val([Values(1, 100, 10000)] int n) => QueueIterateCore(Src.Vals(n), n);
        [Test, Performance]
        public void Queue_Iterate_ref([Values(1, 100, 10000)] int n) => QueueIterateCore(Src.Refs(n), n);
        [Test, Performance]
        public void Queue_Iterate_bool([Values(1, 100, 10000)] int n) => QueueIterateCore(Src.Bools(n), n);

        // =======================================================================
        // Stack<T>  — LIFO
        // =======================================================================

        // ---- Stack Push (build to N): backing-array growth GC > 0 ----
        static void StackPushCore<T>(T[] src, int n)
        {
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var s = new Stack<T>();
                    for (int i = 0; i < n; i++) s.Push(src[i]);
                    return s;
                },
                n: n);
        }

        [Test, Performance]
        public void Stack_Add_int([Values(1, 100, 10000)] int n) => StackPushCore(Src.Ints(n), n);
        [Test, Performance]
        public void Stack_Add_val([Values(1, 100, 10000)] int n) => StackPushCore(Src.Vals(n), n);
        [Test, Performance]
        public void Stack_Add_ref([Values(1, 100, 10000)] int n) => StackPushCore(Src.Refs(n), n);
        [Test, Performance]
        public void Stack_Add_bool([Values(1, 100, 10000)] int n) => StackPushCore(Src.Bools(n), n);

        // ---- Stack Pop (drain to empty): destructive, rebuild in setup ----
        static void StackPopCore<T>(T[] src, int n)
        {
            Stack<T> s = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    while (s.Count > 0) s.Pop();
                },
                setup: () => { s = new Stack<T>(src); },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void Stack_Remove_int([Values(1, 100, 10000)] int n) => StackPopCore(Src.Ints(n), n);
        [Test, Performance]
        public void Stack_Remove_val([Values(1, 100, 10000)] int n) => StackPopCore(Src.Vals(n), n);
        [Test, Performance]
        public void Stack_Remove_ref([Values(1, 100, 10000)] int n) => StackPopCore(Src.Refs(n), n);
        [Test, Performance]
        public void Stack_Remove_bool([Values(1, 100, 10000)] int n) => StackPopCore(Src.Bools(n), n);

        // ---- Stack Peek + Contains (linear scan × LinearScanCount): GC ~= 0 ----
        static void StackPeekContainsCore<T>(T[] src, int n)
        {
            int m = Bench.LinearScanCount(n);
            var s = new Stack<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    var top = s.Peek();
                    if (top != null) sink++;
                    for (int i = 0; i < m; i++) if (s.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Stack_Contains_int([Values(1, 100, 10000)] int n) => StackPeekContainsCore(Src.Ints(n), n);
        [Test, Performance]
        public void Stack_Contains_val([Values(1, 100, 10000)] int n) => StackPeekContainsCore(Src.Vals(n), n);
        [Test, Performance]
        public void Stack_Contains_ref([Values(1, 100, 10000)] int n) => StackPeekContainsCore(Src.Refs(n), n);
        [Test, Performance]
        public void Stack_Contains_bool([Values(1, 100, 10000)] int n) => StackPeekContainsCore(Src.Bools(n), n);

        // ---- Stack Iterate (foreach full): GC ~= 0 ----
        static void StackIterateCore<T>(T[] src, int n)
        {
            var s = new Stack<T>(src);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var v in s) { if (v != null) sink++; }
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Stack_Iterate_int([Values(1, 100, 10000)] int n) => StackIterateCore(Src.Ints(n), n);
        [Test, Performance]
        public void Stack_Iterate_val([Values(1, 100, 10000)] int n) => StackIterateCore(Src.Vals(n), n);
        [Test, Performance]
        public void Stack_Iterate_ref([Values(1, 100, 10000)] int n) => StackIterateCore(Src.Refs(n), n);
        [Test, Performance]
        public void Stack_Iterate_bool([Values(1, 100, 10000)] int n) => StackIterateCore(Src.Bools(n), n);

        // =======================================================================
        // T[]  — managed array (key name: Array). Only set/get-by-index + iterate.
        // =======================================================================

        // ---- Array this[i]=v (indexer set × M): O(1) write, GC ~= 0 ----
        static void ArraySetCore<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            var arr = new T[n];
            System.Array.Copy(src, arr, n);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) arr[i] = src[i];
                },
                setup: null, cleanup: null, n: n);
        }

        [Test, Performance]
        public void Array_Set_int([Values(1, 100, 10000)] int n) => ArraySetCore(Src.Ints(n), n);
        [Test, Performance]
        public void Array_Set_val([Values(1, 100, 10000)] int n) => ArraySetCore(Src.Vals(n), n);
        [Test, Performance]
        public void Array_Set_ref([Values(1, 100, 10000)] int n) => ArraySetCore(Src.Refs(n), n);
        [Test, Performance]
        public void Array_Set_bool([Values(1, 100, 10000)] int n) => ArraySetCore(Src.Bools(n), n);

        // ---- Array this[i] (indexer get × M): O(1) read, GC ~= 0 ----
        static void ArrayGetCore<T>(T[] src, int n)
        {
            int m = Bench.SubOpCount(n);
            var arr = new T[n];
            System.Array.Copy(src, arr, n);
            var sink = new T[1];
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink[0] = arr[i];
                },
                setup: null,
                cleanup: () => { if (sink == null) UnityEngine.Debug.Log("x"); },
                n: n);
        }

        [Test, Performance]
        public void Array_Get_int([Values(1, 100, 10000)] int n) => ArrayGetCore(Src.Ints(n), n);
        [Test, Performance]
        public void Array_Get_val([Values(1, 100, 10000)] int n) => ArrayGetCore(Src.Vals(n), n);
        [Test, Performance]
        public void Array_Get_ref([Values(1, 100, 10000)] int n) => ArrayGetCore(Src.Refs(n), n);
        [Test, Performance]
        public void Array_Get_bool([Values(1, 100, 10000)] int n) => ArrayGetCore(Src.Bools(n), n);

        // ---- Array Iterate (foreach full): GC ~= 0 ----
        static void ArrayIterateCore<T>(T[] src, int n)
        {
            var arr = new T[n];
            System.Array.Copy(src, arr, n);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    foreach (var v in arr) { if (v != null) sink++; }
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Array_Iterate_int([Values(1, 100, 10000)] int n) => ArrayIterateCore(Src.Ints(n), n);
        [Test, Performance]
        public void Array_Iterate_val([Values(1, 100, 10000)] int n) => ArrayIterateCore(Src.Vals(n), n);
        [Test, Performance]
        public void Array_Iterate_ref([Values(1, 100, 10000)] int n) => ArrayIterateCore(Src.Refs(n), n);
        [Test, Performance]
        public void Array_Iterate_bool([Values(1, 100, 10000)] int n) => ArrayIterateCore(Src.Bools(n), n);
    }
}
