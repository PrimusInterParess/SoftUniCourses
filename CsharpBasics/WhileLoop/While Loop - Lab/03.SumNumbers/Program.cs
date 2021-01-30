using System;

namespace _03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            while (true)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                sum += inputNumber;

                if (number <= sum)
                {
                    Console.WriteLine($"{sum}");
                    break;
                }
            }
        }
    }
}
