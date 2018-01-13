* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Stack

* [Definition](#definition)
* [List Api](#list-api)
* [Times for Some Operations](#times-for-some-operations)
* [Other operations](#other-operations)
* [Summary](#summary)

## Definition

**Stack**: Abstract data type with the following operations:

* `Push(Key)`: adds key to collection
* `Key Top()`: returns most recently-added key
* `Key Pop()`: removes and returns most recently-added key
* `Boolean Empty()`: are there any elements?

Stack is useful when you need to be keep track of what has happened in a particular order.

```c#

private static IDictionary<char, char> _brackets = new Dictionary<char, char>()
{
    { '(', ')'},
    { '[', ']'},
    { '{', '}'},
};

static bool IsBalanced(string source)
{
    Stack<char> stack = new Stack<char>();
    foreach (char character in source)
    {
        if (IsOpenBracket(character))
        {
            stack.Push(character);
        }
        else
        {
            if (IsStackEmpty(stack))
            {
                return false;
            }

            char top = stack.Pop();
            if (_brackets.ContainsKey(top) && character != _brackets[top])
            {
                return false;
            }
        }
    }

    return IsStackEmpty(stack);
}

private static bool IsStackEmpty(Stack<char> stack)
{
    return stack.Count == 0;
}

private static bool IsOpenBracket(char character)
{
    return _brackets.ContainsKey(character);
}

```
