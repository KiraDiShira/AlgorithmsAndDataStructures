* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# DataStructure2Exercises

* [Convert array into heap](#convert-array-into-heap)
* [Parallel processing](#parallel-processing)
* [Merging tables](#merging-tables)

## Convert array into heap

### Problem Introduction

In this problem you will convert an array of integers into a heap. This is the crucial step of the sorting algorithm called HeapSort. It has guaranteed worst-case running time of 𝑂(𝑛 log 𝑛) as opposed to QuickSort’s average running time of 𝑂(𝑛 log 𝑛). QuickSort is usually used in practice, because typically it is faster, but HeapSort is used for external sort when you need to sort huge files that don’t fit into memory of your computer.

### Problem Description

**Task.** The first step of the HeapSort algorithm is to create a heap from the array you want to sort. By the way, did you know that algorithms based on Heaps are widely used for external sort, when you need to sort huge files that don’t fit into memory of a computer?
Your task is to implement this first step and convert a given array of integers into a heap. You will do that by applying a certain number of swaps to the array. Swap is an operation which exchanges elements 𝑎𝑖 and 𝑎𝑗 of the array 𝑎 for some 𝑖 and 𝑗. You will need to convert the array into a heap using only 𝑂(𝑛) swaps, as was described in the lectures. Note that you will need to use a min-heap instead of a max-heap in this problem.

### Solution

```c#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BuildHeapAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Read();
            IList<Swap> swaps = BuildMinHeap(data);
            WriteResponse(swaps);
            Console.ReadLine();
        }

        private static void WriteResponse(IList<Swap> swaps)
        {
            Console.WriteLine(swaps.Count);
            foreach (Swap swap in swaps)
            {
                Console.WriteLine(swap);
            }
        }

        private static IList<Swap> BuildMinHeap(int[] data)
        {
            IList<Swap> swaps = new List<Swap>();
            for (int i = (data.Length -1) /2 ; i >= 0; i--)
            {
                MinHeapify(data, i, swaps);
            }
            return swaps;
        }

        private static void MinHeapify(int[] data,int index, IList<Swap> swaps)
        {
            int minimum = index;
            int left = Left(index);
            if (left < data.Length && data[left] < data[index])
            {
                minimum = left;
            }
            int right = Right(index);
            if (right < data.Length && data[right] < data[minimum])
            {
                minimum = right;
            }
            if (minimum != index)
            {
                swaps.Add(new Swap(index, minimum));
                Exchange(data,index, minimum);
                MinHeapify(data,minimum, swaps);
            }
        }

        private static int Right(int index)
        {
            return 2 * index + 2;
        }

        private static int Left(int index)
        {
            return 2 * index + 1;
        }

        private static void Exchange(int[] data, int index, int largest)
        {
            int heapIndex = data[index];
            data[index] = data[largest];
            data[largest] = heapIndex;
        }
       
        private static int[] Read()
        {
            return System.IO.File.ReadAllLines(
                $@"D:\Biblioteca\Algoritmi\Programming-Assignment-2\make_heap\tests\04")[1].Split(" ").Select(Int32.Parse).ToArray();
        }

        class Swap
        {
            public int Index1;
            public int Index2;

            public Swap(int index1, int index2)
            {
                this.Index1 = index1;
                this.Index2 = index2;
            }

            public override string ToString()
            {
                return $"{Index1} {Index2}";
            }
        }
    }
}

```
## Parallel processing

### Problem Description

**Task.** You have a program which is parallelized and uses 𝑛 independent threads to process the given list of 𝑚 jobs. Threads take jobs in the order they are given in the input. If there is a free thread, it immediately takes the next job from the list. If a thread has started processing a job, it doesn’t interrupt or stop until it finishes processing the job. If several threads try to take jobs from the list simultaneously, the thread with smaller index takes the job. For each job you know exactly how long will it take any thread to process this job, and this time is the same for all the threads. You need to determine for each job which thread will process it and when will it start processing. 

**Input Format.** The first line of the input contains integers 𝑛 and 𝑚. The second line contains 𝑚 integers 𝑡𝑖 — the times in seconds it takes any thread to process 𝑖-th job. The times are given in the same order as they are in the list from which threads take jobs. Threads are indexed starting from 0.

**Output Format.** Output exactly 𝑚 lines. 𝑖-th line (0-based index is used) should contain two spaceseparated integers — the 0-based index of the thread which will process the 𝑖-th job and the time in seconds when it will start processing that job.

**Sample 1.**
```
Input:
2 5
1 2 3 4 5

Output:
0 0
1 0
0 1
1 2
0 4
```

```c#

public class Job
{
    public int Priority { get; set; }
    public long Duration { get; set; }
}

class Worker : IComparable<Worker>
{
    public int Id { get; set; }
    public long AvailabilityTime { get; set; }
    
    public int CompareTo(Worker other)
    {
        int availabilityComparer = AvailabilityTime.CompareTo(other.AvailabilityTime);

        if (availabilityComparer == 0)
        {
            return Id.CompareTo(other.Id);
        }

        return availabilityComparer;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Time: {AvailabilityTime}";
    }
}

public class MinPriorityQueue<T> where T : IComparable<T>
{
    private readonly T[] _array;

    public int Size { get; set; }
    public int Length => _array.Length;

    public T this[int index]
    {
        get => _array[index];
        set => _array[index] = value;
    }

    public MinPriorityQueue(T[] array)
    {
        _array = array;
        Size = array.Length;
        BuildMinHeap();
    }

    private void BuildMinHeap()
    {
        for (int i = (_array.Length - 1) / 2; i >= 0; i--)
        {
            MinHeapify(i);
        }
    }

    public void Insert(T key)
    {
        if (Size == Length)
        {
            throw new Exception("error");
        }

        _array[Size] = key;
        SiftUp(Size);
        Size++;
    }

    public T Min()
    {
        return _array[0];
    }

    public T ExtractMin()
    {
        if (Size <= 0)
        {
            throw new Exception("heap underflow");
        }

        T max = _array[0];

        _array[0] = _array[Size - 1];
        Size--;
        MinHeapify(0);

        return max;
    }

    private void MinHeapify(int index)
    {
        int minimum = index;
        int left = Left(index);
        if (left < _array.Length && _array[left].CompareTo(_array[index]) < 0)
        {
            minimum = left;
        }
        int right = Right(index);
        if (right < _array.Length && _array[right].CompareTo(_array[minimum]) < 0)
        {
            minimum = right;
        }
        if (minimum != index)
        {
            Exchange(index, minimum);
            MinHeapify(minimum);
        }
    }

    private void Exchange(int index, int largest)
    {
        T heapIndex = _array[index];
        _array[index] = _array[largest];
        _array[largest] = heapIndex;
    }

    private int Right(int index)
    {
        return 2 * index + 2;
    }

    private int Left(int index)
    {
        return 2 * index + 1;
    }

    private void SiftUp(int index)
    {
        while (index > 0 && _array[Parent(index)].CompareTo(_array[index]) > 0)
        {
            Exchange(index, Parent(index));
            index = Parent(index);
        }
    }

    private static int Parent(int index)
    {
        return (index - 1) / 2;
    }
}

class Program
{
    private int numWorkers;
    private int[] jobs;

    private int[] assignedWorker;
    private long[] startTime;

    static void Main(string[] args)
    {
        new Program().Solve();
    }

    private void Solve()
    {
        ReadData();
        IList<Worker> workers = AssignJobs();
       

        Console.ReadLine();
    }

    private void WriteResponse()
    {
        for (int i = 0; i < jobs.Length; ++i)
        {
            Console.WriteLine(assignedWorker[i] + " " + startTime[i]);
        }
    }

    private IList<Worker> AssignJobs()
    {
        var jobArray = new Job[jobs.Length];
        for (int i = 0; i < jobs.Length; i++)
        {
            jobArray[i] = new Job()
            {
                Duration = jobs[i],
                Priority = i
            };
        }

        var workerArray = new Worker[numWorkers];
        for (int i = 0; i < workerArray.Length; i++)
        {
            workerArray[i] = new Worker()
            {
                Id = i,
                AvailabilityTime = 0
            };
        }
        var workerQueue = new MinPriorityQueue<Worker>(workerArray);

        IList<Worker> workers = new List<Worker>();

        foreach (Job jobToProcess in jobArray)
        {
            Worker currentWorker = workerQueue.ExtractMin();
            workers.Add(new Worker(){AvailabilityTime = currentWorker.AvailabilityTime, Id = currentWorker.Id});
            currentWorker.AvailabilityTime = currentWorker.AvailabilityTime + jobToProcess.Duration;
            workerQueue.Insert(currentWorker);
        }

        return workers;
    }

    private void ReadData()
    {
        string[] lines = System.IO.File.ReadAllLines(
            $@"D:\Biblioteca\Algoritmi\Programming-Assignment-2\job_queue\tests\08");

        numWorkers = Int32.Parse(lines[0].Split(" ")[0]);
        jobs = lines[1].Split(" ").Select(Int32.Parse).ToArray();
    }
}

```

## Merging tables

**Task**. There are 𝑛 tables stored in some database. The tables are numbered from 1 to 𝑛. All tables share the same set of columns. Each table contains either several rows with real data or a symbolic link to another table. Initially, all tables contain data, and 𝑖-th table has 𝑟𝑖 rows. You need to perform 𝑚 of the following operations:

1. Consider table number 𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖. Traverse the path of symbolic links to get to the data. That is,

while 𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖 contains a symbolic link instead of real data do
𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖 ← symlink(𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖)

2. Consider the table number 𝑠𝑜𝑢𝑟𝑐𝑒𝑖 and traverse the path of symbolic links from it in the same manner as for 𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖.

3. Now, 𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖 and 𝑠𝑜𝑢𝑟𝑐𝑒𝑖 are the numbers of two tables with real data. If 𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖 ̸= 𝑠𝑜𝑢𝑟𝑐𝑒𝑖
, copy all the rows from table 𝑠𝑜𝑢𝑟𝑐𝑒𝑖 to table 𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖
, then clear the table 𝑠𝑜𝑢𝑟𝑐𝑒𝑖
and instead of real data put a symbolic link to 𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖 into it.

4. Print the maximum size among all 𝑛 tables (recall that size is the number of rows in the table).

If the table contains only a symbolic link, its size is considered to be 0. See examples and explanations for further clarifications.
Input Format. The first line of the input contains two integers 𝑛 and 𝑚 — the number of tables in the database and the number of merge queries to perform, respectively. The second line of the input contains 𝑛 integers 𝑟𝑖 — the number of rows in the 𝑖-th table. Then follow 𝑚 lines describing merge queries. Each of them contains two integers 𝑑𝑒𝑠𝑡𝑖𝑛𝑎𝑡𝑖𝑜𝑛𝑖 and 𝑠𝑜𝑢𝑟𝑐𝑒𝑖 — the numbers of the tables to merge.

```c#

public class Table
{
    Table parent;
    public int Rank { get; set; }
    public int NumberOfRows { get; set; }

    public Table(int numberOfRows)
    {
        this.NumberOfRows = numberOfRows;
        Rank = 0;
        parent = this;
    }
    public Table GetParent()
    {
        if (parent != this)
        {
            parent = parent.GetParent();
        }

        // find super parent and compress path
        return parent;
    }

    public void AddNumberOfRows(int rows)
    {
        NumberOfRows += rows;
        Rank++;
    }

    public void SetParent(Table parent)
    {
        this.parent = parent;
    }
}

class Program
{
    int maximumNumberOfRows = -1;

    static void Main(string[] args)
    {
        new Program().Run();
        Console.ReadLine();
    }

    private void Run()
    {
        string[] allLines = System.IO.File.ReadAllLines(
            $@"D:\Biblioteca\Algoritmi\Programming-Assignment-2\merging_tables\tests\116");
       
        int n = allLines[0].Split(" ").Select(Int32.Parse).First();
        int m = allLines[0].Split(" ").Select(Int32.Parse).Last();
        var secondRow = allLines[1].Split(" ").Select(Int32.Parse).ToArray();
        var mergeLines = allLines.Skip(2).ToArray();

       Table[] tables = new Table[n];
        for (int i = 0; i < n; i++)
        {
            int numberOfRows = secondRow[i];
            tables[i] = new Table(numberOfRows);
            maximumNumberOfRows = Math.Max(maximumNumberOfRows, numberOfRows);
        }
        for (int i = 0; i < m; i++)
        {
            int destination = mergeLines[i].Split(" ").Select(Int32.Parse).First() -1;
            int source = mergeLines[i].Split(" ").Select(Int32.Parse).Last() -1;
            Merge(tables[destination], tables[source]);
            Console.WriteLine(maximumNumberOfRows);
        }
    }

    void Merge(Table destination, Table source)
    {
        Table realDestination = destination.GetParent();
        Table realSource = source.GetParent();
        if (realDestination == realSource)
        {
            return;
        }

        if (realDestination.Rank < realSource.Rank)
        {
            realDestination.SetParent(realSource);
            realSource.AddNumberOfRows(realDestination.NumberOfRows);
            realDestination.NumberOfRows = 0;
        }
        else
        {
            realDestination.AddNumberOfRows(realSource.NumberOfRows);
           
            realSource.NumberOfRows = 0;
            realSource.SetParent(realDestination);
            if (realDestination.Rank == realSource.Rank)
            {
                realDestination.Rank++;
            }
        }

        maximumNumberOfRows = Math.Max(Math.Max(maximumNumberOfRows, realSource.NumberOfRows), realDestination.NumberOfRows);
    }
}

```
