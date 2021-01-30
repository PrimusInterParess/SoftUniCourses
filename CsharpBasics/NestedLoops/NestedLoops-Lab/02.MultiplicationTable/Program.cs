using System;

namespace _02.MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int number = 1; number <= 10; number++)
            {
                for (int multiplier = 1; multiplier <= 10; multiplier++)
                {
                    int product = number * multiplier;
                    Console.WriteLine($"{number} * {multiplier} = {product}");
                }
            }
        }
    }
}
