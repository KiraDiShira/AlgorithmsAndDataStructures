using System;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 38, 27, 43, 3, 9, 82, 10 };
            Console.WriteLine(String.Join(",", array));

            InsertionSort(array);

            Console.WriteLine(String.Join(",", array));
            Console.ReadLine();
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }

        public static void ReverseInsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] < key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        public static int? LinearSearch(int[] array, int v)
        {
            for (int i = 0; i < array.Length; i++)  //n+1 worst case, 1 best case
            {
                int key = array[i];    //n worst case, 1 best case
                if (key == v)           //n worst case, 1 best case
                {
                    return v;         //1
                }
            }

            return null;    //1
        }

        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)                 //n 
            {
                int minIndex = i;                                      //n-1

                for (int j = i + 1; j < array.Length; j++)             //(n - 1) + (n - 2) + ... + 1 = n(n -1)/2
                {
                    if (array[j] < array[minIndex])                    //n(n -1)/2 - 1
                    {
                        minIndex = j;                                  //tempo inferiore
                    }
                }

                int ikey = array[i];                                  //n -1
                array[i] = array[minIndex];                            //n -1
                array[minIndex] = ikey;                                 //n -1
            }
        }
    }
}
