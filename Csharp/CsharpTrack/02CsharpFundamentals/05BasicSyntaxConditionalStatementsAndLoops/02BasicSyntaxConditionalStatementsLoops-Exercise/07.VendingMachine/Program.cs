using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double sum = 0;

            while (command != "Start")
            {
                double receivedMoney = double.Parse(command);
                bool coins = receivedMoney == 0.1 ||
                             receivedMoney == 0.2 ||
                             receivedMoney == 0.5 ||
                             receivedMoney == 1 ||
                             receivedMoney == 2;


                if (coins)
                {
                    sum += receivedMoney;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {receivedMoney}");
                }
                command = Console.ReadLine();
            }

            string products = Console.ReadLine();

            while (products != "End")
            {
                double price = 0;


                switch (products)
                {
                    case "Nuts":
                        price = 2.0;
                        break;
                    case "Water":
                        price = 0.7;
                        break;
                    case "Crisps":
                        price = 1.5;
                        break;
                    case "Soda":
                        price = 0.8;
                        break;
                    case "Coke":
                        price = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        products = Console.ReadLine();
                        continue;
                }

                if (sum >= price)
                {
                    sum -= price;
                    Console.WriteLine($"Purchased {products.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");

                }

                products = Console.ReadLine();
            }
            Console.WriteLine($"Change: {sum:F2}");
        }
    }
}
