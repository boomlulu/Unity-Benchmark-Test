using System;
using System.Collections.Generic;
using Unity.PerformanceTesting;

// ============================================================================
// Collection Benchmark harness (Stage-1 foundation). Follows BENCHMARK_SPEC.md.
//
// Stage-2 reuse contract (DO NOT break signatures without updating callers):
//   Element types:      BenchInt-free; use int / ValStruct / RefElem.
//   Size constants:     Sizes.Normal = {10,1000,1000000}; Sizes.Quad = {1,100,10000}.
//   Sub-op count:       Bench.SubOpCount(n)        -> clamp(n,1,1000)
//                       Bench.LinearScanCount(n)   -> clamp(n,1,100)
//   Iteration scaling:  Bench.IterationsFor(n) / Bench.MeasurementsFor(n)
//   Source data cache:  Src.Ints(n) / Src.Vals(n) / Src.Refs(n)  (cached, reuse)
//   Combined measure:   Bench.MeasureTimeAndGc(name, action, setup, cleanup, n)
//                       -> records SampleGroup "Time"(ms via Measure) + "GC Allocated"(Bytes)
//   GC bytes only:      Bench.MeasureGcBytes(action, sampleGroup)
//   Naming convention:  test method name  <Collection>_<Op>_<Elem>_N<size>
//                       test class attr    [Category("<Family>")]
// ============================================================================

namespace CollectionBenchmarks
{
    /// <summary>~24B value struct. GetHashCode=>A, IEquatable for set/dict keys,
    /// IComparable (by A) for ordered sets (SortedSet/ImmutableSortedSet red-black tree).
    /// Stays unmanaged (no reference-type fields) so Native family `where T:unmanaged` still binds.</summary>
    public struct ValStruct : IEquatable<ValStruct>, IComparable<ValStruct>
    {
        public int A;
        public int B;
        public float C;
        public double D;

        public ValStruct(int a)
        {
            A = a;
            B = a + 1;
            C = a * 0.5f;
            D = a * 1.5;
        }

        public bool Equals(ValStruct other) => A == other.A && B == other.B && C == other.C && D == other.D;
        public override bool Equals(object obj) => obj is ValStruct v && Equals(v);
        public override int GetHashCode() => A;
        public int CompareTo(ValStruct other) => A.CompareTo(other.A);
    }

    /// <summary>Reference element. GetHashCode=>A, IEquatable for set/dict keys,
    /// IComparable (by A) for ordered sets (SortedSet/ImmutableSortedSet red-black tree).</summary>
    public sealed class RefElem : IEquatable<RefElem>, IComparable<RefElem>
    {
        public int A;
        public int B;

        public RefElem(int a)
        {
            A = a;
            B = a + 1;
        }

        public bool Equals(RefElem other) => other != null && A == other.A && B == other.B;
        public override bool Equals(object obj) => obj is RefElem r && Equals(r);
        public override int GetHashCode() => A;
        public int CompareTo(RefElem other) => other is null ? 1 : A.CompareTo(other.A);
    }

    /// <summary>Size ladders (SPEC §1).</summary>
    public static class Sizes
    {
        public static readonly int[] Normal = { 10, 1_000, 1_000_000 };
        public static readonly int[] Quad = { 1, 100, 10_000 };
    }

    /// <summary>
    /// Source-data builder. One cached source array per (N, elemType), reused across
    /// every measurement so element construction never pollutes a benchmark.
    /// </summary>
    public static class Src
    {
        static readonly Dictionary<int, int[]> _ints = new Dictionary<int, int[]>();
        static readonly Dictionary<int, ValStruct[]> _vals = new Dictionary<int, ValStruct[]>();
        static readonly Dictionary<int, RefElem[]> _refs = new Dictionary<int, RefElem[]>();
        static readonly Dictionary<int, bool[]> _bools = new Dictionary<int, bool[]>();

        public static int[] Ints(int n)
        {
            if (!_ints.TryGetValue(n, out var a))
            {
                a = new int[n];
                for (int i = 0; i < n; i++) a[i] = i;
                _ints[n] = a;
            }
            return a;
        }

        public static ValStruct[] Vals(int n)
        {
            if (!_vals.TryGetValue(n, out var a))
            {
                a = new ValStruct[n];
                for (int i = 0; i < n; i++) a[i] = new ValStruct(i);
                _vals[n] = a;
            }
            return a;
        }

