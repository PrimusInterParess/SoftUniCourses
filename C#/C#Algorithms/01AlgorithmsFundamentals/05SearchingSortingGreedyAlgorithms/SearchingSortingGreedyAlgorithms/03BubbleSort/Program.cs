using System;
using System.Linq;

namespace _03BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            BubbleSort(numbers);

            Console.WriteLine(string.Join(" ",numbers));

        }

        private static void BubbleSort(int[] numbers)
        {
            var isSorted = false;

            

            while (!isSorted)
            {
                isSorted = true;

                for (int j = 1; j < numbers.Length ; j++)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        Swap(numbers, j - 1, j);
                        

                        isSorted = false;
                    }
                }
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {

            (numbers[first], numbers[second]) = (numbers[second], numbers[first]);


        }
    }
}
