using System;

namespace _01BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfPlunder = int.Parse(Console.ReadLine());

            int dailyPlunder = int.Parse(Console.ReadLine());

            int expectedPlunder = int.Parse(Console.ReadLine());

            double totalPlunder = 0;

            int dayCounter = 1;

            while (daysOfPlunder != 0)
            {
                daysOfPlunder--;

                totalPlunder += dailyPlunder;

                if (dayCounter % 3 == 0)
                {
                    totalPlunder += (dailyPlunder * 1.5) - dailyPlunder;
                }

                if (dayCounter % 5 == 0)
                {
                    totalPlunder *= 0.70;
                }

                dayCounter++;

            }
            
            if (totalPlunder < expectedPlunder)
            {
                double result = (totalPlunder / expectedPlunder) * 100;

                Console.WriteLine($"Collected only {result:F2}% of the plunder.");
            }
            else
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }

        }
    }
}
