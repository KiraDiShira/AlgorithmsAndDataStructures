using System;

namespace MaximumSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };

            Console.WriteLine(String.Join(",", array));
            Console.WriteLine();

            Result result = FindMaximumSubarray(array, 0, array.Length - 1);
            
            Console.WriteLine();
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static Result FindMaximumSubarray(int[] array, int low, int high)
        {
            Console.WriteLine($"{low}, {high}");
            if (high == low)
            {
                Console.WriteLine($" --> sum: {array[low]}");
                return new Result()
                {
                    Low = low,
                    High = high,
                    Sum = array[low]
                };
            }

            int mid = (low + high) / 2;
            Result leftResult = FindMaximumSubarray(array, low, mid);
            Result rightResult = FindMaximumSubarray(array, mid + 1, high);
            Result crossResult = FindMaxCrossingSubarray(array, low, mid, high);

            if (leftResult.Sum >= rightResult.Sum && leftResult.Sum >= crossResult.Sum)
            {
                Console.WriteLine($"--------------------> {leftResult.Sum}");
                return new Result()
                {
                    Low = leftResult.Low,
                    High = leftResult.High,
                    Sum = leftResult.Sum
                };
            }

            if (rightResult.Sum >= leftResult.Sum && rightResult.Sum >= crossResult.Sum)
            {
                Console.WriteLine($"--------------------> {rightResult.Sum}");
                return new Result()
                {
                    Low = rightResult.Low,
                    High = rightResult.High,
                    Sum = rightResult.Sum
                };
            }

            Console.WriteLine($"--------------------> {crossResult.Sum}");
            return new Result()
            {
                Low = crossResult.Low,
                High = crossResult.High,
                Sum = crossResult.Sum
            };
        }

        private static Result FindMaxCrossingSubarray(int[] a, int low, int mid, int high)
        {
            int leftSum = int.MinValue;
            int sum = 0;
            int maxLeft = 0;

            for (int i = mid; i >= low; i--)
            {
                sum += a[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            int rightSum = int.MinValue;
            int maxRight = 0;
            sum = 0;

            for (int j = mid + 1; j <= high; j++)
            {
                sum += a[j];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = j;
                }
            }

            Console.WriteLine($"Max crossing subarray: {low}, {high} --> sum: {leftSum + rightSum}");

            return new Result()
            {
                Low = maxLeft,
                High = maxRight,
                Sum = leftSum + rightSum
            };
        }
    }
}