        public static RefElem[] Refs(int n)
        {
            if (!_refs.TryGetValue(n, out var a))
            {
                a = new RefElem[n];
                for (int i = 0; i < n; i++) a[i] = new RefElem(i);
                _refs[n] = a;
            }
            return a;
        }

        public static bool[] Bools(int n)
        {
            if (!_bools.TryGetValue(n, out var a))
            {
                a = new bool[n];
                for (int i = 0; i < n; i++) a[i] = (i & 1) == 0;
                _bools[n] = a;
            }
            return a;
        }
    }

    /// <summary>Measurement helpers: GC bytes + combined Time/GC, iteration scaling, sub-op counts.</summary>
    public static class Bench
    {
        // ---- sub-operation counts (SPEC §3) -------------------------------
        public static int SubOpCount(int n) => Math.Max(1, Math.Min(n, 1000));
        public static int LinearScanCount(int n) => Math.Max(1, Math.Min(n, 100));

        // ---- iteration / measurement scaling (SPEC §4) --------------------
        public static int IterationsFor(int n)
        {
            if (n <= 100) return 1000;
            if (n <= 1000) return 100;
            if (n <= 10000) return 10;
            return 1; // 1m
        }

        public static int MeasurementsFor(int n)
        {
            if (n <= 1000) return 20;
            if (n <= 10000) return 15;
            return 7; // 1m
        }

        public static int WarmupFor(int n) => n >= 1_000_000 ? 1 : 3;

        // ---- GC byte measurement (SPEC §4) --------------------------------
        // IMPORTANT (Unity 2022.3 Mono): GC.GetAllocatedBytesForCurrentThread() is a
        // STUB that always returns 0 in this runtime (verified empirically). The only
        // working byte counter is GC.GetTotalMemory(false), which is process-global and
        // noisy. So we measure with GetTotalMemory, but:
        //   * settle the heap (Collect + WaitForPendingFinalizers + Collect) before baseline,
        //   * run the action GcReps times keeping every result alive (sink) so nothing is
        //     reclaimed mid-window, then divide the total delta by GcReps to average noise out.
        // GcReps is small for big-N builds (already large per-call) and large for tiny ops.
        //
        // KNOWN LIMITATION (Stage-2 read this): GetTotalMemory has coarse (~tens of KB)
        // resolution against the live heap. It reliably reports:
        //   * non-allocating ops as ~0 (lookups / iterate / NativeArray)  -> trustworthy
        //   * large contiguous-array allocations (List/ArrayList growth)   -> trustworthy
        // but it can UNDER-RESOLVE allocation-heavy ops whose result is many small scattered
        // objects collected/compacted mid-build (e.g. ImmutableList AVL-tree builder reads 0
        // even though it allocates ~tens of KB). Treat a 0 on a *build* op as "below the
        // GetTotalMemory floor", not as proof of zero allocation. There is no per-thread
        // allocation counter available in this runtime to do better.
        public static long TotalMemory() => GC.GetTotalMemory(false);

        public static int GcRepsFor(int n)
        {
            if (n >= 100_000) return 1;     // each build already huge
            if (n >= 1_000) return 8;
            if (n >= 100) return 64;
            return 256;                      // tiny ops: many reps to clear GetTotalMemory noise
        }

        static void SettleHeap()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        /// Records the net managed bytes allocated by <paramref name="action"/> into the given
        /// SampleGroup (Bytes), averaged over <paramref name="reps"/> invocations. Each invocation
        /// runs <paramref name="rebuild"/> first (to reset destructive targets) — rebuild is run
        /// OUTSIDE the counted window. Results are pinned in a sink so they survive the window.
        /// </summary>
        public static void MeasureGcBytes(Action action, SampleGroup group, int reps = 1,
            Action rebuild = null)
        {
            if (reps < 1) reps = 1;

            // Baseline pass: run only the rebuild (same as real pass minus `action`) to
            // capture ambient allocation (rebuild + harness/GC bookkeeping) so we can
            // subtract it from the real measurement.
            SettleHeap();
            long b0 = TotalMemory();
            for (int i = 0; i < reps; i++) rebuild?.Invoke();
            long b1 = TotalMemory();
            long baseDelta = b1 - b0;
            if (baseDelta < 0) baseDelta = 0;

            // Measured pass: rebuild + action.
            SettleHeap();
            long before = TotalMemory();
            for (int i = 0; i < reps; i++)
            {
                rebuild?.Invoke();
                action();
            }
            long after = TotalMemory();
            long delta = (after - before) - baseDelta;
            if (delta < 0) delta = 0;
            Measure.Custom(group, (double)delta / reps);
        }

