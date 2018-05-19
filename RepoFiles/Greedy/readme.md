
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

```
Start at A
Refill at the farthest reachable gas station G
Make G the new A
Get from new A to B with minimum number of refills
```

**Subproblem** is a similar problem of smaller size

A greedy choice is called **safe move** if there is an optimal solution consistent with this first move.

## Money change

**Task**. The goal in this problem is to find the minimum number of coins needed to change the input value (an integer) into coins with denominations 1, 5, and 10.

 ```c#
 
public class MoneyChanger
{
    IList<int> _coinSizes = new List<int>()
    {
        10, 5, 1
    };

    public IList<int> ChangeMoney(int input)
    {
        IList<int> coins = new List<int>();

        int coinToExchange = input;
        foreach (int coinSize in _coinSizes)
        {
            while (coinToExchange >= coinSize)
            {
                coins.Add(coinSize);
                coinToExchange -= coinSize;
            }
        }

        return coins;
    }
}

```

## Maximum Value of the Loot

 ```c#
 
public class Item
{
    public double Value { get; }
    public double Weight { get; }
    public double UnitValue => Value / Weight;

    public Item(double value, double weight)
    {
        Value = value;
        Weight = weight;
    }
}

public class FractionalKnapsack
{
    public int Capacity { get; }

    public FractionalKnapsack(int capacity)
    {
        Capacity = capacity;
    }

    public IList<Item> Calculate(IList<Item> items)
    {
        IList<Item> selectedItems = new List<Item>();

        IList<Item> sortedItems = items.OrderByDescending(x => x.UnitValue).ToList();
        double availableCapacity = Capacity;

        foreach (Item item in sortedItems)
        {
            if (availableCapacity == 0)
            {
                return selectedItems;
            }

            double a = Math.Min(item.Weight, availableCapacity);
            Item itemToAdd = new Item(a * item.UnitValue, item.Weight - a);
            selectedItems.Add(itemToAdd);
            availableCapacity -= a;
        }

        return selectedItems;
    }
}

 ```
