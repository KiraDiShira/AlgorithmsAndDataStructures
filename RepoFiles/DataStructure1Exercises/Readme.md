* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Stack

**Task**. Your friend is making a text editor for programmers. He is currently working on a feature that will
find errors in the usage of different types of brackets. Code can contain any brackets from the set
[]{}(), where the opening brackets are [,{, and ( and the closing brackets corresponding to them
are ],}, and ).
For convenience, the text editor should not only inform the user that there is an error in the usage
of brackets, but also point to the exact place in the code with the problematic bracket. First priority
is to find the first unmatched closing bracket which either doesn’t have an opening bracket before it,
like ] in ](), or closes the wrong opening bracket, like } in ()[}. If there are no such mistakes, then
it should find the first unmatched opening bracket without the corresponding closing bracket after it,
like ( in {}([]. If there are no mistakes, text editor should inform the user that the usage of brackets
is correct.
Apart from the brackets, code can contain big and small latin letters, digits and punctuation marks.
More formally, all brackets in the code should be divided into pairs of matching brackets, such that in
each pair the opening bracket goes before the closing bracket, and for any two pairs of brackets either
one of them is nested inside another one as in (foo[bar]) or they are separate as in f(a,b)-g[c].
The bracket [ corresponds to the bracket ], { corresponds to }, and ( corresponds to ).

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
```

Constant-time access also for **multidimensional arrays**:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Array/Images/arr2.PNG" />

We need to skip the full rows that we are not using (`(3 - 1) * 6`), and then the situation is like for mono dimensional arrays:

```
array_addr + elem_size * ((3 - 1) * 6 + (4 - 1))
```
For multimensional arrays we made a supposition: all the elements of the first row, followed by all of the elements of the second row, and so on. That's called **row-major ordering** or **row-major indexing**. And what we do is basically, we lay out, (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6). And then right after that in memory (2, 1), (2, 2), (2, 3), (2, 4), (2, 5), (2, 6). So the column index is changing most rapidly as we're looking at successive elements. And that's an indication of it's row-major indexing. 

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Array/Images/arr3.PNG" />

Time for common operations:

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Array/Images/arr4.PNG" />
