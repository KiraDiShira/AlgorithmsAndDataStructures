* [Index](https://github.com/anlarosa/algorithms/blob/master/README.md#project-title)

# Maximum subarray

* [Overview](#overview)
* [Code](#code)
* [Analyzing the divide-and-conquer algorithm](#analyzing-the-divide-and-conquer-algorithm)

## Overview

![alt text](https://github.com/anlarosa/algorithms/blob/master/RepoFiles/MaximumSubarray/overview.PNG)

```
13,-3,-25,20,-3,-16,-23,18,20,-7,12,-5,-22,15,-4,7

0, 15
0, 7
0, 3
0, 1
0, 0
 --> sum: 13
1, 1
 --> sum: -3
Max crossing subarray: 0, 1 --> sum: 10
--------------------> 13
2, 3
2, 2
 --> sum: -25
3, 3
 --> sum: 20
Max crossing subarray: 2, 3 --> sum: -5
--------------------> 20
Max crossing subarray: 0, 3 --> sum: 5
--------------------> 20
4, 7
4, 5
4, 4
 --> sum: -3
5, 5
 --> sum: -16
Max crossing subarray: 4, 5 --> sum: -19
--------------------> -3
6, 7
6, 6
 --> sum: -23
7, 7
 --> sum: 18
Max crossing subarray: 6, 7 --> sum: -5
--------------------> 18
Max crossing subarray: 4, 7 --> sum: -21
--------------------> 18
Max crossing subarray: 0, 7 --> sum: 17
--------------------> 20
8, 15
8, 11
8, 9
8, 8
 --> sum: 20
9, 9
 --> sum: -7
Max crossing subarray: 8, 9 --> sum: 13
--------------------> 20
10, 11
10, 10
 --> sum: 12
11, 11
 --> sum: -5
Max crossing subarray: 10, 11 --> sum: 7
--------------------> 12
Max crossing subarray: 8, 11 --> sum: 25
--------------------> 25
12, 15
12, 13
12, 12
 --> sum: -22
13, 13
 --> sum: 15
Max crossing subarray: 12, 13 --> sum: -7
--------------------> 15
14, 15
14, 14
 --> sum: -4
15, 15
 --> sum: 7
Max crossing subarray: 14, 15 --> sum: 3
--------------------> 7
Max crossing subarray: 12, 15 --> sum: 18
--------------------> 18
Max crossing subarray: 8, 15 --> sum: 16
--------------------> 25
Max crossing subarray: 0, 15 --> sum: 43
--------------------> 43

Low: 7, High: 10, Sum: 43

```

## Code

```c#
static void Main(string[] args)
{
    int[] array = new int[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };

    Result result = FindMaximumSubarray(array, 0, array.Length - 1);
}

private static Result FindMaximumSubarray(int[] array, int low, int high)
{    
    if (high == low)
    {        
        return new Result()
        {
            Low = low,
            High = high,
            Sum = array[low]
        };
    }

    int mid = (low + high) / 2;
    Result leftResult = FindMaximumSubarray(array, low, mid);
    Result rightResult = FindMaximumSubarray(array, mid + 1, high);
    Result crossResult = FindMaxCrossingSubarray(array, low, mid, high);

    if (leftResult.Sum >= rightResult.Sum && leftResult.Sum >= crossResult.Sum)
    {        
        return new Result()
        {
            Low = leftResult.Low,
            High = leftResult.High,
            Sum = leftResult.Sum
        };
    }

    if (rightResult.Sum >= leftResult.Sum && rightResult.Sum >= crossResult.Sum)
    {        
        return new Result()
        {
            Low = rightResult.Low,
            High = rightResult.High,
            Sum = rightResult.Sum
        };
    }
    
    return new Result()
    {
        Low = crossResult.Low,
        High = crossResult.High,
        Sum = crossResult.Sum
    };
}

private static Result FindMaxCrossingSubarray(int[] a, int low, int mid, int high)
{
    int leftSum = int.MinValue;
    int sum = 0;
    int maxLeft = 0;

    for (int i = mid; i >= low; i--)
    {
        sum += a[i];
        if (sum > leftSum)
        {
            leftSum = sum;
            maxLeft = i;
        }
    }

    int rightSum = int.MinValue;
    int maxRight = 0;
    sum = 0;

    for (int j = mid + 1; j <= high; j++)
    {
        sum += a[j];
        if (sum > rightSum)
        {
            rightSum = sum;
            maxRight = j;
        }
    }
    
    return new Result()
    {
        Low = maxLeft,
        High = maxRight,
        Sum = leftSum + rightSum
    };
}

```
## Analyzing the divide-and-conquer algorithm

The base case, when n = 1, is easy: constant time

<img src="https://github.com/anlarosa/algorithms/blob/master/RepoFiles/MaximumSubarray/constantTime.PNG" />
<img src="https://github.com/anlarosa/algorithms/blob/master/RepoFiles/MaximumSubarray/analysis.PNG" />
