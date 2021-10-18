using System;

namespace _05.DivideWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;

            for (int i = 0; i < numbers; i++)
            {
                double inputNumbers = double.Parse(Console.ReadLine());

                if (inputNumbers % 2 == 0)
                {
                    p1++;
                }
                if (inputNumbers % 3 == 0)
                {
                    p2++;
                }
                if (inputNumbers % 4 == 0)
                {
                    p3++;
                }
            }

            double p1Percentage = p1 / numbers * 100;
            double p2Percentage = p2 / numbers * 100;
            double p3Percentage = p3 / numbers * 100;

            Console.WriteLine($"{p1Percentage:f2}%");
            Console.WriteLine($"{p2Percentage:f2}%");
            Console.WriteLine($"{p3Percentage:f2}%");
        }
    }
}
