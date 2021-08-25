using System;

namespace _02.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberVideoCards = int.Parse(Console.ReadLine());
            int numberProcesors = int.Parse(Console.ReadLine());
            int numberRAMMemory = int.Parse(Console.ReadLine());

            double videoCardPrice = numberVideoCards * 1.0 * 250;
            double processorPrice = ((videoCardPrice * 35) / 100) * numberProcesors;
            double ramMemoryPrice = ((videoCardPrice * 10) / 100) * numberRAMMemory;

            double totalPrice = videoCardPrice + processorPrice + ramMemoryPrice;

            if (numberVideoCards > numberProcesors)
            {
                totalPrice -= totalPrice * 0.15;
            }

            if (totalPrice > budget)
            {
                double neededMoney = totalPrice - budget;
                Console.WriteLine($"Not enough money! You need {neededMoney:f2} leva more!");
            }
            else
            {
                double moneyLeft = budget - totalPrice;
                Console.WriteLine($"You have {moneyLeft:f2} leva left!");
            }
        }
    }
}
