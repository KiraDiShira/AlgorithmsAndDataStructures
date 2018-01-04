* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Quicksort

* [Heaps](#heaps)
* [Description of quicksort](#description-of-quicksort)
* [Building a heap](#building-a-heap)
* [The heapsort algorithm](#the-heapsort-algorithm)
* [Priority queues](#priority-queues)

## Description of quicksort

**Quicksort** applies the divide-and-conquer paradigm. Here is the three-step divide-and-conquer process for sorting a typical subarray A[p..r]:

**Divide**: Partition (rearrange) the array A[p..r] into two (possibly empty) subarrays A[p..q-1] and A[q+1..r] such that each element of A[p..q-1] is less than or equal to A[q], which is, in turn, less than or equal to each element of A[q+1..r]. Compute the index q as part of this partitioning procedure.

**Conquer**: Sort the two subarrays A[p..q-1] and A[q+1..r] by recursive calls to quicksort.

**Combine**: Because the subarrays are already sorted, no work is needed to combine them: the entire array A[p..r] is now sorted.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/QuickSort/Images/qs1.PNG" />

```c#

