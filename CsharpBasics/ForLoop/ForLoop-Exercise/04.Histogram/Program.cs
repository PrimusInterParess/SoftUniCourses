using System;

namespace _04.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i = 0; i < numbers; i++)
            {
                double inputNumbers = double.Parse(Console.ReadLine());

                if (inputNumbers < 200)
                {
                    p1++;
                }
                else if (inputNumbers >= 200 && inputNumbers < 400)
                {
                    p2++;
                }
                else if (inputNumbers >= 400 && inputNumbers < 600)
                {
                    p3++;
                }
                else if (inputNumbers >= 600 && inputNumbers < 800)
                {
                    p4++;
                }
                else
                {
                    p5++;
                }

            }
            double p1Percentaage = p1 / numbers * 100;
            double p2Percentaage = p2 / numbers * 100;
            double p3Percentaage = p3 / numbers * 100;
            double p4Percentaage = p4 / numbers * 100;
            double p5Percentaage = p5 / numbers * 100;

            Console.WriteLine($"{p1Percentaage:f2}%");
            Console.WriteLine($"{p2Percentaage:f2}%");
            Console.WriteLine($"{p3Percentaage:f2}%");
            Console.WriteLine($"{p4Percentaage:f2}%");
            Console.WriteLine($"{p5Percentaage:f2}%");

        }
    }
}
