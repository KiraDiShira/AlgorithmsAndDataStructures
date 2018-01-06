* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Sorting in linear time

* [Intro](#intro)
* [Lower bounds for sorting](#lower-bounds-for-sorting)

## Intro

We have now introduced several algorithms that can sort n numbers in `O(n lg n)` time. Merge sort and heapsort achieve this upper bound in the worst case; quicksort achieves it on average. Moreover, for each of these algorithms, we can produce a sequence of n input numbers that causes the algorithm to run in OMEGA(n lg n) time.

These algorithms share an interesting property: *the sorted order they determine is based only on comparisons between the input elements*. We call such sorting algorithms **comparison sorts**.

We shall prove that any comparison sort must make OMEGA(n lg n) comparisons in the worst case to sort n elements. Thus, merge sort and heapsort are asymptotically optimal, and no comparison sort exists that is faster by more than a constant factor.

## Lower bounds for sorting

We can view comparison sorts abstractly in terms of decision trees. A **decision tree** is a *full binary tree* that represents the comparisons between elements that are performed by a particular sorting algorithm operating on an input of a given size. Control, data movement, and all other aspects of the algorithm are ignored.

Figure shows the decision tree corresponding to the *insertion sort algorithm* operating on an input sequence of three elements.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SortingInLinearTime/Images/slt1.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SortingInLinearTime/Images/slt2.PNG" />

Because any correct sorting algorithm must be able to produce each permutation of its input, each of the `n!` permutations on n elements must appear as one of the leaves of the decision tree for a comparison sort to be correct. Furthermore, each of these leaves must be reachable from the root by a downward path corresponding to an actual execution of the comparison sort. Thus, we shall consider only decision trees in which each permutation appears as a reachable leaf.

The length of the longest simple path from the root of a decision tree to any of its reachable leaves represents the worst-case number of comparisons that the corresponding sorting algorithm performs. Consequently, the worst-case number of comparisons for a given comparison sort algorithm equals the height of its decision tree. A lower bound on the heights of all decision trees in which each permutation appears as a reachable leaf is therefore a lower bound on the running time of any comparison sort algorithm. The following theorem establishes such a lower bound.

### Theorem

Any comparison sort algorithm requires `OMEGA(n lg n)` comparisons in the worst case.

### Proof 

Consider a decision tree of height `h` with `l` reachable leaves corresponding to a comparison sort on `n` elements. Because each of the `n!` permutations of the input appears as some leaf, we have `n! <= l` . Since a binary tree of height h has no more than `2^h` leaves, we have:

```
n! <= l <= 2^h

```

which, by taking logarithms, implies

```
h >= lg (n!)             (since the lg function is monotonically increasing)

  = OMEGA(n lg n)        (by equation (3.19): lg(n!) = THETA(n lg n))