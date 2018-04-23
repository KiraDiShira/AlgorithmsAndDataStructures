* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Binary Search Trees

* [Introduction](#introduction)
* [Search Trees](#search-trees)
* [Basic Operations](#basic-operations)

## Introduction

- Find all words that start with some given string
- Find all emails received in a given period.
- Find the person in your class whose height is closest to yours

All of these are example of **local search problems**:

A **Local Search Datastructure** stores a number of elements each with a key coming from an ordered set. It supports operations:

- **RangeSearch(x, y)**: Returns all elements with keys between x and y.
- **NearestNeighbors(z)**: Returns the element with keys on either side of z
- **Insert(x)**: Adds a element with key x
- **Delete(x)**: Removes the element with key x

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst1.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst2.PNG" />

How we can implement this data structure?

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst3.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst4.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst5.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst6.PNG" />

## Search Trees

Sorted arrays can search but not update.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst7.PNG" />

The Search Tree Structure:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst8.PNG" />

X’s key is larger than the key of any descendent of its left child, and smaller than the key of any descendant of its right child.

## Basic Operations

### Find

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst10.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst9.PNG" />

```c#

public class SearchTree<T>
{
    public T Key { get; set; }
    public SearchTree<T> Left { get; set; }
    public SearchTree<T> Right { get; set; }
    public SearchTree<T> Parent { get; set; }
}

```
if I want to return a null value when the key value is not found:

```c#

public class SearchTreeOperations<T> where T : IComparable<T>
{
    public SearchTree<T> Find(T key, SearchTree<T> root)
    {
        if (root.Key == null)
        {
            return null; //key value not found
        }

        if (key.Equals(root.Key))
        {
            return root;
        }

        if (key.CompareTo(root.Key) < 0)
        {
            return Find(key, root.Left);
        }

        if (key.CompareTo(root.Key) > 0)
        {
            return Find(key, root.Right);
        }

        throw new Exception("Illegal Find execution");
    }
}
```
If I want to return the closest value in the set when the key is not found:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst11.PNG" />

```c#

public class SearchTreeOperations<T> where T : IComparable<T>
{
    public SearchTree<T> Find(T key, SearchTree<T> root)
    {      
        if (key.Equals(root.Key))
        {
            return root;
        }

        if (key.CompareTo(root.Key) < 0)
        {
            if (root.Left == null)
            {
                return root;
            }

            return Find(key, root.Left);
        }

        if (key.CompareTo(root.Key) > 0)
        {
            if (root.Right == null)
            {
                return root;
            }

            return Find(key, root.Right);
        }

        throw new Exception("Illegal Find execution");
    }
}

```

### Next - node with the next largest key

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst12.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst13.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst14.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/BinarySearchTrees/Images/bst15.PNG" />