        /// <summary>
        /// Build-op variant: <paramref name="produce"/> returns the freshly built object; every
        /// rep's result is PINNED in a sink so the background GC cannot reclaim transient garbage
        /// mid-window. This makes the GetTotalMemory live-heap delta reflect TOTAL allocation,
        /// which matters for allocation-heavy builders (e.g. ImmutableList) whose intermediate
        /// instances would otherwise be collected and undercount. Sink is dropped after measure.
        /// </summary>
        public static void MeasureGcBytesProducing(Func<object> produce, SampleGroup group, int reps = 1)
        {
            if (reps < 1) reps = 1;
            // Take the MAX per-rep delta over a few attempts: the attempt with the least
            // mid-window concurrent-GC interference yields the truest (largest) live-heap rise.
            const int attempts = 3;
            double best = 0;
            for (int a = 0; a < attempts; a++)
            {
                var sink = new object[reps];
                SettleHeap();
                long before = TotalMemory();
                for (int i = 0; i < reps; i++) sink[i] = produce();
                long after = TotalMemory();
                long delta = after - before;
                double per = delta > 0 ? (double)delta / reps : 0;
                if (per > best) best = per;
                for (int i = 0; i < reps; i++) sink[i] = null; // release before next attempt
            }
            Measure.Custom(group, best);
        }

        /// <summary>
        /// Combined measure for BUILD ops (action allocates+returns a collection). Time via
        /// Measure.Method; GC via pinned-sink producing method (no undercount on heavy builders).
        /// </summary>
        public static void MeasureTimeAndGcProducing(
            Func<object> produce,
            int n,
            string gcSampleName = "GC Allocated")
        {
            var m = Measure.Method(() => { var _ = produce(); })
                .WarmupCount(WarmupFor(n))
                .MeasurementCount(MeasurementsFor(n))
                .IterationsPerMeasurement(IterationsFor(n));
            m.Run();

            // Build ops allocate enough per call to measure in ONE rep; using reps=1 avoids
            // mid-window concurrent GC compacting transient builder garbage (which would make
            // GetTotalMemory's live-heap delta undercount, e.g. ImmutableList builder -> 0).
            var gcGroup = new SampleGroup(gcSampleName, SampleUnit.Byte);
            MeasureGcBytesProducing(produce, gcGroup, 1);
        }

        /// <summary>
        /// Combined measure: records Time(ms) via Measure.Method (warmup/measure/iterate per N)
        /// AND "GC Allocated"(Bytes) via the GetTotalMemory rep-averaged method.
        /// setup/cleanup rebuild destructive targets and are NOT counted (SPEC §3).
        /// Use this for IN-PLACE ops (lookups / writes / iterate) that allocate ~0, or whose
        /// allocation lives in a field. For BUILD ops use MeasureTimeAndGcProducing instead.
        /// </summary>
        public static void MeasureTimeAndGc(
            Action action,
            Action setup,
            Action cleanup,
            int n,
            string gcSampleName = "GC Allocated")
        {
            // --- Time(ms): standard Performance harness ---
            var m = Measure.Method(action)
                .WarmupCount(WarmupFor(n))
                .MeasurementCount(MeasurementsFor(n))
                .IterationsPerMeasurement(IterationsFor(n));
            if (setup != null) m = m.SetUp(setup);
            if (cleanup != null) m = m.CleanUp(cleanup);
            m.Run();

            // --- GC Allocated(Bytes): rep-averaged GetTotalMemory delta ---
            var gcGroup = new SampleGroup(gcSampleName, SampleUnit.Byte);
            int reps = GcRepsFor(n);
            setup?.Invoke();
            MeasureGcBytes(action, gcGroup, reps, rebuild: setup);
            cleanup?.Invoke();
        }
    }
}
