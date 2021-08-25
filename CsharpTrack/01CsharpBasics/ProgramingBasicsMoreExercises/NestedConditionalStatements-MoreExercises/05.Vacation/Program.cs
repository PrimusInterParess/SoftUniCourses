using System;

namespace _05.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string location = string.Empty;
            string accomodation = string.Empty;
            double cost = 0;

            if (budget <= 1000)
            {
                accomodation = "Camp";
                if (season == "Summer")
                {
                    location = "Alaska";
                    cost = budget * 0.65;
                }
                else
                {
                    location = "Morocco";
                    cost = budget * 0.45;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                accomodation = "Hut";
                if (season == "Summer")
                {
                    location = "Alaska";
                    cost = budget * 0.80;
                }
                else
                {
                    location = "Morocco";
                    cost = budget * 0.60;
                }
            }
            else
            {
                accomodation = "Hotel";
                cost = budget * 0.90;
                if (season == "Summer")
                {
                    location = "Alaska";
                }
                else
                {
                    location = "Morocco";
                }
            }
            Console.WriteLine($"{location} - {accomodation} - {cost:f2}");
        }
    }
}
