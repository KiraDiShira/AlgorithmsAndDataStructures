using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 38, 27, 43, 3, 9, 82, 10 };
           
            Console.WriteLine(String.Join(",", array));

            MergeSort(array, 0, array.Length - 1);

            Console.WriteLine(String.Join(",", array));
            Console.ReadLine();
        }

        private static void MergeSort(int[] array, int left, int right)
        {
            Console.WriteLine($"{left}, {right}");
            if (left >= right)
            {
                return;
            }

            int center = (left + right) / 2;
            MergeSort(array, left, center);
            MergeSort(array, center + 1, right);
            MergeWithoutSentinel(array, left, center, right);
        }

        private static void MergeWithoutSentinel(int[] array, int left, int center, int right)
        {
            Console.WriteLine($"merge:{left}, {right}");

            int lLength = center - left + 1;
            int rLength = right - center;
            int[] leftArray = new int[lLength];
            int[] rightArray = new int[rLength];

            for (int i = 0; i < lLength; i++)
            {
                leftArray[i] = array[left + i];
            }

            for (int i = 0; i < rLength; i++)
            {
                rightArray[i] = array[center + i + 1];
            }

            int l = 0;
            int r = 0;
            int k = left;
            while (l != lLength && r != rLength)
            {
                if (leftArray[l] <= rightArray[r])
                {
                    array[k] = leftArray[l];
                    l++;
                }
                else
                {
                    array[k] = rightArray[r];
                    r++;
                }
                k++;
            }

            for (int i = l; i < leftArray.Length; i++)
            {
                array[k] = leftArray[i];
                k++;
            }

            for (int i = r; i < rightArray.Length; i++)
            {
                array[k] = rightArray[i];
                k++;
            }
        }

        private static void MergeWithSentinel(int[] array, int left, int center, int right)
        {
            int lLength = center - left + 1;
            int rLength = right - center;
            int[] leftArray = new int[lLength + 1];
            int[] rightArray = new int[rLength + 1];

            for (int i = 0; i < lLength; i++)
            {
                leftArray[i] = array[left + i];
            }
            leftArray[lLength] = int.MaxValue;

            for (int i = 0; i < rLength; i++)
            {
                rightArray[i] = array[center + i + 1];
            }
            rightArray[rLength] = int.MaxValue;

            int l = 0;
            int r = 0;
            for (int k = left; k <= right; k++)
            {
                if (leftArray[l] <= rightArray[r])
                {
                    array[k] = leftArray[l];
                    l++;
                }
                else
                {
                    array[k] = rightArray[r];
                    r++;
                }
            }
        }
    }
}
