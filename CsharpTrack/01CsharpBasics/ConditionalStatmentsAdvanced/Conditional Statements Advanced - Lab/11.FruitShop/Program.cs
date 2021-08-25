using System;

namespace _11.FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string friut = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double pricePerFruit = 0.0;
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    if (friut == "banana")
                    {
                        pricePerFruit = 2.5;
                    }
                    else if (friut == "apple")
                    {
                        pricePerFruit = 1.20;
                    }
                    else if (friut == "orange")
                    {
                        pricePerFruit = 0.85;
                    }
                    else if (friut == "grapefruit")
                    {
                        pricePerFruit = 1.45;
                    }
                    else if (friut == "kiwi")
                    {
                        pricePerFruit = 2.70;
                    }
                    else if (friut == "pineapple")
                    {
                        pricePerFruit = 5.50;
                    }
                    else if (friut == "grapes")
                    {
                        pricePerFruit = 3.85;
                    }
                    break;

                case "Saturday":
                case "Sunday":
                    if (friut == "banana")
                    {
                        pricePerFruit = 2.70;
                    }
                    else if (friut == "apple")
                    {
                        pricePerFruit = 1.25;
                    }
                    else if (friut == "orange")
                    {
                        pricePerFruit = 0.90;
                    }
                    else if (friut == "grapefruit")
                    {
                        pricePerFruit = 1.60;
                    }
                    else if (friut == "pineapple")
                    {
                        pricePerFruit = 5.60;
                    }
                    else if (friut == "grapes")
                    {
                        pricePerFruit = 4.20;
                    }
                    else if (friut == "kiwi")
                    {
                        pricePerFruit = 3;
                    }
                    break;

            }
            double totalPrice = quantity * pricePerFruit;
            if (totalPrice > 0)
            {
                Console.WriteLine($"{totalPrice:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
