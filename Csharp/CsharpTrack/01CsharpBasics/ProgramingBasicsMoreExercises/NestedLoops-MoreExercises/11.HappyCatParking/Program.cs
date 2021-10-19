using System;

namespace _11.HappyCatParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            int daysCounter = 0;
            double total = 0;

            for (int d = 1; d <= days; d++)
            {
                double price = 0;


                for (int h = 1; h <= hours; h++)
                {
                    if (d % 2 == 0 && h % 2 == 1)
                    {
                        price += 2.50;
                    }
                    else if (d % 2 == 1 && h % 2 == 0)
                    {
                        price += 1.25;
                    }
                    else
                    {
                        price += 1;
                    }
                }
                total += price;
                daysCounter++;
                Console.WriteLine($"Day: {daysCounter} - {price:F2} leva");
            }
            Console.WriteLine($"Total: {total:F2} leva");
        }
    }
}
