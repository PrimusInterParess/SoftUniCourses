using System;

namespace _04.TouristShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int productCount = 0;
            double sum = 0;
            bool notEnough = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }

                double productsPrice = double.Parse(Console.ReadLine());
                productCount++;

                if (productCount % 3 == 0)
                {
                    productsPrice *= 0.50;

                }
                sum += productsPrice;

                if (sum > budget)
                {
                    notEnough = true;
                    break;
                }

            }
            if (notEnough)
            {
                double notEnoughMoney = sum - budget;
                Console.WriteLine("You don't have enough money!");
                Console.WriteLine($"You need {notEnoughMoney:f2} leva!");
            }
            else
            {
                Console.WriteLine($"You bought {productCount} products for {sum:f2} leva.");

            }
        }
    }
}
