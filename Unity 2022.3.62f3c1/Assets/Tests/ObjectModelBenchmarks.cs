using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace CollectionBenchmarks
{
    // ============================================================================
    // ObjectModel family (SPEC §5.D). System.Collections.ObjectModel.
    //
    // Collections covered:
    //   Collection<T>          : 增(Add) / 增-头插(Insert0) / 删(RemoveAt尾) / 改(this[i]=) / 查(this[i]+Contains) / 遍历
    //   ObservableCollection<T>: 同 Collection (每次增删改触发 CollectionChanged 通知 -> 额外开销, 不订阅事件; 增/删 GC/time 应高于 Collection, 这是看点)
    //   ReadOnlyCollection<T>  : 只读, 构造自预建 List<T> (构造在 setup, 不计测量) -> 查(this[i]+Contains) / 遍历
    //   ReadOnlyDictionary<K,V>: 只读, 构造自预建 Dictionary (构造在 setup, 不计测量) -> 查(TryGetValue) / 遍历
    //   KeyedCollection<int,T> : 内联子类 (GetKeyForItem: int->自身, ValStruct/RefElem->.A) -> 增(Add) / 删(Remove(key)) / 查(this[key]+Contains(key)) / 遍历
    //
    // 元素: int / ValStruct / RefElem (全跑). Naming: <Collection>_<Op>_<Elem>, [Values(1,100,10000)]int n.
    //   BUILD ops      -> Bench.MeasureTimeAndGcProducing(produce, n)
    //   IN-PLACE ops   -> Bench.MeasureTimeAndGc(action, setup, cleanup, n)
    //   删 ops         -> rebuild in setup (or producing for build-then-drain), 不计入测量.
    // ============================================================================

    // ---- KeyedCollection inline subclasses: key extracted from element ----------
    //   int   -> the element itself is the key
    //   ValStruct / RefElem -> the .A field is the key
    internal sealed class IntKeyedCollection : KeyedCollection<int, int>
    {
        protected override int GetKeyForItem(int item) => item;
    }

    internal sealed class ValKeyedCollection : KeyedCollection<int, ValStruct>
    {
        protected override int GetKeyForItem(ValStruct item) => item.A;
    }

    internal sealed class RefKeyedCollection : KeyedCollection<int, RefElem>
    {
        protected override int GetKeyForItem(RefElem item) => item.A;
    }

    [Category("ObjectModel")]
    public class ObjectModelBenchmarks
    {
        // ====================================================================
        // Collection<T> : 索引线性 (增/增-头插/删/改/查/遍历)
        // Collection<T> wraps a List<T>; Add/Insert/RemoveAt/this[]= forward to it.
        // ====================================================================

        // ---- Collection<T> 增 (Add append, build to N): GC = backing List growth ----
        [Test, Performance]
        public void Collection_Add_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new Collection<int>();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void Collection_Add_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new Collection<ValStruct>();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void Collection_Add_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new Collection<RefElem>();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void Collection_Add_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new Collection<bool>();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                    return col;
                },
                n: n);
        }

        // ---- Collection<T> 增-头插 (Insert(0), build to N): O(n) shift each ----
        [Test, Performance]
        public void Collection_InsertHead_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new Collection<int>();
                    for (int i = 0; i < n; i++) col.Insert(0, src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void Collection_InsertHead_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new Collection<ValStruct>();
                    for (int i = 0; i < n; i++) col.Insert(0, src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void Collection_InsertHead_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new Collection<RefElem>();
                    for (int i = 0; i < n; i++) col.Insert(0, src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void Collection_InsertHead_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new Collection<bool>();
                    for (int i = 0; i < n; i++) col.Insert(0, src[i]);
                    return col;
                },
                n: n);
        }

        // ---- Collection<T> 删 (RemoveAt(末) drain to empty): rebuild in setup ----
        [Test, Performance]
        public void Collection_RemoveAt_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Collection<int> col = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = col.Count - 1; i >= 0; i--) col.RemoveAt(i);
                },
                setup: () => { col = new Collection<int>(new List<int>(src)); },
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void Collection_RemoveAt_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Collection<ValStruct> col = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = col.Count - 1; i >= 0; i--) col.RemoveAt(i);
                },
                setup: () => { col = new Collection<ValStruct>(new List<ValStruct>(src)); },
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void Collection_RemoveAt_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Collection<RefElem> col = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = col.Count - 1; i >= 0; i--) col.RemoveAt(i);
                },
                setup: () => { col = new Collection<RefElem>(new List<RefElem>(src)); },
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void Collection_RemoveAt_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            Collection<bool> col = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = col.Count - 1; i >= 0; i--) col.RemoveAt(i);
                },
                setup: () => { col = new Collection<bool>(new List<bool>(src)); },
                cleanup: null,
                n: n);
        }

        // ---- Collection<T> 改 (this[i]=v ×M): in-place, expect GC ~= 0 ----
        [Test, Performance]
        public void Collection_Set_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            var col = new Collection<int>(new List<int>(src));
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) col[i] = src[i];
                },
                setup: null,
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void Collection_Set_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            var col = new Collection<ValStruct>(new List<ValStruct>(src));
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) col[i] = src[i];
                },
                setup: null,
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void Collection_Set_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            var col = new Collection<RefElem>(new List<RefElem>(src));
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) col[i] = src[i];
                },
                setup: null,
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void Collection_Set_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            int m = Bench.SubOpCount(n);
            var col = new Collection<bool>(new List<bool>(src));
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) col[i] = src[i];
                },
                setup: null,
                cleanup: null,
                n: n);
        }

        // ---- Collection<T> 查 (this[i] index O(1) ×M + Contains O(n) ×LinearScan) ----
        [Test, Performance]
        public void Collection_Get_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new Collection<int>(new List<int>(src));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i];
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Collection_Get_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new Collection<ValStruct>(new List<ValStruct>(src));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i].A;
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Collection_Get_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new Collection<RefElem>(new List<RefElem>(src));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i].A;
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Collection_Get_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new Collection<bool>(new List<bool>(src));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i] ? 1 : 0;
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        // ---- Collection<T> 遍历 (foreach full): expect GC ~= 0 ----
        [Test, Performance]
        public void Collection_Iterate_int([Values(1, 100, 10000)] int n)
        {
            var col = new Collection<int>(new List<int>(Src.Ints(n)));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (int v in col) sink += v; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Collection_Iterate_val([Values(1, 100, 10000)] int n)
        {
            var col = new Collection<ValStruct>(new List<ValStruct>(Src.Vals(n)));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (ValStruct v in col) sink += v.A; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Collection_Iterate_ref([Values(1, 100, 10000)] int n)
        {
            var col = new Collection<RefElem>(new List<RefElem>(Src.Refs(n)));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (RefElem v in col) sink += v.A; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void Collection_Iterate_bool([Values(1, 100, 10000)] int n)
        {
            var col = new Collection<bool>(new List<bool>(Src.Bools(n)));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (bool v in col) sink += v ? 1 : 0; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        // ====================================================================
        // ObservableCollection<T> : 同 Collection, 但每次增删改触发 CollectionChanged
        // 通知 (不订阅事件). 增/删/改 应比 Collection 慢且分配更多 -> 看点.
        // ====================================================================

        // ---- ObservableCollection<T> 增 (Add append, build to N) ----
        [Test, Performance]
        public void ObservableCollection_Add_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new ObservableCollection<int>();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Add_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new ObservableCollection<ValStruct>();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Add_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new ObservableCollection<RefElem>();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Add_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new ObservableCollection<bool>();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                    return col;
                },
                n: n);
        }

        // ---- ObservableCollection<T> 增-头插 (Insert(0), build to N) ----
        [Test, Performance]
        public void ObservableCollection_InsertHead_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new ObservableCollection<int>();
                    for (int i = 0; i < n; i++) col.Insert(0, src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_InsertHead_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new ObservableCollection<ValStruct>();
                    for (int i = 0; i < n; i++) col.Insert(0, src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_InsertHead_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new ObservableCollection<RefElem>();
                    for (int i = 0; i < n; i++) col.Insert(0, src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_InsertHead_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new ObservableCollection<bool>();
                    for (int i = 0; i < n; i++) col.Insert(0, src[i]);
                    return col;
                },
                n: n);
        }

        // ---- ObservableCollection<T> 删 (RemoveAt(末) drain): rebuild in setup ----
        [Test, Performance]
        public void ObservableCollection_RemoveAt_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            ObservableCollection<int> col = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = col.Count - 1; i >= 0; i--) col.RemoveAt(i);
                },
                setup: () => { col = new ObservableCollection<int>(src); },
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_RemoveAt_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            ObservableCollection<ValStruct> col = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = col.Count - 1; i >= 0; i--) col.RemoveAt(i);
                },
                setup: () => { col = new ObservableCollection<ValStruct>(src); },
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_RemoveAt_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            ObservableCollection<RefElem> col = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = col.Count - 1; i >= 0; i--) col.RemoveAt(i);
                },
                setup: () => { col = new ObservableCollection<RefElem>(src); },
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_RemoveAt_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            ObservableCollection<bool> col = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = col.Count - 1; i >= 0; i--) col.RemoveAt(i);
                },
                setup: () => { col = new ObservableCollection<bool>(src); },
                cleanup: null,
                n: n);
        }

        // ---- ObservableCollection<T> 改 (this[i]=v ×M): triggers Replace notify ----
        [Test, Performance]
        public void ObservableCollection_Set_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            var col = new ObservableCollection<int>(src);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) col[i] = src[i];
                },
                setup: null,
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Set_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            var col = new ObservableCollection<ValStruct>(src);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) col[i] = src[i];
                },
                setup: null,
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Set_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            var col = new ObservableCollection<RefElem>(src);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) col[i] = src[i];
                },
                setup: null,
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Set_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            int m = Bench.SubOpCount(n);
            var col = new ObservableCollection<bool>(src);
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) col[i] = src[i];
                },
                setup: null,
                cleanup: null,
                n: n);
        }

        // ---- ObservableCollection<T> 查 (this[i] ×M + Contains ×LinearScan) ----
        [Test, Performance]
        public void ObservableCollection_Get_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new ObservableCollection<int>(src);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i];
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Get_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new ObservableCollection<ValStruct>(src);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i].A;
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Get_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new ObservableCollection<RefElem>(src);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i].A;
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Get_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new ObservableCollection<bool>(src);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i] ? 1 : 0;
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        // ---- ObservableCollection<T> 遍历 (foreach full): expect GC ~= 0 ----
        [Test, Performance]
        public void ObservableCollection_Iterate_int([Values(1, 100, 10000)] int n)
        {
            var col = new ObservableCollection<int>(Src.Ints(n));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (int v in col) sink += v; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Iterate_val([Values(1, 100, 10000)] int n)
        {
            var col = new ObservableCollection<ValStruct>(Src.Vals(n));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (ValStruct v in col) sink += v.A; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Iterate_ref([Values(1, 100, 10000)] int n)
        {
            var col = new ObservableCollection<RefElem>(Src.Refs(n));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (RefElem v in col) sink += v.A; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ObservableCollection_Iterate_bool([Values(1, 100, 10000)] int n)
        {
            var col = new ObservableCollection<bool>(Src.Bools(n));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (bool v in col) sink += v ? 1 : 0; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        // ====================================================================
        // ReadOnlyCollection<T> : 只读 (构造自预建 List<T>, 构造在 setup 不计测量).
        // 只测 查(this[i]+Contains) / 遍历. 无增删改.
        // ====================================================================

        // ---- ReadOnlyCollection<T> 查 (this[i] ×M + Contains ×LinearScan) ----
        [Test, Performance]
        public void ReadOnlyCollection_Get_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new ReadOnlyCollection<int>(new List<int>(src)); // construct: not measured
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i];
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ReadOnlyCollection_Get_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new ReadOnlyCollection<ValStruct>(new List<ValStruct>(src));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i].A;
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ReadOnlyCollection_Get_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new ReadOnlyCollection<RefElem>(new List<RefElem>(src));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i].A;
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ReadOnlyCollection_Get_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            int m = Bench.SubOpCount(n);
            int ls = Bench.LinearScanCount(n);
            var col = new ReadOnlyCollection<bool>(new List<bool>(src)); // construct: not measured
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[i] ? 1 : 0;
                    for (int i = 0; i < ls; i++) if (col.Contains(src[i])) sink++;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        // ---- ReadOnlyCollection<T> 遍历 (foreach full): expect GC ~= 0 ----
        [Test, Performance]
        public void ReadOnlyCollection_Iterate_int([Values(1, 100, 10000)] int n)
        {
            var col = new ReadOnlyCollection<int>(new List<int>(Src.Ints(n)));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (int v in col) sink += v; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ReadOnlyCollection_Iterate_val([Values(1, 100, 10000)] int n)
        {
            var col = new ReadOnlyCollection<ValStruct>(new List<ValStruct>(Src.Vals(n)));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (ValStruct v in col) sink += v.A; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ReadOnlyCollection_Iterate_ref([Values(1, 100, 10000)] int n)
        {
            var col = new ReadOnlyCollection<RefElem>(new List<RefElem>(Src.Refs(n)));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (RefElem v in col) sink += v.A; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ReadOnlyCollection_Iterate_bool([Values(1, 100, 10000)] int n)
        {
            var col = new ReadOnlyCollection<bool>(new List<bool>(Src.Bools(n)));
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (bool v in col) sink += v ? 1 : 0; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        // ====================================================================
        // ReadOnlyDictionary<int,T> : 只读 (构造自预建 Dictionary, 构造在 setup 不计测量).
        // 只测 查(TryGetValue) / 遍历. 无增删改. key=int, value=elem.
        // ====================================================================

        // ---- ReadOnlyDictionary<int,T> 查 (TryGetValue ×M) ----
        [Test, Performance]
        public void ReadOnlyDictionary_Get_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            var inner = new Dictionary<int, int>(n);
            for (int i = 0; i < n; i++) inner[src[i]] = src[i];
            var dict = new ReadOnlyDictionary<int, int>(inner); // construct: not measured
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++)
                        if (dict.TryGetValue(src[i], out int v)) sink += v;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ReadOnlyDictionary_Get_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            var inner = new Dictionary<int, ValStruct>(n);
            for (int i = 0; i < n; i++) inner[src[i].A] = src[i];
            var dict = new ReadOnlyDictionary<int, ValStruct>(inner);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++)
                        if (dict.TryGetValue(src[i].A, out ValStruct v)) sink += v.A;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ReadOnlyDictionary_Get_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            var inner = new Dictionary<int, RefElem>(n);
            for (int i = 0; i < n; i++) inner[src[i].A] = src[i];
            var dict = new ReadOnlyDictionary<int, RefElem>(inner);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++)
                        if (dict.TryGetValue(src[i].A, out RefElem v)) sink += v.A;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        // key=int (loop index i, distinct per slot), value=bool. bool 不能当键 (退化), 故键用 i.
        [Test, Performance]
        public void ReadOnlyDictionary_Get_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            int m = Bench.SubOpCount(n);
            var inner = new Dictionary<int, bool>(n);
            for (int i = 0; i < n; i++) inner[i] = src[i];
            var dict = new ReadOnlyDictionary<int, bool>(inner); // construct: not measured
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++)
                        if (dict.TryGetValue(i, out bool v)) sink += v ? 1 : 0;
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        // ---- ReadOnlyDictionary<int,T> 遍历 (foreach KVP full): expect GC ~= 0 ----
        [Test, Performance]
        public void ReadOnlyDictionary_Iterate_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            var inner = new Dictionary<int, int>(n);
            for (int i = 0; i < n; i++) inner[src[i]] = src[i];
            var dict = new ReadOnlyDictionary<int, int>(inner);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (var kv in dict) sink += kv.Value; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ReadOnlyDictionary_Iterate_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            var inner = new Dictionary<int, ValStruct>(n);
            for (int i = 0; i < n; i++) inner[src[i].A] = src[i];
            var dict = new ReadOnlyDictionary<int, ValStruct>(inner);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (var kv in dict) sink += kv.Value.A; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void ReadOnlyDictionary_Iterate_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            var inner = new Dictionary<int, RefElem>(n);
            for (int i = 0; i < n; i++) inner[src[i].A] = src[i];
            var dict = new ReadOnlyDictionary<int, RefElem>(inner);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (var kv in dict) sink += kv.Value.A; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        // key=int (loop index i), value=bool.
        [Test, Performance]
        public void ReadOnlyDictionary_Iterate_bool([Values(1, 100, 10000)] int n)
        {
            bool[] src = Src.Bools(n);
            var inner = new Dictionary<int, bool>(n);
            for (int i = 0; i < n; i++) inner[i] = src[i];
            var dict = new ReadOnlyDictionary<int, bool>(inner);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (var kv in dict) sink += kv.Value ? 1 : 0; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        // ====================================================================
        // KeyedCollection<int,T> : 字典-ish (内联子类提供 GetKeyForItem).
        // key: int->自身, ValStruct/RefElem->.A. 增(Add) / 删(Remove(key)) /
        // 查(this[key]+Contains(key)) / 遍历.
        // ====================================================================

        // ---- KeyedCollection<int,T> 增 (Add, build to N): builds list + key dict ----
        [Test, Performance]
        public void KeyedCollection_Add_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new IntKeyedCollection();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void KeyedCollection_Add_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new ValKeyedCollection();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                    return col;
                },
                n: n);
        }

        [Test, Performance]
        public void KeyedCollection_Add_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var col = new RefKeyedCollection();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                    return col;
                },
                n: n);
        }

        // ---- KeyedCollection<int,T> 删 (Remove(key) ×M): rebuild in setup ----
        [Test, Performance]
        public void KeyedCollection_Remove_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            IntKeyedCollection col = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) col.Remove(src[i]); // key == element
                },
                setup: () =>
                {
                    col = new IntKeyedCollection();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                },
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void KeyedCollection_Remove_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            ValKeyedCollection col = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) col.Remove(src[i].A); // key == .A
                },
                setup: () =>
                {
                    col = new ValKeyedCollection();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                },
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void KeyedCollection_Remove_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            RefKeyedCollection col = null;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) col.Remove(src[i].A); // key == .A
                },
                setup: () =>
                {
                    col = new RefKeyedCollection();
                    for (int i = 0; i < n; i++) col.Add(src[i]);
                },
                cleanup: null,
                n: n);
        }

        // ---- KeyedCollection<int,T> 查 (this[key] ×M + Contains(key) ×M) ----
        [Test, Performance]
        public void KeyedCollection_Get_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            var col = new IntKeyedCollection();
            for (int i = 0; i < n; i++) col.Add(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[src[i]];          // this[key]
                    for (int i = 0; i < m; i++) if (col.Contains(src[i])) sink++; // Contains(key)
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void KeyedCollection_Get_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            var col = new ValKeyedCollection();
            for (int i = 0; i < n; i++) col.Add(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[src[i].A].A;            // this[key]
                    for (int i = 0; i < m; i++) if (col.Contains(src[i].A)) sink++; // Contains(key)
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void KeyedCollection_Get_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            var col = new RefKeyedCollection();
            for (int i = 0; i < n; i++) col.Add(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++) sink += col[src[i].A].A;            // this[key]
                    for (int i = 0; i < m; i++) if (col.Contains(src[i].A)) sink++; // Contains(key)
                },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        // ---- KeyedCollection<int,T> 遍历 (foreach full): expect GC ~= 0 ----
        [Test, Performance]
        public void KeyedCollection_Iterate_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            var col = new IntKeyedCollection();
            for (int i = 0; i < n; i++) col.Add(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (int v in col) sink += v; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void KeyedCollection_Iterate_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            var col = new ValKeyedCollection();
            for (int i = 0; i < n; i++) col.Add(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (ValStruct v in col) sink += v.A; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }

        [Test, Performance]
        public void KeyedCollection_Iterate_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            var col = new RefKeyedCollection();
            for (int i = 0; i < n; i++) col.Add(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (RefElem v in col) sink += v.A; },
                setup: null,
                cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); },
                n: n);
        }
    }
}
