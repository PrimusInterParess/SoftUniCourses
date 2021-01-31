using System;

namespace _03.ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            decimal sum = 0M;

            for (int i = 0; i < numbers; i++)
            {
                sum += decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine($"{sum}");
        }
    }
}
