[Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#table-of-contents)

# Dynamic programming

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
