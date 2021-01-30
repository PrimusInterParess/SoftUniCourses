using System;

namespace _05.AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double numbersSum = 0;
            int numbersCount = 0;
            double averageSum = 0;
            for (int i = 0; i < n; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                numbersCount++;
                numbersSum += numbers;

            }
            averageSum = numbersSum / numbersCount;
            Console.WriteLine($"{averageSum:f2}");
        }
    }
}
