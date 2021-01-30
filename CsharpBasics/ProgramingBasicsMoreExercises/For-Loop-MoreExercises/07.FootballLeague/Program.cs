using System;

namespace _07.FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            double stadiumSeats = double.Parse(Console.ReadLine());
            double fansNumber = double.Parse(Console.ReadLine());
            double secA = 0;
            double secB = 0;
            double secV = 0;
            double secG = 0;

            for (int i = 1; i <= fansNumber; i++)
            {
                string input = Console.ReadLine();


                if (input == "A")
                {
                    secA++;
                }
                else if (input == "B")
                {
                    secB++;
                }
                else if (input == "V")
                {
                    secV++;
                }
                else
                {
                    secG++;
                }

            }
            double secAPercentage = (secA / fansNumber) * 100;
            double secBPercentage = (secB / fansNumber) * 100;
            double secVPercentage = (secV / fansNumber) * 100;
            double secGPercentage = (secG / fansNumber) * 100;
            double stadiumCapacityPercentage = (fansNumber / stadiumSeats) * 100;
            Console.WriteLine($"{secAPercentage:f2}%");
            Console.WriteLine($"{secBPercentage:f2}%");
            Console.WriteLine($"{secVPercentage:f2}%");
            Console.WriteLine($"{secGPercentage:f2}%");
            Console.WriteLine($"{stadiumCapacityPercentage:f2}%");

        }
    }
}
