* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# Stack

* [Definition](#definition)
* [Balanced Brackets example](#balanced-brackets-example)
* [Stack Implementation with Array](#stack-implementation-with-array)
* [Other operations](#other-operations)
* [Summary](#summary)

## Definition

**Stack**: Abstract data type with the following operations:

* `Push(Key)`: adds key to collection
* `Key Top()`: returns most recently-added key
* `Key Pop()`: removes and returns most recently-added key
* `Boolean Empty()`: are there any elements?

Stack is useful when you need to be keep track of what has happened in a particular order.

Stacks can be implemented with either an **array** or a **linked list**.

Stacks are ocassionaly known as **LIFO queues**.

Each stack operation is `O(1)`: Push, Pop, Top, Empty.

## Balanced Brackets example

**Balanced**: 
* `([])[]()`
* `((([([])]))())`

**Unbalanced**:
* `([]]()`
* `][`

<img src="https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/RepoFiles/Stack/Images/st1.PNG" />

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

## Stack Implementation with Array

Each stack operation is `O(1)`: Push, Pop, Top, Empty.

```c#

public class MyStack<T>
{
    private int _index;
    private readonly T[] _array;

    public MyStack(int size)
    {
        _array = new T[size];
        _index = 0;
    }

    public void Push(T item)
    {
        if (_index >= _array.Length)
        {
            throw new IndexOutOfRangeException("pushing index error");
        }

        _array[_index] = item;
        _index++;
    }

    public T Peek()
    {
        return _array[_index - 1];
    }

    public T Pop()
    {
        if (_index - 1 < 0)
        {
            throw new IndexOutOfRangeException("popping index error");
        }

        T item = _array[_index - 1];
        _index--;
        return item;
    }

    public bool IsEmpty()
    {
        if (_index == 0)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return String.Join(",", _array.Take(_index));
    }
}

```
