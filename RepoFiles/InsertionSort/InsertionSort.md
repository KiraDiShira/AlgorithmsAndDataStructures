* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Insertion sort

* [Overview](#overview)
* [Code](#code)
* [Analysis of insertion sort](#analysis-of-insertion-sort)

## Overview

![alt text](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/InsertionSort/Insertion-sort-example-300px.gif)
![alt text](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/InsertionSort/InsertionSort.PNG)

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
