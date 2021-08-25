using System;

namespace _02Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

            int sum = 0;
        }

        static int Sum(int[] arr ,int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            int currentSum =  arr[index] + Sum(arr, index + 1);

            return currentSum;
        }
    }
}
