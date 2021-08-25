using System;

namespace _03.MovieDestination
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int numberOfDays = int.Parse(Console.ReadLine());
            double price = 0;

            switch (destination)
            {
                case "Dubai":
                    switch (season)
                    {
                        case "Winter":
                            price = 45000;
                            break;
                        case "Summer":
                            price = 40000;
                            break;
                    }
                    break;
                case "Sofia":
                    switch (season)
                    {
                        case "Winter":
                            price = 17000;
                            break;
                        case "Summer":
                            price = 12500;
                            break;
                    }
                    break;
                case "London":
                    switch (season)
                    {
                        case "Winter":
                            price = 24000;
                            break;
                        case "Summer":
                            price = 20250;
                            break;
                    }
                    break;
            }

            double totalPrice = numberOfDays * price;

            if (destination == "Dubai")
            {
                totalPrice *= 0.70;
            }
            else if (destination == "Sofia")
            {
                totalPrice *= 1.25;
            }

            double left = budget - totalPrice;


            if (budget > totalPrice)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {left:F2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {Math.Abs(left):f2} leva more!");
            }
        }
    }
}
