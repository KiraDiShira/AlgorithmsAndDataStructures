* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Master theorem

* [Overview](#overview)
* [Code](#code)
* [Analysis of insertion sort](#analysis-of-insertion-sort)

## Overview

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Master%20Theorem/Images/mt1.PNG" />



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

