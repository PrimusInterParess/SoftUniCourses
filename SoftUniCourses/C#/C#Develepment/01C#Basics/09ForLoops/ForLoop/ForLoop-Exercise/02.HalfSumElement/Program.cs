using System;

namespace _02.HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int max = int.MinValue;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                sum += number;

                if (number > max)
                {
                    max = number;
                }
            }

            int sumWithOutMaxNum = sum - max;
            if (max == sumWithOutMaxNum)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine("Sum = " + max);
            }
            else
            {
                int diff = Math.Abs(sumWithOutMaxNum - max);
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }

        }
    }
}
