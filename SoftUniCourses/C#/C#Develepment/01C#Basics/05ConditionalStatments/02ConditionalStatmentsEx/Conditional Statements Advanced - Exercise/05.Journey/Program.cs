using System;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string accomodation = string.Empty;
            string destination = string.Empty;
            double holidayCost = 0.0;


            if (budget <= 100)
            {

                if (season == "summer")
                {
                    destination = "Bulgaria";
                    holidayCost = budget * 0.30;
                    accomodation = "Camp";
                }
                else
                {
                    destination = "Bulgaria";

                    holidayCost = budget * 0.70;
                    accomodation = "Hotel";
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                if (season == "summer")
                {
                    destination = "Balkans";

                    holidayCost = budget * 0.40;
                    accomodation = "Camp";
                }
                else
                {
                    destination = "Balkans";

                    holidayCost = budget * 0.80;
                    accomodation = "Hotel";
                }

            }
            else
            {
                destination = "Europe";
                accomodation = "Hotel";
                holidayCost = budget * 0.90;

            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{accomodation} - {holidayCost:f2}");
        }
    }
}
