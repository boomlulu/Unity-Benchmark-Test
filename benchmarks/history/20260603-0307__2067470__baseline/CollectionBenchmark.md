# Collection Benchmark Results

Rows: 1521  (generated 2026-06-03)

| 家族 | 集合 | 操作 | 元素类型 | N | 时间中位(ms) | GC(bytes) | Big-O 时间 | Big-O 空间 | 备注 |
|---|---|---|---|---|---|---|---|---|---|
| Concurrent | BlockingCollection | Add | class | 1 | 0.1245 | 0 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | class | 100 | 8.613 | 4096 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | class | 10000 | 7.095 | 286720 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | int | 1 | 0.1192 | 0 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | int | 100 | 7.789 | 0 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | int | 10000 | 6.321 | 151552 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | struct | 1 | 0.122 | 0 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | struct | 100 | 7.993 | 12288 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | struct | 10000 | 6.923 | 552960 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Iterate | class | 1 | 0.1626 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | class | 100 | 1.708 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | class | 10000 | 1.506 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | int | 1 | 0.1475 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | int | 100 | 1.099 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | int | 10000 | 0.941 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | struct | 1 | 0.1572 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | struct | 100 | 1.24 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | struct | 10000 | 1.076 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Remove | class | 1 | 0.1789 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | class | 100 | 13.32 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | class | 10000 | 13.44 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | int | 1 | 0.167 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | int | 100 | 12.61 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | int | 10000 | 12.4 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | struct | 1 | 0.1719 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | struct | 100 | 12.73 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | struct | 10000 | 12.44 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentBag | Add | class | 1 | 0.627 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | class | 100 | 5.249 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | class | 10000 | 4.278 | 286720 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | int | 1 | 0.6013 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | int | 100 | 4.302 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | int | 10000 | 3.393 | 151552 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | struct | 1 | 0.6991 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | struct | 100 | 5.531 | 4096 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | struct | 10000 | 3.865 | 811008 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Iterate | class | 1 | 0.179 | 0 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | class | 100 | 2.44 | 0 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | class | 10000 | 2.215 | 81920 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | int | 1 | 0.1562 | 0 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | int | 100 | 1.158 | 448 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | int | 10000 | 0.948 | 40960 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | struct | 1 | 0.1662 | 0 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | struct | 100 | 1.819 | 4096 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | struct | 10000 | 1.237 | 241664 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Remove | class | 1 | 0.1595 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | class | 100 | 4.887 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | class | 10000 | 4.713 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | int | 1 | 0.1338 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | int | 100 | 3.588 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | int | 10000 | 3.406 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | struct | 1 | 0.1352 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | struct | 100 | 3.802 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | struct | 10000 | 3.933 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | class | 1 | 0.7417 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | class | 100 | 16.08 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | class | 10000 | 16.72 | 360448 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | int | 1 | 0.7087 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | int | 100 | 14.69 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | int | 10000 | 14.94 | 360448 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | struct | 1 | 0.6895 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | struct | 100 | 16.12 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | struct | 10000 | 17.14 | 360448 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | class | 1 | 0.06285 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | class | 100 | 2.191 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | class | 10000 | 0.2155 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | int | 1 | 0.0445 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | int | 100 | 1.558 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | int | 10000 | 0.164 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | struct | 1 | 0.0431 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | struct | 100 | 1.718 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | struct | 10000 | 0.1692 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | class | 1 | 0.3603 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | class | 100 | 3.693 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | class | 10000 | 3.89 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | int | 1 | 0.3106 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | int | 100 | 2.69 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | int | 10000 | 2.943 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | struct | 1 | 0.3099 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | struct | 100 | 3.024 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | struct | 10000 | 3.244 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | class | 1 | 0.0859 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | class | 100 | 5.755 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | class | 10000 | 0.5732 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | int | 1 | 0.08095 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | int | 100 | 4.888 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | int | 10000 | 0.4916 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | struct | 1 | 0.0851 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | struct | 100 | 5.246 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | struct | 10000 | 0.5062 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | class | 1 | 0.0646 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | class | 100 | 4.981 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | class | 10000 | 0.4967 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | int | 1 | 0.0445 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | int | 100 | 3.888 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | int | 10000 | 0.367 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | struct | 1 | 0.09095 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | struct | 100 | 8.696 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | struct | 10000 | 0.8279 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentQueue | Add | class | 1 | 0.2938 | 0 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | class | 100 | 3.159 | 4096 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | class | 10000 | 2.035 | 286720 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | int | 1 | 0.2343 | 0 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | int | 100 | 2.019 | 0 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | int | 10000 | 1.197 | 151552 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | struct | 1 | 0.3405 | 0 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | struct | 100 | 2.866 | 12288 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | struct | 10000 | 1.56 | 552960 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Contains | class | 1 | 0.162 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | class | 100 | 127.1 | 5056 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | class | 10000 | 1.251 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | int | 1 | 0.1692 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | int | 100 | 72.13 | 4992 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | int | 10000 | 0.7847 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | struct | 1 | 0.1593 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | struct | 100 | 96.69 | 6208 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | struct | 10000 | 0.9661 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | class | 1 | 0.1505 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | class | 100 | 1.707 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | class | 10000 | 1.519 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | int | 1 | 0.142 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | int | 100 | 1.105 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | int | 10000 | 0.949 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | struct | 1 | 0.1406 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | struct | 100 | 1.25 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | struct | 10000 | 1.075 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | class | 1 | 0.0663 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | class | 100 | 1.775 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | class | 10000 | 1.648 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | int | 1 | 0.0594 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | int | 100 | 1.17 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | int | 10000 | 1.029 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | struct | 1 | 0.0633 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | struct | 100 | 1.25 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | struct | 10000 | 1.113 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Add | class | 1 | 0.109 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | class | 100 | 4.708 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | class | 10000 | 4.535 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | int | 1 | 0.08415 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | int | 100 | 3.73 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | int | 10000 | 3.744 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | struct | 1 | 0.0914 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | struct | 100 | 4.019 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | struct | 10000 | 3.781 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Iterate | class | 1 | 0.1045 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | class | 100 | 1.858 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | class | 10000 | 1.741 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | int | 1 | 0.08725 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | int | 100 | 1.168 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | int | 10000 | 1.126 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | struct | 1 | 0.09455 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | struct | 100 | 1.38 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | struct | 10000 | 1.301 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | class | 1 | 0.04115 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | class | 100 | 0.9614 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | class | 10000 | 0.0919 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | int | 1 | 0.03575 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | int | 100 | 0.3893 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | int | 10000 | 0.0358 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | struct | 1 | 0.03735 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | struct | 100 | 0.4654 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | struct | 10000 | 0.0421 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | class | 1 | 0.0589 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | class | 100 | 1.931 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | class | 10000 | 1.901 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | int | 1 | 0.0534 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | int | 100 | 1.298 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | int | 10000 | 1.296 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | struct | 1 | 0.04985 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | struct | 100 | 1.364 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | struct | 10000 | 1.359 | 68096 | O(1) | O(1) |  |
| Generic | Array | Get | class | 1 | 0.037 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | class | 100 | 0.7475 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | class | 10000 | 0.0694 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | int | 1 | 0.02825 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | int | 100 | 0.1138 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | int | 10000 | 0.0093 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | struct | 1 | 0.02985 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | struct | 100 | 0.1569 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | struct | 10000 | 0.0138 | 0 | O(1) | O(1) |  |
| Generic | Array | Iterate | class | 1 | 0.02915 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | class | 100 | 0.1966 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | class | 10000 | 0.1876 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | int | 1 | 0.045 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | int | 100 | 2.027 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | int | 10000 | 1.979 | 176640 | O(n) | O(1) |  |
| Generic | Array | Iterate | struct | 1 | 0.0554 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | struct | 100 | 2.305 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | struct | 10000 | 2.018 | 285184 | O(n) | O(1) |  |
| Generic | Array | Set | class | 1 | 0.0093 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | class | 100 | 0.743 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | class | 10000 | 0.0693 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | int | 1 | 0.0031 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | int | 100 | 0.1083 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | int | 10000 | 0.0103 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | struct | 1 | 0.0039 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | struct | 100 | 0.1382 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | struct | 10000 | 0.0133 | 0 | O(1) | O(1) |  |
| Generic | Dictionary | Add | class | 1 | 0.1609 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | class | 100 | 4.963 | 12288 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | class | 10000 | 2.569 | 962560 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | int | 1 | 0.1074 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | int | 100 | 5.011 | 4096 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | int | 10000 | 1.971 | 684032 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | struct | 1 | 0.1296 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | struct | 100 | 4.082 | 12288 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | struct | 10000 | 2.295 | 1.49504e+06 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Get | class | 1 | 0.04915 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | class | 100 | 2.065 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | class | 10000 | 0.1995 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | int | 1 | 0.06135 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | int | 100 | 3.226 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | int | 10000 | 0.3143 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | struct | 1 | 0.0658 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | struct | 100 | 3.624 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | struct | 10000 | 0.3602 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Iterate | class | 1 | 0.07765 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | class | 100 | 1.994 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | class | 10000 | 1.997 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | int | 1 | 0.06165 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | int | 100 | 1.078 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | int | 10000 | 1.036 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | struct | 1 | 0.06195 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | struct | 100 | 1.26 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | struct | 10000 | 1.235 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Remove | class | 1 | 0.04375 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | class | 100 | 1.473 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | class | 10000 | 0.1489 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | int | 1 | 0.0429 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | int | 100 | 1.374 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | int | 10000 | 0.1396 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | struct | 1 | 0.04365 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | struct | 100 | 1.354 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | struct | 10000 | 0.1387 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | class | 1 | 0.0243 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | class | 100 | 2.118 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | class | 10000 | 0.2103 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | int | 1 | 0.0147 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | int | 100 | 1.448 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | int | 10000 | 0.14 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | struct | 1 | 0.0174 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | struct | 100 | 1.859 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | struct | 10000 | 0.1769 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Add | class | 1 | 0.1647 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | class | 100 | 5.425 | 4096 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | class | 10000 | 3.959 | 684032 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | int | 1 | 0.1145 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | int | 100 | 3.056 | 4096 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | int | 10000 | 2.047 | 552960 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | struct | 1 | 0.1313 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | struct | 100 | 4.117 | 12288 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | struct | 10000 | 2.932 | 1.2288e+06 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Contains | class | 1 | 0.04465 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | class | 100 | 2.969 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | class | 10000 | 0.3038 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | int | 1 | 0.03475 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | int | 100 | 1.335 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | int | 10000 | 0.1242 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | struct | 1 | 0.0462 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | struct | 100 | 2.329 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | struct | 10000 | 0.2201 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Iterate | class | 1 | 0.06855 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | class | 100 | 1.132 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | class | 10000 | 1.08 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | int | 1 | 0.07165 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | int | 100 | 2.388 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | int | 10000 | 2.073 | 148992 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | struct | 1 | 0.0862 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | struct | 100 | 2.895 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | struct | 10000 | 2.543 | 257536 | O(n) | O(1) |  |
| Generic | HashSet | Remove | class | 1 | 0.0583 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | class | 100 | 3.386 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | class | 10000 | 0.3442 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | int | 1 | 0.0433 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | int | 100 | 1.511 | 64 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | int | 10000 | 0.1503 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | struct | 1 | 0.04995 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | struct | 100 | 2.355 | 64 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | struct | 10000 | 0.2534 | 0 | O(1) avg | O(1) |  |
| Generic | LinkedList | Add | class | 1 | 0.1071 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | class | 100 | 5.997 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | class | 10000 | 5.773 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | int | 1 | 0.08485 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | int | 100 | 5.148 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | int | 10000 | 4.866 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | struct | 1 | 0.08285 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | struct | 100 | 5.485 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | struct | 10000 | 5.452 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | class | 1 | 0.1132 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | class | 100 | 6.988 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | class | 10000 | 6.428 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | int | 1 | 0.09095 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | int | 100 | 5.666 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | int | 10000 | 5.299 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | struct | 1 | 0.0828 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | struct | 100 | 6.508 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | struct | 10000 | 6.209 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | Contains | class | 1 | 0.0426 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | class | 100 | 48.19 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | class | 10000 | 0.4715 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | int | 1 | 0.0376 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | int | 100 | 19.02 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | int | 10000 | 0.1864 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | struct | 1 | 0.0437 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | struct | 100 | 37.35 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | struct | 10000 | 0.3613 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | class | 1 | 0.0906 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | class | 100 | 1.619 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | class | 10000 | 1.569 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | int | 1 | 0.08995 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | int | 100 | 2.823 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | int | 10000 | 2.53 | 148992 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | struct | 1 | 0.0965 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | struct | 100 | 3.326 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | struct | 10000 | 3.229 | 257536 | O(n) | O(1) |  |
| Generic | LinkedList | Remove | class | 1 | 0.0364 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | class | 100 | 2.157 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | class | 10000 | 2.187 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | int | 1 | 0.03815 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | int | 100 | 2.285 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | int | 10000 | 2.137 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | struct | 1 | 0.0372 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | struct | 100 | 2.11 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | struct | 10000 | 2.23 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | List | Add | class | 1 | 0.1403 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | class | 100 | 1.979 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | class | 10000 | 1.227 | 286720 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | int | 1 | 0.0684 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | int | 100 | 0.7758 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | int | 10000 | 0.4298 | 151552 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | struct | 1 | 0.09265 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | struct | 100 | 1.527 | 4096 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | struct | 10000 | 0.8577 | 811008 | O(1) amortized | O(1) amortized |  |
| Generic | List | Contains | class | 1 | 0.0649 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | class | 100 | 20.54 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | class | 10000 | 0.2515 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | int | 1 | 0.04135 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | int | 100 | 12.52 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | int | 10000 | 0.1306 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | struct | 1 | 0.0524 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | struct | 100 | 16.62 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | struct | 10000 | 0.1745 | 0 | O(n) | O(1) |  |
| Generic | List | Get | class | 1 | 0.04185 | 0 | O(1) | O(1) |  |
| Generic | List | Get | class | 100 | 1.037 | 0 | O(1) | O(1) |  |
| Generic | List | Get | class | 10000 | 0.0942 | 0 | O(1) | O(1) |  |
| Generic | List | Get | int | 1 | 0.0304 | 0 | O(1) | O(1) |  |
| Generic | List | Get | int | 100 | 0.2867 | 0 | O(1) | O(1) |  |
| Generic | List | Get | int | 10000 | 0.0244 | 0 | O(1) | O(1) |  |
| Generic | List | Get | struct | 1 | 0.0292 | 0 | O(1) | O(1) |  |
| Generic | List | Get | struct | 100 | 0.3823 | 0 | O(1) | O(1) |  |
| Generic | List | Get | struct | 10000 | 0.0313 | 0 | O(1) | O(1) |  |
| Generic | List | InsertHead | class | 1 | 0.1139 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | class | 100 | 5.022 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | class | 10000 | 113.5 | 286720 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | int | 1 | 0.0679 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | int | 100 | 2.323 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | int | 10000 | 19.59 | 151552 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | struct | 1 | 0.07965 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | struct | 100 | 7.018 | 4096 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | struct | 10000 | 336.6 | 811008 | O(n) per insert | O(1) amortized |  |
| Generic | List | Iterate | class | 1 | 0.07465 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | class | 100 | 1.112 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | class | 10000 | 1.051 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | int | 1 | 0.0731 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | int | 100 | 2.38 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | int | 10000 | 2.099 | 148992 | O(n) | O(1) |  |
| Generic | List | Iterate | struct | 1 | 0.0878 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | struct | 100 | 2.811 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | struct | 10000 | 2.458 | 258048 | O(n) | O(1) |  |
| Generic | List | Remove | class | 1 | 0.0456 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | class | 100 | 1.078 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | class | 10000 | 1.037 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | int | 1 | 0.0378 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | int | 100 | 0.3219 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | int | 10000 | 0.2998 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | struct | 1 | 0.03495 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | struct | 100 | 0.315 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | struct | 10000 | 0.262 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Set | class | 1 | 0.0161 | 0 | O(1) | O(1) |  |
| Generic | List | Set | class | 100 | 1.038 | 0 | O(1) | O(1) |  |
| Generic | List | Set | class | 10000 | 0.1003 | 0 | O(1) | O(1) |  |
| Generic | List | Set | int | 1 | 0.005 | 0 | O(1) | O(1) |  |
| Generic | List | Set | int | 100 | 0.5228 | 0 | O(1) | O(1) |  |
| Generic | List | Set | int | 10000 | 0.0534 | 0 | O(1) | O(1) |  |
| Generic | List | Set | struct | 1 | 0.0055 | 0 | O(1) | O(1) |  |
| Generic | List | Set | struct | 100 | 0.3764 | 0 | O(1) | O(1) |  |
| Generic | List | Set | struct | 10000 | 0.0348 | 0 | O(1) | O(1) |  |
| Generic | Queue | Add | class | 1 | 0.1154 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | class | 100 | 2.102 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | class | 10000 | 1.378 | 286720 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | int | 1 | 0.07525 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | int | 100 | 0.983 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | int | 10000 | 0.5769 | 151552 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | struct | 1 | 0.0846 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | struct | 100 | 2.034 | 4096 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | struct | 10000 | 0.9342 | 811008 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Contains | class | 1 | 0.06065 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | class | 100 | 20.18 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | class | 10000 | 0.2158 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | int | 1 | 0.05705 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | int | 100 | 12.4 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | int | 10000 | 0.1429 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | struct | 1 | 0.07265 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | struct | 100 | 17.62 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | struct | 10000 | 0.1727 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Iterate | class | 1 | 0.07155 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | class | 100 | 1.206 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | class | 10000 | 1.127 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | int | 1 | 0.0739 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | int | 100 | 2.491 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | int | 10000 | 2.243 | 148992 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | struct | 1 | 0.08815 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | struct | 100 | 3.023 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | struct | 10000 | 2.704 | 258560 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Remove | class | 1 | 0.0497 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | class | 100 | 1.32 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | class | 10000 | 1.263 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | int | 1 | 0.0369 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | int | 100 | 0.6148 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | int | 10000 | 0.5784 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | struct | 1 | 0.03805 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | struct | 100 | 0.7695 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | struct | 10000 | 0.7259 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | SortedDictionary | Add | class | 1 | 0.1704 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | class | 100 | 28.09 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | class | 10000 | 48.02 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | int | 1 | 0.1497 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | int | 100 | 26.65 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | int | 10000 | 46.27 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | struct | 1 | 0.1532 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | struct | 100 | 29 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | struct | 10000 | 50.83 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Get | class | 1 | 0.068 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | class | 100 | 10.97 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | class | 10000 | 1.896 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | int | 1 | 0.0678 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | int | 100 | 12.01 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | int | 10000 | 2.19 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | struct | 1 | 0.08505 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | struct | 100 | 12.83 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | struct | 10000 | 2.161 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Iterate | class | 1 | 0.2496 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | class | 100 | 5.434 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | class | 10000 | 5.177 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | int | 1 | 0.2362 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | int | 100 | 5.318 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | int | 10000 | 5.143 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | struct | 1 | 0.2463 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | struct | 100 | 5.129 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | struct | 10000 | 5.348 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Remove | class | 1 | 0.09025 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | class | 100 | 23.33 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | class | 10000 | 5.166 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | int | 1 | 0.0759 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | int | 100 | 22.45 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | int | 10000 | 5.059 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | struct | 1 | 0.0836 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | struct | 100 | 23.59 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | struct | 10000 | 5.238 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | class | 1 | 0.0447 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | class | 100 | 12.03 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | class | 10000 | 1.974 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | int | 1 | 0.0238 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | int | 100 | 10.85 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | int | 10000 | 2.079 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | struct | 1 | 0.0365 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | struct | 100 | 11.72 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | struct | 10000 | 2.114 | 0 | O(log n) | O(1) |  |
| Generic | SortedList | Add | class | 1 | 0.1484 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | class | 100 | 6.062 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | class | 10000 | 7.993 | 438272 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | int | 1 | 0.1239 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | int | 100 | 4.81 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | int | 10000 | 7.03 | 303104 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | struct | 1 | 0.1404 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | struct | 100 | 5.864 | 4096 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | struct | 10000 | 7.512 | 962560 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Get | class | 1 | 0.05515 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | class | 100 | 6.032 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | class | 10000 | 0.8716 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | int | 1 | 0.0611 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | int | 100 | 7.28 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | int | 10000 | 1.01 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | struct | 1 | 0.0687 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | struct | 100 | 7.76 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | struct | 10000 | 1.065 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Iterate | class | 1 | 0.1117 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | class | 100 | 2.357 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | class | 10000 | 2.27 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | int | 1 | 0.09895 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | int | 100 | 1.331 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | int | 10000 | 1.23 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | struct | 1 | 0.09585 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | struct | 100 | 1.481 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | struct | 10000 | 1.413 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Remove | class | 1 | 0.05995 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | class | 100 | 9.385 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | class | 10000 | 26.45 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | int | 1 | 0.04765 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | int | 100 | 7.14 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | int | 10000 | 7.874 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | struct | 1 | 0.04845 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | struct | 100 | 11.33 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | struct | 10000 | 71.45 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Set | class | 1 | 0.0273 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | class | 100 | 5.729 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | class | 10000 | 0.8805 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | int | 1 | 0.01875 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | int | 100 | 4.068 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | int | 10000 | 0.8332 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | struct | 1 | 0.0179 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | struct | 100 | 4.253 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | struct | 10000 | 0.828 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedSet | Add | class | 1 | 0.1313 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | class | 100 | 34.68 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | class | 10000 | 63.3 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | int | 1 | 0.0775 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | int | 100 | 21.05 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | int | 10000 | 35.33 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | struct | 1 | 0.0863 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | struct | 100 | 25.43 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | struct | 10000 | 45.86 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Contains | class | 1 | 0.0483 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | class | 100 | 11.35 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | class | 10000 | 2.142 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | int | 1 | 0.0343 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | int | 100 | 5.349 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | int | 10000 | 1.032 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | struct | 1 | 0.04275 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | struct | 100 | 8.878 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | struct | 10000 | 1.751 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Iterate | class | 1 | 0.22 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | class | 100 | 5.01 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | class | 10000 | 4.721 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | int | 1 | 0.2186 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | int | 100 | 6.888 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | int | 10000 | 6.542 | 148992 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | struct | 1 | 0.2201 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | struct | 100 | 7.022 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | struct | 10000 | 6.754 | 260096 | O(n) | O(1) |  |
| Generic | SortedSet | Remove | class | 1 | 0.0893 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | class | 100 | 27.22 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | class | 10000 | 6.382 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | int | 1 | 0.0637 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | int | 100 | 18.6 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | int | 10000 | 4.069 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | struct | 1 | 0.07375 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | struct | 100 | 21.12 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | struct | 10000 | 4.988 | 0 | O(log n) | O(1) |  |
| Generic | Stack | Add | class | 1 | 0.1328 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | class | 100 | 1.859 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | class | 10000 | 1.158 | 286720 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | int | 1 | 0.08705 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | int | 100 | 0.7527 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | int | 10000 | 0.3963 | 151552 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | struct | 1 | 0.0972 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | struct | 100 | 1.502 | 4096 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | struct | 10000 | 0.6311 | 811008 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Contains | class | 1 | 0.07415 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | class | 100 | 20.45 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | class | 10000 | 31.67 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | int | 1 | 0.06145 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | int | 100 | 12.67 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | int | 10000 | 20.73 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | struct | 1 | 0.0815 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | struct | 100 | 19.95 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | struct | 10000 | 30.27 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Iterate | class | 1 | 0.0722 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | class | 100 | 1.186 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | class | 10000 | 1.077 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | int | 1 | 0.0747 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | int | 100 | 2.492 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | int | 10000 | 2.215 | 148992 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | struct | 1 | 0.0882 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | struct | 100 | 2.953 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | struct | 10000 | 2.494 | 260608 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Remove | class | 1 | 0.04755 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | class | 100 | 1.166 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | class | 10000 | 1.119 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | int | 1 | 0.0356 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | int | 100 | 0.4648 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | int | 10000 | 0.422 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | struct | 1 | 0.0379 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | struct | 100 | 0.6715 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | struct | 10000 | 0.6313 | 0 | O(1) per Pop | O(1) |  |
| Immutable | ImmutableArray | AddOne | class | 1 | 0.159 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | class | 100 | 0.3502 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | class | 10000 | 0.0428 | 81920 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | int | 1 | 0.2514 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | int | 100 | 0.1471 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | int | 10000 | 0.0398 | 40960 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | struct | 1 | 0.0901 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | struct | 100 | 0.749 | 4096 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | struct | 10000 | 0.1147 | 241664 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | Build | class | 1 | 0.2261 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | class | 100 | 2.085 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | class | 10000 | 1.088 | 163840 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | int | 1 | 0.1362 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | int | 100 | 0.7997 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | int | 10000 | 0.7055 | 81920 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | struct | 1 | 0.1459 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | struct | 100 | 1.831 | 8192 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | struct | 10000 | 0.8742 | 483328 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Contains | class | 1 | 0.1101 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | class | 100 | 23.73 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | class | 10000 | 0.237 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | int | 1 | 0.06215 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | int | 100 | 13.89 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | int | 10000 | 0.1366 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | struct | 1 | 0.072 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | struct | 100 | 20.16 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | struct | 10000 | 0.2256 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Index | class | 1 | 0.03375 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | class | 100 | 0.7938 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | class | 10000 | 0.0704 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | int | 1 | 0.04165 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | int | 100 | 0.581 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | int | 10000 | 0.0554 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | struct | 1 | 0.03435 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | struct | 100 | 0.712 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | struct | 10000 | 0.0622 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Iterate | class | 1 | 0.06235 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | class | 100 | 0.5082 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | class | 10000 | 0.4351 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | int | 1 | 0.04495 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | int | 100 | 0.4052 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | int | 10000 | 0.3414 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | struct | 1 | 0.04885 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | struct | 100 | 0.5169 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | struct | 10000 | 0.454 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | RemoveAt | class | 1 | 0.1426 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | class | 100 | 0.3307 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | class | 10000 | 0.032 | 81920 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | int | 1 | 0.0969 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | int | 100 | 0.1583 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | int | 10000 | 0.0434 | 40960 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | struct | 1 | 0.098 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | struct | 100 | 0.6899 | 4096 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | struct | 10000 | 0.1221 | 241664 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | SetItem | class | 1 | 0.1441 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | class | 100 | 0.3474 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | class | 10000 | 0.0308 | 81920 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | int | 1 | 0.08695 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | int | 100 | 0.1298 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | int | 10000 | 0.0445 | 40960 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | struct | 1 | 0.08445 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | struct | 100 | 0.6871 | 4096 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | struct | 10000 | 0.1046 | 241664 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableDictionary | Build | class | 1 | 0.3703 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | class | 100 | 41.06 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | class | 10000 | 64.06 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | int | 1 | 0.3189 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | int | 100 | 34.76 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | int | 10000 | 55.78 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | struct | 1 | 0.3444 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | struct | 100 | 39.34 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | struct | 10000 | 60.7 | 405504 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Get | class | 1 | 0.1017 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | class | 100 | 7.636 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | class | 10000 | 0.9103 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | int | 1 | 0.0819 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | int | 100 | 6.828 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | int | 10000 | 0.8136 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | struct | 1 | 0.08235 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | struct | 100 | 7.046 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | struct | 10000 | 0.8473 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Iterate | class | 1 | 0.5146 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | class | 100 | 16.71 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | class | 10000 | 16.55 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | int | 1 | 0.48 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | int | 100 | 13.47 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | int | 10000 | 13.28 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | struct | 1 | 0.4964 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | struct | 100 | 14.11 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | struct | 10000 | 14.01 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Remove | class | 1 | 0.1293 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | class | 100 | 0.8735 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | class | 10000 | 0.0172 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | int | 1 | 0.09915 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | int | 100 | 0.7021 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | int | 10000 | 0.0144 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | struct | 1 | 0.1045 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | struct | 100 | 0.8374 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | struct | 10000 | 0.015 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | SetItem | class | 1 | 0.4021 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | class | 100 | 1.079 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | class | 10000 | 0.0191 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | int | 1 | 0.3047 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | int | 100 | 0.8074 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | int | 10000 | 0.015 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | struct | 1 | 0.3451 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | struct | 100 | 1.006 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | struct | 10000 | 0.0164 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | class | 1 | 0.4218 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | class | 100 | 1.108 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | class | 10000 | 0.02 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | int | 1 | 0.3578 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | int | 100 | 0.8687 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | int | 10000 | 0.0164 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | struct | 1 | 0.3849 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | struct | 100 | 1.065 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | struct | 10000 | 0.018 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | class | 1 | 0.5286 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | class | 100 | 1.222 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | class | 10000 | 0.0225 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | int | 1 | 0.3413 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | int | 100 | 0.8294 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | int | 10000 | 0.0165 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | struct | 1 | 0.3735 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | struct | 100 | 0.9698 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | struct | 10000 | 0.0188 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | Build | class | 1 | 0.5219 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | class | 100 | 48.02 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | class | 10000 | 75.24 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | int | 1 | 0.3347 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | int | 100 | 35.96 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | int | 10000 | 56.7 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | struct | 1 | 0.3587 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | struct | 100 | 39.68 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | struct | 10000 | 61.54 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Contains | class | 1 | 0.1407 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | class | 100 | 11.96 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | class | 10000 | 1.311 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | int | 1 | 0.1012 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | int | 100 | 8.32 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | int | 10000 | 0.9689 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | struct | 1 | 0.1059 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | struct | 100 | 8.99 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | struct | 10000 | 1.046 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Iterate | class | 1 | 0.5654 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | class | 100 | 19.82 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | class | 10000 | 18.98 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | int | 1 | 0.4836 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | int | 100 | 13.45 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | int | 10000 | 13.28 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | struct | 1 | 0.4952 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | struct | 100 | 14.71 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | struct | 10000 | 14.58 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Remove | class | 1 | 0.2803 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | class | 100 | 1.016 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | class | 10000 | 0.0198 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | int | 1 | 0.1641 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | int | 100 | 0.6715 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | int | 10000 | 0.0142 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | struct | 1 | 0.1854 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | struct | 100 | 0.7872 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | struct | 10000 | 0.0161 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableList | AddOne | class | 1 | 0.2629 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | class | 100 | 0.6247 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | class | 10000 | 0.0142 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | int | 1 | 0.1657 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | int | 100 | 0.3917 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | int | 10000 | 0.0091 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | struct | 1 | 0.1505 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | struct | 100 | 0.428 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | struct | 10000 | 0.0093 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | Build | class | 1 | 0.2521 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | class | 100 | 32.92 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | class | 10000 | 54.77 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | int | 1 | 0.1732 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | int | 100 | 20.6 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | int | 10000 | 34.23 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | struct | 1 | 0.1625 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | struct | 100 | 22.07 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | struct | 10000 | 36.69 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Contains | class | 1 | 0.4732 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | class | 100 | 698 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | class | 10000 | 7.334 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | int | 1 | 0.3803 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | int | 100 | 386.6 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | int | 10000 | 4.054 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | struct | 1 | 0.3786 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | struct | 100 | 406.3 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | struct | 10000 | 4.269 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Index | class | 1 | 0.044 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | class | 100 | 4.873 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | class | 10000 | 1.009 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | int | 1 | 0.03795 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | int | 100 | 3.7 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | int | 10000 | 0.8986 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | struct | 1 | 0.037 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | struct | 100 | 3.847 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | struct | 10000 | 0.9103 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Iterate | class | 1 | 0.4438 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | class | 100 | 12.26 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | class | 10000 | 11.95 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | int | 1 | 0.3566 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | int | 100 | 6.83 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | int | 10000 | 6.592 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | struct | 1 | 0.3555 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | struct | 100 | 6.975 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | struct | 10000 | 6.755 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Remove | class | 1 | 0.4997 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | class | 100 | 7.802 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | class | 10000 | 6.463 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | int | 1 | 0.3775 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | int | 100 | 4.407 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | int | 10000 | 3.555 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | struct | 1 | 0.3855 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | struct | 100 | 4.62 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | struct | 10000 | 3.711 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | SetItem | class | 1 | 0.1681 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | class | 100 | 0.1719 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | class | 10000 | 0.0016 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | int | 1 | 0.09965 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | int | 100 | 0.09845 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | int | 10000 | 0.0008 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | struct | 1 | 0.09995 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | struct | 100 | 0.1014 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | struct | 10000 | 0.0013 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableQueue | Build | class | 1 | 0.1502 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | class | 100 | 8.244 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | class | 10000 | 8.178 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | int | 1 | 0.0853 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | int | 100 | 5.813 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | int | 10000 | 5.829 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | struct | 1 | 0.0942 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | struct | 100 | 6.592 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | struct | 10000 | 6.882 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Drain | class | 1 | 0.05965 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | class | 100 | 6.276 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | class | 10000 | 6.335 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | int | 1 | 0.0208 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | int | 100 | 4.162 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | int | 10000 | 4.202 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | struct | 1 | 0.0213 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | struct | 100 | 4.181 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | struct | 10000 | 4.235 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Iterate | class | 1 | 0.1298 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | class | 100 | 3.834 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | class | 10000 | 3.699 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | int | 1 | 0.0921 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | int | 100 | 2.191 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | int | 10000 | 2.1 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | struct | 1 | 0.09795 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | struct | 100 | 2.361 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | struct | 10000 | 2.284 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Peek | class | 1 | 0.05085 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | class | 100 | 0.0485 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | class | 10000 | 0.0005 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | int | 1 | 0.0351 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | int | 100 | 0.03655 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | int | 10000 | 0.0004 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | struct | 1 | 0.0394 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | struct | 100 | 0.0381 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | struct | 10000 | 0.0004 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableSortedDictionary | Build | class | 1 | 0.2605 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | class | 100 | 27.94 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | class | 10000 | 50.51 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | int | 1 | 0.2314 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | int | 100 | 27.01 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | int | 10000 | 49.54 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | struct | 1 | 0.22 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | struct | 100 | 27.62 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | struct | 10000 | 50.55 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Get | class | 1 | 0.06585 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | class | 100 | 6.312 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | class | 10000 | 1.211 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | int | 1 | 0.0427 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | int | 100 | 5.297 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | int | 10000 | 1.134 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | struct | 1 | 0.04845 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | struct | 100 | 5.186 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | struct | 10000 | 1.133 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Iterate | class | 1 | 0.3759 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | class | 100 | 8.077 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | class | 10000 | 8.017 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | int | 1 | 0.3683 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | int | 100 | 7.552 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | int | 10000 | 7.635 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | struct | 1 | 0.3654 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | struct | 100 | 7.636 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | struct | 10000 | 7.536 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Remove | class | 1 | 0.0452 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | class | 100 | 0.5552 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | class | 10000 | 0.013 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | int | 1 | 0.03085 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | int | 100 | 0.5047 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | int | 10000 | 0.0119 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | struct | 1 | 0.031 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | struct | 100 | 0.5574 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | struct | 10000 | 0.0118 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | SetItem | class | 1 | 0.2171 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | class | 100 | 0.2184 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | class | 10000 | 0.0022 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | int | 1 | 0.1588 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | int | 100 | 0.1559 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | int | 10000 | 0.0016 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | struct | 1 | 0.1553 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | struct | 100 | 0.1574 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | struct | 10000 | 0.0013 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | class | 1 | 0.2615 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | class | 100 | 0.5773 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | class | 10000 | 0.0122 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | int | 1 | 0.2209 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | int | 100 | 0.4985 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | int | 10000 | 0.0119 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | struct | 1 | 0.2044 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | struct | 100 | 0.557 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | struct | 10000 | 0.0111 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | class | 1 | 0.3264 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | class | 100 | 0.9613 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | class | 10000 | 0.0208 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | int | 1 | 0.1894 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | int | 100 | 0.4893 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | int | 10000 | 0.0106 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | struct | 1 | 0.1837 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | struct | 100 | 0.57 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | struct | 10000 | 0.0127 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | Build | class | 1 | 0.2865 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | class | 100 | 55.07 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | class | 10000 | 106.3 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | int | 1 | 0.1993 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | int | 100 | 27.26 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | int | 10000 | 51.11 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | struct | 1 | 0.1912 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | struct | 100 | 31.18 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | struct | 10000 | 58.94 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Contains | class | 1 | 0.07805 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | class | 100 | 16.36 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | class | 10000 | 3.146 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | int | 1 | 0.04065 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | int | 100 | 6.293 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | int | 10000 | 1.302 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | struct | 1 | 0.05685 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | struct | 100 | 10.33 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | struct | 10000 | 2.224 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Iterate | class | 1 | 0.4414 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | class | 100 | 10.94 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | class | 10000 | 10.73 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | int | 1 | 0.3583 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | int | 100 | 6.826 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | int | 10000 | 6.619 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | struct | 1 | 0.3631 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | struct | 100 | 7.033 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | struct | 10000 | 6.885 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Remove | class | 1 | 0.0714 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | class | 100 | 0.9293 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | class | 10000 | 0.0216 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | int | 1 | 0.0258 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | int | 100 | 0.4673 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | int | 10000 | 0.0111 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | struct | 1 | 0.0358 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | struct | 100 | 0.5528 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | struct | 10000 | 0.0127 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableStack | Build | class | 1 | 0.0715 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | class | 100 | 3.951 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | class | 10000 | 3.984 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | int | 1 | 0.045 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | int | 100 | 2.862 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | int | 10000 | 2.83 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | struct | 1 | 0.0494 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | struct | 100 | 3.291 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | struct | 10000 | 2.936 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Drain | class | 1 | 0.0243 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | class | 100 | 0.6025 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | class | 10000 | 0.6068 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | int | 1 | 0.0109 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | int | 100 | 0.435 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | int | 10000 | 0.4797 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | struct | 1 | 0.0111 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | struct | 100 | 0.4374 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | struct | 10000 | 0.5265 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Iterate | class | 1 | 0.1017 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | class | 100 | 3.186 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | class | 10000 | 3.046 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | int | 1 | 0.06945 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | int | 100 | 1.78 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | int | 10000 | 1.717 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | struct | 1 | 0.0712 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | struct | 100 | 1.927 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | struct | 10000 | 1.868 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Peek | class | 1 | 0.0348 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | class | 100 | 0.0361 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | class | 10000 | 0.0003 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | int | 1 | 0.03275 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | int | 100 | 0.0319 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | int | 10000 | 0.0003 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | struct | 1 | 0.03455 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | struct | 100 | 0.0343 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | struct | 10000 | 0.0004 | 0 | O(1) | O(1) (head cons-node) |  |
| Legacy | ArrayList | Add | class | 1 | 0.0955 | 0 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | class | 100 | 2.69 | 0 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | class | 10000 | 1.114 | 286720 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | int | 1 | 0.3507 | 0 | O(1) amortized | O(1) (boxed elem heap) | boxing |
| Legacy | ArrayList | Add | int | 100 | 6.572 | 0 | O(1) amortized | O(1) (boxed elem heap) | boxing |
| Legacy | ArrayList | Add | int | 10000 | 5.306 | 286720 | O(1) amortized | O(1) (boxed elem heap) | boxing |
| Legacy | ArrayList | Add | struct | 1 | 0.1259 | 0 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | struct | 100 | 7.579 | 0 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | struct | 10000 | 3.095 | 286720 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Contains | class | 1 | 0.0309 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | class | 100 | 19.97 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | class | 10000 | 0.1992 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | int | 1 | 0.048 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) | boxing |
| Legacy | ArrayList | Contains | int | 100 | 20.35 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) | boxing |
| Legacy | ArrayList | Contains | int | 10000 | 0.197 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) | boxing |
| Legacy | ArrayList | Contains | struct | 1 | 0.0553 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | struct | 100 | 32.29 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | struct | 10000 | 0.3184 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Index | class | 1 | 0.03645 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | class | 100 | 0.7787 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | class | 10000 | 0.0755 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | int | 1 | 0.0415 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) | boxing |
| Legacy | ArrayList | Index | int | 100 | 0.766 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) | boxing |
| Legacy | ArrayList | Index | int | 10000 | 0.0745 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) | boxing |
| Legacy | ArrayList | Index | struct | 1 | 0.03805 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | struct | 100 | 0.7748 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | struct | 10000 | 0.0747 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Insert0 | class | 1 | 0.0969 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | class | 100 | 4.374 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | class | 10000 | 113.9 | 286720 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | int | 1 | 0.1208 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc | boxing |
| Legacy | ArrayList | Insert0 | int | 100 | 6.17 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc | boxing |
| Legacy | ArrayList | Insert0 | int | 10000 | 115.7 | 286720 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc | boxing |
| Legacy | ArrayList | Insert0 | struct | 1 | 0.1188 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | struct | 100 | 6.544 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | struct | 10000 | 115.9 | 286720 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Iterate | class | 1 | 0.09445 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | class | 100 | 1.041 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | class | 10000 | 0.9369 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | int | 1 | 0.09415 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | ArrayList | Iterate | int | 100 | 1.052 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | ArrayList | Iterate | int | 10000 | 0.9465 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | ArrayList | Iterate | struct | 1 | 0.09515 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | struct | 100 | 1.045 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | struct | 10000 | 0.9363 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | RemoveAt | class | 1 | 0.04415 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | class | 100 | 1.057 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | class | 10000 | 1.035 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | int | 1 | 0.04545 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) | boxing |
| Legacy | ArrayList | RemoveAt | int | 100 | 1.057 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) | boxing |
| Legacy | ArrayList | RemoveAt | int | 10000 | 1.024 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) | boxing |
| Legacy | ArrayList | RemoveAt | struct | 1 | 0.043 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | struct | 100 | 1.056 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | struct | 10000 | 1.021 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | Set | class | 1 | 0.0103 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | class | 100 | 0.9069 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | class | 10000 | 0.0906 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | int | 1 | 0.02765 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box | boxing |
| Legacy | ArrayList | Set | int | 100 | 2.746 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box | boxing |
| Legacy | ArrayList | Set | int | 10000 | 0.265 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box | boxing |
| Legacy | ArrayList | Set | struct | 1 | 0.0293 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | struct | 100 | 3.089 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | struct | 10000 | 0.3065 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | BitArray | Get | bool | 1 | 0.0366 | 0 | O(1) | O(1) (pure bit read, NO boxing; bool returned by value) |  |
| Legacy | BitArray | Get | bool | 100 | 1.154 | 0 | O(1) | O(1) (pure bit read, NO boxing; bool returned by value) |  |
| Legacy | BitArray | Get | bool | 10000 | 0.1123 | 0 | O(1) | O(1) (pure bit read, NO boxing; bool returned by value) |  |
| Legacy | BitArray | Iterate | bool | 1 | 0.0988 | 0 | O(n) | O(1) live, but non-generic enumerator boxes each bool per step |  |
| Legacy | BitArray | Iterate | bool | 100 | 2.94 | 0 | O(n) | O(1) live, but non-generic enumerator boxes each bool per step |  |
| Legacy | BitArray | Iterate | bool | 10000 | 2.671 | 0 | O(n) | O(1) live, but non-generic enumerator boxes each bool per step |  |
| Legacy | BitArray | Set | bool | 1 | 0.008 | 0 | O(1) | O(1) (packed 32 bits/int; pure bit write, NO boxing) |  |
| Legacy | BitArray | Set | bool | 100 | 0.6528 | 0 | O(1) | O(1) (packed 32 bits/int; pure bit write, NO boxing) |  |
| Legacy | BitArray | Set | bool | 10000 | 0.0644 | 0 | O(1) | O(1) (packed 32 bits/int; pure bit write, NO boxing) |  |
| Legacy | Hashtable | Add | class | 1 | 0.1109 | 0 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | class | 100 | 8.467 | 12288 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | class | 10000 | 6.984 | 823296 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | int | 1 | 0.1281 | 0 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | Hashtable | Add | int | 100 | 9.563 | 12288 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | Hashtable | Add | int | 10000 | 8.5 | 823296 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | Hashtable | Add | struct | 1 | 0.135 | 0 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | struct | 100 | 10.52 | 12288 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | struct | 10000 | 8.977 | 823296 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Get | class | 1 | 0.1042 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | class | 100 | 7.234 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | class | 10000 | 0.7406 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | int | 1 | 0.1042 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) | boxing |
| Legacy | Hashtable | Get | int | 100 | 7.178 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) | boxing |
| Legacy | Hashtable | Get | int | 10000 | 0.7296 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) | boxing |
| Legacy | Hashtable | Get | struct | 1 | 0.1053 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | struct | 100 | 7.412 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | struct | 10000 | 0.7476 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Iterate | class | 1 | 0.1457 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | class | 100 | 6.266 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | class | 10000 | 5.859 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | int | 1 | 0.14 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | Hashtable | Iterate | int | 100 | 6.272 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | Hashtable | Iterate | int | 10000 | 5.957 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | Hashtable | Iterate | struct | 1 | 0.1467 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | struct | 100 | 6.311 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | struct | 10000 | 6.055 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Remove | class | 1 | 0.0681 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | class | 100 | 3.84 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | class | 10000 | 0.3889 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | int | 1 | 0.06925 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | Hashtable | Remove | int | 100 | 3.914 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | Hashtable | Remove | int | 10000 | 0.3917 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | Hashtable | Remove | struct | 1 | 0.073 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | struct | 100 | 3.842 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | struct | 10000 | 0.394 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Set | class | 1 | 0.0426 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | class | 100 | 4.656 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | class | 10000 | 0.4286 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | int | 1 | 0.0569 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | Hashtable | Set | int | 100 | 5.74 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | Hashtable | Set | int | 10000 | 0.6034 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | Hashtable | Set | struct | 1 | 0.0594 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | struct | 100 | 6.266 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | struct | 10000 | 0.6398 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Queue | Dequeue | class | 1 | 0.0429 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | class | 100 | 1.017 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | class | 10000 | 1.06 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | int | 1 | 0.04315 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) | boxing |
| Legacy | Queue | Dequeue | int | 100 | 1.021 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) | boxing |
| Legacy | Queue | Dequeue | int | 10000 | 1.148 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) | boxing |
| Legacy | Queue | Dequeue | struct | 1 | 0.044 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | struct | 100 | 1.022 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | struct | 10000 | 1.004 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Enqueue | class | 1 | 0.0977 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | class | 100 | 1.539 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | class | 10000 | 1.122 | 286720 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | int | 1 | 0.1361 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Queue | Enqueue | int | 100 | 3.068 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Queue | Enqueue | int | 10000 | 2.73 | 286720 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Queue | Enqueue | struct | 1 | 0.1157 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | struct | 100 | 3.748 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | struct | 10000 | 3.198 | 286720 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Iterate | class | 1 | 0.1135 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | class | 100 | 1.324 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | class | 10000 | 1.246 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | int | 1 | 0.08925 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Queue | Iterate | int | 100 | 1.327 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Queue | Iterate | int | 10000 | 1.246 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Queue | Iterate | struct | 1 | 0.0892 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | struct | 100 | 1.472 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | struct | 10000 | 1.329 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Peek | class | 1 | 0.04315 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | class | 100 | 25.76 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | class | 10000 | 0.2871 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | int | 1 | 0.05895 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Queue | Peek | int | 100 | 26.31 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Queue | Peek | int | 10000 | 0.2906 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Queue | Peek | struct | 1 | 0.0698 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | struct | 100 | 35.82 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | struct | 10000 | 0.3563 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | SortedList | Add | class | 1 | 0.2381 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | class | 100 | 11.24 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | class | 10000 | 16.71 | 573440 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | int | 1 | 0.2511 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | SortedList | Add | int | 100 | 12.93 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | SortedList | Add | int | 10000 | 18.27 | 573440 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | SortedList | Add | struct | 1 | 0.2543 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | struct | 100 | 12.95 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | struct | 10000 | 18.6 | 573440 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | ContainsKey | class | 1 | 0.0586 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | class | 100 | 10.28 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | class | 10000 | 1.658 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | int | 1 | 0.06605 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) | boxing |
| Legacy | SortedList | ContainsKey | int | 100 | 9.862 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) | boxing |
| Legacy | SortedList | ContainsKey | int | 10000 | 1.673 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) | boxing |
| Legacy | SortedList | ContainsKey | struct | 1 | 0.06415 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | struct | 100 | 10.06 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | struct | 10000 | 1.904 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | Iterate | class | 1 | 0.1401 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | class | 100 | 5.92 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | class | 10000 | 5.602 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | int | 1 | 0.1359 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | SortedList | Iterate | int | 100 | 6.052 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | SortedList | Iterate | int | 10000 | 5.765 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | SortedList | Iterate | struct | 1 | 0.1408 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | struct | 100 | 6.46 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | struct | 10000 | 5.729 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Remove | class | 1 | 0.0816 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | class | 100 | 15 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | class | 10000 | 45.12 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | int | 1 | 0.078 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | SortedList | Remove | int | 100 | 14.71 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | SortedList | Remove | int | 10000 | 45.24 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | SortedList | Remove | struct | 1 | 0.08005 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | struct | 100 | 14.69 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | struct | 10000 | 45 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Set | class | 1 | 0.04195 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | class | 100 | 10.42 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | class | 10000 | 1.756 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | int | 1 | 0.0596 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | SortedList | Set | int | 100 | 12.08 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | SortedList | Set | int | 10000 | 1.892 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | SortedList | Set | struct | 1 | 0.06175 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | struct | 100 | 12.72 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | struct | 10000 | 1.991 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Stack | Iterate | class | 1 | 0.0816 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | class | 100 | 1.086 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | class | 10000 | 0.9929 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | int | 1 | 0.07755 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Stack | Iterate | int | 100 | 1.088 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Stack | Iterate | int | 10000 | 1.011 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Stack | Iterate | struct | 1 | 0.0785 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | struct | 100 | 1.095 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | struct | 10000 | 1.012 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Peek | class | 1 | 0.0465 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | class | 100 | 20.06 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | class | 10000 | 37.73 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | int | 1 | 0.0627 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Stack | Peek | int | 100 | 19.93 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Stack | Peek | int | 10000 | 32.34 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Stack | Peek | struct | 1 | 0.0652 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | struct | 100 | 31.9 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | struct | 10000 | 61.12 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Pop | class | 1 | 0.0448 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | class | 100 | 0.905 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | class | 10000 | 0.8813 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | int | 1 | 0.045 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) | boxing |
| Legacy | Stack | Pop | int | 100 | 0.907 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) | boxing |
| Legacy | Stack | Pop | int | 10000 | 0.8844 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) | boxing |
| Legacy | Stack | Pop | struct | 1 | 0.0449 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | struct | 100 | 0.9061 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | struct | 10000 | 0.8844 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Push | class | 1 | 0.0743 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | class | 100 | 1.562 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | class | 10000 | 0.9948 | 180224 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | int | 1 | 0.09145 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Stack | Push | int | 100 | 3.068 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Stack | Push | int | 10000 | 2.587 | 180224 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Stack | Push | struct | 1 | 0.0916 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | struct | 100 | 3.495 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | struct | 10000 | 3.011 | 180224 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Native | NativeArray | Get | int | 1 | 0.04045 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | int | 100 | 0.8818 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | int | 10000 | 0.0855 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | struct | 1 | 0.04075 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | struct | 100 | 1.249 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | struct | 10000 | 0.1211 | 1024 | O(1) | O(1) |  |
| Native | NativeArray | Iterate | int | 1 | 0.042 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | int | 100 | 0.991 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | int | 10000 | 0.9573 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | struct | 1 | 0.04435 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | struct | 100 | 1.39 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | struct | 10000 | 1.348 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Set | int | 1 | 0.0406 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | int | 100 | 0.8684 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | int | 10000 | 0.083 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | struct | 1 | 0.04135 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | struct | 100 | 1.151 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | struct | 10000 | 0.1108 | 0 | O(1) | O(1) |  |
| Native | NativeHashMap | Add | int | 1 | 0.315 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | int | 100 | 2.954 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | int | 10000 | 2.685 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | struct | 1 | 0.321 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | struct | 100 | 3.421 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | struct | 10000 | 3.157 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Get | int | 1 | 0.06145 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | int | 100 | 2.344 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | int | 10000 | 0.2324 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | struct | 1 | 0.066 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | struct | 100 | 2.611 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | struct | 10000 | 0.2623 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | int | 1 | 0.6725 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | int | 100 | 4.114 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | int | 10000 | 3.806 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | struct | 1 | 0.6733 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | struct | 100 | 4.294 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | struct | 10000 | 4.035 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Remove | int | 1 | 0.06025 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | int | 100 | 2.243 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | int | 10000 | 0.2235 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | struct | 1 | 0.05995 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | struct | 100 | 2.204 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | struct | 10000 | 0.2178 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | int | 1 | 0.0606 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | int | 100 | 2.1 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | int | 10000 | 0.2082 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | struct | 1 | 0.062 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | struct | 100 | 2.406 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | struct | 10000 | 0.2397 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Add | int | 1 | 0.3083 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Add | int | 100 | 2.662 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Add | int | 10000 | 2.36 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Add | struct | 1 | 0.3171 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Add | struct | 100 | 3.088 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Add | struct | 10000 | 2.787 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Contains | int | 1 | 0.0579 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Contains | int | 100 | 1.918 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Contains | int | 10000 | 0.1917 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Contains | struct | 1 | 0.0618 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Contains | struct | 100 | 2.435 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Contains | struct | 10000 | 0.2405 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | int | 1 | 0.6622 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | int | 100 | 2.394 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | int | 10000 | 2.104 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | struct | 1 | 0.6665 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | struct | 100 | 2.84 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | struct | 10000 | 2.505 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Remove | int | 1 | 0.06015 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Remove | int | 100 | 2.126 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Remove | int | 10000 | 0.2081 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Remove | struct | 1 | 0.0644 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Remove | struct | 100 | 2.601 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Remove | struct | 10000 | 0.2605 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Add | int | 1 | 0.4186 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | int | 100 | 1.173 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | int | 10000 | 0.7564 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | struct | 1 | 0.4138 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | struct | 100 | 1.197 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | struct | 10000 | 0.7871 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Contains | int | 1 | 0.0623 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | int | 100 | 21.8 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | int | 10000 | 0.2182 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | struct | 1 | 0.0679 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | struct | 100 | 32.16 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | struct | 10000 | 0.3245 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Get | int | 1 | 0.04425 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | int | 100 | 1.111 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | int | 10000 | 0.1097 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | struct | 1 | 0.0493 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | struct | 100 | 1.524 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | struct | 10000 | 0.1527 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | int | 1 | 0.06685 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | int | 100 | 1.988 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | int | 10000 | 1.945 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | struct | 1 | 0.0709 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | struct | 100 | 2.455 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | struct | 10000 | 2.419 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | int | 1 | 0.09215 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | int | 100 | 4.454 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | int | 10000 | 4.364 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | struct | 1 | 0.09295 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | struct | 100 | 4.506 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | struct | 10000 | 4.424 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | int | 1 | 0.04525 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | int | 100 | 1.041 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | int | 10000 | 0.1001 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | struct | 1 | 0.047 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | struct | 100 | 1.309 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | struct | 10000 | 0.1272 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Add | int | 1 | 0.284 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | int | 100 | 1.621 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | int | 10000 | 1.352 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | struct | 1 | 0.2932 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | struct | 100 | 1.932 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | struct | 10000 | 1.696 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Iterate | int | 1 | 0.2346 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | int | 100 | 1.203 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | int | 10000 | 0.9536 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | struct | 1 | 0.2579 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | struct | 100 | 1.773 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | struct | 10000 | 1.455 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Remove | int | 1 | 0.187 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | int | 100 | 2.578 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | int | 10000 | 2.487 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | struct | 1 | 0.1974 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | struct | 100 | 3.319 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | struct | 10000 | 3.731 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| ObjectModel | Collection | Add | class | 1 | 0.1642 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | class | 100 | 5.484 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | class | 10000 | 3.079 | 286720 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | int | 1 | 0.2831 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | int | 100 | 2.212 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | int | 10000 | 1.06 | 151552 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | struct | 1 | 0.1066 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | struct | 100 | 2.74 | 4096 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | struct | 10000 | 1.662 | 811008 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Get | class | 1 | 0.0824 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | class | 100 | 21.18 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | class | 10000 | 0.3146 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | int | 1 | 0.04945 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | int | 100 | 13.45 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | int | 10000 | 0.1706 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | struct | 1 | 0.06035 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | struct | 100 | 19.5 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | struct | 10000 | 0.2379 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | InsertHead | class | 1 | 0.1594 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | class | 100 | 6.578 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | class | 10000 | 117.3 | 286720 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | int | 1 | 0.104 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | int | 100 | 2.995 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | int | 10000 | 20.67 | 151552 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | struct | 1 | 0.1219 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | struct | 100 | 8.146 | 4096 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | struct | 10000 | 345.4 | 811008 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | Iterate | class | 1 | 0.1146 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | class | 100 | 1.032 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | class | 10000 | 1.031 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | int | 1 | 0.08475 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | int | 100 | 0.5741 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | int | 10000 | 0.4863 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | struct | 1 | 0.0918 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | struct | 100 | 0.7139 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | struct | 10000 | 0.6127 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | RemoveAt | class | 1 | 0.0624 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | class | 100 | 2.776 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | class | 10000 | 2.666 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | int | 1 | 0.04045 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | int | 100 | 1.017 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | int | 10000 | 0.8721 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | struct | 1 | 0.04045 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | struct | 100 | 0.8867 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | struct | 10000 | 0.8983 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | Set | class | 1 | 0.0317 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | class | 100 | 2.657 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | class | 10000 | 0.2626 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | int | 1 | 0.0107 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | int | 100 | 0.8969 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | int | 10000 | 0.1032 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | struct | 1 | 0.01365 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | struct | 100 | 1.187 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | struct | 10000 | 0.1175 | 0 | O(1) | O(1) |  |
| ObjectModel | KeyedCollection | Add | class | 1 | 0.3783 | 0 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | class | 100 | 9.481 | 12288 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | class | 10000 | 6.063 | 1.24928e+06 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | int | 1 | 0.2847 | 0 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | int | 100 | 5.396 | 4096 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | int | 10000 | 3.191 | 835584 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | struct | 1 | 0.3234 | 0 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | struct | 100 | 7.485 | 16384 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | struct | 10000 | 4.566 | 2.30605e+06 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Get | class | 1 | 0.07015 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | class | 100 | 4.004 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | class | 10000 | 0.43 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | int | 1 | 0.05825 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | int | 100 | 3.682 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | int | 10000 | 0.3617 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | struct | 1 | 0.06635 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | struct | 100 | 3.9 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | struct | 10000 | 0.3854 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | class | 1 | 0.1066 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | class | 100 | 1.047 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | class | 10000 | 0.9517 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | int | 1 | 0.0824 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | int | 100 | 0.5886 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | int | 10000 | 0.4967 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | struct | 1 | 0.08945 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | struct | 100 | 0.7154 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | struct | 10000 | 0.6227 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | class | 1 | 0.1481 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | class | 100 | 15.75 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | class | 10000 | 22.86 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | int | 1 | 0.0894 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | int | 100 | 8.731 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | int | 10000 | 4.178 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | struct | 1 | 0.0977 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | struct | 100 | 12.39 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | struct | 10000 | 66.6 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | ObservableCollection | Add | class | 1 | 0.3302 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | class | 100 | 14.21 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | class | 10000 | 14.45 | 339968 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | int | 1 | 0.2475 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | int | 100 | 12.86 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | int | 10000 | 11.83 | 204800 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | struct | 1 | 0.2849 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | struct | 100 | 15.2 | 4096 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | struct | 10000 | 14.23 | 864256 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Get | class | 1 | 0.0794 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | class | 100 | 21.45 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | class | 10000 | 0.2873 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | int | 1 | 0.04725 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | int | 100 | 13.54 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | int | 10000 | 0.17 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | struct | 1 | 0.05825 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | struct | 100 | 19.19 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | struct | 10000 | 0.2329 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | InsertHead | class | 1 | 0.2897 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | class | 100 | 16.88 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | class | 10000 | 127.2 | 339968 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | int | 1 | 0.243 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | int | 100 | 15.48 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | int | 10000 | 32.37 | 204800 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | struct | 1 | 0.2582 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | struct | 100 | 20.26 | 4096 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | struct | 10000 | 353.8 | 864256 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | Iterate | class | 1 | 0.1124 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | class | 100 | 1.055 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | class | 10000 | 0.9364 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | int | 1 | 0.08465 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | int | 100 | 0.5798 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | int | 10000 | 0.4903 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | struct | 1 | 0.0877 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | struct | 100 | 0.7014 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | struct | 10000 | 0.6116 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | RemoveAt | class | 1 | 0.1799 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | class | 100 | 13.86 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | class | 10000 | 13.5 | 286720 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | int | 1 | 0.1675 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | int | 100 | 12.09 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | int | 10000 | 11.41 | 564224 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | struct | 1 | 0.1703 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | struct | 100 | 13.72 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | struct | 10000 | 13.93 | 547328 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | Set | class | 1 | 0.2098 | 0 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | class | 100 | 20.02 | 2240 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | class | 10000 | 1.869 | 30720 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | int | 1 | 0.2127 | 0 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | int | 100 | 19.62 | 3328 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | int | 10000 | 1.89 | 52224 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | struct | 1 | 0.2231 | 0 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | struct | 100 | 22.25 | 2240 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | struct | 10000 | 1.961 | 30720 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ReadOnlyCollection | Get | class | 1 | 0.08045 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | class | 100 | 21 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | class | 10000 | 0.2923 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | int | 1 | 0.04895 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | int | 100 | 13.21 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | int | 10000 | 0.1619 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | struct | 1 | 0.0594 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | struct | 100 | 19.27 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | struct | 10000 | 0.2377 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | class | 1 | 0.1082 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | class | 100 | 1.052 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | class | 10000 | 0.9277 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | int | 1 | 0.0863 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | int | 100 | 0.5708 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | int | 10000 | 0.4891 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | struct | 1 | 0.0873 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | struct | 100 | 0.7082 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | struct | 10000 | 0.6435 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | class | 1 | 0.0539 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | class | 100 | 2.166 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | class | 10000 | 0.2119 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | int | 1 | 0.0455 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | int | 100 | 1.665 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | int | 10000 | 0.1684 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | struct | 1 | 0.045 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | struct | 100 | 1.729 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | struct | 10000 | 0.1684 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | class | 1 | 0.1024 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | class | 100 | 1.992 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | class | 10000 | 1.956 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | int | 1 | 0.08655 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | int | 100 | 1.128 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | int | 10000 | 1.043 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | struct | 1 | 0.09295 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | struct | 100 | 1.442 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | struct | 10000 | 1.346 | 0 | O(n) | O(1) |  |
