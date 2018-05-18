
[Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#table-of-contents)

# Greedy algorithms

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Greedy/Images/Greedy_1.PNG" />

**Example**

What is the largest number that consists of digits 3, 9, 5, 9, 7, 1? Use all the digits.

Correct answer: 997531

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Greedy/Images/Greedy_2.PNG" />

**Another Example**

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Greedy/Images/Greedy_3.PNG" />

`Input`: A car which can travel at most L kilometers with full tank, a source point A, a destination point B and n gas stations at distances x1 ≤ x2 ≤ x3 ≤ · · · ≤ xn in kilometers from A along the path from A to B.

`Output`: The minimum number of refills to get from A to B, besides refill at A.

There are different greedy choice, for example:

- Refill at the the closest gas station
- Refill at the farthest reachable gas station
- Go until there is no fuel

The second option will give you the optimal number of refills. We will prove it later. 

A greedy choice is called **safe move** if there is an optimal solution consistent with this first move.
