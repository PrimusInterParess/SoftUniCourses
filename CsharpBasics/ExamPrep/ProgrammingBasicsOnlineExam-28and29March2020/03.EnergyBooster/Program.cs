using System;

namespace _03.EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string taste = Console.ReadLine();
            string boosterSize = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());

            double total = 0;


            if (taste == "Watermelon")
            {
                if (boosterSize == "small")
                {
                    total = (2 * 56) * amount;
                }
                else
                {
                    total = (5 * 28.70) * amount;
                }
            }
            else if (taste == "Mango")
            {
                if (boosterSize == "small")
                {
                    total = (2 * 36.66) * amount;
                }
                else
                {
                    total = (5 * 19.60) * amount;
                }
            }
            else if (taste == "Pineapple")
            {
                if (boosterSize == "small")
                {
                    total = (2 * 42.10) * amount;
                }
                else
                {
                    total = (5 * 24.80) * amount;
                }
            }
            else if (taste == "Raspberry")
            {
                if (boosterSize == "small")
                {
                    total = (2 * 20) * amount;
                }
                else
                {
                    total = (5 * 15.20) * amount;
                }
            }
            if (total >= 400 && total <= 1000)
            {
                total -= (total * 0.15);
            }
            else if (total > 1000)
            {
                total -= (total * 0.50);
            }

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
