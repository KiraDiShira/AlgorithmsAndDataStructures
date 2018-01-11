* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Singly-Linked Lists

* [Definition](#definition)
* [List Api](#list-api)
* [Times for Some Operations](#times-for-some-operations)

## Definition

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll1b.PNG" />

It's possible to have also a **Tail**: a pointer to the last node.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/Tail.PNG" />

```c#

public class Node
{
    public object Key { get; set; }
    public Node Next { get; set; }
}

```

```c#

public class SinglyLinkedList
{
    public Node Head { get; set; }
    public Node Tail { get; set; }
    
    public void PushFront(object key)
    {
           ...

```

## List API

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll2b.PNG" />


## Times for Some Operations

### PushFront

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll3.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll4.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll5.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/codice1.PNG" />

```c#

public void PushFront(object key)
{
    var node = new Node()
    {
        Key = key,
        Next = Head
    };

    Head = node;

    //Se la coda non punta ad alcuna parte vuol dire che prima la lista era vuota e 
    //il nuovo nodo è il primo nodo, quindi faccio puntare la tail all'unico elemento inserito
    if (Tail == null)
    {
        Tail = Head;
    }
}

```

### PopFront

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll6.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll7.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll8.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/codice2.PNG" />

```c#

public void PopFront()
{
    if (Head == null)
    {
        throw new Exception("ERROR: empty list");
    }

    Head = Head.Next;
    if (Head == null) //significa che la lista è vuota, quindi setto a null anche la tail
    {
        Tail = null;
    }
}

```

### Times for PushBack (no tail)

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll9.PNG" />

### Times for PopBack (no tail)

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll10.PNG" />

### Times for PushBack (with tail)

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll11.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll12.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll13.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll14.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/codice3.PNG" />

```c#

public void PushBack(object key)
{
    var node = new Node()
    {
        Key = key,
        Next = null
    };

    if (Tail == null)
    {
        Head = node;
        Tail = node;
    }
    else
    {
        Tail.Next = node;
        Tail = node;
    }
}

```

### Times for PopBack (with tail)

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll15.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll16.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll17.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll18.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/codice4.PNG" />

```c#
public void PopBack()
{
    if (Head == null)
            {
                throw new Exception("ERROR: empty list");
            }

    if (Head == Tail)
    {
        Head = null;
        Tail = null;
    }
    else
    {
        Node currentNode = Head;

        //mi trova il penultimo elemento
        while (currentNode.Next.Next != null)
        {
            currentNode = currentNode.Next;
        }

        currentNode.Next = null;
        Tail = currentNode;
    }
}

```
### Add After

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/codice5.PNG" />

```c#

public void AddAfter(Node node, object key)
{
    var newNode = new Node()
    {
        Key = key,
        Next = node.Next
    };

    node.Next = newNode;

    if (Tail == node)
    {
        Tail = newNode;
    }
}

```

## Summary

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/codice5.PNG" />
