using System;

namespace _02.Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double fuelLitters = double.Parse(Console.ReadLine());
            string dayOfTheWeekend = Console.ReadLine();


            double sum = (fuelLitters * 2.10) + 100;

            if (dayOfTheWeekend == "Saturday")
            {
                sum -= sum * 0.10;
            }
            else
            {
                sum -= sum * 0.20;
            }
            if (sum <= budget)
            {
                double moneyLeft = budget - sum;
                Console.WriteLine($"Safari time! Money left: {moneyLeft:f2} lv.");
            }
            else
            {
                double neededMoney = sum - budget;
                Console.WriteLine($"Not enough money! Money needed: {neededMoney:f2} lv.");
            }
        }
    }
}
