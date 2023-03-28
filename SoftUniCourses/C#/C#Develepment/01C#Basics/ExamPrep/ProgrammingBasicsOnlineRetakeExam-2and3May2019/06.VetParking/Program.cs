using System;

namespace _06.VetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int dayCount = 0;
            double total = 0;


            for (int d = 1; d <= days; d++)
            {
                dayCount++;
                double dayTotal = 0;

                for (int h = 1; h <= hours; h++)
                {
                    double hoursPrice = 0;
                    if (d % 2 == 0)
                    {
                        if (h % 2 == 0)
                        {
                            hoursPrice += 1;

                        }
                        else
                        {
                            hoursPrice += 2.50;
                        }
                    }
                    else
                    {
                        if (h % 2 == 0)
                        {
                            hoursPrice += 1.25;
                        }
                        else
                        {
                            hoursPrice += 1;
                        }
                    }
                    dayTotal += hoursPrice;
                }
                total += dayTotal;

                Console.WriteLine($"Day: {dayCount} - {dayTotal:f2} leva");
            }
            Console.WriteLine($"Total: {total:f2} leva");
        }
    }
}
