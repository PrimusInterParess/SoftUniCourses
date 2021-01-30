using System;

namespace _03.CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string baverageType = Console.ReadLine();
            string sugarAmount = Console.ReadLine();
            int numberOfbaverages = int.Parse(Console.ReadLine());

            double price = 0;
            double discount = 0;

            switch (baverageType)
            {
                case "Espresso":
                    switch (sugarAmount)
                    {
                        case "Without":
                            price = 0.90;
                            break;
                        case "Normal":
                            price = 1.0;
                            break;
                        case "Extra":
                            price = 1.20;
                            break;
                    }
                    break;
                case "Cappuccino":
                    switch (sugarAmount)
                    {
                        case "Without":
                            price = 1.0;
                            break;
                        case "Normal":
                            price = 1.20;
                            break;
                        case "Extra":
                            price = 1.60;
                            break;
                    }
                    break;
                case "Tea":
                    switch (sugarAmount)
                    {
                        case "Without":
                            price = 0.50;
                            break;
                        case "Normal":
                            price = 0.60;
                            break;
                        case "Extra":
                            price = 0.70;
                            break;
                    }
                    break;
            }
            if (sugarAmount == "Without")
            {
                price -= (price * 35) / 100;
            }

            if (baverageType == "Espresso" && numberOfbaverages >= 5)
            {
                price -= (price * 25) / 100;
            }

            double totalPrice = price * numberOfbaverages;

            if (totalPrice > 15)
            {
                totalPrice -= (totalPrice * 20) / 100;
            }
            Console.WriteLine($"You bought {numberOfbaverages} cups of {baverageType} for {totalPrice:f2} lv.");
        }
    }
}
