* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Disjoint Sets

* [Dynamic Arrays](#dynamic-arrays)
    - [Implementation](#implementation)
    - [Runtimes](#runtimes)
* Amortized Analysis
    - [Aggregate Method](#aggregate-method)
    - [Banker's Method](#bankers-method)
    - [Physicist's method](http://www.cs.cornell.edu/courses/cs3110/2013sp/lectures/lec21-amortized/lec21.html)
* [Summary](#summary)


## Definition

A **disjoint-set** data structure supports the following operations:

* `MakeSet(x)`: creates a singleton set {x}
* `Find(x)`: returns ID of the set containing x:
    - if x and y lie in the same set, then `Find(x) = Find(y)`
    - otherwise, `Find(x) ̸= Find(y)` 
* `Union(x, y)`: merges two sets containing x and y

### Implementation

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



