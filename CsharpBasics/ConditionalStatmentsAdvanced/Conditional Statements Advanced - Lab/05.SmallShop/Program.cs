using System;

namespace _05.SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double pricePerUnit = 0.0;
            if (city == "Sofia")
            {
                if (product == "coffee")
                {
                    pricePerUnit = 0.50;
                }
                else if (product == "water")
                {
                    pricePerUnit = 0.80;
                }
                else if (product == "beer")
                {
                    pricePerUnit = 1.20;
                }
                else if (product == "sweets")
                {
                    pricePerUnit = 1.45;
                }
                else if (product == "peanuts")
                {
                    pricePerUnit = 1.60;
                }
            }
            else if (city == "Plovdiv")
            {
                if (product == "coffee")
                {
                    pricePerUnit = 0.40;
                }
                else if (product == "water")
                {
                    pricePerUnit = 0.70;
                }
                else if (product == "beer")
                {
                    pricePerUnit = 1.15;
                }
                else if (product == "sweets")
                {
                    pricePerUnit = 1.30;
                }
                else if (product == "peanuts")
                {
                    pricePerUnit = 1.50;
                }

            }
            else
            if (product == "coffee")
            {
                pricePerUnit = 0.45;
            }
            else if (product == "water")
            {
                pricePerUnit = 0.70;
            }
            else if (product == "beer")
            {
                pricePerUnit = 1.10;
            }
            else if (product == "sweets")
            {
                pricePerUnit = 1.35;
            }
            else if (product == "peanuts")
            {
                pricePerUnit = 1.55;
            }

            double totalPrice = pricePerUnit * quantity;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
