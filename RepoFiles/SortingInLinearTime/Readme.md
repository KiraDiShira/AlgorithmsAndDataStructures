* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Sorting in linear time

* [Intro](#intro)
* [Lower bounds for sorting](#lower-bounds-for-sorting)
* [Counting sort](#counting-sort)

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

Consider a decision tree of height `h` with `l` reachable leaves corresponding to a comparison sort on `n` elements. Because each of the `n!` permutations of the input appears as some leaf, we have `n! <= l` (perchè non tutti i nodi arrivano al livello più profondo). Since a binary tree of height h has no more than `2^h` leaves, we have:

```
n! <= l <= 2^h

```

which, by taking logarithms, implies

```
h >= lg (n!)             (since the lg function is monotonically increasing)

  = OMEGA(n lg n)        (by equation (3.19): lg(n!) = THETA(n lg n))

```

## Counting sort

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SortingInLinearTime/Images/slt3.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SortingInLinearTime/Images/slt4.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SortingInLinearTime/Images/slt5.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SortingInLinearTime/Images/slt6.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/SortingInLinearTime/Images/slt7.PNG" />

```c#

static void Main(string[] args)
{
    int[] array = {2, 5, 3, 0, 2 ,3, 0, 3};
    int[] sortedOutput = new int[array.Length];

    Console.WriteLine(string.Join(",", array));

    CountingSort(array, sortedOutput, 5);

    Console.WriteLine(string.Join(",", sortedOutput));

    Console.Read();
}


private static void CountingSort(int[] array, int[] sortedOutput, int max)
{
    int[] temporaryStorage = new int[max + 1];

    foreach (int item in array)
    {
        temporaryStorage[item] += 1;
    }   

    for (int i = 1; i < temporaryStorage.Length; i++)
    {
        temporaryStorage[i] += temporaryStorage[i - 1];
    } 

    for (int i = array.Length - 1; i >= 0; i--)
    {
        sortedOutput[temporaryStorage[array[i]] - 1] = array[i];
        temporaryStorage[array[i]] -= 1;
    }
}

```
Finally, the for loop of lines 10–12 places each element `A[j]` into its correct sorted position in the output array B. If all `n` elements are distinct, then when we first enter line 10, for each `A[j]`, the value `C[A[j]]` is the correct final position of `A[j]` in the output array, since there are `C[A[j]]` elements less than or equal to `A[j]`. Because the elements might not be distinct, we decrement `C[A[j]]` each time we place a value `A[j]` into the B array. Decrementing `C[A[j]]` causes the next input element with a value equal to `A[j]`, if one exists, to go to the position immediately before `A[j]` in the output array.

How much time does counting sort require? The for loop of lines 2–3 takes time `THETA(k)`, the for loop of lines 4–5 takes time `THETA(n)`, the for loop of lines 7–8 takes time `THETA(k)`, and the for loop of lines 10–12 takes time `THETA(n)`. Thus, the overall time is`THETA(k + n)`. In practice, we usually use counting sort when we have `k = O(n)`, in which case the running time is `THETA(n)`.

An important property of counting sort is that it is stable: numbers with the same value appear in the output array in the same order as they do in the input array. That's why the for loop is in the inverted order:

```c#
for (int i = array.Length - 1; i >= 0; i--)
```
