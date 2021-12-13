using System;
using System.Linq;

namespace _02SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();


            SelectionSort(inputNumbers);

            Console.WriteLine(string.Join(" ", inputNumbers));
        }

        private static void SelectionSort(int[] inputNumbers)
        {

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                int minIndx = i;

                int minNumber = inputNumbers[i];

                for (int j = i + 1; j < inputNumbers.Length; j++)
                {
                    if (inputNumbers[j] < minNumber)
                    {
                        minNumber = inputNumbers[j];
                        minIndx = j;
                    }
                }

                Swap(i, inputNumbers, minIndx);
            }
        }

        private static void Swap(int first, int[] inputNumbers, int second)
        {
            (inputNumbers[first], inputNumbers[second]) = (inputNumbers[second], inputNumbers[first]);
        }
    }
}
}
