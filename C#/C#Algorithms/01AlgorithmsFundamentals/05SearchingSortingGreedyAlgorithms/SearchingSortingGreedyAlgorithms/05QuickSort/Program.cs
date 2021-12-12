using System;
using System.Linq;

namespace _05QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();


            QuickSort(numbers, 0, numbers.Length - 1);

                Console.WriteLine(string.Join(" ", numbers));
        }

        private static void QuickSort(int[] numbers, int start, int end)
        {

            if (start>=end)
            {
                return;
            }

            int pivot = start;

            int left = start + 1;

            int right = end;

            while (left <= right)
            {

                if (numbers[left] > numbers[pivot] &&
                    numbers[right] < numbers[pivot])
                {
                    Swap(numbers, left, right);
                }

                if (numbers[left] <=numbers[pivot])
                {
                    left += 1;
                }

                if (numbers[right] >= numbers[pivot])
                {
                    right -= 1;
                }
            }

            Swap(numbers, pivot, right);

            bool isLeftSubarraySmaller = right - 1 - start < end - (right + 1);

            if (isLeftSubarraySmaller)
            {
                QuickSort(numbers, start , right - 1);
                QuickSort(numbers, right + 1, end );
            }
            else
            {
                QuickSort(numbers, right + 1, end);
                QuickSort(numbers, start, right - 1);
            }


        }

        private static void Swap(int[] numbers, int first, int second)
        {
            (numbers[first], numbers[second]) = (numbers[second], numbers[first]);
        }
    }
}
