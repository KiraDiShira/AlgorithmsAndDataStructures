* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Heapsort

* [Heaps](#heaps)
* [Maintaining the heap property](#maintaining-the-heap-property)
* [Building a heap](#building-a-heap)
* [The heapsort algorithm](#the-heapsort-algorithm)
* [Priority queues](#priority-queues)

## Heaps

The **(binary) heap** data structure is an array object that we can view as a nearly complete binary tree.
Quasi completo significa che tutti i livelli, tranne l’ultimo, sono completi: possono mancare alcune foglie consecutive a partire
dall’ultima foglia a destra. La *quasi* completezza garantisce che l’altezza di un heap con *n* nodi è THETA(ln n).

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/heaps.PNG" />

An array A that represents a heap is an object with two attributes: *A.length*, which gives the number of elements in the array, and
*A.heap-size*, which represents how many elements in the heap are stored within array A. That is, although A[1...A.length] may contain numbers, only the elements in A[1...A:heap-size], where 0 <= A.heap-size <= A.length, are valid elements of the heap.

```c#

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

    public override string ToString()
    {
        return $"{nameof(_array)}: {String.Join(",",_array)}";
    }
}

```

The root of the tree is A[1], and given the index i of a node, we can easily compute the indices of its parent, left child, and right child:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/ParentLeftRight.PNG" />

```c#

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

```

There are two kinds of binary heaps: max-heaps and min-heaps. In a max-heap, the **max-heap property** is that for every node i
other than the root,

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/maxheapformula.PNG" />

A min-heap is organized in the opposite way;

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/minheapformula.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/max-heap-min-heap.jpg" />

We define the **height of a node** in a heap to be the number of edges on the longest simple downward path from the node to a leaf, and
we define the **height of the heap** to be the height of its root.

## Maintaining the heap property

**Max-Heapify(A, i)** è un importante subroutine per manipolare max-heap quando:
* i sotto-alberi binari con radice left[i] e right[i] sono max-heap,
* ma A[i] è più piccolo dei suoi figli, violando così la proprietà del max-heap

Idea: far scendere il valore di A[i] nel max-heap in modo da ripristinare la proprietà desiderata.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/MaxHeapify1.PNG" />

```c#

public static void MaxHeapify(Heap heap, int index)
{
    int left = Left(index);
    int right = Right(index);
    int largest;
    if (left < heap.Size && heap[left] > heap[index])
    {
        largest = left;
    }
    else
    {
        largest = index;
    }
    if (right < heap.Size && heap[right] > heap[largest])
    {
        largest = right;
    }
    if (largest != index)
    {
        Exchange(heap,index,largest);
        MaxHeapify(heap, largest);
    }
}

private static void Exchange(Heap heap, int index, int largest)
{
    int heapIndex = heap[index];
    heap[index] = heap[largest];
    heap[largest] = heapIndex;
}


private static int Right(int index)
{
    return 2 * index + 2;
}

private static int Left(int index)
{
    return 2 * index + 1;
}
```
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/MaxHeapify2.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/MaxHeapify3.PNG" />

## Building a heap

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/MaxHeapify4.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/MaxHeapify5.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/MaxHeapify6.PNG" />

```c#

 private static void BuildMaxHeap(Heap heap)
 {
     heap.Size = heap.Length;
     for (int i = heap.Length / 2; i >= 0; i--)
     {
         MaxHeapify(heap, i);
     }
 }

```
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/MaxHeapify7.PNG" />

Possiamo fare di meglio osservando che il tempo di esecuzione di Max-Heapify varia al variare dell’altezza del nodo nell’heap

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/Buimaxhea.PNG" />

**Da integrareeeeeeeeeeeeeeeeeeeeeeeeeee**

## The heapsort algorithm

```c#

private static void Heapsort(Heap heap)
{
    BuildMaxHeap(heap);
    for (int i = heap.Length - 1; i >= 1; i--)
    {
        Exchange(heap, 0, i);
        heap.Size = heap.Size - 1;
        MaxHeapify(heap, 0);
    }
}
```
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/heapsortalgo1.PNG" />
<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/heapsortalgo2.PNG" />

## Priority queues

Heapsort is an excellent algorithm, but a good implementation of quicksort, presented in Chapter 7, usually beats it in practice. Nevertheless, the heap data structure itself has many uses, one of the most popular applications of a heap: as an efficient **priority queue**. 

As with heaps, priority queues come in two forms: **max-priority queues** and **min-priority queues**. We will focus here on how to implement max-priority queues.

A priority queue is a data structure for maintaining a set *S* of elements, each with an associated value called a **key**. A max-priority queue supports the following operations:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Heapsort/Images/pq1.PNG" />

Among their other applications, we can use max-priority queues to schedule jobs on a shared computer. Alternatively, a min-priority queue supports the operations INSERT, MINIMUM, EXTRACT-MIN, and DECREASE-KEY. A min-priority queue can be used in an event-driven simulator.

In a given application, such as job scheduling or event-driven simulation, elements of a priority queue correspond to objects in the application. We often need to determine which application object corresponds to a given priority-queue element, and vice versa.
When we use a heap to implement a priority queue, therefore, we often need to store a **handle** to the corresponding application object in each heap element. The exact makeup of the handle (such as a pointer or an integer) depends on the application. Similarly, we need to store a handle to the corresponding heap element in each application object. *Here, the handle would typically be an array index*. Because heap elements change locations within the array during heap operations, an actual implementation, upon relocating a heap element, would also have to update the array index in the corresponding application object. *Because the details of accessing application objects depend heavily on the application and its implementation, we shall not pursue them here, other than noting that in practice, these handles do need to be correctly maintained*.

The procedure **HEAP-MAXIMUM** implements the MAXIMUM operation in TETHA(1) time.

```c#

public int HeapMaxmimum(Heap heap)
{
    return heap[0];
}

```

The running time of **HEAP-EXTRACT-MAX** is O(lg n), since it performs only a constant amount of work on top of the O(lg n) time for MAX-HEAPIFY.

```c#

public int HeapExtractMax(Heap heap)
{
    if (heap.Size <= 0)
    {
        throw new Exception("heap underflow");
    }

    int max = heap[0];

    heap[0] = heap[heap.Size - 1];
    heap.Size--;
    MaxHeapify(heap, 0);

    return max;
}

```
The procedure **HEAP-INCREASE-KEY** implements the INCREASE-KEY operation. An index *i* into the array identifies the priority-queue element whose key we wish to increase. The procedure first updates the key of element A[i] to its new value. Because increasing the key of A[i] might violate the max-heap property, the procedure then, in a manner reminiscent of the insertion loop, traverses a simple path from this node toward the root to find a proper place for the newly increased key.

The running time of HEAP-INCREASE-KEY on an n-element heap is O(lg n), since the path traced from the node updated in line 3 to the root has length O(lg n).

```c#

public void HeapIncreaseKey(Heap heap, int index, int key)
{
    if (key < heap[index])
    {
        throw new Exception("new key is smaller than current key");
    }

    heap[index] = key;

    while (index > 0 && heap[Parent(index)] < heap[index])
    {
        Exchange(heap, index, Parent(index));
        index = Parent(index);
    }
}

```
The procedure **MAX-HEAP-INSERT** implements the INSERT operation. It takes as an input the key of the new element to be inserted into max-heap A. The procedure first expands the max-heap by adding to the tree a new leaf whose key is *-Inf*. Then it calls HEAP-INCREASE-KEY to set the key of this new node to its correct value and maintain the max-heap property.

```c#

public void MaxHeapInsert(Heap heap, int key)
{
    heap.Size++;
    heap[heap.Size] = int.MinValue;
    HeapIncreaseKey(heap, heap.Size, key);
}

```
