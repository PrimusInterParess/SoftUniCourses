    using System;
    using System.Linq;

    namespace _04InsertionSort
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                InsertionSort(numbers);

                Console.WriteLine(string.Join(" ",numbers));
            }

            private static void InsertionSort(int[] numbers)
            {
                for (int i = 1; i < numbers.Length; i++)
                {

                    int j = i;
                    while (j > 0 && numbers[j] < numbers[j-1])
                    {
                        Swap(numbers, j, j - 1);
                        j -= 1;
                    }

                }

            }

            private static void Swap(int[] numbers, int first, int second)
            {
                (numbers[first], numbers[second]) = (numbers[second], numbers[first]);
            }
        }
    }
