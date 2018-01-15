* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Queues

* [Definition](#definition)
* [Balanced Brackets example](#balanced-brackets-example)
* [Stack Implementation with Array](#stack-implementation-with-array)
* [Stack Implementation with Linked List](#stack-implementation-with-linked-list)
* [Summary](#summary)

## Definition

**Queue**: Abstract data type with the following operations:

* `Enqueue(Key)`: adds key to collection
* `Key Dequeue()`: removes and returns least recently-added key
* `Boolean Empty()`: are there any elements?

Queues are known as **FIFO queues**.

Queue is useful when you need to be keep track of what has happened in a particular order.

Queues can be implemented with either an **array** or a **linked list**.

Each Queue operation is `O(1)`: Enqueue, Dequeue, Empty.

## Queue Implementation with Linked List

With a linked list, where you have a head and a tail pointer. 

Enqueue: we are going to push to the back of the linked list.

Dequeue: that's just an implementation of popping from the front.

```c#

public class LinkedListQueue<T>
{
    private readonly SinglyLinkedList<T> _singlyLinkedList;

    public LinkedListQueue()
    {
        _singlyLinkedList = new SinglyLinkedList<T>();
    }

    public void Enqueue(T key)
    {
        _singlyLinkedList.PushBack(key);
    }

    public T Dequeue()
    {
        T key = _singlyLinkedList.TopFront();
        _singlyLinkedList.PopFront();
        return key;
    }

    public bool IsEmpty()
    {
        return _singlyLinkedList.Empty();
    }

    public override string ToString()
    {
        return _singlyLinkedList.ToString();
    }
}

```

What would happen if we use List.PushFront to implement Enqueue and List.TopBack and List.PopBack to implement Dequeue?

If the linked-list is implemente as a doubly-linked-list there is no problem.
If the linked-list is implemente as a singly-linked-list, Dequeue would be `O(n)`.

## Stack Implementation with Array

```c#

public class MyStack<T>
{
    private int _index;
    private readonly T[] _array;

    public MyStack(int size)
    {
        _array = new T[size];
        _index = 0;
    }

    public void Push(T item)
    {
        if (_index >= _array.Length)
        {
            throw new IndexOutOfRangeException("pushing index error");
        }

        _array[_index] = item;
        _index++;
    }

    public T Peek()
    {
        return _array[_index - 1];
    }

    public T Pop()
    {
        if (_index - 1 < 0)
        {
            throw new IndexOutOfRangeException("popping index error");
        }

        T item = _array[_index - 1];
        _index--;
        return item;
    }

    public bool IsEmpty()
    {
        if (_index == 0)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return String.Join(",", _array.Take(_index));
    }
}

```
## Stack Implementation with Linked List

One limitation of the array is that we have a maximum size, based on the array we initially allocated. 

The other potential problem is that we have potentially wasted space. So if we allocated a very large array, to allow a possibly large stack, we didn't actually use much of it, all the rest of it is wasted.

 If we have a linked list, there's no a priori limit as to the number of elements you can add. As long as you have available memory, you can keep adding. There's an overhead though, like in the array, we have each element size, is just big enough to store our key. Here we've got the overhead of storing a pointer as well. On the other hand there's no wasted space in terms of allocated space that isn't actually being used. 

```c#

public class LinkedListStack<T>
{
    private readonly SinglyLinkedList<T> _singlyLinkedList;

    public LinkedListStack()
    {
        _singlyLinkedList = new SinglyLinkedList<T>();
    }

    public void Push(T item)
    {
        _singlyLinkedList.PushFront(item);
    }

    public T Peek()
    {
        return _singlyLinkedList.TopFront();
    }

    public T Pop()
    {
        T top = _singlyLinkedList.TopFront();
        _singlyLinkedList.PopFront();
        return top;
    }

    public bool IsEmpty()
    {
        return _singlyLinkedList.Empty();
    }

    public override string ToString()
    {
        return _singlyLinkedList.ToString();
    }
}

```
