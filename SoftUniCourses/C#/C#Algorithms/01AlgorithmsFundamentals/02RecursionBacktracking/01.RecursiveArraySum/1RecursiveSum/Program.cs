using System;
using System.Linq;

namespace _1RecursiveSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int result = RecursiveSum(array, 0);

            Console.WriteLine(result);


        }

        private static int RecursiveSum(int[] arr, int index)
        {


            if (index == arr.Length-1)
            {
                return arr[index];
            }

            return arr[index] + RecursiveSum(arr, index + 1);

        }
    }
}
