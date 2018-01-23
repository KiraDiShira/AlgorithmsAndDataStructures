* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Dynamic Arrays and Amortized Analysis

* [Dynamic Arrays](#dynamic-arrays)
* Amortized Analysis
  — [Aggregate Method](#aggregate-method)


## Dynamic Arrays

Unlike static arrays, dynamic arrays can be resized. Solution: dynamic arrays (also known as resizable arrays are an abstract data type with the following operations (at a minimum):

* `Get(i)`: returns element at location `i`. Must must be constant time
* `Set(i, val)`: Sets element `i` to `val`. Must be constant time
* `PushBack(val)`: Adds `val` to the end
* `Remove(i)`: Removes element at location `i`
* `Size()`: the number of elements

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicArraysandAmortizedAnalysis/Images/daaa1.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicArraysandAmortizedAnalysis/Images/daaa2.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicArraysandAmortizedAnalysis/Images/daaa3.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicArraysandAmortizedAnalysis/Images/daaa4.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicArraysandAmortizedAnalysis/Images/daaa5.PNG" />

```c#

public class DynamicArray<T>
{
    private T[] _array;
    
    private int _capacity;

    public DynamicArray(int size)
    {
        Size = 0;
        _array = new T[size];
        _capacity = size;
    }

    public int Size { get; set; }

    public T Get(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new Exception("index out of range");
            }

            return _array[index];
        }

    public void Set(int index, T value)
    {
        if (index < 0 || index >= Size)
        {
            throw new Exception("index out of range");
        }
        _array[index] = value;
    }

    public void PushBack(T value)
    {
        if (Size == _capacity)
        {
            T[] newArray = new T[_capacity * 2];
            _array.CopyTo(newArray, 0);
            _array = newArray;
            _capacity = 2 * _capacity;
        }

        _array[Size] = value;
        Size++;
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= Size)
        {
            throw new Exception("index out of range");
        }

        for (int j = index; j < Size - 1; j++)
        {
            _array[j] = _array[j + 1];
        }

        Size--;
    }
}
```

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicArraysandAmortizedAnalysis/Images/daaa6.PNG" />
