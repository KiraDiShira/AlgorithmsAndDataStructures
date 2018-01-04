* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Quicksort

* [Heaps](#heaps)
* [Description of quicksort](#description-of-quicksort)
* [Performance of quicksort](#performance-of-quicksort)
* [The heapsort algorithm](#the-heapsort-algorithm)
* [Priority queues](#priority-queues)

## Description of quicksort

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


```c#

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Authentication;

namespace Heaps
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {13, 19, 9, 5, 12, 8, 7, 4, 21, 2, 6, 11};

            Console.WriteLine(string.Join(",", array));

            QuickSort(array, 0, array.Length - 1);

            Console.WriteLine(string.Join(",", array));

            Console.Read();
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int q = Partition(array, left, right);
            QuickSort(array, left, q -1);
            QuickSort(array, q + 1, right);
        }

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

        private static void Exchange(int[] array, int index1, int index2)
        {
            int item1 = array[index1];
            array[index1] = array[index2];
            array[index2] = item1;
        }
    }
}


```


