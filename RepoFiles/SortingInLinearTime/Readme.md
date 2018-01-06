* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Sorting in linear time

* [Intro](#intro)
* [Lower bounds for sorting](#lower-bounds-for-sorting)

## Intro

We have now introduced several algorithms that can sort n numbers in `O(n lg n)` time. Merge sort and heapsort achieve this upper bound in the worst case; quicksort achieves it on average. Moreover, for each of these algorithms, we can produce a sequence of n input numbers that causes the algorithm to run in OMEGA(n lg n) time.

These algorithms share an interesting property: *the sorted order they determine is based only on comparisons between the input elements*. We call such sorting algorithms **comparison sorts**.

We shall prove that any comparison sort must make OMEGA(n lg n) comparisons in the worst case to sort n elements. Thus, merge sort and heapsort are asymptotically optimal, and no comparison sort exists that is faster by more than a constant factor.

## Lower bounds for sorting

We can view comparison sorts abstractly in terms of decision trees. A **decision tree** is a *full binary tree* that represents the comparisons between elements that are performed by a particular sorting algorithm operating on an input of a given size. Control, data movement, and all other aspects of the algorithm are ignored.

Figure shows the decision tree corresponding to the *insertion sort algorithm* operating on an input sequence of three elements.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SortingInLinearTime/Images/slt1.PNG" />


**Quicksort** applies the divide-and-conquer paradigm. Here is the three-step divide-and-conquer process for sorting a typical subarray A[p..r]:

**Divide**: Partition (rearrange) the array A[p..r] into two (possibly empty) subarrays A[p..q-1] and A[q+1..r] such that each element of A[p..q-1] is less than or equal to A[q], which is, in turn, less than or equal to each element of A[q+1..r]. Compute the index q as part of this partitioning procedure.

**Conquer**: Sort the two subarrays A[p..q-1] and A[q+1..r] by recursive calls to quicksort.

**Combine**: Because the subarrays are already sorted, no work is needed to combine them: the entire array A[p..r] is now sorted.

The following procedure implements quicksort:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/QuickSort/Images/qs2.PNG" />

```c#

private static void QuickSort(int[] array, int left, int right)
{
    if (left >= right)
    {
        return;
    }

    int pivotIndex = Partition(array, left, right);
    QuickSort(array, left, pivotIndex -1);
    QuickSort(array, pivotIndex + 1, right);
}


```

To sort an entire array A, the initial call is `QuickSort(array, 0, array.Length - 1);`

The key to the algorithm is the PARTITION procedure, which rearranges the subarray A[p..r] in place.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/QuickSort/Images/qs3.PNG" />

```c#

private static int Partition(int[] array, int left, int right)
{
    int pivot = array[right];

    int i = left - 1;

    for (int j = left; j <= right - 1; j++)
    {
        if (array[j] <= pivot)
        {
            i++;
            Exchange(array,i,j);
        }
    }

    Exchange(array,i + 1, right);
    return i + 1;
}

```

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/QuickSort/Images/qs1.PNG" />

The running time of PARTITION on the subarray A[p..r] is THETA(n), where n = r - p + 1

## Performance of quicksort

The running time of quicksort depends on whether the partitioning is balanced or unbalanced. If the partitioning is balanced, the algorithm runs asymptotically as fast as merge sort. If the partitioning is unbalanced, however, it can run asymptotically as slowly
as insertion sort.

### Worst-case partitioning

The worst-case behavior for quicksort occurs when the partitioning routine produces one subproblem with *n - 1* elements and one with 0 elements. Let us assume that this unbalanced partitioning arises in each recursive call. Since the recursive call on an array of size 0 just returns, T(0) = THETA(1), and the recurrence for the running time is:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/QuickSort/Images/qs4.PNG" />

Osservazioni: 

1) Invece di aT(n/b) si va ai nodi figli e si sommano le ricorrenze: costo delle chiamate di quicksort
2) D(n) è il costo del *partioning*
3) C(n) = 0 in questo algoritmo

Intuitively, if we sum the costs incurred at each level of the recursion, we get an arithmetic series (equation (A.2)), which evaluates to THETA(n^2).

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/QuickSort/Images/qs5.PNG" />

Indeed the recurrence has solution `T(n) = THETA(n^2)`.

Therefore the worst-case running time of quicksort is no better than that of insertion sort. Moreover, the THETA(n^2) running time
occurs when the input array is already completely sorted—a common situation in which insertion sort runs in O(n) time.

### Best-case partitioning

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/QuickSort/Images/qs6.PNG" />

### Balanced partitioning

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/QuickSort/Images/qs7.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/QuickSort/Images/qs8.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/QuickSort/Images/qs9.PNG" />

### Intuition for the average case

To develop a clear notion of the randomized behavior of quicksort, we must make an assumption about how frequently we expect to encounter the various inputs. When we run quicksort on a random input array, the partitioning is highly unlikely to happen in the same way at every level, as our informal analysis has assumed. We expect that some of the splits will be reasonably well balanced and that some will be fairly unbalanced.

In the average case, PARTITION produces a mix of “good” and “bad” splits. In a recursion tree for an average-case execution of PARTITION, the good and bad splits are distributed randomly throughout the tree. Suppose, for the sake of intuition, that the good and bad splits alternate levels in the tree, and that the good splits are best-case splits and the bad splits are worst-case splits.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/QuickSort/Images/qs10.PNG" />

Thus, the running time of quicksort, when levels alternate between good and bad splits, is like the running time for good splits alone: still O(n lg n)
