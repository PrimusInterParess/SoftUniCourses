using System;

namespace _02.Family_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfNights = int.Parse(Console.ReadLine());
            double nightPrice = double.Parse(Console.ReadLine());
            double percentageAdditinalExpences = double.Parse(Console.ReadLine());

            if (numberOfNights > 7)
            {
                nightPrice *= 0.95;
            }

            double additinalExpences = (budget * percentageAdditinalExpences) / 100; ;
            double totalPrice = (numberOfNights * nightPrice) + additinalExpences;


            if (totalPrice > budget)
            {
                double neededMOney = totalPrice - budget;

                Console.WriteLine($"{neededMOney:f2} leva needed.");
            }
            else
            {
                double moneyLeft = budget - totalPrice;
                Console.WriteLine($"Ivanovi will be left with {moneyLeft:f2} leva after vacation.");
            }
        }
    }
}
