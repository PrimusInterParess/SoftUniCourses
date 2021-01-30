using System;

namespace _02.Godzillavs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberStatists = int.Parse(Console.ReadLine());
            double statistsOutfitPrice = double.Parse(Console.ReadLine());

            double decorPrice = budget * 0.10;

            if (numberStatists > 150)
            {
                statistsOutfitPrice *= 0.90;
            }

            double total = (statistsOutfitPrice * numberStatists) + decorPrice;

            if (budget >= total)
            {
                double leftMoney = budget - total;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {leftMoney:f2} leva left.");
            }
            else if (budget < total)
            {
                double neededMOney = total - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {neededMOney:f2} leva more.");
            }
        }
    }
}
