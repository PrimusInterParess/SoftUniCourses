using System;
using System.Linq;

namespace _06MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] merged = MergeSort(numbers);

            Console.WriteLine(string.Join(" ", merged));
        }

        private static int[] MergeSort(int[] numbers)
        {

            if (numbers.Length <= 1)
            {
                return numbers;
            }
            int[] leftArr = numbers.Take(numbers.Length / 2).ToArray();
            int[] rightArr = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(leftArr), MergeSort(rightArr));
        }

        private static int[] Merge(int[] left, int[] right)
        {

            int[] merged = new int[left.Length + right.Length];
            int mergedIndx = 0;
            int leftIndx = 0;
            int rightIndx = 0;

            while (leftIndx < left.Length && rightIndx < right.Length)
            {

                if (left[leftIndx] < right[rightIndx])
                {
                    merged[mergedIndx] = left[leftIndx];
                    leftIndx += 1;
                }
                else
                {
                    merged[mergedIndx] = right[rightIndx];
                    rightIndx += 1;
                }

                mergedIndx += 1;
            }

            while (leftIndx < left.Length)
            {
                merged[mergedIndx] = left[leftIndx];
                leftIndx += 1;
                mergedIndx += 1;
            }

            while (rightIndx < right.Length)
            {
                merged[mergedIndx] = right[rightIndx];
                rightIndx += 1;
                mergedIndx += 1;
            }

            return merged;
        }
    }
}
