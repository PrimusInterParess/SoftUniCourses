using System;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                long[] numbers = new long[input.Length];

                long biggestNumber = 0;

                for (int j = 0; j < numbers.Length; j++)
                {
                    numbers[j] = long.Parse(input[j]);

                }

                if (numbers[0] > numbers[1])
                {
                    biggestNumber = numbers[0];
                }
                else
                {
                    biggestNumber = numbers[1];
                }

                long sumOfDigits = 0;

                while (biggestNumber != 0)
                {
                    sumOfDigits += biggestNumber % 10;
                    biggestNumber /= 10;
                }

                Console.WriteLine(Math.Abs(sumOfDigits));
            }
    }
}
