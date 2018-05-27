[Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#table-of-contents)

# Dynamic programming

- [Coin change problem](#coin-change-problem)
- [The Alignment Game](#the-alignment-game)

## Coin change problem

**Greedy implementation**:

Greedy choice however uses the fact that, for many currencies, we simply can take the maximum value that still gives us less than then our amount and ignore all other possibilities. However, greedy doesn't work for all currencies.

For example: V = {1, 3, 4} and making change for 6: Greedy gives 4 + 1 + 1 = 3 Dynamic gives 3 + 3 = 2

**Recursive implementation**:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicProgramming/Images/dp1.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicProgramming/Images/dp2.PNG" />

**Dynamic programming implementation**:

Wouldn’t it be nice to know all the answers for changing money − coini by the time we need to compute an optimal way of changing money?

Instead of the time-consuming calls to RecursiveChange(money−coini, coins) we would simply look up these values!

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicProgramming/Images/dp3.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicProgramming/Images/dp4.PNG" />

 ```c#

public int DynamicProgrammingChange(int money, int[] coins)
{
    int[] minNumCoins = new int[money+1];
    for (int m = 1; m <= money ; m++)
    {
        minNumCoins[m] = int.MaxValue;

        for (int i = 0; i < coins.Length; i++)
        {
            if (m >= coins[i])
            {
                int numCoins = minNumCoins[m - coins[i]] + 1;
                if (numCoins < minNumCoins[m])
                {
                    minNumCoins[m] = numCoins;
                }
            }
        }
    }

    return minNumCoins[money];
}

 ```

## The Alignment Game

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicProgramming/Images/dp5.PNG" />

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicProgramming/Images/dp6.PNG" />

**Sequence alignment**

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicProgramming/Images/dp7.PNG" />

**Alignment** of two strings is a two-row matrix: 
- 1st row: symbols of the 1st string (in order) interspersed by “–”
- 2nd row: symbols of the 2nd string (in order) interspersed by “–”

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicProgramming/Images/dp8.PNG" />

Alignment score: premium for every match (+1) and penalty for every mismatch (−𝜇), indel (−𝜎).

Example: 𝜇 = 0 and 𝜎 = 1

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicProgramming/Images/dp9.PNG" />

**Alignment Score**: #matches − 𝜇 · #mismatches − 𝜎 · #indels

**Optimal alignment problem**

**Input**: Two strings, mismatch penalty 𝜇, and indel penalty 𝜎.
**Output**: An alignment of the strings maximizing the score.

We will be particularly interested in one particular score of alignment:  **common subsequence**. In this case, common subsequence is represented by ATGT, and the **longest common subsequence problems** that we will be interested in is the following. Given two strings we want to find the longest common subsequence of these strings. 

Another classical problem in computer science is the **edit distance problem**.

- Input: Two strings.
- Output: The minimum number of operations (insertions, deletions, and substitutions of symbols) to transform one string into another.

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DynamicProgramming/Images/dp10.PNG" />

And to see that the edit distance problem is equivalent to the alignment problem let's consider this alignment between editing and distance. And let's compute the total number of symbols in the two strings. 
