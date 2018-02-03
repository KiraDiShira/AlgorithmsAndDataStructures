* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Disjoint Sets

* [Definition](#definition)
* [Naive Implementations](#naive-implementations)
* [Trees](#trees)
* [Union by Rank](#union-by-rank)
* [Path Compression](#path-compression)

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

## Trees

- Represent each set as a rooted tree
- ID of a set is the root of the tree
- Use array parent[1 . . . n]: parent[i] is the parent of i, or i if it is the root

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds7.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds8.PNG" />

How to merge two trees?

Hang one of the trees under the root of the other one

Which one to hang?

A shorter one, since we would like to keep the trees shallow

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds9.PNG" />

## Union by Rank

* When merging two trees we hang a shorter one under the root of a taller one
* To quickly find a height of a tree, we will keep the height of each subtree in an array rank[1 . . . n]: rank[i] is the
* Hanging a shorter tree under a taller one is called a union by rank heuristic

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds10.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds11.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds12.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds13.PNG" />

Union(5, 2)
Union(3, 1)
Union(2, 3)
Union(2, 6)

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds14.PNG" />

**Lemma**

`The height of any tree in the forest is at most log2 n`

Follows from the following lemma.

**Lemma**

`Any tree of height k in the forest has at least 2^k nodes`

This will imply the first lemma as follows. I assume that some tree has height strictly greater than binany logarithm of n. Using the second lemma it will be possible to show then that this tree contains more than n nodes, right? Which would lead to a contradiction with the fact that we only have n objects in our data structure. 

Proof on 2nd lemma:

Induction on k.

*Base*: initially, a tree has height 0 and one node: 2^0 = 1.

*Step*: a tree of height k results from merging two trees of height k − 1. By induction hypothesis, each of two trees
has at least 2^(k−1) nodes, hence the resulting tree contains at least 2^k nodes: 

```
2^(k−1) + 2^(k−1) = 2^(k−1) * (1 + 1) = 2^(k−1) * (2) = 2^(k-1+1) = 2^k
```

Mia spigazione intuitiva:
Il disjoint-cresce nel caso peggiore come un albero binario. I nodi di un albero binario completo sono `2^(k+1) - 1`. Quando creaiamo un nuovo livello di profondità, nel caso peggiore, abbiamo un solo nodo all'ultimo livello, quindi il numero di nodi è quello di un albero binario completo meno un livello più un nodo: `2^(k+1-1) - 1 + 1=  2^k`

The union by rank heuristic guarantees that Union and Find work in time `O(log n)`.

Next part We’ll discover another heuristic that improves the running time to nearly constant!

## Path Compression

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds15.PNG" />

not only it finds the root for 6, it does so for all the nodes on this path. Let’s not lose this useful info.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds16.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds17.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds18.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds19.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds20.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DisjointSet/Images/ds21.PNG" />

