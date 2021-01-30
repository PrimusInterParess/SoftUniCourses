using System;

namespace _04.CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string typeOfCar = string.Empty;
            string claass = string.Empty;

            double cost = 0;

            if (budget <= 100)
            {
                claass = "Economy class";
                if (season == "Summer")
                {
                    typeOfCar = "Cabrio";
                    cost = budget * 0.35;
                }
                else
                {
                    typeOfCar = "Jeep";
                    cost = budget * 0.65;
                }

            }
            else if (budget > 100 && budget <= 500)
            {
                claass = "Compact class";
                if (season == "Summer")
                {
                    typeOfCar = "Cabrio";
                    cost = budget * 0.45;
                }
                else
                {
                    typeOfCar = "Jeep";
                    cost = budget * 0.80;
                }
            }
            else
            {
                claass = "Luxury class";
                typeOfCar = "Jeep";
                cost = budget * 0.90;

            }
            Console.WriteLine($"{claass}");
            Console.WriteLine($"{typeOfCar} - {cost:f2}");
        }
    }
}
