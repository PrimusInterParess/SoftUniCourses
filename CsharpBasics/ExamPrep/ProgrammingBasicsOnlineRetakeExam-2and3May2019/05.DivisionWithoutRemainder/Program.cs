using System;

namespace _05.DivisionWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            for (int i = 1; i <= n; i++)
            {
                double numbers = int.Parse(Console.ReadLine());

                if (numbers % 2 == 0)
                {
                    p1++;
                }
                if (numbers % 3 == 0)
                {
                    p2++;
                }
                if (numbers % 4 == 0)
                {
                    p3++;
                }
            }
            double p1Percentage = (p1 / n) * 100;
            double p2Percentage = (p2 / n) * 100;
            double p3Percentage = (p3 / n) * 100;

            Console.WriteLine($"{p1Percentage:f2}%");
            Console.WriteLine($"{p2Percentage:f2}%");
            Console.WriteLine($"{p3Percentage:f2}%");
        }
    }
}
