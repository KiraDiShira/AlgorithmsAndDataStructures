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


## Dynamic Arrays

Unlike static arrays, dynamic arrays can be resized. Solution: dynamic arrays (also known as resizable arrays are an abstract data type with the following operations (at a minimum):

* `Get(i)`: returns element at location `i`. Must must be constant time
* `Set(i, val)`: Sets element `i` to `val`. Must be constant time
* `PushBack(val)`: Adds `val` to the end
* `Remove(i)`: Removes element at location `i`
* `Size()`: the number of elements

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



