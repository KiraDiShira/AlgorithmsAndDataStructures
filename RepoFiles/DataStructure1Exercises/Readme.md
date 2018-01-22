* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# DataStructure1Exercises

* [Check brackets in the code](#check-brackets-in-the-code)
* [Compute tree height](#compute-tree-height)
* [Network packet processing simulation](#network-packet-processing-simulation)

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

## Network packet processing simulation

**Task**. You are given a series of incoming network packets, and your task is to simulate their processing. Packets arrive in some order. For each packet number 𝑖, you know the time when it arrived 𝐴𝑖 and the time it takes the processor to process it 𝑃𝑖 (both in milliseconds). There is only one processor, and it processes the incoming packets in the order of their arrival. If the processor started to process some packet, it doesn’t interrupt or stop until it finishes the processing of this packet, and the processing of
packet 𝑖 takes exactly 𝑃𝑖 milliseconds.

The computer processing the packets has a network buffer of fixed size 𝑆. When packets arrive, they are stored in the buffer before being processed. However, if the buffer is full when a packet arrives (there are 𝑆 packets which have arrived before this packet, and the computer hasn’t finished processing any of them), it is dropped and won’t be processed at all. If several packets arrive at the same time, they are first all stored in the buffer (some of them may be dropped because of that — those which are described later in the input). The computer processes the packets in the order of their arrival, and it starts processing the next available packet from the buffer as soon as it finishes processing the previous one. If at some point the computer is not busy, and there are no packets in the buffer, the computer just waits for the next packet to arrive. Note that a packet leaves the buffer and frees the space in the buffer as soon as the computer finishes processing it.

**Input Format**. The first line of the input contains the size 𝑆 of the buffer and the number 𝑛 of incoming network packets. Each of the next 𝑛 lines contains two numbers. 𝑖-th line contains the time of arrival 𝐴𝑖 and the processing time 𝑃𝑖 (both in milliseconds) of the 𝑖-th packet. It is guaranteed that the sequence of arrival times is non-decreasing (however, it can contain the exact same times of arrival in milliseconds — in this case the packet which is earlier in the input is considered to have arrived earlier).

**Constraints**. All the numbers in the input are integers. 1 ≤ 𝑆 ≤ 105 ; 1 ≤ 𝑛 ≤ 105 ; 0 ≤ 𝐴𝑖 ≤ 106 ; 0 ≤ 𝑃𝑖 ≤ 103 ; 𝐴𝑖 ≤ 𝐴𝑖+1 for 1 ≤ 𝑖 ≤ 𝑛 − 1.

**Output Format**. For each packet output either the moment of time (in milliseconds) when the processor began processing it or −1 if the packet was dropped (output the answers for the packets in the same order as the packets are given in the input).

```c#

public class Request
{
    public int ArrivalTime { get; set; }
    public int ProcessTime { get; set; }
}

public class Response
{
    public bool IsDropped { get; set; }
    public int StartTime { get; set; }

    public override string ToString()
    {
        if (IsDropped)
        {
            return "-1";
        }

        return StartTime.ToString();   
    }
}

public class Buffer
{
    private readonly int _size;
    private readonly Queue<int> _finishTime;

    public Buffer(int size)
    {
        _size = size;
        _finishTime = new Queue<int>();
    }

    public Response Process(Request request)
    {
        int arrivalTime = request.ArrivalTime;

        while (_finishTime.Count > 0 && _finishTime.Peek() <= arrivalTime)
        {
            _finishTime.Dequeue();
        }

        if (_finishTime.Count >= _size)
        {
            return new Response
            {
                IsDropped = false,
                StartTime = -1
            };
        }

        int delay = _finishTime.LastOrDefault() - request.ArrivalTime;
        if (delay < 0)
        {
            delay = 0;
        }
        int startProcessingTime = request.ArrivalTime + delay;
       
        _finishTime.Enqueue(startProcessingTime + request.ProcessTime);
        return new Response
        {
            IsDropped = false,
            StartTime = startProcessingTime
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        for (int i = 1; i <= 22; i++)
        {
            string[] lines = System.IO.File.ReadAllLines(
                $@"D:\Biblioteca\Algoritmi\DataStructure1Exercises\_74e7ea8e7a02d429cc01bd7d644ed177_Programming-Assignment-1\network_packet_processing_simulation\tests\{i.ToString().PadLeft(2,'0')}");

            IList<string> firstRow = lines[0].Split(" ").ToList();

            int bufferMaxSize = Int32.Parse(firstRow[0]);
            var buffer = new Buffer(bufferMaxSize);

            IList<Request> requests = ReadQueries(lines.Skip(1).ToArray(), Int32.Parse(firstRow[1]));
            IList<Response> responses = ProcessRequests(requests, buffer);
            IList<string> expected = System.IO.File.ReadAllLines(
                $@"D:\Biblioteca\Algoritmi\DataStructure1Exercises\_74e7ea8e7a02d429cc01bd7d644ed177_Programming-Assignment-1\network_packet_processing_simulation\tests\{i.ToString().PadLeft(2, '0')}.a");

            PrintResponses(responses, expected, i);
            //   Console.ReadLine();
        }
    }

    private static IList<Response> ProcessRequests(IList<Request> requests, Buffer buffer)
    {
        IList<Response> responses = new List<Response>();
        for (int i = 0; i < requests.Count; ++i)
        {
            responses.Add(buffer.Process(requests[i]));
        }
        return responses;
      
    }

    private static IList<Request> ReadQueries(string[] lines, int requestCount)
    {          
        IList<Request> requests = new List<Request>();
        for (int i = 0; i < requestCount; ++i)
        {
            var arr = lines[i].Split(" ").Select(Int32.Parse).ToArray();
            int arrivalTime = arr[0];
            int processTime = arr[1];
            requests.Add(new Request
            {
                ArrivalTime = arrivalTime,
                ProcessTime = processTime
            });
        }
        return requests;
    }

    private static void PrintResponses(IList<Response> responses, IList<string> expected, int file)
    {
        for (int i = 0; i < responses.Count; ++i)
        {
            string response = responses[i].ToString();

            if (response != expected[i])
            {
                Console.WriteLine($"file: {file}, expected: {expected}, value: {response}, row: {i}");
            }
        }
    }
}


```
