* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# DataStructure1Exercises

* [Check brackets in the code](#check-brackets-in-the-code)
* [Compute tree height](#compute-tree-height)

## Check brackets in the code

**Task**. Your friend is making a text editor for programmers. He is currently working on a feature that will find errors in the usage of different types of brackets. Code can contain any brackets from the set []{}(), where the opening brackets are [,{, and ( and the closing brackets corresponding to them are ],}, and ). For convenience, the text editor should not only inform the user that there is an error in the usage of brackets, but also point to the exact place in the code with the problematic bracket. First priority is to find the first unmatched closing bracket which either doesn’t have an opening bracket before it, like ] in ](), or closes the wrong opening bracket, like } in ()[}. If there are no such mistakes, then it should find the first unmatched opening bracket without the corresponding closing bracket after it, like ( in {}([]. If there are no mistakes, text editor should inform the user that the usage of brackets is correct. Apart from the brackets, code can contain big and small latin letters, digits and punctuation marks. More formally, all brackets in the code should be divided into pairs of matching brackets, such that in each pair the opening bracket goes before the closing bracket, and for any two pairs of brackets either one of them is nested inside another one as in (foo[bar]) or they are separate as in f(a,b)-g[c]. The bracket [ corresponds to the bracket ], { corresponds to }, and ( corresponds to ).

**Input Format**. Input contains one string 𝑆 which consists of big and small latin letters, digits, punctuation marks and brackets from the set []{}().

**Constraints**. The length of 𝑆 is at least 1 and at most 105.

**Output Format**. If the code in 𝑆 uses brackets correctly, output “Success" (without the quotes). Otherwise, output the 1-based index of the first unmatched closing bracket, and if there are no unmatched closing brackets, output the 1-based index of the first unmatched opening bracket


```c#
public enum BracketCheckOutput
{
    Error,
    Success
}

public class BracketsCheckResult
{
    public BracketCheckOutput BracketCheckOutput { get; set; }
    public int ErrorCharacterIndex { get; set; }

    public override string ToString()
    {
        if (BracketCheckOutput == BracketCheckOutput.Success)
        {
            return BracketCheckOutput.ToString();
        }
        return ErrorCharacterIndex.ToString();
    }
}

public class BracketsChecker
{
    private IDictionary<char, char> _bracketPairs = new Dictionary<char, char>()
    {
        {'{', '}'},
        {'[', ']'},
        {'(', ')'}
    };

    public BracketsCheckResult CheckBrackets(string text)
    {
        if (text == null) throw new ArgumentNullException(nameof(text));
        var openBracketStack = new Stack<char>();

        for (int index = 0; index < text.Length; index++)
        {
            char character = text[index];
            if (IsOpenBracket(character))
            {
                openBracketStack.Push(character);
            }
            else
            {
                if (!IsClosingBracket(character))
                {
                    continue;
                }

                if (openBracketStack.Count == 0)
                {
                    return new BracketsCheckResult()
                    {
                        BracketCheckOutput = BracketCheckOutput.Error,
                        ErrorCharacterIndex = index + 1
                    };
                }

                char lastOpenBracket = openBracketStack.Pop();
                if (_bracketPairs[lastOpenBracket] != character)
                {
                    return new BracketsCheckResult()
                    {
                        BracketCheckOutput = BracketCheckOutput.Error,
                        ErrorCharacterIndex = index + 1
                    };
                }
            }
        }

        if (openBracketStack.Count == 0)
        {
            return new BracketsCheckResult()
            {
                BracketCheckOutput = BracketCheckOutput.Success
            };
        }

        return new BracketsCheckResult()
        {
            BracketCheckOutput = BracketCheckOutput.Error,
            ErrorCharacterIndex = text.Length
        };
    }

    private bool IsClosingBracket(char character)
    {
        return _bracketPairs.Values.Contains(character);
    }

    private bool IsOpenBracket(char character)
    {
        return _bracketPairs.ContainsKey(character);
    }
}

var bracketsChecker = new BracketsChecker();

Console.WriteLine(bracketsChecker.CheckBrackets("[]")); //Success
Console.WriteLine(bracketsChecker.CheckBrackets("{}[]"));//Success
Console.WriteLine(bracketsChecker.CheckBrackets("[()]"));//Success
Console.WriteLine(bracketsChecker.CheckBrackets("(())"));//Success
Console.WriteLine(bracketsChecker.CheckBrackets("{[]}()"));//Success
Console.WriteLine(bracketsChecker.CheckBrackets("{")); //1
Console.WriteLine(bracketsChecker.CheckBrackets("{[}")); //3
Console.WriteLine(bracketsChecker.CheckBrackets("foo(bar);")); //Success
Console.WriteLine(bracketsChecker.CheckBrackets("foo(bar[i);")); //10
Console.WriteLine(bracketsChecker.CheckBrackets("{{{")); //3

```

## Compute tree height

Task. You are given a description of a rooted tree. Your task is to compute and output its height. Recall that the height of a (rooted) tree is the maximum depth of a node, or the maximum distance from a leaf to the root. You are given an arbitrary tree, not necessarily a binary tree.

Sample 1.
Input:

`5`

`4 -1 4 1 1`

<img src='https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/DataStructure1Exercises/Images/ds1e1.PNG' />

```c#

public int ComputeIterativeTreeHeight(int[] parents)
{
    int[] heights = new int[parents.Length];
    int maxHeight = 0;
    for (int key = 0; key < parents.Length; key++)
    {
        int level = 0;
        var unexploredNodes = new Stack<int>();
        int currentNode = key;
        do
        {
            if (heights[currentNode] != 0)
            {
                level = heights[currentNode];
                break;
            }
            unexploredNodes.Push(currentNode);
            currentNode = parents[currentNode];
        } while (currentNode != -1);

       
        while (unexploredNodes.Count != 0)
        {
            int node = unexploredNodes.Pop();
            heights[node] = ++level;
        }

        if (level > maxHeight)
        {
            maxHeight = level;
        }
    }

    return maxHeight;
}

```
