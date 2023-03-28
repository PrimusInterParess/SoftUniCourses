using System;
using System.Linq;

namespace _01ReversedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();



            for (int i = 0; i < inputArray.Length / 2; i++)
            {
                Swap(inputArray, i, inputArray.Length - 1 - i);

            }


            Console.WriteLine(string.Join(" ", inputArray));
        }

        private static void Swap(int[] inputArray, int first, int second)
        {

            (inputArray[first], inputArray[second]) = (inputArray[second], inputArray[first]);
        }
    }
}
