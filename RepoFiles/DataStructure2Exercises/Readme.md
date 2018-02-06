* [Index](https://github.com/KiraDiShira/AlgorithmsAndDataStructures/blob/master/README.md#project-title)

# DataStructure2Exercises

* [Convert array into heap](#convert-array-into-heap)

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
