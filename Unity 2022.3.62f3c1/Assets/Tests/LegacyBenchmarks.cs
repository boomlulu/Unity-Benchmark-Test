using System.Collections;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace CollectionBenchmarks
{
    // ============================================================================
    // Legacy non-generic family (SPEC §5.B, Category=Legacy). System.Collections.
    //
    // HEADLINE = BOXING. These containers store `object`, so every int / ValStruct
    // element (and every int key) is BOXED into a heap object on insertion. RefElem
    // is already a reference -> no boxing. Build ops over int/val should therefore
    // show GC clearly > 0 (~N boxed objects + backing-array growth); ref builds show
    // only backing-array growth; in-place lookups/iterate/writes-of-existing show ~0.
    //
    // Convention (task spec):
    //   * thin [Test] wrapper -> private typed/generic core (keeps method count down)
    //   * [Values(1,100,10000)] int n   (== Sizes.Quad, the single size ladder)
    //   * BUILD ops (增)            -> Bench.MeasureTimeAndGcProducing
    //   * IN-PLACE ops (删/改/查/遍历) -> Bench.MeasureTimeAndGc (+ setup rebuild for 删)
    //   * sub-op count M = Bench.SubOpCount(n) (clamp 1..1000);
    //     linear-scan Contains M = Bench.LinearScanCount(n) (clamp 1..100)
    //   * naming <Collection>_<Op>_<Elem>; elem in {int, val, ref}; BitArray -> bool
    //   * dict-like (Hashtable/SortedList): key = int (BOXED), value = elem.
    //
    // NOTE: GC byte readings come from GetTotalMemory deltas (this Mono has no working
    // per-thread counter); a 0 on a *build* op = below the ~tens-of-KB floor, not proof
    // of zero allocation. Boxing on the larger N is well above that floor.
    // ============================================================================
    [Category("Legacy")]
    public class LegacyBenchmarks
    {
        // ====================================================================
        // ArrayList (索引线性): 增(Add) / 增-头插(Insert0) / 删(RemoveAt尾) /
        //                       改(this[i]=) / 查(索引 + Contains) / 遍历
        // ====================================================================

        // ---- 增: Add appends; each value elem boxed -> heap object per Add.
        // We iterate the strongly-typed source array per-elem-type so the box cost
        // lands ON THE CONTAINER (ArrayList.Add(object)), not on a source read. ----
        [Test, Performance]
        public void ArrayList_Add_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var list = new ArrayList();
                    for (int i = 0; i < n; i++) list.Add(src[i]); // int boxed into ArrayList
                    return list;
                },
                n: n);
        }

        [Test, Performance]
        public void ArrayList_Add_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var list = new ArrayList();
                    for (int i = 0; i < n; i++) list.Add(src[i]); // ValStruct boxed
                    return list;
                },
                n: n);
        }

        [Test, Performance]
        public void ArrayList_Add_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var list = new ArrayList();
                    for (int i = 0; i < n; i++) list.Add(src[i]); // already a reference -> no box
                    return list;
                },
                n: n);
        }

        // ---- 增-头插: Insert(0) each time -> O(n) shift per insert (O(n^2) build) ----
        [Test, Performance]
        public void ArrayList_Insert0_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var list = new ArrayList();
                    for (int i = 0; i < n; i++) list.Insert(0, src[i]); // box + head shift
                    return list;
                },
                n: n);
        }

        [Test, Performance]
        public void ArrayList_Insert0_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var list = new ArrayList();
                    for (int i = 0; i < n; i++) list.Insert(0, src[i]);
                    return list;
                },
                n: n);
        }

        [Test, Performance]
        public void ArrayList_Insert0_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var list = new ArrayList();
                    for (int i = 0; i < n; i++) list.Insert(0, src[i]);
                    return list;
                },
                n: n);
        }

        // ---- 删: RemoveAt(Count-1) drain to empty. In-place; rebuild in setup ----
        void ArrayList_RemoveAt_Core(int n, ArrayList template)
        {
            ArrayList list = null;
            Bench.MeasureTimeAndGc(
                action: () => { while (list.Count > 0) list.RemoveAt(list.Count - 1); },
                setup: () => { list = (ArrayList)template.Clone(); },
                cleanup: null,
                n: n);
        }

        [Test, Performance]
        public void ArrayList_RemoveAt_int([Values(1, 100, 10000)] int n)
        {
            var template = new ArrayList();
            int[] src = Src.Ints(n);
            for (int i = 0; i < n; i++) template.Add(src[i]);
            ArrayList_RemoveAt_Core(n, template);
        }

        [Test, Performance]
        public void ArrayList_RemoveAt_val([Values(1, 100, 10000)] int n)
        {
            var template = new ArrayList();
            ValStruct[] src = Src.Vals(n);
            for (int i = 0; i < n; i++) template.Add(src[i]);
            ArrayList_RemoveAt_Core(n, template);
        }

        [Test, Performance]
        public void ArrayList_RemoveAt_ref([Values(1, 100, 10000)] int n)
        {
            var template = new ArrayList();
            RefElem[] src = Src.Refs(n);
            for (int i = 0; i < n; i++) template.Add(src[i]);
            ArrayList_RemoveAt_Core(n, template);
        }

        // ---- 改: this[i] = v  ×M. Re-box per write for value elems (replacement box) ----
        [Test, Performance]
        public void ArrayList_Set_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            var list = new ArrayList();
            for (int i = 0; i < n; i++) list.Add(src[i]);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) list[i % n] = src[(i + 1) % n]; },
                setup: null, cleanup: null, n: n);
        }

        [Test, Performance]
        public void ArrayList_Set_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            var list = new ArrayList();
            for (int i = 0; i < n; i++) list.Add(src[i]);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) list[i % n] = src[(i + 1) % n]; },
                setup: null, cleanup: null, n: n);
        }

        [Test, Performance]
        public void ArrayList_Set_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            var list = new ArrayList();
            for (int i = 0; i < n; i++) list.Add(src[i]);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) list[i % n] = src[(i + 1) % n]; },
                setup: null, cleanup: null, n: n);
        }

        // ---- 查-索引: this[i] read ×M (O(1) each). Unbox not forced (stays object) ----
        [Test, Performance]
        public void ArrayList_Index_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            var list = new ArrayList();
            for (int i = 0; i < n; i++) list.Add(src[i]);
            object sink = null;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sink = list[i % n]; },
                setup: null, cleanup: () => { if (sink == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void ArrayList_Index_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            var list = new ArrayList();
            for (int i = 0; i < n; i++) list.Add(src[i]);
            object sink = null;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sink = list[i % n]; },
                setup: null, cleanup: () => { if (sink == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void ArrayList_Index_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            var list = new ArrayList();
            for (int i = 0; i < n; i++) list.Add(src[i]);
            object sink = null;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sink = list[i % n]; },
                setup: null, cleanup: () => { if (sink == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ---- 查-Contains: linear O(n) scan ×M (M capped to LinearScan). Boxes probe ----
        [Test, Performance]
        public void ArrayList_Contains_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.LinearScanCount(n);
            var list = new ArrayList();
            for (int i = 0; i < n; i++) list.Add(src[i]);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) if (list.Contains(src[i])) sink++; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void ArrayList_Contains_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.LinearScanCount(n);
            var list = new ArrayList();
            for (int i = 0; i < n; i++) list.Add(src[i]);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) if (list.Contains(src[i])) sink++; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void ArrayList_Contains_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.LinearScanCount(n);
            var list = new ArrayList();
            for (int i = 0; i < n; i++) list.Add(src[i]);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) if (list.Contains(src[i])) sink++; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ---- 遍历: foreach full. Enumerator yields object; no per-elem alloc ----
        [Test, Performance]
        public void ArrayList_Iterate_int([Values(1, 100, 10000)] int n)
        {
            var list = new ArrayList();
            int[] src = Src.Ints(n);
            for (int i = 0; i < n; i++) list.Add(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (object o in list) sink += (int)o; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void ArrayList_Iterate_val([Values(1, 100, 10000)] int n)
        {
            var list = new ArrayList();
            ValStruct[] src = Src.Vals(n);
            for (int i = 0; i < n; i++) list.Add(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (object o in list) sink += ((ValStruct)o).A; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void ArrayList_Iterate_ref([Values(1, 100, 10000)] int n)
        {
            var list = new ArrayList();
            RefElem[] src = Src.Refs(n);
            for (int i = 0; i < n; i++) list.Add(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (object o in list) sink += ((RefElem)o).A; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ====================================================================
        // Hashtable (字典): 增(Add k,v) / 删(Remove k ×M) / 改(this[k]= ×M) /
        //                   查(ContainsKey + this[k] ×M) / 遍历(DictionaryEntry)
        // key = int (BOXED), value = elem (boxed for int/val).
        // ====================================================================

        // ---- 增: Add(intKey, elem) build. Both key AND value boxed (int/val) ----
        [Test, Performance]
        public void Hashtable_Add_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var h = new Hashtable();
                    for (int i = 0; i < n; i++) h.Add(i, src[i]); // key box + value box
                    return h;
                },
                n: n);
        }

        [Test, Performance]
        public void Hashtable_Add_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var h = new Hashtable();
                    for (int i = 0; i < n; i++) h.Add(i, src[i]); // key box + struct box
                    return h;
                },
                n: n);
        }

        [Test, Performance]
        public void Hashtable_Add_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () =>
                {
                    var h = new Hashtable();
                    for (int i = 0; i < n; i++) h.Add(i, src[i]); // key box only (value is ref)
                    return h;
                },
                n: n);
        }

        // ---- 删: Remove(intKey) ×M, drain. In-place; rebuild in setup (box key probe) ----
        void Hashtable_Remove_Core(int n, Hashtable template)
        {
            int m = Bench.SubOpCount(n);
            Hashtable h = null;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) h.Remove(i % n); },
                setup: () => { h = (Hashtable)template.Clone(); },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void Hashtable_Remove_int([Values(1, 100, 10000)] int n)
        {
            var t = new Hashtable();
            int[] src = Src.Ints(n);
            for (int i = 0; i < n; i++) t.Add(i, src[i]);
            Hashtable_Remove_Core(n, t);
        }

        [Test, Performance]
        public void Hashtable_Remove_val([Values(1, 100, 10000)] int n)
        {
            var t = new Hashtable();
            ValStruct[] src = Src.Vals(n);
            for (int i = 0; i < n; i++) t.Add(i, src[i]);
            Hashtable_Remove_Core(n, t);
        }

        [Test, Performance]
        public void Hashtable_Remove_ref([Values(1, 100, 10000)] int n)
        {
            var t = new Hashtable();
            RefElem[] src = Src.Refs(n);
            for (int i = 0; i < n; i++) t.Add(i, src[i]);
            Hashtable_Remove_Core(n, t);
        }

        // ---- 改: this[intKey] = v2 ×M (overwrite existing). Box key probe + value ----
        [Test, Performance]
        public void Hashtable_Set_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            var h = new Hashtable();
            for (int i = 0; i < n; i++) h.Add(i, src[i]);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) h[i % n] = src[(i + 1) % n]; },
                setup: null, cleanup: null, n: n);
        }

        [Test, Performance]
        public void Hashtable_Set_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            var h = new Hashtable();
            for (int i = 0; i < n; i++) h.Add(i, src[i]);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) h[i % n] = src[(i + 1) % n]; },
                setup: null, cleanup: null, n: n);
        }

        [Test, Performance]
        public void Hashtable_Set_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            var h = new Hashtable();
            for (int i = 0; i < n; i++) h.Add(i, src[i]);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) h[i % n] = src[(i + 1) % n]; },
                setup: null, cleanup: null, n: n);
        }

        // ---- 查: ContainsKey + this[k] ×M. Box key probe each lookup ----
        [Test, Performance]
        public void Hashtable_Get_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            var h = new Hashtable();
            for (int i = 0; i < n; i++) h.Add(i, src[i]);
            object sink = null;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) { int k = i % n; if (h.ContainsKey(k)) sink = h[k]; } },
                setup: null, cleanup: () => { if (sink == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Hashtable_Get_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            var h = new Hashtable();
            for (int i = 0; i < n; i++) h.Add(i, src[i]);
            object sink = null;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) { int k = i % n; if (h.ContainsKey(k)) sink = h[k]; } },
                setup: null, cleanup: () => { if (sink == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Hashtable_Get_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            var h = new Hashtable();
            for (int i = 0; i < n; i++) h.Add(i, src[i]);
            object sink = null;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) { int k = i % n; if (h.ContainsKey(k)) sink = h[k]; } },
                setup: null, cleanup: () => { if (sink == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ---- 遍历: foreach DictionaryEntry full. Enumerator boxes entry struct ----
        [Test, Performance]
        public void Hashtable_Iterate_int([Values(1, 100, 10000)] int n)
        {
            var h = new Hashtable();
            int[] src = Src.Ints(n);
            for (int i = 0; i < n; i++) h.Add(i, src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (DictionaryEntry e in h) sink += (int)e.Key; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Hashtable_Iterate_val([Values(1, 100, 10000)] int n)
        {
            var h = new Hashtable();
            ValStruct[] src = Src.Vals(n);
            for (int i = 0; i < n; i++) h.Add(i, src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (DictionaryEntry e in h) sink += ((ValStruct)e.Value).A; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Hashtable_Iterate_ref([Values(1, 100, 10000)] int n)
        {
            var h = new Hashtable();
            RefElem[] src = Src.Refs(n);
            for (int i = 0; i < n; i++) h.Add(i, src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (DictionaryEntry e in h) sink += ((RefElem)e.Value).A; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ====================================================================
        // Queue (非泛型 System.Collections.Queue):
        //   增(Enqueue) / 删(Dequeue 排空) / 查(Peek + Contains ×LinearScan) / 遍历
        // ====================================================================

        // ---- 增: Enqueue build. Value elems boxed into object[] ring buffer ----
        [Test, Performance]
        public void Queue_Enqueue_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () => { var q = new Queue(); for (int i = 0; i < n; i++) q.Enqueue(src[i]); return q; },
                n: n);
        }

        [Test, Performance]
        public void Queue_Enqueue_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () => { var q = new Queue(); for (int i = 0; i < n; i++) q.Enqueue(src[i]); return q; },
                n: n);
        }

        [Test, Performance]
        public void Queue_Enqueue_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () => { var q = new Queue(); for (int i = 0; i < n; i++) q.Enqueue(src[i]); return q; },
                n: n);
        }

        // ---- 删: Dequeue drain to empty. In-place; rebuild via Clone in setup ----
        void Queue_Dequeue_Core(int n, Queue template)
        {
            Queue q = null;
            Bench.MeasureTimeAndGc(
                action: () => { while (q.Count > 0) q.Dequeue(); },
                setup: () => { q = (Queue)template.Clone(); },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void Queue_Dequeue_int([Values(1, 100, 10000)] int n)
        {
            var t = new Queue(); int[] src = Src.Ints(n);
            for (int i = 0; i < n; i++) t.Enqueue(src[i]);
            Queue_Dequeue_Core(n, t);
        }

        [Test, Performance]
        public void Queue_Dequeue_val([Values(1, 100, 10000)] int n)
        {
            var t = new Queue(); ValStruct[] src = Src.Vals(n);
            for (int i = 0; i < n; i++) t.Enqueue(src[i]);
            Queue_Dequeue_Core(n, t);
        }

        [Test, Performance]
        public void Queue_Dequeue_ref([Values(1, 100, 10000)] int n)
        {
            var t = new Queue(); RefElem[] src = Src.Refs(n);
            for (int i = 0; i < n; i++) t.Enqueue(src[i]);
            Queue_Dequeue_Core(n, t);
        }

        // ---- 查: Peek + Contains (O(n) linear) ×LinearScan. ~0 alloc ----
        [Test, Performance]
        public void Queue_Peek_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.LinearScanCount(n);
            var q = new Queue(); for (int i = 0; i < n; i++) q.Enqueue(src[i]);
            int sink = 0; object pk = null;
            Bench.MeasureTimeAndGc(
                action: () => { pk = q.Peek(); for (int i = 0; i < m; i++) if (q.Contains(src[i])) sink++; },
                setup: null, cleanup: () => { if (sink < 0 || pk == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Queue_Peek_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.LinearScanCount(n);
            var q = new Queue(); for (int i = 0; i < n; i++) q.Enqueue(src[i]);
            int sink = 0; object pk = null;
            Bench.MeasureTimeAndGc(
                action: () => { pk = q.Peek(); for (int i = 0; i < m; i++) if (q.Contains(src[i])) sink++; },
                setup: null, cleanup: () => { if (sink < 0 || pk == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Queue_Peek_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.LinearScanCount(n);
            var q = new Queue(); for (int i = 0; i < n; i++) q.Enqueue(src[i]);
            int sink = 0; object pk = null;
            Bench.MeasureTimeAndGc(
                action: () => { pk = q.Peek(); for (int i = 0; i < m; i++) if (q.Contains(src[i])) sink++; },
                setup: null, cleanup: () => { if (sink < 0 || pk == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ---- 遍历: foreach full ----
        [Test, Performance]
        public void Queue_Iterate_int([Values(1, 100, 10000)] int n)
        {
            var q = new Queue(); int[] src = Src.Ints(n);
            for (int i = 0; i < n; i++) q.Enqueue(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (object o in q) sink += (int)o; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Queue_Iterate_val([Values(1, 100, 10000)] int n)
        {
            var q = new Queue(); ValStruct[] src = Src.Vals(n);
            for (int i = 0; i < n; i++) q.Enqueue(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (object o in q) sink += ((ValStruct)o).A; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Queue_Iterate_ref([Values(1, 100, 10000)] int n)
        {
            var q = new Queue(); RefElem[] src = Src.Refs(n);
            for (int i = 0; i < n; i++) q.Enqueue(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (object o in q) sink += ((RefElem)o).A; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ====================================================================
        // Stack (非泛型 System.Collections.Stack):
        //   增(Push) / 删(Pop 排空) / 查(Peek + Contains ×LinearScan) / 遍历
        // ====================================================================

        [Test, Performance]
        public void Stack_Push_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () => { var s = new Stack(); for (int i = 0; i < n; i++) s.Push(src[i]); return s; },
                n: n);
        }

        [Test, Performance]
        public void Stack_Push_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () => { var s = new Stack(); for (int i = 0; i < n; i++) s.Push(src[i]); return s; },
                n: n);
        }

        [Test, Performance]
        public void Stack_Push_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () => { var s = new Stack(); for (int i = 0; i < n; i++) s.Push(src[i]); return s; },
                n: n);
        }

        // ---- 删: Pop drain to empty. In-place; rebuild via Clone in setup ----
        void Stack_Pop_Core(int n, Stack template)
        {
            Stack s = null;
            Bench.MeasureTimeAndGc(
                action: () => { while (s.Count > 0) s.Pop(); },
                setup: () => { s = (Stack)template.Clone(); },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void Stack_Pop_int([Values(1, 100, 10000)] int n)
        {
            var t = new Stack(); int[] src = Src.Ints(n);
            for (int i = 0; i < n; i++) t.Push(src[i]);
            Stack_Pop_Core(n, t);
        }

        [Test, Performance]
        public void Stack_Pop_val([Values(1, 100, 10000)] int n)
        {
            var t = new Stack(); ValStruct[] src = Src.Vals(n);
            for (int i = 0; i < n; i++) t.Push(src[i]);
            Stack_Pop_Core(n, t);
        }

        [Test, Performance]
        public void Stack_Pop_ref([Values(1, 100, 10000)] int n)
        {
            var t = new Stack(); RefElem[] src = Src.Refs(n);
            for (int i = 0; i < n; i++) t.Push(src[i]);
            Stack_Pop_Core(n, t);
        }

        // ---- 查: Peek + Contains (O(n)) ×LinearScan ----
        [Test, Performance]
        public void Stack_Peek_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.LinearScanCount(n);
            var s = new Stack(); for (int i = 0; i < n; i++) s.Push(src[i]);
            int sink = 0; object pk = null;
            Bench.MeasureTimeAndGc(
                action: () => { pk = s.Peek(); for (int i = 0; i < m; i++) if (s.Contains(src[i])) sink++; },
                setup: null, cleanup: () => { if (sink < 0 || pk == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Stack_Peek_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.LinearScanCount(n);
            var s = new Stack(); for (int i = 0; i < n; i++) s.Push(src[i]);
            int sink = 0; object pk = null;
            Bench.MeasureTimeAndGc(
                action: () => { pk = s.Peek(); for (int i = 0; i < m; i++) if (s.Contains(src[i])) sink++; },
                setup: null, cleanup: () => { if (sink < 0 || pk == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Stack_Peek_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.LinearScanCount(n);
            var s = new Stack(); for (int i = 0; i < n; i++) s.Push(src[i]);
            int sink = 0; object pk = null;
            Bench.MeasureTimeAndGc(
                action: () => { pk = s.Peek(); for (int i = 0; i < m; i++) if (s.Contains(src[i])) sink++; },
                setup: null, cleanup: () => { if (sink < 0 || pk == this) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ---- 遍历: foreach full ----
        [Test, Performance]
        public void Stack_Iterate_int([Values(1, 100, 10000)] int n)
        {
            var s = new Stack(); int[] src = Src.Ints(n);
            for (int i = 0; i < n; i++) s.Push(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (object o in s) sink += (int)o; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Stack_Iterate_val([Values(1, 100, 10000)] int n)
        {
            var s = new Stack(); ValStruct[] src = Src.Vals(n);
            for (int i = 0; i < n; i++) s.Push(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (object o in s) sink += ((ValStruct)o).A; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void Stack_Iterate_ref([Values(1, 100, 10000)] int n)
        {
            var s = new Stack(); RefElem[] src = Src.Refs(n);
            for (int i = 0; i < n; i++) s.Push(src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (object o in s) sink += ((RefElem)o).A; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ====================================================================
        // SortedList (非泛型 System.Collections.SortedList):
        //   增(Add 顺序键) / 删(Remove k ×M) / 改(this[k]= ×M) /
        //   查(ContainsKey ×M) / 遍历
        // key = int (BOXED), value = elem. Keys inserted in ascending order so each
        // Add appends to the tail of the sorted key array (no mid shift) -> O(n) build.
        // ====================================================================

        [Test, Performance]
        public void SortedList_Add_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () => { var sl = new SortedList(); for (int i = 0; i < n; i++) sl.Add(i, src[i]); return sl; },
                n: n);
        }

        [Test, Performance]
        public void SortedList_Add_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () => { var sl = new SortedList(); for (int i = 0; i < n; i++) sl.Add(i, src[i]); return sl; },
                n: n);
        }

        [Test, Performance]
        public void SortedList_Add_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            Bench.MeasureTimeAndGcProducing(
                produce: () => { var sl = new SortedList(); for (int i = 0; i < n; i++) sl.Add(i, src[i]); return sl; },
                n: n);
        }

        // ---- 删: Remove(intKey) ×M. In-place; rebuild via Clone in setup ----
        void SortedList_Remove_Core(int n, SortedList template)
        {
            int m = Bench.SubOpCount(n);
            SortedList sl = null;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sl.Remove(i % n); },
                setup: () => { sl = (SortedList)template.Clone(); },
                cleanup: null, n: n);
        }

        [Test, Performance]
        public void SortedList_Remove_int([Values(1, 100, 10000)] int n)
        {
            var t = new SortedList(); int[] src = Src.Ints(n);
            for (int i = 0; i < n; i++) t.Add(i, src[i]);
            SortedList_Remove_Core(n, t);
        }

        [Test, Performance]
        public void SortedList_Remove_val([Values(1, 100, 10000)] int n)
        {
            var t = new SortedList(); ValStruct[] src = Src.Vals(n);
            for (int i = 0; i < n; i++) t.Add(i, src[i]);
            SortedList_Remove_Core(n, t);
        }

        [Test, Performance]
        public void SortedList_Remove_ref([Values(1, 100, 10000)] int n)
        {
            var t = new SortedList(); RefElem[] src = Src.Refs(n);
            for (int i = 0; i < n; i++) t.Add(i, src[i]);
            SortedList_Remove_Core(n, t);
        }

        // ---- 改: this[intKey] = v2 ×M (overwrite existing) ----
        [Test, Performance]
        public void SortedList_Set_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            var sl = new SortedList(); for (int i = 0; i < n; i++) sl.Add(i, src[i]);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sl[i % n] = src[(i + 1) % n]; },
                setup: null, cleanup: null, n: n);
        }

        [Test, Performance]
        public void SortedList_Set_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            var sl = new SortedList(); for (int i = 0; i < n; i++) sl.Add(i, src[i]);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sl[i % n] = src[(i + 1) % n]; },
                setup: null, cleanup: null, n: n);
        }

        [Test, Performance]
        public void SortedList_Set_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            var sl = new SortedList(); for (int i = 0; i < n; i++) sl.Add(i, src[i]);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) sl[i % n] = src[(i + 1) % n]; },
                setup: null, cleanup: null, n: n);
        }

        // ---- 查: ContainsKey(intKey) ×M (binary search O(log n)). Box key probe ----
        [Test, Performance]
        public void SortedList_ContainsKey_int([Values(1, 100, 10000)] int n)
        {
            int[] src = Src.Ints(n);
            int m = Bench.SubOpCount(n);
            var sl = new SortedList(); for (int i = 0; i < n; i++) sl.Add(i, src[i]);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) if (sl.ContainsKey(i % n)) sink++; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void SortedList_ContainsKey_val([Values(1, 100, 10000)] int n)
        {
            ValStruct[] src = Src.Vals(n);
            int m = Bench.SubOpCount(n);
            var sl = new SortedList(); for (int i = 0; i < n; i++) sl.Add(i, src[i]);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) if (sl.ContainsKey(i % n)) sink++; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void SortedList_ContainsKey_ref([Values(1, 100, 10000)] int n)
        {
            RefElem[] src = Src.Refs(n);
            int m = Bench.SubOpCount(n);
            var sl = new SortedList(); for (int i = 0; i < n; i++) sl.Add(i, src[i]);
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) if (sl.ContainsKey(i % n)) sink++; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ---- 遍历: foreach DictionaryEntry full ----
        [Test, Performance]
        public void SortedList_Iterate_int([Values(1, 100, 10000)] int n)
        {
            var sl = new SortedList(); int[] src = Src.Ints(n);
            for (int i = 0; i < n; i++) sl.Add(i, src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (DictionaryEntry e in sl) sink += (int)e.Key; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void SortedList_Iterate_val([Values(1, 100, 10000)] int n)
        {
            var sl = new SortedList(); ValStruct[] src = Src.Vals(n);
            for (int i = 0; i < n; i++) sl.Add(i, src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (DictionaryEntry e in sl) sink += ((ValStruct)e.Value).A; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        [Test, Performance]
        public void SortedList_Iterate_ref([Values(1, 100, 10000)] int n)
        {
            var sl = new SortedList(); RefElem[] src = Src.Refs(n);
            for (int i = 0; i < n; i++) sl.Add(i, src[i]);
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (DictionaryEntry e in sl) sink += ((RefElem)e.Value).A; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ====================================================================
        // BitArray (元素类型固定 bool, 单列, 不跑 int/val/ref):
        //   改(this[i]= bool ×SubOp) / 查(this[i] / Get ×SubOp) / 遍历
        // Packed 32 bits/int -> no per-element boxing; pure bit ops, GC ~= 0.
        // Naming: BitArray_<Op>_bool.
        // ====================================================================

        // ---- 改: this[i] = bool ×M (toggle pattern). Pure bit write, ~0 GC ----
        [Test, Performance]
        public void BitArray_Set_bool([Values(1, 100, 10000)] int n)
        {
            int m = Bench.SubOpCount(n);
            var ba = new BitArray(n);
            Bench.MeasureTimeAndGc(
                action: () => { for (int i = 0; i < m; i++) ba[i % n] = (i & 1) == 0; },
                setup: null, cleanup: null, n: n);
        }

        // ---- 查: this[i] / Get(i) read ×M. Pure bit read, ~0 GC ----
        [Test, Performance]
        public void BitArray_Get_bool([Values(1, 100, 10000)] int n)
        {
            int m = Bench.SubOpCount(n);
            var ba = new BitArray(n);
            for (int i = 0; i < n; i++) ba[i] = (i & 1) == 0;
            int sink = 0;
            Bench.MeasureTimeAndGc(
                action: () =>
                {
                    for (int i = 0; i < m; i++)
                    {
                        if (ba[i % n]) sink++;       // indexer read
                        if (ba.Get(i % n)) sink++;   // Get(i) read
                    }
                },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }

        // ---- 遍历: foreach full (enumerator yields boxed bool). ----
        [Test, Performance]
        public void BitArray_Iterate_bool([Values(1, 100, 10000)] int n)
        {
            var ba = new BitArray(n);
            for (int i = 0; i < n; i++) ba[i] = (i & 1) == 0;
            long sink = 0;
            Bench.MeasureTimeAndGc(
                action: () => { foreach (bool b in ba) if (b) sink++; },
                setup: null, cleanup: () => { if (sink < 0) UnityEngine.Debug.Log(sink); }, n: n);
        }
    }
}
