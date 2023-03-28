using System;
using System.Linq;

namespace Recurtion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int result = RecursiveSum(array, 0);

            Console.WriteLine(result);

        }

        private static int RecursiveSum(int[] array, int index)
        {
            if (array.Length - 1 == index)
            {
                return array[index]; 
            }

           var currSum = array[index] + RecursiveSum(array, index + 1);

            Console.WriteLine($"After Recursive: {currSum}");

            return currSum;
        }
    }
}
