* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Singly-Linked Lists

* [Definition](#definition)
* [List Api](#list-api)
* [Times for Some Operations](#times-for-some-operations)

## Definition

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll1b.PNG" />

```c#

public class Node
{
    public object Key { get; set; }
    public Node Next { get; set; }
}

```

## List API

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll2b.PNG" />


## Times for Some Operations

### PushFront

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll3.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll4.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll5.PNG" />

### PopFront

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll6.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll7.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll8.PNG" />

### Times for PushBack (no tail)

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll9.PNG" />

### Times for PopBack (no tail)

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll10.PNG" />

### Times for PushBack (with tail)

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll11.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll12.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll13.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll14.PNG" />

### Times for PopBack (with tail)

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll15.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll16.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll17.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SinglyLinkedList/Images/sll18.PNG" />


```
array_addr + elem_size * (i - first_index)
```
