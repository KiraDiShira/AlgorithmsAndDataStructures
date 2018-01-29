* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Priority Queues

* [Definition](#definition)
  
## Definition

**Priority queue** is an abstract data type supporting the following main operations:

* `Insert(p)` adds a new element with priority p
* `ExtractMax()` extracts an element with maximum priority

**Additional operations**:

* `Remove(it)` removes an element pointed by an iterator `it`
* `GetMax()` returns an element with maximum priority (without changing the set of elements)
* `ChangePriority(it, p)` changes the priority of an element pointed by `it` to `p`

**Algorithms that Use Priority Queues**

* `Dijkstra’s algorithm`: finding a shortest path in a graph
* `Prim’s algorithm`: constructing a minimum spanning tree of a graph
* `Huffman’s algorithm`: constructing an optimum prefix-free encoding of a string
* `Heap sort`: sorting a given sequence

About implementation?

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/PriorityQueues/Images/pq1.PNG" />

```c#

using System;
using System.Linq;

namespace HeapCoursera
{
    public class Heap
    {
        private readonly int[] _array;

        public int Size { get; set; }
        public int Length => _array.Length;

        public int this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public Heap(int[] array)
        {
            _array = array;
            Size = array.Length;
        }

        private static int Right(int index)
        {
            return 2 * index + 2;
        }

        private static int Left(int index)
        {
            return 2 * index + 1;
        }

        private static int Parent(int index)
        {
            return (index - 1) / 2;
        }

        //MaxHeapify
        private void SiftDown(int index)
        {
            int largest = index;
            int left = Left(index);
            if (left < Size && _array[left] > _array[index])
            {
                largest = left;
            }
            int right = Right(index);
            if (right < Size && _array[right] > _array[largest])
            {
                largest = right;
            }
            if (largest != index)
            {
                Exchange(index, largest);
                SiftDown(largest);
            }
        }

        private void SiftUp(int index)
        {
            while (index > 0 && _array[Parent(index)] < _array[index])
            {
                Exchange(index, Parent(index));
                index = Parent(index);
            }
        }

        public void Insert(int key)
        {
            if (Size == Length)
            {
                throw new Exception("error");
            }

            Size++;
            _array[Size] = key;
            SiftUp(Size);
        }

        public int ExtractMax()
        {
            if (Size <= 0)
            {
                throw new Exception("heap underflow");
            }

            int max = _array[0];

            _array[0] = _array[Size - 1];
            Size--;
            SiftDown(0);

            return max;
        }

        public int Max()
        {
            return _array[0];
        }

        public void Remove(int index)
        {
            _array[index] = int.MaxValue;
            SiftUp(index);
            ExtractMax();
        }

        public void ChangePriority(int index, int priority)
        {
            var oldPriority = _array[index];
            _array[index] = priority;

            if (priority > oldPriority)
            {
                SiftUp(index);
            }
            else
            {
                SiftDown(index);
            }
        }

        private  void Exchange(int index, int largest)
        {
            int heapIndex = _array[index];
            _array[index] = _array[largest];
            _array[largest] = heapIndex;
        }

        public override string ToString()
        {
            return $"{nameof(_array)}: {String.Join(",", _array.Take(Size - 1))}";
        }
    }
}

```
