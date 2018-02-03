* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Disjoint Sets

* [Definition](#definition)
* [Naive Implementations](#naive-implementations)

## Definition

A **disjoint-set** data structure supports the following operations:

* `MakeSet(x)`: creates a singleton set {x}
* `Find(x)`: returns ID of the set containing x:
    - if x and y lie in the same set, then `Find(x) = Find(y)`
    - otherwise, `Find(x) ̸= Find(y)` 
* `Union(x, y)`: merges two sets containing x and y

## Naive Implementations

* Use the smallest element of a set as its ID
* Use array smallest[1 . . . n]: smallest[i] stores the smallest element in the set i belongs to

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds1.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds2.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds3.PNG" />

```c#

public class ArrayDisjointSet
{
    private readonly int[] _smallest;

    public ArrayDisjointSet()
    {
        _smallest = new int[100];
    }

    public void MakeSet(int index)
    {
        _smallest[index] = index;
    }

    public int Find(int index)
    {
        return _smallest[index];
    }

    public void Union(int indexI, int indexJ)
    {
        int iId = Find(indexI);
        int jId = Find(indexJ);
        if (iId == jId)
        {
            return;
        }
        int min = Math.Min(iId, jId);
        for (int i = 0; i < _smallest.Length; i++)
        {
            if (_smallest[i] == iId || _smallest[i] == jId)
            {
                _smallest[i] = min;
            }
        }
    }
}

```
Current bottleneck: Union.

What basic data structure allows for efficient merging? Linked list!

Idea: represent a set as a linked list, use the list tail as ID of the set

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds4.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds5.PNG" />

- Pros:
    * Running time of Union is O(1)
    * Well-defined ID    
- Cons:
    * Running time of Find is O(n) as we need to traverse the list to find its tail
    * Union(x, y) works in time O(1) only if we can get the tail of the list of x and the head of the list of y in constant time!
    
Can we merge in a different way?

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds6.PNG" />

**Lemma**

The height of any tree in the forest is at most log2 n.

Follows from the following lemma.

**Lemma**

Any tree of height k in the forest has at least 2^k nodes

This will imply the first lemma as follows. I assume that some tree has height strictly greater than binany logarithm of n. Using the second lemma it will be possible to show then that this tree contains more than n nodes, right? Which would lead to a contradiction with the fact that we only have n objects in our data structure. 

Proof on 2nd lemma:

Induction on k.

*Base*: initially, a tree has height 0 and one node: 2^0 = 1.
*Step*: a tree of height k results from merging two trees of height k − 1. By induction hypothesis, each of two trees
has at least 2^(k−1) nodes, hence the resulting tree contains at least 2^k nodes: 

```
2^(k−1) + 2^(k−1) = 2^(k−1) * (1 + 1) = 2^(k−1) * (2) = 2^(k-1+1) = 2^k
```



