# Collection Benchmark Results

Rows: 1968  (generated 2026-06-03)

| 家族 | 集合 | 操作 | 元素类型 | N | 时间中位(ms) | GC(bytes) | Big-O 时间 | Big-O 空间 | 备注 |
|---|---|---|---|---|---|---|---|---|---|
| Concurrent | BlockingCollection | Add | bool | 1 | 0.1185 | 0 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | bool | 100 | 8.02 | 0 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | bool | 10000 | 6.468 | 151552 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | class | 1 | 0.1252 | 0 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | class | 100 | 8.294 | 4608 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | class | 10000 | 7.087 | 286720 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | int | 1 | 0.1213 | 0 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | int | 100 | 7.165 | 0 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | int | 10000 | 6.282 | 151552 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | struct | 1 | 0.1252 | 0 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | struct | 100 | 8.18 | 12288 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Add | struct | 10000 | 6.879 | 552960 | O(1) amortized | O(1) amortized (backing ConcurrentQueue) |  |
| Concurrent | BlockingCollection | Iterate | bool | 1 | 0.1499 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | bool | 100 | 1.092 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | bool | 10000 | 0.9248 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | class | 1 | 0.1604 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | class | 100 | 1.733 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | class | 10000 | 1.519 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | int | 1 | 0.1489 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | int | 100 | 1.114 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | int | 10000 | 0.9629 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | struct | 1 | 0.1538 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | struct | 100 | 1.248 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Iterate | struct | 10000 | 1.075 | 0 | O(n) | O(1) |  |
| Concurrent | BlockingCollection | Remove | bool | 1 | 0.1698 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | bool | 100 | 12.6 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | bool | 10000 | 12.38 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | class | 1 | 0.1769 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | class | 100 | 13.26 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | class | 10000 | 13.16 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | int | 1 | 0.1657 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | int | 100 | 12.63 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | int | 10000 | 12.35 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | struct | 1 | 0.172 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | struct | 100 | 12.68 | 0 | O(1) | O(1) |  |
| Concurrent | BlockingCollection | Remove | struct | 10000 | 12.55 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentBag | Add | bool | 1 | 0.6063 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | bool | 100 | 4.126 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | bool | 10000 | 3.328 | 45056 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | class | 1 | 0.6606 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | class | 100 | 5.482 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | class | 10000 | 4.299 | 286720 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | int | 1 | 0.5991 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | int | 100 | 4.331 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | int | 10000 | 3.429 | 151552 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | struct | 1 | 0.7509 | 0 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | struct | 100 | 5.517 | 4096 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Add | struct | 10000 | 3.981 | 811008 | O(1) amortized | O(1) amortized (thread-local node) |  |
| Concurrent | ConcurrentBag | Iterate | bool | 1 | 0.1573 | 0 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | bool | 100 | 1.006 | 0 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | bool | 10000 | 0.8421 | 12288 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | class | 1 | 0.1729 | 0 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | class | 100 | 2.421 | 704 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | class | 10000 | 2.177 | 81920 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | int | 1 | 0.1545 | 0 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | int | 100 | 1.051 | 448 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | int | 10000 | 0.9298 | 40960 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | struct | 1 | 0.1723 | 0 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | struct | 100 | 1.803 | 4096 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Iterate | struct | 10000 | 1.103 | 241664 | O(n) | O(n) snapshot |  |
| Concurrent | ConcurrentBag | Remove | bool | 1 | 0.1336 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | bool | 100 | 3.571 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | bool | 10000 | 3.398 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | class | 1 | 0.1578 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | class | 100 | 4.894 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | class | 10000 | 4.755 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | int | 1 | 0.1372 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | int | 100 | 3.576 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | int | 10000 | 3.507 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | struct | 1 | 0.1321 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | struct | 100 | 3.842 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentBag | Remove | struct | 10000 | 3.634 | 0 | O(1) amortized | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | bool | 1 | 0.6707 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | bool | 100 | 14.2 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | bool | 10000 | 14.8 | 360448 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | class | 1 | 0.6968 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | class | 100 | 15.91 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | class | 10000 | 16.82 | 360448 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | int | 1 | 0.6941 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | int | 100 | 14.2 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | int | 10000 | 14.79 | 360448 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | struct | 1 | 0.6783 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | struct | 100 | 15.17 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Add | struct | 10000 | 16.28 | 360448 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | bool | 1 | 0.04545 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | bool | 100 | 1.557 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | bool | 10000 | 0.1526 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | class | 1 | 0.05145 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | class | 100 | 2.263 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | class | 10000 | 0.2191 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | int | 1 | 0.0455 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | int | 100 | 1.54 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | int | 10000 | 0.1509 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | struct | 1 | 0.0467 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | struct | 100 | 1.736 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Get | struct | 10000 | 0.1721 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | bool | 1 | 0.305 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | bool | 100 | 2.733 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | bool | 10000 | 2.896 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | class | 1 | 0.3169 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | class | 100 | 3.733 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | class | 10000 | 3.957 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | int | 1 | 0.3062 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | int | 100 | 2.726 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | int | 10000 | 2.912 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | struct | 1 | 0.3027 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | struct | 100 | 3.073 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Iterate | struct | 10000 | 3.305 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | bool | 1 | 0.0772 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | bool | 100 | 4.816 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | bool | 10000 | 0.4771 | 512 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | class | 1 | 0.0853 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | class | 100 | 5.745 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | class | 10000 | 0.5654 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | int | 1 | 0.07815 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | int | 100 | 4.886 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | int | 10000 | 0.473 | 512 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | struct | 1 | 0.08605 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | struct | 100 | 5.264 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Remove | struct | 10000 | 0.5211 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | bool | 1 | 0.04685 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | bool | 100 | 3.997 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | bool | 10000 | 0.396 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | class | 1 | 0.05605 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | class | 100 | 4.946 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | class | 10000 | 0.4969 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | int | 1 | 0.0454 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | int | 100 | 3.858 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | int | 10000 | 0.3852 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | struct | 1 | 0.0919 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | struct | 100 | 8.259 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentDictionary | Update | struct | 10000 | 0.7783 | 0 | O(1) avg | O(1) |  |
| Concurrent | ConcurrentQueue | Add | bool | 1 | 0.2334 | 0 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | bool | 100 | 2.111 | 0 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | bool | 10000 | 1.209 | 151552 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | class | 1 | 0.3118 | 0 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | class | 100 | 3.31 | 4096 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | class | 10000 | 1.855 | 286720 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | int | 1 | 0.236 | 0 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | int | 100 | 2.008 | 0 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | int | 10000 | 1.227 | 151552 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | struct | 1 | 0.3803 | 0 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | struct | 100 | 2.997 | 12288 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Add | struct | 10000 | 1.727 | 552960 | O(1) amortized | O(1) amortized (segment alloc) |  |
| Concurrent | ConcurrentQueue | Contains | bool | 1 | 0.1512 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | bool | 100 | 10.96 | 7872 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | bool | 10000 | 0.1205 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | class | 1 | 0.1705 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | class | 100 | 131.7 | 7936 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | class | 10000 | 1.303 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | int | 1 | 0.1431 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | int | 100 | 71.96 | 7936 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | int | 10000 | 0.7232 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | struct | 1 | 0.164 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | struct | 100 | 97.67 | 3904 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Contains | struct | 10000 | 0.9599 | 0 | O(n) per probe | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | bool | 1 | 0.1399 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | bool | 100 | 1.113 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | bool | 10000 | 0.9323 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | class | 1 | 0.1515 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | class | 100 | 1.71 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | class | 10000 | 1.529 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | int | 1 | 0.1461 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | int | 100 | 1.087 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | int | 10000 | 0.9498 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | struct | 1 | 0.1437 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | struct | 100 | 1.226 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Iterate | struct | 10000 | 1.074 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | bool | 1 | 0.06015 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | bool | 100 | 1.183 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | bool | 10000 | 1.07 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | class | 1 | 0.0674 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | class | 100 | 1.752 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | class | 10000 | 1.589 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | int | 1 | 0.0565 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | int | 100 | 1.193 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | int | 10000 | 1.037 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | struct | 1 | 0.06195 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | struct | 100 | 1.268 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentQueue | Remove | struct | 10000 | 1.108 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Add | bool | 1 | 0.08275 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | bool | 100 | 3.687 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | bool | 10000 | 3.688 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | class | 1 | 0.1062 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | class | 100 | 4.769 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | class | 10000 | 4.728 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | int | 1 | 0.0814 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | int | 100 | 3.744 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | int | 10000 | 3.635 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | struct | 1 | 0.09865 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | struct | 100 | 4.069 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Add | struct | 10000 | 3.852 | 0 | O(1) | O(1) (node per push) |  |
| Concurrent | ConcurrentStack | Iterate | bool | 1 | 0.09035 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | bool | 100 | 1.17 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | bool | 10000 | 1.08 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | class | 1 | 0.1123 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | class | 100 | 1.885 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | class | 10000 | 1.801 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | int | 1 | 0.08625 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | int | 100 | 1.212 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | int | 10000 | 1.166 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | struct | 1 | 0.0905 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | struct | 100 | 1.367 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Iterate | struct | 10000 | 1.309 | 0 | O(n) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | bool | 1 | 0.0364 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | bool | 100 | 0.3954 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | bool | 10000 | 0.0362 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | class | 1 | 0.04205 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | class | 100 | 0.9366 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | class | 10000 | 0.0908 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | int | 1 | 0.0375 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | int | 100 | 0.3903 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | int | 10000 | 0.0355 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | struct | 1 | 0.0385 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | struct | 100 | 0.469 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Peek | struct | 10000 | 0.0438 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | bool | 1 | 0.04955 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | bool | 100 | 1.407 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | bool | 10000 | 1.327 | 56320 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | class | 1 | 0.0556 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | class | 100 | 1.933 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | class | 10000 | 1.891 | 56320 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | int | 1 | 0.05005 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | int | 100 | 1.306 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | int | 10000 | 1.281 | 56320 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | struct | 1 | 0.05015 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | struct | 100 | 1.309 | 0 | O(1) | O(1) |  |
| Concurrent | ConcurrentStack | Remove | struct | 10000 | 1.285 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | bool | 1 | 0.0319 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | bool | 100 | 0.1134 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | bool | 10000 | 0.0094 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | class | 1 | 0.03605 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | class | 100 | 0.7935 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | class | 10000 | 0.0694 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | int | 1 | 0.0296 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | int | 100 | 0.1155 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | int | 10000 | 0.0094 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | struct | 1 | 0.0324 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | struct | 100 | 0.1665 | 0 | O(1) | O(1) |  |
| Generic | Array | Get | struct | 10000 | 0.0139 | 0 | O(1) | O(1) |  |
| Generic | Array | Iterate | bool | 1 | 0.0484 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | bool | 100 | 2.19 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | bool | 10000 | 2.843 | 33280 | O(n) | O(1) |  |
| Generic | Array | Iterate | class | 1 | 0.02995 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | class | 100 | 0.1958 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | class | 10000 | 0.1884 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | int | 1 | 0.04695 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | int | 100 | 2.033 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | int | 10000 | 1.917 | 33280 | O(n) | O(1) |  |
| Generic | Array | Iterate | struct | 1 | 0.05775 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | struct | 100 | 2.306 | 0 | O(n) | O(1) |  |
| Generic | Array | Iterate | struct | 10000 | 2.984 | 0 | O(n) | O(1) |  |
| Generic | Array | Set | bool | 1 | 0.0033 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | bool | 100 | 0.1086 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | bool | 10000 | 0.0105 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | class | 1 | 0.0091 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | class | 100 | 0.7353 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | class | 10000 | 0.0685 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | int | 1 | 0.00375 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | int | 100 | 0.1106 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | int | 10000 | 0.0117 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | struct | 1 | 0.0037 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | struct | 100 | 0.149 | 0 | O(1) | O(1) |  |
| Generic | Array | Set | struct | 10000 | 0.0144 | 0 | O(1) | O(1) |  |
| Generic | Dictionary | Add | bool | 1 | 0.1038 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | bool | 100 | 5.245 | 4096 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | bool | 10000 | 2.255 | 684032 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | class | 1 | 0.1227 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | class | 100 | 6.925 | 12288 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | class | 10000 | 3.285 | 962560 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | int | 1 | 0.1049 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | int | 100 | 4.784 | 4096 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | int | 10000 | 2.155 | 684032 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | struct | 1 | 0.1209 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | struct | 100 | 5.916 | 12288 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Add | struct | 10000 | 2.586 | 1.49504e+06 | O(1) avg amortized | O(1) amortized |  |
| Generic | Dictionary | Get | bool | 1 | 0.0593 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | bool | 100 | 3.348 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | bool | 10000 | 0.3112 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | class | 1 | 0.05295 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | class | 100 | 2.046 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | class | 10000 | 0.2012 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | int | 1 | 0.059 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | int | 100 | 3.229 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | int | 10000 | 0.3118 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | struct | 1 | 0.0696 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | struct | 100 | 3.741 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Get | struct | 10000 | 0.3751 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Iterate | bool | 1 | 0.0596 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | bool | 100 | 1.068 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | bool | 10000 | 1.025 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | class | 1 | 0.08825 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | class | 100 | 2.04 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | class | 10000 | 1.999 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | int | 1 | 0.0606 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | int | 100 | 1.121 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | int | 10000 | 1.057 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | struct | 1 | 0.06245 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | struct | 100 | 1.308 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Iterate | struct | 10000 | 1.284 | 0 | O(n) | O(1) |  |
| Generic | Dictionary | Remove | bool | 1 | 0.0441 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | bool | 100 | 1.387 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | bool | 10000 | 0.1392 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | class | 1 | 0.04335 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | class | 100 | 1.484 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | class | 10000 | 0.1467 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | int | 1 | 0.046 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | int | 100 | 1.389 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | int | 10000 | 0.1408 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | struct | 1 | 0.04585 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | struct | 100 | 1.414 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Remove | struct | 10000 | 0.1496 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | bool | 1 | 0.01465 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | bool | 100 | 1.478 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | bool | 10000 | 0.145 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | class | 1 | 0.0235 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | class | 100 | 2.115 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | class | 10000 | 0.215 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | int | 1 | 0.0146 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | int | 100 | 1.462 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | int | 10000 | 0.1409 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | struct | 1 | 0.0175 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | struct | 100 | 1.865 | 0 | O(1) avg | O(1) |  |
| Generic | Dictionary | Set | struct | 10000 | 0.1853 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Add | class | 1 | 0.165 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | class | 100 | 6.016 | 4096 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | class | 10000 | 4.289 | 684032 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | int | 1 | 0.1119 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | int | 100 | 3.141 | 4096 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | int | 10000 | 2.062 | 552960 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | struct | 1 | 0.134 | 0 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | struct | 100 | 4.109 | 12288 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Add | struct | 10000 | 2.727 | 1.2288e+06 | O(1) avg amortized | O(1) amortized |  |
| Generic | HashSet | Contains | class | 1 | 0.047 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | class | 100 | 3.125 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | class | 10000 | 0.3076 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | int | 1 | 0.0413 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | int | 100 | 1.356 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | int | 10000 | 0.1334 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | struct | 1 | 0.04695 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | struct | 100 | 2.328 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Contains | struct | 10000 | 0.2278 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Iterate | class | 1 | 0.07405 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | class | 100 | 1.149 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | class | 10000 | 1.094 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | int | 1 | 0.08085 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | int | 100 | 2.408 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | int | 10000 | 2.168 | 65024 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | struct | 1 | 0.09405 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | struct | 100 | 2.832 | 0 | O(n) | O(1) |  |
| Generic | HashSet | Iterate | struct | 10000 | 2.567 | 247296 | O(n) | O(1) |  |
| Generic | HashSet | Remove | class | 1 | 0.06275 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | class | 100 | 3.556 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | class | 10000 | 0.3562 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | int | 1 | 0.044 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | int | 100 | 1.535 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | int | 10000 | 0.154 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | struct | 1 | 0.05205 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | struct | 100 | 2.436 | 0 | O(1) avg | O(1) |  |
| Generic | HashSet | Remove | struct | 10000 | 0.2454 | 0 | O(1) avg | O(1) |  |
| Generic | LinkedList | Add | bool | 1 | 0.0977 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | bool | 100 | 5.209 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | bool | 10000 | 4.966 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | class | 1 | 0.1331 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | class | 100 | 6.199 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | class | 10000 | 5.931 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | int | 1 | 0.1048 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | int | 100 | 5.262 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | int | 10000 | 4.939 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | struct | 1 | 0.09605 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | struct | 100 | 5.9 | 0 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | Add | struct | 10000 | 5.879 | 163840 | O(1) per AddLast | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | bool | 1 | 0.09655 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | bool | 100 | 5.652 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | bool | 10000 | 5.385 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | class | 1 | 0.115 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | class | 100 | 6.528 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | class | 10000 | 6.457 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | int | 1 | 0.0989 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | int | 100 | 5.918 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | int | 10000 | 5.376 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | struct | 1 | 0.09395 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | struct | 100 | 6.057 | 0 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | AddFirst | struct | 10000 | 6.325 | 163840 | O(1) per AddFirst | O(1) node alloc per add |  |
| Generic | LinkedList | Contains | bool | 1 | 0.0424 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | bool | 100 | 1.188 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | bool | 10000 | 0.0126 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | class | 1 | 0.04415 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | class | 100 | 49.26 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | class | 10000 | 0.5283 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | int | 1 | 0.04395 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | int | 100 | 18.54 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | int | 10000 | 0.1841 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | struct | 1 | 0.04895 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | struct | 100 | 37.29 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Contains | struct | 10000 | 0.4034 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | bool | 1 | 0.09675 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | bool | 100 | 2.867 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | bool | 10000 | 2.567 | 65024 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | class | 1 | 0.09795 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | class | 100 | 1.676 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | class | 10000 | 1.642 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | int | 1 | 0.0951 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | int | 100 | 2.889 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | int | 10000 | 2.63 | 65024 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | struct | 1 | 0.1022 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | struct | 100 | 3.394 | 0 | O(n) | O(1) |  |
| Generic | LinkedList | Iterate | struct | 10000 | 3.04 | 248320 | O(n) | O(1) |  |
| Generic | LinkedList | Remove | bool | 1 | 0.03905 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | bool | 100 | 2.105 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | bool | 10000 | 2.162 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | class | 1 | 0.03765 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | class | 100 | 2.148 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | class | 10000 | 2.187 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | int | 1 | 0.03825 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | int | 100 | 2.146 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | int | 10000 | 2.195 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | struct | 1 | 0.03835 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | struct | 100 | 2.187 | 0 | O(1) per RemoveFirst | O(1) |  |
| Generic | LinkedList | Remove | struct | 10000 | 2.205 | 512 | O(1) per RemoveFirst | O(1) |  |
| Generic | List | Add | bool | 1 | 0.0721 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | bool | 100 | 0.6346 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | bool | 10000 | 0.3452 | 45056 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | class | 1 | 0.1119 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | class | 100 | 1.915 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | class | 10000 | 1.316 | 286720 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | int | 1 | 0.0699 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | int | 100 | 0.7243 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | int | 10000 | 0.4607 | 151552 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | struct | 1 | 0.0881 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | struct | 100 | 1.63 | 4096 | O(1) amortized | O(1) amortized |  |
| Generic | List | Add | struct | 10000 | 1.015 | 811008 | O(1) amortized | O(1) amortized |  |
| Generic | List | Contains | bool | 1 | 0.0482 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | bool | 100 | 1.697 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | bool | 10000 | 0.0159 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | class | 1 | 0.0683 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | class | 100 | 20.88 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | class | 10000 | 0.2082 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | int | 1 | 0.0439 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | int | 100 | 13.07 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | int | 10000 | 0.1319 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | struct | 1 | 0.05235 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | struct | 100 | 17.08 | 0 | O(n) | O(1) |  |
| Generic | List | Contains | struct | 10000 | 0.1705 | 0 | O(n) | O(1) |  |
| Generic | List | Get | bool | 1 | 0.0314 | 0 | O(1) | O(1) |  |
| Generic | List | Get | bool | 100 | 0.288 | 0 | O(1) | O(1) |  |
| Generic | List | Get | bool | 10000 | 0.024 | 0 | O(1) | O(1) |  |
| Generic | List | Get | class | 1 | 0.04105 | 0 | O(1) | O(1) |  |
| Generic | List | Get | class | 100 | 1.055 | 0 | O(1) | O(1) |  |
| Generic | List | Get | class | 10000 | 0.0982 | 0 | O(1) | O(1) |  |
| Generic | List | Get | int | 1 | 0.032 | 0 | O(1) | O(1) |  |
| Generic | List | Get | int | 100 | 0.2896 | 0 | O(1) | O(1) |  |
| Generic | List | Get | int | 10000 | 0.0241 | 0 | O(1) | O(1) |  |
| Generic | List | Get | struct | 1 | 0.0306 | 0 | O(1) | O(1) |  |
| Generic | List | Get | struct | 100 | 0.3857 | 0 | O(1) | O(1) |  |
| Generic | List | Get | struct | 10000 | 0.0331 | 0 | O(1) | O(1) |  |
| Generic | List | InsertHead | bool | 1 | 0.0734 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | bool | 100 | 2.1 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | bool | 10000 | 6.176 | 45056 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | class | 1 | 0.1096 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | class | 100 | 4.805 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | class | 10000 | 117.2 | 286720 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | int | 1 | 0.0715 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | int | 100 | 2.307 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | int | 10000 | 20.29 | 151552 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | struct | 1 | 0.08165 | 0 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | struct | 100 | 7.327 | 4096 | O(n) per insert | O(1) amortized |  |
| Generic | List | InsertHead | struct | 10000 | 342.3 | 811008 | O(n) per insert | O(1) amortized |  |
| Generic | List | Iterate | bool | 1 | 0.0772 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | bool | 100 | 2.336 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | bool | 10000 | 2.012 | 65536 | O(n) | O(1) |  |
| Generic | List | Iterate | class | 1 | 0.07585 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | class | 100 | 1.118 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | class | 10000 | 1.037 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | int | 1 | 0.08085 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | int | 100 | 2.355 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | int | 10000 | 2.145 | 65536 | O(n) | O(1) |  |
| Generic | List | Iterate | struct | 1 | 0.0909 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | struct | 100 | 2.829 | 0 | O(n) | O(1) |  |
| Generic | List | Iterate | struct | 10000 | 2.556 | 249344 | O(n) | O(1) |  |
| Generic | List | Remove | bool | 1 | 0.03545 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | bool | 100 | 0.3245 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | bool | 10000 | 0.3045 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | class | 1 | 0.04655 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | class | 100 | 1.075 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | class | 10000 | 1.04 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | int | 1 | 0.0371 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | int | 100 | 0.3218 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | int | 10000 | 0.3042 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | struct | 1 | 0.0356 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | struct | 100 | 0.2909 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Remove | struct | 10000 | 0.2677 | 0 | O(1) per RemoveAt(last) | O(1) |  |
| Generic | List | Set | bool | 1 | 0.0047 | 0 | O(1) | O(1) |  |
| Generic | List | Set | bool | 100 | 0.5179 | 0 | O(1) | O(1) |  |
| Generic | List | Set | bool | 10000 | 0.0533 | 0 | O(1) | O(1) |  |
| Generic | List | Set | class | 1 | 0.0157 | 0 | O(1) | O(1) |  |
| Generic | List | Set | class | 100 | 1.044 | 0 | O(1) | O(1) |  |
| Generic | List | Set | class | 10000 | 0.0974 | 0 | O(1) | O(1) |  |
| Generic | List | Set | int | 1 | 0.0044 | 0 | O(1) | O(1) |  |
| Generic | List | Set | int | 100 | 0.5267 | 0 | O(1) | O(1) |  |
| Generic | List | Set | int | 10000 | 0.0533 | 0 | O(1) | O(1) |  |
| Generic | List | Set | struct | 1 | 0.00545 | 0 | O(1) | O(1) |  |
| Generic | List | Set | struct | 100 | 0.3906 | 0 | O(1) | O(1) |  |
| Generic | List | Set | struct | 10000 | 0.0379 | 0 | O(1) | O(1) |  |
| Generic | Queue | Add | bool | 1 | 0.08915 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | bool | 100 | 0.8621 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | bool | 10000 | 0.4845 | 45056 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | class | 1 | 0.1263 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | class | 100 | 2.067 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | class | 10000 | 1.392 | 286720 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | int | 1 | 0.095 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | int | 100 | 0.9688 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | int | 10000 | 0.593 | 151552 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | struct | 1 | 0.1002 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | struct | 100 | 1.918 | 4096 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Add | struct | 10000 | 1.183 | 811008 | O(1) amortized | O(1) amortized |  |
| Generic | Queue | Contains | bool | 1 | 0.06275 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | bool | 100 | 1.586 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | bool | 10000 | 0.0154 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | class | 1 | 0.0623 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | class | 100 | 20.33 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | class | 10000 | 0.2136 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | int | 1 | 0.05985 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | int | 100 | 12.99 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | int | 10000 | 0.1429 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | struct | 1 | 0.078 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | struct | 100 | 16.25 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Contains | struct | 10000 | 0.1704 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Queue | Iterate | bool | 1 | 0.0788 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | bool | 100 | 2.459 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | bool | 10000 | 2.177 | 65536 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | class | 1 | 0.0688 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | class | 100 | 1.215 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | class | 10000 | 1.12 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | int | 1 | 0.0764 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | int | 100 | 2.508 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | int | 10000 | 2.237 | 65536 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | struct | 1 | 0.09285 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | struct | 100 | 2.999 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Iterate | struct | 10000 | 2.602 | 250368 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Queue | Remove | bool | 1 | 0.0374 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | bool | 100 | 0.6208 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | bool | 10000 | 0.5819 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | class | 1 | 0.0494 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | class | 100 | 1.32 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | class | 10000 | 1.278 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | int | 1 | 0.03955 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | int | 100 | 0.6129 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | int | 10000 | 0.5736 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | struct | 1 | 0.03855 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | struct | 100 | 0.7871 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | Queue | Remove | struct | 10000 | 0.7333 | 0 | O(1) per Dequeue | O(1) |  |
| Generic | SortedDictionary | Add | bool | 1 | 0.1687 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | bool | 100 | 26.47 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | bool | 10000 | 47.38 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | class | 1 | 0.1888 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | class | 100 | 28.16 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | class | 10000 | 49.06 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | int | 1 | 0.1561 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | int | 100 | 26.79 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | int | 10000 | 47.02 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | struct | 1 | 0.1611 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | struct | 100 | 29.09 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Add | struct | 10000 | 50.64 | 192512 | O(log n) per add | O(1) per node |  |
| Generic | SortedDictionary | Get | bool | 1 | 0.06835 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | bool | 100 | 11.83 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | bool | 10000 | 2.094 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | class | 1 | 0.0713 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | class | 100 | 10.87 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | class | 10000 | 1.881 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | int | 1 | 0.0744 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | int | 100 | 12.28 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | int | 10000 | 2.159 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | struct | 1 | 0.088 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | struct | 100 | 12.93 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Get | struct | 10000 | 2.165 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Iterate | bool | 1 | 0.2408 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | bool | 100 | 5.341 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | bool | 10000 | 5.202 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | class | 1 | 0.2419 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | class | 100 | 5.458 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | class | 10000 | 5.261 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | int | 1 | 0.2363 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | int | 100 | 5.527 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | int | 10000 | 5.298 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | struct | 1 | 0.2436 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | struct | 100 | 5.169 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Iterate | struct | 10000 | 5.03 | 0 | O(n) | O(1) |  |
| Generic | SortedDictionary | Remove | bool | 1 | 0.07615 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | bool | 100 | 22.32 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | bool | 10000 | 5.01 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | class | 1 | 0.08795 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | class | 100 | 23.56 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | class | 10000 | 5.196 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | int | 1 | 0.07785 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | int | 100 | 22.18 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | int | 10000 | 5.134 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | struct | 1 | 0.08265 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | struct | 100 | 24.15 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Remove | struct | 10000 | 5.402 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | bool | 1 | 0.02615 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | bool | 100 | 11.26 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | bool | 10000 | 2.001 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | class | 1 | 0.04475 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | class | 100 | 11.59 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | class | 10000 | 1.952 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | int | 1 | 0.02365 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | int | 100 | 11.06 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | int | 10000 | 2.054 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | struct | 1 | 0.0348 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | struct | 100 | 11.78 | 0 | O(log n) | O(1) |  |
| Generic | SortedDictionary | Set | struct | 10000 | 2.055 | 0 | O(log n) | O(1) |  |
| Generic | SortedList | Add | bool | 1 | 0.1203 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | bool | 100 | 4.673 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | bool | 10000 | 6.986 | 196608 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | class | 1 | 0.1474 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | class | 100 | 5.99 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | class | 10000 | 8.093 | 438272 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | int | 1 | 0.1151 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | int | 100 | 4.885 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | int | 10000 | 7.038 | 303104 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | struct | 1 | 0.1255 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | struct | 100 | 5.679 | 4096 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Add | struct | 10000 | 7.407 | 962560 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Generic | SortedList | Get | bool | 1 | 0.06265 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | bool | 100 | 7.253 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | bool | 10000 | 1.003 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | class | 1 | 0.05095 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | class | 100 | 5.666 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | class | 10000 | 0.8906 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | int | 1 | 0.06625 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | int | 100 | 7.324 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | int | 10000 | 1.007 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | struct | 1 | 0.07635 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | struct | 100 | 7.752 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Get | struct | 10000 | 1.05 | 0 | O(log n) binary search | O(1) |  |
| Generic | SortedList | Iterate | bool | 1 | 0.1147 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | bool | 100 | 1.32 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | bool | 10000 | 1.218 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | class | 1 | 0.1308 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | class | 100 | 2.279 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | class | 10000 | 2.177 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | int | 1 | 0.1131 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | int | 100 | 1.32 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | int | 10000 | 1.211 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | struct | 1 | 0.0918 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | struct | 100 | 1.474 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Iterate | struct | 10000 | 1.402 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Generic | SortedList | Remove | bool | 1 | 0.0488 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | bool | 100 | 8.046 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | bool | 10000 | 5.444 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | class | 1 | 0.05865 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | class | 100 | 9.829 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | class | 10000 | 26.76 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | int | 1 | 0.04785 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | int | 100 | 7.807 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | int | 10000 | 7.939 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | struct | 1 | 0.0517 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | struct | 100 | 11.88 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Remove | struct | 10000 | 72.26 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Generic | SortedList | Set | bool | 1 | 0.0176 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | bool | 100 | 3.862 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | bool | 10000 | 0.8054 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | class | 1 | 0.02785 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | class | 100 | 5.523 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | class | 10000 | 0.8881 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | int | 1 | 0.0171 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | int | 100 | 4.15 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | int | 10000 | 0.8287 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | struct | 1 | 0.018 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | struct | 100 | 4.139 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedList | Set | struct | 10000 | 0.836 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Generic | SortedSet | Add | class | 1 | 0.1183 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | class | 100 | 35.07 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | class | 10000 | 63.21 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | int | 1 | 0.0882 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | int | 100 | 20.74 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | int | 10000 | 35.7 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | struct | 1 | 0.0901 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | struct | 100 | 25.89 | 0 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Add | struct | 10000 | 46.61 | 200704 | O(log n) per add | O(1) per node |  |
| Generic | SortedSet | Contains | class | 1 | 0.04605 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | class | 100 | 11.87 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | class | 10000 | 2.169 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | int | 1 | 0.0372 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | int | 100 | 5.088 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | int | 10000 | 1.059 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | struct | 1 | 0.0463 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | struct | 100 | 9.026 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Contains | struct | 10000 | 1.75 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Iterate | class | 1 | 0.1969 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | class | 100 | 4.939 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | class | 10000 | 4.74 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | int | 1 | 0.2106 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | int | 100 | 6.503 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | int | 10000 | 6.325 | 65536 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | struct | 1 | 0.2208 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | struct | 100 | 7.037 | 0 | O(n) | O(1) |  |
| Generic | SortedSet | Iterate | struct | 10000 | 6.63 | 251904 | O(n) | O(1) |  |
| Generic | SortedSet | Remove | class | 1 | 0.08905 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | class | 100 | 27.69 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | class | 10000 | 6.731 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | int | 1 | 0.06695 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | int | 100 | 18.72 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | int | 10000 | 4.054 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | struct | 1 | 0.07415 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | struct | 100 | 21.36 | 0 | O(log n) | O(1) |  |
| Generic | SortedSet | Remove | struct | 10000 | 5.054 | 0 | O(log n) | O(1) |  |
| Generic | Stack | Add | bool | 1 | 0.0855 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | bool | 100 | 0.6299 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | bool | 10000 | 0.3384 | 45056 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | class | 1 | 0.1265 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | class | 100 | 1.891 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | class | 10000 | 1.217 | 286720 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | int | 1 | 0.08445 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | int | 100 | 0.7281 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | int | 10000 | 0.4263 | 151552 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | struct | 1 | 0.0954 | 0 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | struct | 100 | 1.749 | 4096 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Add | struct | 10000 | 0.9587 | 811008 | O(1) amortized | O(1) amortized |  |
| Generic | Stack | Contains | bool | 1 | 0.06665 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | bool | 100 | 1.657 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | bool | 10000 | 0.015 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | class | 1 | 0.07165 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | class | 100 | 20.91 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | class | 10000 | 32.69 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | int | 1 | 0.0656 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | int | 100 | 13.29 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | int | 10000 | 22.6 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | struct | 1 | 0.0828 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | struct | 100 | 20.1 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Contains | struct | 10000 | 31.2 | 0 | O(n) (Peek O(1) + Contains O(n)) | O(1) |  |
| Generic | Stack | Iterate | bool | 1 | 0.0775 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | bool | 100 | 2.352 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | bool | 10000 | 2.124 | 65536 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | class | 1 | 0.07245 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | class | 100 | 1.164 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | class | 10000 | 1.098 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | int | 1 | 0.0778 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | int | 100 | 2.478 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | int | 10000 | 2.209 | 65536 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | struct | 1 | 0.09335 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | struct | 100 | 2.974 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Iterate | struct | 10000 | 2.58 | 252416 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Generic | Stack | Remove | bool | 1 | 0.03695 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | bool | 100 | 0.463 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | bool | 10000 | 0.423 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | class | 1 | 0.04765 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | class | 100 | 1.191 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | class | 10000 | 1.12 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | int | 1 | 0.036 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | int | 100 | 0.463 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | int | 10000 | 0.4283 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | struct | 1 | 0.0371 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | struct | 100 | 0.6995 | 0 | O(1) per Pop | O(1) |  |
| Generic | Stack | Remove | struct | 10000 | 0.6277 | 0 | O(1) per Pop | O(1) |  |
| Immutable | ImmutableArray | AddOne | bool | 1 | 0.2628 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | bool | 100 | 0.09915 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | bool | 10000 | 0.0089 | 12288 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | class | 1 | 0.1497 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | class | 100 | 0.3591 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | class | 10000 | 0.0528 | 81920 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | int | 1 | 0.08665 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | int | 100 | 0.1354 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | int | 10000 | 0.0427 | 40960 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | struct | 1 | 0.09525 | 0 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | struct | 100 | 0.7168 | 4096 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | AddOne | struct | 10000 | 0.1414 | 241664 | O(n) | O(n) (full array copy: NOT structural-sharing — flat array) |  |
| Immutable | ImmutableArray | Build | bool | 1 | 0.1383 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | bool | 100 | 0.561 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | bool | 10000 | 0.7247 | 24576 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | class | 1 | 0.2063 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | class | 100 | 2.108 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | class | 10000 | 1.189 | 163840 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | int | 1 | 0.147 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | int | 100 | 0.7347 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | int | 10000 | 0.6437 | 81920 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | struct | 1 | 0.1536 | 0 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | struct | 100 | 1.631 | 8192 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Build | struct | 10000 | 0.5888 | 483328 | O(n) | O(n) (one contiguous T[]; builder doubles then ToImmutable steals/copies) |  |
| Immutable | ImmutableArray | Contains | bool | 1 | 0.0622 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | bool | 100 | 2.985 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | bool | 10000 | 0.0297 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | class | 1 | 0.1133 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | class | 100 | 23.88 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | class | 10000 | 0.2351 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | int | 1 | 0.06005 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | int | 100 | 14.61 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | int | 10000 | 0.1532 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | struct | 1 | 0.0711 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | struct | 100 | 20.16 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Contains | struct | 10000 | 0.2004 | 0 | O(n) | O(1) (linear scan) |  |
| Immutable | ImmutableArray | Index | bool | 1 | 0.03255 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | bool | 100 | 0.5849 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | bool | 10000 | 0.0528 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | class | 1 | 0.0363 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | class | 100 | 0.7258 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | class | 10000 | 0.0686 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | int | 1 | 0.03465 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | int | 100 | 0.583 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | int | 10000 | 0.0555 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | struct | 1 | 0.0351 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | struct | 100 | 0.6435 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Index | struct | 10000 | 0.0622 | 0 | O(1) | O(1) (direct array index) |  |
| Immutable | ImmutableArray | Iterate | bool | 1 | 0.0483 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | bool | 100 | 0.4054 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | bool | 10000 | 0.3449 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | class | 1 | 0.05345 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | class | 100 | 0.5157 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | class | 10000 | 0.4385 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | int | 1 | 0.04905 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | int | 100 | 0.405 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | int | 10000 | 0.3422 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | struct | 1 | 0.0492 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | struct | 100 | 0.5116 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | Iterate | struct | 10000 | 0.4625 | 0 | O(n) | O(1) (struct enumerator, no alloc) |  |
| Immutable | ImmutableArray | RemoveAt | bool | 1 | 0.09895 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | bool | 100 | 0.1104 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | bool | 10000 | 0.0087 | 12288 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | class | 1 | 0.1335 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | class | 100 | 0.359 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | class | 10000 | 0.0332 | 81920 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | int | 1 | 0.0939 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | int | 100 | 0.161 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | int | 10000 | 0.0443 | 40960 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | struct | 1 | 0.0967 | 0 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | struct | 100 | 0.7411 | 4096 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | RemoveAt | struct | 10000 | 0.0917 | 241664 | O(n) | O(n) (full array copy minus 1 slot) |  |
| Immutable | ImmutableArray | SetItem | bool | 1 | 0.07865 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | bool | 100 | 0.0888 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | bool | 10000 | 0.009 | 12288 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | class | 1 | 0.1361 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | class | 100 | 0.3611 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | class | 10000 | 0.0323 | 81920 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | int | 1 | 0.0802 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | int | 100 | 0.1488 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | int | 10000 | 0.0498 | 40960 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | struct | 1 | 0.08375 | 0 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | struct | 100 | 0.7408 | 4096 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableArray | SetItem | struct | 10000 | 0.2157 | 241664 | O(n) | O(n) (full array copy with 1 slot changed) |  |
| Immutable | ImmutableDictionary | Build | bool | 1 | 0.3275 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | bool | 100 | 36.13 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | bool | 10000 | 56.14 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | class | 1 | 0.3571 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | class | 100 | 41.35 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | class | 10000 | 63.25 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | int | 1 | 0.3201 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | int | 100 | 36.33 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | int | 10000 | 56.62 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | struct | 1 | 0.3319 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | struct | 100 | 39.85 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Build | struct | 10000 | 61.55 | 270336 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableDictionary | Get | bool | 1 | 0.08255 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | bool | 100 | 6.667 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | bool | 10000 | 0.7966 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | class | 1 | 0.1032 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | class | 100 | 7.683 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | class | 10000 | 0.9022 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | int | 1 | 0.08255 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | int | 100 | 6.7 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | int | 10000 | 0.8003 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | struct | 1 | 0.0843 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | struct | 100 | 7.013 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Get | struct | 10000 | 0.8375 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableDictionary | Iterate | bool | 1 | 0.4754 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | bool | 100 | 13.49 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | bool | 10000 | 13.25 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | class | 1 | 0.52 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | class | 100 | 16.84 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | class | 10000 | 16.67 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | int | 1 | 0.482 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | int | 100 | 13.57 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | int | 10000 | 13.34 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | struct | 1 | 0.4875 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | struct | 100 | 14.24 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Iterate | struct | 10000 | 14.12 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableDictionary | Remove | bool | 1 | 0.0963 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | bool | 100 | 0.7232 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | bool | 10000 | 0.0141 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | class | 1 | 0.1351 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | class | 100 | 0.8869 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | class | 10000 | 0.0168 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | int | 1 | 0.09945 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | int | 100 | 0.713 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | int | 10000 | 0.0134 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | struct | 1 | 0.1123 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | struct | 100 | 0.822 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | Remove | struct | 10000 | 0.0145 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableDictionary | SetItem | bool | 1 | 0.1351 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | bool | 100 | 0.1767 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | bool | 10000 | 0.0027 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | class | 1 | 0.396 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | class | 100 | 1.092 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | class | 10000 | 0.0175 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | int | 1 | 0.299 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | int | 100 | 0.8057 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | int | 10000 | 0.014 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | struct | 1 | 0.3442 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | struct | 100 | 0.9972 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItem | struct | 10000 | 0.016 | 0 | O(log n) avg | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | bool | 1 | 0.3385 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | bool | 100 | 0.8788 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | bool | 10000 | 0.0155 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | class | 1 | 0.4095 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | class | 100 | 1.132 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | class | 10000 | 0.019 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | int | 1 | 0.345 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | int | 100 | 0.8468 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | int | 10000 | 0.0152 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | struct | 1 | 0.3745 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | struct | 100 | 1.07 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableDictionary | SetItemOne | struct | 10000 | 0.0177 | 0 | O(log n) avg | O(log n) (path-copy of the affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | class | 1 | 0.5251 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | class | 100 | 1.237 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | class | 10000 | 0.0208 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | int | 1 | 0.3321 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | int | 100 | 0.8472 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | int | 10000 | 0.0148 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | struct | 1 | 0.3503 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | struct | 100 | 1.011 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | AddOne | struct | 10000 | 0.0163 | 0 | O(log n) avg | O(log n) (path-copy of affected bucket's spine) |  |
| Immutable | ImmutableHashSet | Build | class | 1 | 0.536 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | class | 100 | 48.13 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | class | 10000 | 76.92 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | int | 1 | 0.3231 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | int | 100 | 36.31 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | int | 10000 | 57.21 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | struct | 1 | 0.346 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | struct | 100 | 40.35 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Build | struct | 10000 | 62.82 | 0 | O(n) avg | O(n) (hash bucket AVL trees; builder mutates then freezes) |  |
| Immutable | ImmutableHashSet | Contains | class | 1 | 0.1503 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | class | 100 | 12.13 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | class | 10000 | 1.349 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | int | 1 | 0.09675 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | int | 100 | 8.568 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | int | 10000 | 0.9831 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | struct | 1 | 0.1059 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | struct | 100 | 9.029 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Contains | struct | 10000 | 1.075 | 0 | O(log n) avg | O(1) (hash + tree descent) |  |
| Immutable | ImmutableHashSet | Iterate | class | 1 | 0.5811 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | class | 100 | 19.35 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | class | 10000 | 19.22 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | int | 1 | 0.5011 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | int | 100 | 13.7 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | int | 10000 | 13.43 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | struct | 1 | 0.4991 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | struct | 100 | 14.87 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Iterate | struct | 10000 | 14.67 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableHashSet | Remove | class | 1 | 0.285 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | class | 100 | 1.029 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | class | 10000 | 0.0182 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | int | 1 | 0.1576 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | int | 100 | 0.692 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | int | 10000 | 0.0128 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | struct | 1 | 0.1752 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | struct | 100 | 0.7818 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableHashSet | Remove | struct | 10000 | 0.0147 | 0 | O(log n) avg | O(log n) (path-copy to rebalance affected bucket) |  |
| Immutable | ImmutableList | AddOne | bool | 1 | 0.1438 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | bool | 100 | 0.3682 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | bool | 10000 | 0.0079 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | class | 1 | 0.2497 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | class | 100 | 0.6314 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | class | 10000 | 0.0123 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | int | 1 | 0.1565 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | int | 100 | 0.3999 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | int | 10000 | 0.0078 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | struct | 1 | 0.141 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | struct | 100 | 0.4472 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | AddOne | struct | 10000 | 0.0086 | 0 | O(log n) | O(log n) (structural share) |  |
| Immutable | ImmutableList | Build | bool | 1 | 0.1507 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | bool | 100 | 20.36 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | bool | 10000 | 33.67 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | class | 1 | 0.2524 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | class | 100 | 33.35 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | class | 10000 | 55.33 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | int | 1 | 0.1657 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | int | 100 | 21.28 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | int | 10000 | 34.68 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | struct | 1 | 0.1534 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | struct | 100 | 22.64 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Build | struct | 10000 | 36.85 | 0 | O(n log n) build | O(n) (AVL tree of ~n nodes; builder mutates in place then freezes) |  |
| Immutable | ImmutableList | Contains | bool | 1 | 0.3786 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | bool | 100 | 55.54 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | bool | 10000 | 0.7277 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | class | 1 | 0.4707 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | class | 100 | 697.6 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | class | 10000 | 7.25 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | int | 1 | 0.3804 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | int | 100 | 389.2 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | int | 10000 | 4.101 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | struct | 1 | 0.3935 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | struct | 100 | 410.6 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Contains | struct | 10000 | 4.24 | 0 | O(n) | O(1) (in-order linear scan) |  |
| Immutable | ImmutableList | Index | bool | 1 | 0.03965 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | bool | 100 | 3.619 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | bool | 10000 | 0.8533 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | class | 1 | 0.0449 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | class | 100 | 5.016 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | class | 10000 | 1.018 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | int | 1 | 0.0396 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | int | 100 | 3.657 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | int | 10000 | 0.9373 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | struct | 1 | 0.03865 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | struct | 100 | 3.686 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Index | struct | 10000 | 0.92 | 0 | O(log n) | O(1) (tree descent by rank) |  |
| Immutable | ImmutableList | Iterate | bool | 1 | 0.3636 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | bool | 100 | 6.857 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | bool | 10000 | 6.59 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | class | 1 | 0.4428 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | class | 100 | 12.12 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | class | 10000 | 12.05 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | int | 1 | 0.3588 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | int | 100 | 6.839 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | int | 10000 | 6.609 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | struct | 1 | 0.3581 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | struct | 100 | 6.969 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Iterate | struct | 10000 | 6.81 | 0 | O(n) | O(1) (struct enumerator with bounded stack) |  |
| Immutable | ImmutableList | Remove | bool | 1 | 0.3709 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | bool | 100 | 0.8901 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | bool | 10000 | 0.0155 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | class | 1 | 0.5415 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | class | 100 | 7.738 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | class | 10000 | 6.516 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | int | 1 | 0.3731 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | int | 100 | 4.509 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | int | 10000 | 3.527 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | struct | 1 | 0.3867 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | struct | 100 | 4.656 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | Remove | struct | 10000 | 3.715 | 0 | O(n) | O(log n) (O(n) to locate by value via scan + O(log n) path-copy to rebalance) |  |
| Immutable | ImmutableList | SetItem | bool | 1 | 0.08495 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | bool | 100 | 0.08635 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | bool | 10000 | 0.0012 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | class | 1 | 0.1596 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | class | 100 | 0.1611 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | class | 10000 | 0.0018 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | int | 1 | 0.093 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | int | 100 | 0.09305 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | int | 10000 | 0.0012 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | struct | 1 | 0.09175 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | struct | 100 | 0.09245 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableList | SetItem | struct | 10000 | 0.0013 | 0 | O(log n) | O(log n) (path-copy of spine to the index) |  |
| Immutable | ImmutableQueue | Build | bool | 1 | 0.08635 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | bool | 100 | 5.899 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | bool | 10000 | 6.011 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | class | 1 | 0.1482 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | class | 100 | 8.449 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | class | 10000 | 8.201 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | int | 1 | 0.0847 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | int | 100 | 6.032 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | int | 10000 | 5.931 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | struct | 1 | 0.08345 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | struct | 100 | 6.375 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Build | struct | 10000 | 6.568 | 0 | O(n) | O(n) (n Enqueue: each appends 1 node to a persistent forward stack; total n nodes) |  |
| Immutable | ImmutableQueue | Drain | bool | 1 | 0.0227 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | bool | 100 | 4.266 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | bool | 10000 | 4.29 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | class | 1 | 0.0613 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | class | 100 | 6.394 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | class | 10000 | 6.445 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | int | 1 | 0.0214 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | int | 100 | 4.286 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | int | 10000 | 4.341 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | struct | 1 | 0.0221 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | struct | 100 | 4.286 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Drain | struct | 10000 | 4.329 | 0 | O(n) | O(n) (n Dequeue: forward stack reversed once O(n), then n new queue heads allocated along the chain) |  |
| Immutable | ImmutableQueue | Iterate | bool | 1 | 0.093 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | bool | 100 | 2.191 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | bool | 10000 | 2.113 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | class | 1 | 0.1289 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | class | 100 | 3.823 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | class | 10000 | 3.611 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | int | 1 | 0.09325 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | int | 100 | 2.211 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | int | 10000 | 2.116 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | struct | 1 | 0.0927 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | struct | 100 | 2.344 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Iterate | struct | 10000 | 2.275 | 0 | O(n) | O(1) (struct enumerator; backward then reversed-forward) |  |
| Immutable | ImmutableQueue | Peek | bool | 1 | 0.03795 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | bool | 100 | 0.03655 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | bool | 10000 | 0.0004 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | class | 1 | 0.05095 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | class | 100 | 0.04895 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | class | 10000 | 0.0005 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | int | 1 | 0.0387 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | int | 100 | 0.03845 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | int | 10000 | 0.0004 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | struct | 1 | 0.0402 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | struct | 100 | 0.03805 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableQueue | Peek | struct | 10000 | 0.0005 | 0 | O(1) | O(1) (head of backward stack) |  |
| Immutable | ImmutableSortedDictionary | Build | bool | 1 | 0.2027 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | bool | 100 | 26.84 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | bool | 10000 | 49.64 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | class | 1 | 0.2494 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | class | 100 | 28.06 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | class | 10000 | 50.96 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | int | 1 | 0.219 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | int | 100 | 27.32 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | int | 10000 | 49.69 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | struct | 1 | 0.2007 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | struct | 100 | 27.95 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Build | struct | 10000 | 50.55 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedDictionary | Get | bool | 1 | 0.04265 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | bool | 100 | 5.094 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | bool | 10000 | 1.134 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | class | 1 | 0.06285 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | class | 100 | 6.056 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | class | 10000 | 1.2 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | int | 1 | 0.0449 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | int | 100 | 5.354 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | int | 10000 | 1.163 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | struct | 1 | 0.0469 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | struct | 100 | 5.207 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Get | struct | 10000 | 1.153 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedDictionary | Iterate | bool | 1 | 0.3743 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | bool | 100 | 7.714 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | bool | 10000 | 7.325 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | class | 1 | 0.3823 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | class | 100 | 8.14 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | class | 10000 | 7.985 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | int | 1 | 0.3637 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | int | 100 | 7.552 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | int | 10000 | 7.508 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | struct | 1 | 0.3726 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | struct | 100 | 7.63 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Iterate | struct | 10000 | 7.528 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedDictionary | Remove | bool | 1 | 0.03005 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | bool | 100 | 0.5202 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | bool | 10000 | 0.0103 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | class | 1 | 0.0462 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | class | 100 | 0.5815 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | class | 10000 | 0.0129 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | int | 1 | 0.03215 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | int | 100 | 0.529 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | int | 10000 | 0.0117 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | struct | 1 | 0.0305 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | struct | 100 | 0.5679 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | Remove | struct | 10000 | 0.011 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedDictionary | SetItem | bool | 1 | 0.02485 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | bool | 100 | 0.0255 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | bool | 10000 | 0.0003 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | class | 1 | 0.2119 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | class | 100 | 0.2115 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | class | 10000 | 0.0023 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | int | 1 | 0.1511 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | int | 100 | 0.154 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | int | 10000 | 0.0012 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | struct | 1 | 0.1509 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | struct | 100 | 0.1481 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItem | struct | 10000 | 0.0012 | 0 | O(log n) | O(log n) (path-copy; existing-key overwrite still allocs new spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | bool | 1 | 0.1862 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | bool | 100 | 0.5056 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | bool | 10000 | 0.0099 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | class | 1 | 0.2544 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | class | 100 | 0.595 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | class | 10000 | 0.0122 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | int | 1 | 0.2071 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | int | 100 | 0.5198 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | int | 10000 | 0.011 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | struct | 1 | 0.1954 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | struct | 100 | 0.5833 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedDictionary | SetItemOne | struct | 10000 | 0.0099 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | class | 1 | 0.306 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | class | 100 | 0.9706 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | class | 10000 | 0.0187 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | int | 1 | 0.1827 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | int | 100 | 0.5141 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | int | 10000 | 0.0101 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | struct | 1 | 0.176 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | struct | 100 | 0.6024 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | AddOne | struct | 10000 | 0.0113 | 0 | O(log n) | O(log n) (path-copy of root-to-leaf spine) |  |
| Immutable | ImmutableSortedSet | Build | class | 1 | 0.271 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | class | 100 | 55.52 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | class | 10000 | 106.9 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | int | 1 | 0.185 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | int | 100 | 27.2 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | int | 10000 | 50.17 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | struct | 1 | 0.1784 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | struct | 100 | 31.33 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Build | struct | 10000 | 59.73 | 0 | O(n log n) build | O(n) (sorted AVL tree of n nodes; builder mutates then freezes) |  |
| Immutable | ImmutableSortedSet | Contains | class | 1 | 0.0772 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | class | 100 | 16.06 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | class | 10000 | 3.121 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | int | 1 | 0.0404 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | int | 100 | 6.073 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | int | 10000 | 1.265 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | struct | 1 | 0.0564 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | struct | 100 | 10.86 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Contains | struct | 10000 | 2.305 | 0 | O(log n) | O(1) (binary tree descent) |  |
| Immutable | ImmutableSortedSet | Iterate | class | 1 | 0.4412 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | class | 100 | 11.09 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | class | 10000 | 10.86 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | int | 1 | 0.3548 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | int | 100 | 6.875 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | int | 10000 | 6.883 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | struct | 1 | 0.3541 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | struct | 100 | 7.002 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Iterate | struct | 10000 | 6.832 | 0 | O(n) | O(1) (struct enumerator) |  |
| Immutable | ImmutableSortedSet | Remove | class | 1 | 0.072 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | class | 100 | 0.9675 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | class | 10000 | 0.0195 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | int | 1 | 0.026 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | int | 100 | 0.4918 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | int | 10000 | 0.0103 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | struct | 1 | 0.0345 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | struct | 100 | 0.5821 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableSortedSet | Remove | struct | 10000 | 0.0112 | 0 | O(log n) | O(log n) (path-copy to rebalance) |  |
| Immutable | ImmutableStack | Build | bool | 1 | 0.0374 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | bool | 100 | 2.934 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | bool | 10000 | 2.899 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | class | 1 | 0.0665 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | class | 100 | 3.992 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | class | 10000 | 3.973 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | int | 1 | 0.0349 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | int | 100 | 2.913 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | int | 10000 | 2.997 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | struct | 1 | 0.0439 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | struct | 100 | 3.399 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Build | struct | 10000 | 3.039 | 0 | O(n) | O(n) (n Push: each prepends 1 cons-node; O(1) per push, n nodes total, tails shared) |  |
| Immutable | ImmutableStack | Drain | bool | 1 | 0.0111 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | bool | 100 | 0.4355 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | bool | 10000 | 0.4627 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | class | 1 | 0.0234 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | class | 100 | 0.6074 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | class | 10000 | 0.6072 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | int | 1 | 0.0111 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | int | 100 | 0.4365 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | int | 10000 | 0.462 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | struct | 1 | 0.011 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | struct | 100 | 0.4379 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Drain | struct | 10000 | 0.4787 | 0 | O(n) | O(0) measured (n Pop just walks shared tails; NO new nodes allocated — returns existing sub-stacks) |  |
| Immutable | ImmutableStack | Iterate | bool | 1 | 0.06695 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | bool | 100 | 1.797 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | bool | 10000 | 1.764 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | class | 1 | 0.1046 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | class | 100 | 3.134 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | class | 10000 | 3.023 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | int | 1 | 0.07205 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | int | 100 | 1.842 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | int | 10000 | 1.752 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | struct | 1 | 0.07355 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | struct | 100 | 1.91 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Iterate | struct | 10000 | 1.865 | 0 | O(n) | O(1) (struct enumerator walking the linked nodes) |  |
| Immutable | ImmutableStack | Peek | bool | 1 | 0.0345 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | bool | 100 | 0.03445 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | bool | 10000 | 0.0003 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | class | 1 | 0.03615 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | class | 100 | 0.0337 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | class | 10000 | 0.0004 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | int | 1 | 0.0335 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | int | 100 | 0.033 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | int | 10000 | 0.0003 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | struct | 1 | 0.03485 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | struct | 100 | 0.0332 | 0 | O(1) | O(1) (head cons-node) |  |
| Immutable | ImmutableStack | Peek | struct | 10000 | 0.0002 | 0 | O(1) | O(1) (head cons-node) |  |
| Legacy | ArrayList | Add | bool | 1 | 0.2789 | 0 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | bool | 100 | 6.163 | 0 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | bool | 10000 | 4.122 | 286720 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | class | 1 | 0.1046 | 0 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | class | 100 | 2.795 | 0 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | class | 10000 | 1.162 | 286720 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | int | 1 | 0.1251 | 0 | O(1) amortized | O(1) (boxed elem heap) | boxing |
| Legacy | ArrayList | Add | int | 100 | 6.404 | 0 | O(1) amortized | O(1) (boxed elem heap) | boxing |
| Legacy | ArrayList | Add | int | 10000 | 3.158 | 286720 | O(1) amortized | O(1) (boxed elem heap) | boxing |
| Legacy | ArrayList | Add | struct | 1 | 0.1337 | 0 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | struct | 100 | 3.755 | 0 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Add | struct | 10000 | 3.364 | 286720 | O(1) amortized | O(1) (boxed elem heap) |  |
| Legacy | ArrayList | Contains | bool | 1 | 0.05225 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | bool | 100 | 4.74 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | bool | 10000 | 0.0253 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | class | 1 | 0.03115 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | class | 100 | 20.13 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | class | 10000 | 0.1981 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | int | 1 | 0.0514 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) | boxing |
| Legacy | ArrayList | Contains | int | 100 | 19.57 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) | boxing |
| Legacy | ArrayList | Contains | int | 10000 | 0.1919 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) | boxing |
| Legacy | ArrayList | Contains | struct | 1 | 0.05645 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | struct | 100 | 32.11 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Contains | struct | 10000 | 0.3207 | 0 | O(n) | O(1) (linear scan; probe value boxed once per call for int/val) |  |
| Legacy | ArrayList | Index | bool | 1 | 0.03825 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | bool | 100 | 0.7768 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | bool | 10000 | 0.0757 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | class | 1 | 0.04005 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | class | 100 | 0.7793 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | class | 10000 | 0.0746 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | int | 1 | 0.04025 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) | boxing |
| Legacy | ArrayList | Index | int | 100 | 0.7798 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) | boxing |
| Legacy | ArrayList | Index | int | 10000 | 0.0747 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) | boxing |
| Legacy | ArrayList | Index | struct | 1 | 0.03905 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | struct | 100 | 0.777 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Index | struct | 10000 | 0.0737 | 0 | O(1) | O(1) (returns stored boxed reference; no new box on read) |  |
| Legacy | ArrayList | Insert0 | bool | 1 | 0.1202 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | bool | 100 | 6.24 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | bool | 10000 | 117.6 | 286720 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | class | 1 | 0.1107 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | class | 100 | 4.44 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | class | 10000 | 121.1 | 286720 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | int | 1 | 0.1233 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc | boxing |
| Legacy | ArrayList | Insert0 | int | 100 | 6.335 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc | boxing |
| Legacy | ArrayList | Insert0 | int | 10000 | 121.1 | 286720 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc | boxing |
| Legacy | ArrayList | Insert0 | struct | 1 | 0.1259 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | struct | 100 | 6.435 | 0 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Insert0 | struct | 10000 | 122.2 | 286720 | O(n) per insert (O(n^2) build) | O(1) array growth amortized + 1 boxed heap obj per value elem; head shift moves refs, no extra alloc |  |
| Legacy | ArrayList | Iterate | bool | 1 | 0.1012 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | bool | 100 | 1.072 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | bool | 10000 | 0.9749 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | class | 1 | 0.0979 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | class | 100 | 1.031 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | class | 10000 | 0.9241 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | int | 1 | 0.1003 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | ArrayList | Iterate | int | 100 | 1.058 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | ArrayList | Iterate | int | 10000 | 0.9424 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | ArrayList | Iterate | struct | 1 | 0.09545 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | struct | 100 | 1.071 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | Iterate | struct | 10000 | 0.9749 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | ArrayList | RemoveAt | bool | 1 | 0.04855 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | bool | 100 | 1.082 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | bool | 10000 | 1.045 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | class | 1 | 0.04645 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | class | 100 | 1.083 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | class | 10000 | 1.05 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | int | 1 | 0.04725 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) | boxing |
| Legacy | ArrayList | RemoveAt | int | 100 | 1.093 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) | boxing |
| Legacy | ArrayList | RemoveAt | int | 10000 | 1.046 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) | boxing |
| Legacy | ArrayList | RemoveAt | struct | 1 | 0.0482 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | struct | 100 | 1.079 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | RemoveAt | struct | 10000 | 1.04 | 0 | O(1) tail remove (O(n) drain) | O(1) (no alloc; boxed objs become garbage as removed) |  |
| Legacy | ArrayList | Set | bool | 1 | 0.02775 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | bool | 100 | 2.793 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | bool | 10000 | 0.2504 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | class | 1 | 0.0106 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | class | 100 | 0.9387 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | class | 10000 | 0.0904 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | int | 1 | 0.02905 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box | boxing |
| Legacy | ArrayList | Set | int | 100 | 2.755 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box | boxing |
| Legacy | ArrayList | Set | int | 10000 | 0.2613 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box | boxing |
| Legacy | ArrayList | Set | struct | 1 | 0.0321 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | struct | 100 | 3.294 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | ArrayList | Set | struct | 10000 | 0.3316 | 0 | O(1) | O(1) per write, but +1 NEW boxed heap obj per value-elem assignment (int/val); ref = no box |  |
| Legacy | BitArray | Get | bool | 1 | 0.03705 | 0 | O(1) | O(1) (pure bit read, NO boxing; bool returned by value) |  |
| Legacy | BitArray | Get | bool | 100 | 1.206 | 0 | O(1) | O(1) (pure bit read, NO boxing; bool returned by value) |  |
| Legacy | BitArray | Get | bool | 10000 | 0.1147 | 0 | O(1) | O(1) (pure bit read, NO boxing; bool returned by value) |  |
| Legacy | BitArray | Iterate | bool | 1 | 0.1044 | 0 | O(n) | O(1) live, but non-generic enumerator boxes each bool per step |  |
| Legacy | BitArray | Iterate | bool | 100 | 3.054 | 0 | O(n) | O(1) live, but non-generic enumerator boxes each bool per step |  |
| Legacy | BitArray | Iterate | bool | 10000 | 2.855 | 0 | O(n) | O(1) live, but non-generic enumerator boxes each bool per step |  |
| Legacy | BitArray | Set | bool | 1 | 0.0087 | 0 | O(1) | O(1) (packed 32 bits/int; pure bit write, NO boxing) |  |
| Legacy | BitArray | Set | bool | 100 | 0.6513 | 0 | O(1) | O(1) (packed 32 bits/int; pure bit write, NO boxing) |  |
| Legacy | BitArray | Set | bool | 10000 | 0.0652 | 0 | O(1) | O(1) (packed 32 bits/int; pure bit write, NO boxing) |  |
| Legacy | Hashtable | Add | bool | 1 | 0.1385 | 0 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | bool | 100 | 9.783 | 12288 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | bool | 10000 | 8.444 | 823296 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | class | 1 | 0.1333 | 0 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | class | 100 | 8.344 | 12288 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | class | 10000 | 7.216 | 823296 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | int | 1 | 0.1465 | 0 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | Hashtable | Add | int | 100 | 9.843 | 12288 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | Hashtable | Add | int | 10000 | 8.363 | 823296 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | Hashtable | Add | struct | 1 | 0.1452 | 0 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | struct | 100 | 10.51 | 12288 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Add | struct | 10000 | 9.136 | 823296 | O(1) avg | O(1) avg bucket growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | Hashtable | Get | bool | 1 | 0.1065 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | bool | 100 | 7.381 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | bool | 10000 | 0.7321 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | class | 1 | 0.1084 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | class | 100 | 7.305 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | class | 10000 | 0.7322 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | int | 1 | 0.1037 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) | boxing |
| Legacy | Hashtable | Get | int | 100 | 7.264 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) | boxing |
| Legacy | Hashtable | Get | int | 10000 | 0.7299 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) | boxing |
| Legacy | Hashtable | Get | struct | 1 | 0.1063 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | struct | 100 | 7.325 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Get | struct | 10000 | 0.7205 | 0 | O(1) avg | O(1) (int key boxed once per ContainsKey/indexer lookup; value returned as stored ref, no new box) |  |
| Legacy | Hashtable | Iterate | bool | 1 | 0.1481 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | bool | 100 | 6.82 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | bool | 10000 | 6.582 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | class | 1 | 0.1479 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | class | 100 | 6.469 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | class | 10000 | 6.056 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | int | 1 | 0.1442 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | Hashtable | Iterate | int | 100 | 6.544 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | Hashtable | Iterate | int | 10000 | 6.111 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | Hashtable | Iterate | struct | 1 | 0.1472 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | struct | 100 | 6.414 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Iterate | struct | 10000 | 6.044 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | Hashtable | Remove | bool | 1 | 0.07265 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | bool | 100 | 3.897 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | bool | 10000 | 0.3809 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | class | 1 | 0.0728 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | class | 100 | 3.919 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | class | 10000 | 0.3802 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | int | 1 | 0.07395 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | Hashtable | Remove | int | 100 | 3.921 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | Hashtable | Remove | int | 10000 | 0.3919 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | Hashtable | Remove | struct | 1 | 0.07275 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | struct | 100 | 3.847 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Remove | struct | 10000 | 0.3875 | 0 | O(1) avg | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | Hashtable | Set | bool | 1 | 0.0601 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | bool | 100 | 5.907 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | bool | 10000 | 0.5937 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | class | 1 | 0.0436 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | class | 100 | 4.393 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | class | 10000 | 0.4243 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | int | 1 | 0.0595 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | Hashtable | Set | int | 100 | 5.876 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | Hashtable | Set | int | 10000 | 0.5913 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | Hashtable | Set | struct | 1 | 0.06405 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | struct | 100 | 6.398 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Hashtable | Set | struct | 10000 | 0.6425 | 0 | O(1) avg | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Queue | Dequeue | bool | 1 | 0.0477 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | bool | 100 | 1.049 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | bool | 10000 | 1.008 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | class | 1 | 0.0469 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | class | 100 | 1.047 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | class | 10000 | 1.017 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | int | 1 | 0.04645 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) | boxing |
| Legacy | Queue | Dequeue | int | 100 | 1.035 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) | boxing |
| Legacy | Queue | Dequeue | int | 10000 | 1.015 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) | boxing |
| Legacy | Queue | Dequeue | struct | 1 | 0.0466 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | struct | 100 | 1.034 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Dequeue | struct | 10000 | 0.9989 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as dequeued) |  |
| Legacy | Queue | Enqueue | bool | 1 | 0.1178 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | bool | 100 | 3.132 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | bool | 10000 | 2.768 | 286720 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | class | 1 | 0.1063 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | class | 100 | 1.46 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | class | 10000 | 1.176 | 286720 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | int | 1 | 0.1222 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Queue | Enqueue | int | 100 | 3.185 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Queue | Enqueue | int | 10000 | 2.984 | 286720 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Queue | Enqueue | struct | 1 | 0.1296 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | struct | 100 | 3.438 | 0 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Enqueue | struct | 10000 | 3.142 | 286720 | O(1) amortized | O(1) amortized ring-buffer growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Queue | Iterate | bool | 1 | 0.0921 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | bool | 100 | 1.34 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | bool | 10000 | 1.264 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | class | 1 | 0.09235 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | class | 100 | 1.349 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | class | 10000 | 1.261 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | int | 1 | 0.09025 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Queue | Iterate | int | 100 | 1.332 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Queue | Iterate | int | 10000 | 1.256 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Queue | Iterate | struct | 1 | 0.09385 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | struct | 100 | 1.361 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Iterate | struct | 10000 | 1.282 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Queue | Peek | bool | 1 | 0.06305 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | bool | 100 | 2.653 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | bool | 10000 | 0.0254 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | class | 1 | 0.04735 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | class | 100 | 25.93 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | class | 10000 | 0.2605 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | int | 1 | 0.06495 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Queue | Peek | int | 100 | 26.47 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Queue | Peek | int | 10000 | 0.2639 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Queue | Peek | struct | 1 | 0.06525 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | struct | 100 | 36.07 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Queue | Peek | struct | 10000 | 0.3564 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | SortedList | Add | bool | 1 | 0.2655 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | bool | 100 | 12.75 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | bool | 10000 | 18.73 | 573440 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | class | 1 | 0.2499 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | class | 100 | 11.02 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | class | 10000 | 16.83 | 573440 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | int | 1 | 0.2747 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | SortedList | Add | int | 100 | 12.72 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | SortedList | Add | int | 10000 | 18.52 | 573440 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) | boxing |
| Legacy | SortedList | Add | struct | 1 | 0.2727 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | struct | 100 | 13.02 | 0 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | Add | struct | 10000 | 18.93 | 573440 | O(log n) search + O(n) shift; ascending keys -> O(1) amortized tail append (O(n) build) | O(1) amortized key/value array growth + boxed int KEY heap obj per entry + boxed value heap obj for int/val (ref value = no box) |  |
| Legacy | SortedList | ContainsKey | bool | 1 | 0.0653 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | bool | 100 | 10.37 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | bool | 10000 | 1.737 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | class | 1 | 0.06505 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | class | 100 | 10.43 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | class | 10000 | 1.749 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | int | 1 | 0.06565 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) | boxing |
| Legacy | SortedList | ContainsKey | int | 100 | 10.39 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) | boxing |
| Legacy | SortedList | ContainsKey | int | 10000 | 1.744 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) | boxing |
| Legacy | SortedList | ContainsKey | struct | 1 | 0.06765 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | struct | 100 | 10.44 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | ContainsKey | struct | 10000 | 1.723 | 0 | O(log n) binary search | O(1) (int key boxed once per lookup) |  |
| Legacy | SortedList | Iterate | bool | 1 | 0.1449 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | bool | 100 | 6.71 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | bool | 10000 | 6.202 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | class | 1 | 0.1419 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | class | 100 | 6.053 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | class | 10000 | 5.674 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | int | 1 | 0.144 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | SortedList | Iterate | int | 100 | 6.434 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | SortedList | Iterate | int | 10000 | 5.845 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) | boxing |
| Legacy | SortedList | Iterate | struct | 1 | 0.1373 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | struct | 100 | 6.108 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Iterate | struct | 10000 | 5.846 | 0 | O(n) | O(1) (foreach DictionaryEntry: entry struct boxed per step by the non-generic enumerator) |  |
| Legacy | SortedList | Remove | bool | 1 | 0.0799 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | bool | 100 | 14.76 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | bool | 10000 | 46.56 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | class | 1 | 0.0809 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | class | 100 | 14.93 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | class | 10000 | 46.47 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | int | 1 | 0.08385 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | SortedList | Remove | int | 100 | 15.12 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | SortedList | Remove | int | 10000 | 46.22 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) | boxing |
| Legacy | SortedList | Remove | struct | 1 | 0.08345 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | struct | 100 | 14.87 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Remove | struct | 10000 | 46.72 | 0 | O(log n) search + O(n) shift | O(1) (key probe boxed once per call; entry objs become garbage) |  |
| Legacy | SortedList | Set | bool | 1 | 0.06195 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | bool | 100 | 12.42 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | bool | 10000 | 1.938 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | class | 1 | 0.0441 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | class | 100 | 10.82 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | class | 10000 | 1.751 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | int | 1 | 0.06465 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | SortedList | Set | int | 100 | 12.41 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | SortedList | Set | int | 10000 | 1.988 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box | boxing |
| Legacy | SortedList | Set | struct | 1 | 0.06395 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | struct | 100 | 12.92 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | SortedList | Set | struct | 10000 | 1.982 | 0 | O(log n) | O(1), but key probe boxed + NEW boxed value heap obj per value-elem write (int/val); ref = no value box |  |
| Legacy | Stack | Iterate | bool | 1 | 0.0797 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | bool | 100 | 1.094 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | bool | 10000 | 0.9888 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | class | 1 | 0.07565 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | class | 100 | 1.076 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | class | 10000 | 0.9927 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | int | 1 | 0.078 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Stack | Iterate | int | 100 | 1.09 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Stack | Iterate | int | 10000 | 0.9963 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) | boxing |
| Legacy | Stack | Iterate | struct | 1 | 0.075 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | struct | 100 | 1.088 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Iterate | struct | 10000 | 1.007 | 0 | O(n) | O(1) (enumerator yields stored object refs; no per-elem box) |  |
| Legacy | Stack | Peek | bool | 1 | 0.06225 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | bool | 100 | 2.614 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | bool | 10000 | 0.0249 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | class | 1 | 0.04555 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | class | 100 | 20.08 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | class | 10000 | 37.89 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | int | 1 | 0.06175 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Stack | Peek | int | 100 | 19.87 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Stack | Peek | int | 10000 | 32.51 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) | boxing |
| Legacy | Stack | Peek | struct | 1 | 0.06925 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | struct | 100 | 32.34 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Peek | struct | 10000 | 62.24 | 0 | O(1) peek + O(n) Contains | O(1) (linear Contains; probe boxed once per call for int/val) |  |
| Legacy | Stack | Pop | bool | 1 | 0.04605 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | bool | 100 | 0.9114 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | bool | 10000 | 0.889 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | class | 1 | 0.04685 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | class | 100 | 0.9095 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | class | 10000 | 0.8827 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | int | 1 | 0.0479 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) | boxing |
| Legacy | Stack | Pop | int | 100 | 0.9218 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) | boxing |
| Legacy | Stack | Pop | int | 10000 | 0.884 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) | boxing |
| Legacy | Stack | Pop | struct | 1 | 0.04575 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | struct | 100 | 0.914 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Pop | struct | 10000 | 0.8857 | 0 | O(1) | O(1) (no alloc; boxed objs become garbage as popped) |  |
| Legacy | Stack | Push | bool | 1 | 0.08615 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | bool | 100 | 3.211 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | bool | 10000 | 2.598 | 180224 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | class | 1 | 0.06815 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | class | 100 | 1.548 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | class | 10000 | 1.02 | 180224 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | int | 1 | 0.0872 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Stack | Push | int | 100 | 3.188 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Stack | Push | int | 10000 | 2.593 | 180224 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box | boxing |
| Legacy | Stack | Push | struct | 1 | 0.09045 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | struct | 100 | 3.679 | 0 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Legacy | Stack | Push | struct | 10000 | 3.215 | 180224 | O(1) amortized | O(1) amortized array growth + 1 boxed heap obj per value elem (int/val); ref = no box |  |
| Native | NativeArray | Get | bool | 1 | 0.0391 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | bool | 100 | 0.9045 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | bool | 10000 | 0.0867 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | int | 1 | 0.04005 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | int | 100 | 0.8858 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | int | 10000 | 0.0844 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | struct | 1 | 0.04115 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | struct | 100 | 1.282 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Get | struct | 10000 | 0.1248 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Iterate | bool | 1 | 0.0422 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | bool | 100 | 0.9824 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | bool | 10000 | 0.9474 | 17408 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | int | 1 | 0.0423 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | int | 100 | 0.9936 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | int | 10000 | 0.9492 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | struct | 1 | 0.04345 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | struct | 100 | 1.379 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Iterate | struct | 10000 | 1.343 | 0 | O(n) | O(1) |  |
| Native | NativeArray | Set | bool | 1 | 0.039 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | bool | 100 | 0.9009 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | bool | 10000 | 0.0848 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | int | 1 | 0.04115 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | int | 100 | 0.8841 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | int | 10000 | 0.0838 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | struct | 1 | 0.0413 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | struct | 100 | 1.151 | 0 | O(1) | O(1) |  |
| Native | NativeArray | Set | struct | 10000 | 0.1119 | 0 | O(1) | O(1) |  |
| Native | NativeHashMap | Add | bool | 1 | 0.3146 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | bool | 100 | 2.986 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | bool | 10000 | 2.69 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | int | 1 | 0.3166 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | int | 100 | 2.976 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | int | 10000 | 2.685 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | struct | 1 | 0.3174 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | struct | 100 | 3.428 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Add | struct | 10000 | 3.15 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashMap | Get | bool | 1 | 0.06155 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | bool | 100 | 2.309 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | bool | 10000 | 0.2308 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | int | 1 | 0.0611 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | int | 100 | 2.367 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | int | 10000 | 0.2369 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | struct | 1 | 0.0635 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | struct | 100 | 2.656 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Get | struct | 10000 | 0.2638 | 0 | O(1) avg | O(1) (native; TryGetValue; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | bool | 1 | 0.6755 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | bool | 100 | 4.174 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | bool | 10000 | 3.796 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | int | 1 | 0.6768 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | int | 100 | 4.051 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | int | 10000 | 3.734 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | struct | 1 | 0.6777 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | struct | 100 | 4.332 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Iterate | struct | 10000 | 4.047 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashMap | Remove | bool | 1 | 0.0603 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | bool | 100 | 2.306 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | bool | 10000 | 0.2291 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | int | 1 | 0.0603 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | int | 100 | 2.246 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | int | 10000 | 0.2274 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | struct | 1 | 0.06055 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | struct | 100 | 2.27 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Remove | struct | 10000 | 0.2263 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | bool | 1 | 0.0604 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | bool | 100 | 2.081 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | bool | 10000 | 0.2052 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | int | 1 | 0.0612 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | int | 100 | 2.067 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | int | 10000 | 0.2043 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | struct | 1 | 0.0615 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | struct | 100 | 2.428 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashMap | Set | struct | 10000 | 0.2401 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Add | int | 1 | 0.3108 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Add | int | 100 | 2.664 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Add | int | 10000 | 2.377 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Add | struct | 1 | 0.316 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Add | struct | 100 | 3.159 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Add | struct | 10000 | 2.82 | 0 | O(1) avg amortized | O(n) native (managed GC ~0) |  |
| Native | NativeHashSet | Contains | int | 1 | 0.058 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Contains | int | 100 | 1.932 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Contains | int | 10000 | 0.1926 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Contains | struct | 1 | 0.0624 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Contains | struct | 100 | 2.452 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Contains | struct | 10000 | 0.2407 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | int | 1 | 0.6623 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | int | 100 | 2.411 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | int | 10000 | 2.109 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | struct | 1 | 0.6648 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | struct | 100 | 2.81 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Iterate | struct | 10000 | 2.522 | 0 | O(n) | O(1) (native struct enumerator; managed GC ~0) |  |
| Native | NativeHashSet | Remove | int | 1 | 0.06045 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Remove | int | 100 | 2.169 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Remove | int | 10000 | 0.2123 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Remove | struct | 1 | 0.06455 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Remove | struct | 100 | 2.65 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeHashSet | Remove | struct | 10000 | 0.264 | 0 | O(1) avg | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Add | bool | 1 | 0.4262 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | bool | 100 | 1.178 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | bool | 10000 | 0.7459 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | int | 1 | 0.4219 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | int | 100 | 1.182 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | int | 10000 | 0.7512 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | struct | 1 | 0.4196 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | struct | 100 | 1.203 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Add | struct | 10000 | 0.7731 | 0 | O(1) amortized | O(n) native buffer (managed GC ~0) |  |
| Native | NativeList | Contains | bool | 1 | 0.0628 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | bool | 100 | 2.429 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | bool | 10000 | 0.0244 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | int | 1 | 0.06395 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | int | 100 | 22.67 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | int | 10000 | 0.2224 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | struct | 1 | 0.0676 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | struct | 100 | 32.31 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Contains | struct | 10000 | 0.3253 | 0 | O(n) | O(1) (native linear scan; managed GC ~0) |  |
| Native | NativeList | Get | bool | 1 | 0.0458 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | bool | 100 | 1.005 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | bool | 10000 | 0.096 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | int | 1 | 0.0452 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | int | 100 | 1.088 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | int | 10000 | 0.1073 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | struct | 1 | 0.04975 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | struct | 100 | 1.507 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Get | struct | 10000 | 0.1503 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | bool | 1 | 0.0667 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | bool | 100 | 1.809 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | bool | 10000 | 1.75 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | int | 1 | 0.06895 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | int | 100 | 2.048 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | int | 10000 | 1.996 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | struct | 1 | 0.07085 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | struct | 100 | 2.495 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Iterate | struct | 10000 | 2.429 | 0 | O(n) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | bool | 1 | 0.09175 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | bool | 100 | 4.54 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | bool | 10000 | 4.419 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | int | 1 | 0.09095 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | int | 100 | 4.57 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | int | 10000 | 4.437 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | struct | 1 | 0.09235 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | struct | 100 | 4.454 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Remove | struct | 10000 | 4.38 | 0 | O(1) per RemoveAtSwapBack, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | bool | 1 | 0.0484 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | bool | 100 | 1.07 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | bool | 10000 | 0.1003 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | int | 1 | 0.0453 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | int | 100 | 1.047 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | int | 10000 | 0.1016 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | struct | 1 | 0.04735 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | struct | 100 | 1.314 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeList | Set | struct | 10000 | 0.1264 | 0 | O(1) | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Add | bool | 1 | 0.2879 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | bool | 100 | 1.629 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | bool | 10000 | 1.379 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | int | 1 | 0.2872 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | int | 100 | 1.66 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | int | 10000 | 1.347 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | struct | 1 | 0.2906 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | struct | 100 | 1.984 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Add | struct | 10000 | 1.733 | 0 | O(1) amortized | O(n) native blocks (managed GC ~0) |  |
| Native | NativeQueue | Iterate | bool | 1 | 0.2361 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | bool | 100 | 1.188 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | bool | 10000 | 0.9538 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | int | 1 | 0.2289 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | int | 100 | 1.214 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | int | 10000 | 0.9525 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | struct | 1 | 0.2348 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | struct | 100 | 1.801 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Iterate | struct | 10000 | 1.43 | 0 | O(n) | O(n) TEMP native array (Allocator.Temp, disposed in-op; managed GC ~0) |  |
| Native | NativeQueue | Remove | bool | 1 | 0.1913 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | bool | 100 | 2.561 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | bool | 10000 | 2.411 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | int | 1 | 0.1963 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | int | 100 | 2.649 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | int | 10000 | 2.546 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | struct | 1 | 0.2006 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | struct | 100 | 3.415 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| Native | NativeQueue | Remove | struct | 10000 | 3.794 | 0 | O(1) per Dequeue, O(n) to drain all | O(1) (native; managed GC ~0) |  |
| ObjectModel | Collection | Add | bool | 1 | 0.2295 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | bool | 100 | 2.275 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | bool | 10000 | 0.9964 | 45056 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | class | 1 | 0.1767 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | class | 100 | 5.317 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | class | 10000 | 3.199 | 286720 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | int | 1 | 0.1104 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | int | 100 | 2.247 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | int | 10000 | 0.998 | 151552 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | struct | 1 | 0.1121 | 0 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | struct | 100 | 3.512 | 4096 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Add | struct | 10000 | 1.907 | 811008 | O(1) amortized | O(1) amortized (backing List growth) |  |
| ObjectModel | Collection | Get | bool | 1 | 0.05315 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | bool | 100 | 2.473 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | bool | 10000 | 0.0683 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | class | 1 | 0.0829 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | class | 100 | 22.73 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | class | 10000 | 0.31 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | int | 1 | 0.0529 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | int | 100 | 13.31 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | int | 10000 | 0.1684 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | struct | 1 | 0.06115 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | struct | 100 | 19.47 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | Get | struct | 10000 | 0.2389 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | Collection | InsertHead | bool | 1 | 0.1096 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | bool | 100 | 2.718 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | bool | 10000 | 6.82 | 45056 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | class | 1 | 0.1731 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | class | 100 | 6.622 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | class | 10000 | 118.4 | 286720 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | int | 1 | 0.1092 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | int | 100 | 2.912 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | int | 10000 | 20.66 | 151552 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | struct | 1 | 0.1191 | 0 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | struct | 100 | 8.15 | 4096 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | InsertHead | struct | 10000 | 347.4 | 811008 | O(n) per insert | O(1) amortized |  |
| ObjectModel | Collection | Iterate | bool | 1 | 0.0851 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | bool | 100 | 0.6035 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | bool | 10000 | 0.5154 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | class | 1 | 0.1128 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | class | 100 | 1.078 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | class | 10000 | 0.9424 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | int | 1 | 0.0891 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | int | 100 | 0.5943 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | int | 10000 | 0.4909 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | struct | 1 | 0.09615 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | struct | 100 | 0.7285 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | Iterate | struct | 10000 | 0.6286 | 0 | O(n) | O(1) |  |
| ObjectModel | Collection | RemoveAt | bool | 1 | 0.04235 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | bool | 100 | 0.8856 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | bool | 10000 | 0.9113 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | class | 1 | 0.06285 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | class | 100 | 2.811 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | class | 10000 | 2.689 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | int | 1 | 0.0415 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | int | 100 | 0.9135 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | int | 10000 | 0.8661 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | struct | 1 | 0.04185 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | struct | 100 | 0.8967 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | RemoveAt | struct | 10000 | 0.8963 | 0 | O(1) at tail | O(1) |  |
| ObjectModel | Collection | Set | bool | 1 | 0.01095 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | bool | 100 | 0.8954 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | bool | 10000 | 0.0867 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | class | 1 | 0.0307 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | class | 100 | 2.688 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | class | 10000 | 0.2658 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | int | 1 | 0.0107 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | int | 100 | 0.8614 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | int | 10000 | 0.085 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | struct | 1 | 0.0125 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | struct | 100 | 1.17 | 0 | O(1) | O(1) |  |
| ObjectModel | Collection | Set | struct | 10000 | 0.1184 | 0 | O(1) | O(1) |  |
| ObjectModel | KeyedCollection | Add | class | 1 | 0.3881 | 0 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | class | 100 | 9.237 | 12288 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | class | 10000 | 6.454 | 1.24928e+06 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | int | 1 | 0.3091 | 0 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | int | 100 | 5.068 | 4096 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | int | 10000 | 3.339 | 835584 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | struct | 1 | 0.3352 | 0 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | struct | 100 | 7.574 | 16384 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Add | struct | 10000 | 4.754 | 2.30605e+06 | O(1) avg amortized | O(1) amortized (List + key Dictionary) |  |
| ObjectModel | KeyedCollection | Get | class | 1 | 0.0695 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | class | 100 | 4.053 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | class | 10000 | 0.3956 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | int | 1 | 0.0648 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | int | 100 | 3.632 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | int | 10000 | 0.3492 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | struct | 1 | 0.06875 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | struct | 100 | 3.95 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Get | struct | 10000 | 0.389 | 0 | O(1) avg (this[key] + Contains(key)) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | class | 1 | 0.1074 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | class | 100 | 1.052 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | class | 10000 | 0.9535 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | int | 1 | 0.0868 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | int | 100 | 0.5945 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | int | 10000 | 0.4971 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | struct | 1 | 0.1 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | struct | 100 | 0.7163 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Iterate | struct | 10000 | 0.6187 | 0 | O(n) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | class | 1 | 0.1543 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | class | 100 | 15.71 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | class | 10000 | 23.28 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | int | 1 | 0.0913 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | int | 100 | 8.694 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | int | 10000 | 4.3 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | struct | 1 | 0.09815 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | struct | 100 | 12.88 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | KeyedCollection | Remove | struct | 10000 | 67.1 | 0 | O(n) (dict lookup O(1) + List shift O(n)) | O(1) |  |
| ObjectModel | ObservableCollection | Add | bool | 1 | 0.2581 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | bool | 100 | 11.75 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | bool | 10000 | 11.3 | 167936 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | class | 1 | 0.3046 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | class | 100 | 14.74 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | class | 10000 | 13.02 | 286720 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | int | 1 | 0.2568 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | int | 100 | 12.5 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | int | 10000 | 11.44 | 274432 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | struct | 1 | 0.2756 | 0 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | struct | 100 | 15.04 | 4096 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Add | struct | 10000 | 13.29 | 811008 | O(1) amortized | O(1) |  |
| ObjectModel | ObservableCollection | Get | bool | 1 | 0.0519 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | bool | 100 | 2.493 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | bool | 10000 | 0.0655 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | class | 1 | 0.08145 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | class | 100 | 22.55 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | class | 10000 | 0.3122 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | int | 1 | 0.05025 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | int | 100 | 13.34 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | int | 10000 | 0.1702 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | struct | 1 | 0.0566 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | struct | 100 | 19.62 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | Get | struct | 10000 | 0.239 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ObservableCollection | InsertHead | bool | 1 | 0.2599 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | bool | 100 | 14.77 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | bool | 10000 | 17.41 | 167936 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | class | 1 | 0.3036 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | class | 100 | 16.57 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | class | 10000 | 130.3 | 286720 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | int | 1 | 0.259 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | int | 100 | 14.31 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | int | 10000 | 32.1 | 274432 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | struct | 1 | 0.2722 | 0 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | struct | 100 | 19.73 | 4096 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | InsertHead | struct | 10000 | 358.9 | 811008 | O(n) per insert (+ notify) | O(1) amortized (+ EventArgs per insert) |  |
| ObjectModel | ObservableCollection | Iterate | bool | 1 | 0.08185 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | bool | 100 | 0.6078 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | bool | 10000 | 0.5142 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | class | 1 | 0.1082 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | class | 100 | 1.043 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | class | 10000 | 0.9376 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | int | 1 | 0.08475 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | int | 100 | 0.5832 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | int | 10000 | 0.4885 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | struct | 1 | 0.09685 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | struct | 100 | 0.7182 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | Iterate | struct | 10000 | 0.6116 | 0 | O(n) | O(1) |  |
| ObjectModel | ObservableCollection | RemoveAt | bool | 1 | 0.1697 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | bool | 100 | 11.73 | 128 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | bool | 10000 | 11.79 | 572928 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | class | 1 | 0.1907 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | class | 100 | 13.89 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | class | 10000 | 13.37 | 275968 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | int | 1 | 0.169 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | int | 100 | 12.1 | 64 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | int | 10000 | 11.73 | 571904 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | struct | 1 | 0.1798 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | struct | 100 | 12.71 | 0 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | RemoveAt | struct | 10000 | 12.51 | 545280 | O(1) at tail (+ notify) | O(1) (+ EventArgs per remove) |  |
| ObjectModel | ObservableCollection | Set | bool | 1 | 0.2206 | 0 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | bool | 100 | 19.76 | 4096 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | bool | 10000 | 1.865 | 58368 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | class | 1 | 0.226 | 0 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | class | 100 | 19.33 | 768 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | class | 10000 | 1.886 | 18944 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | int | 1 | 0.2252 | 0 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | int | 100 | 19.58 | 4096 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | int | 10000 | 1.866 | 58368 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | struct | 1 | 0.2396 | 0 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | struct | 100 | 22.48 | 768 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ObservableCollection | Set | struct | 10000 | 2.097 | 18944 | O(1) (+ notify) | O(1) (+ EventArgs per set) |  |
| ObjectModel | ReadOnlyCollection | Get | bool | 1 | 0.05095 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | bool | 100 | 2.472 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | bool | 10000 | 0.0649 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | class | 1 | 0.0757 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | class | 100 | 22.51 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | class | 10000 | 0.3157 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | int | 1 | 0.0522 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | int | 100 | 13.22 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | int | 10000 | 0.1693 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | struct | 1 | 0.06085 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | struct | 100 | 18.8 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Get | struct | 10000 | 0.2337 | 0 | O(1) index + O(n) Contains | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | bool | 1 | 0.0854 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | bool | 100 | 0.6099 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | bool | 10000 | 0.5244 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | class | 1 | 0.1078 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | class | 100 | 1.033 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | class | 10000 | 0.9299 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | int | 1 | 0.0848 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | int | 100 | 0.5859 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | int | 10000 | 0.4902 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | struct | 1 | 0.09555 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | struct | 100 | 0.7141 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyCollection | Iterate | struct | 10000 | 0.6226 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | bool | 1 | 0.049 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | bool | 100 | 1.616 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | bool | 10000 | 0.157 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | class | 1 | 0.05145 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | class | 100 | 2.141 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | class | 10000 | 0.2117 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | int | 1 | 0.04365 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | int | 100 | 1.718 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | int | 10000 | 0.1653 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | struct | 1 | 0.0463 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | struct | 100 | 1.724 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Get | struct | 10000 | 0.1693 | 0 | O(1) avg | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | bool | 1 | 0.09925 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | bool | 100 | 1.085 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | bool | 10000 | 1.023 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | class | 1 | 0.1115 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | class | 100 | 1.974 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | class | 10000 | 1.865 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | int | 1 | 0.0951 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | int | 100 | 1.14 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | int | 10000 | 1.046 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | struct | 1 | 0.0959 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | struct | 100 | 1.451 | 0 | O(n) | O(1) |  |
| ObjectModel | ReadOnlyDictionary | Iterate | struct | 10000 | 1.358 | 0 | O(n) | O(1) |  |
