* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Sorting in linear time

* [Intro](#intro)
* [Lower bounds for sorting](#lower-bounds-for-sorting)

## Intro

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Array/Images/arr1.PNG" />







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
