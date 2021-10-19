using System;

namespace _06.Godzillavs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extra = int.Parse(Console.ReadLine());
            double extraClothsExpence = double.Parse(Console.ReadLine());


            double decorExpence = budget * 0.10;

            double neededMoney = 0;
            double moneyLeft = 0;



            if (extra >= 150)
            {
                extraClothsExpence = extraClothsExpence * 0.90;
            }
            extraClothsExpence = extra * extraClothsExpence;
            double expences = extraClothsExpence + decorExpence;

            if (expences > budget)
            {
                neededMoney = expences - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {neededMoney:f2} leva more.");

            }
            else if (expences <= budget)
            {
                moneyLeft = budget - expences;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }
        }
    }
}
