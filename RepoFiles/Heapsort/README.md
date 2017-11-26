* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Heapsort

* [Heaps](#heaps)
* [Code](#code)
* [Analysis of insertion sort](#analysis-of-insertion-sort)

## Heaps

The **(binary) heap** data structure is an array object that we can view as a nearly complete binary tree.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/heaps.PNG" />

An array A that represents a heap is an object with two attributes: *A.length*, which gives the number of elements in the array, and
*A.heap-size*, which represents how many elements in the heap are stored within array A. That is, although A[1...A.length] may contain numbers, only the elements in A[1...A:heap-size], where 0 <= A.heap-size <= A.length, are valid elements of the heap. The root of the tree is A[1], and given the index i of a node, we can easily compute the indices of its parent, left child, and right child:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/ParentLeftRight.PNG" />

There are two kinds of binary heaps: max-heaps and min-heaps. In a max-heap, the max-heap property is that for every node i
other than the root,

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/maxheapformula.PNG" />

A min-heap is organized in the opposite way;

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/minheapformula.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/max-heap-min-heap.jpg" />

We define the height of a node in a heap to be the number of edges on the longest simple downward path from the node to a leaf, and
we define the height of the heap to be the height of its root.

## Code

```c#

public static void InsertionSort(int[] array)
{
    for (int i = 1; i < array.Length; i++)
    {
        int key = array[i];
        int j = i - 1;

        while (j >= 0 && array[j] > key)
        {
            array[j + 1] = array[j];
            j--;
        }
        
        array[j + 1] = key;
    }
}
```

## Analysis of insertion sort
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/InsertionSort/InsertionSortRunningTime.PNG" width="600">

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/InsertionSort/InsertionSortRunningTimeFormula.PNG">

The best-case running time is a linear function of n:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/InsertionSort/insertionsortbestcase.PNG">

The worst case is a quadratic function:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/InsertionSort/inssortWorscase.PNG">
