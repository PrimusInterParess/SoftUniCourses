using System;

namespace _03.NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            double flowerNum = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double flowerPrice = 0.0;




            if (flowerType == "Roses")
            {
                flowerPrice = flowerNum * 5;
                if (flowerNum > 80)
                {
                    flowerPrice *= 0.90;
                }

            }

            else if (flowerType == "Dahlias")
            {
                flowerPrice = flowerNum * 3.8;
                if (flowerNum > 90)
                {
                    flowerPrice *= 0.85;
                }
            }

            else if (flowerType == "Tulips")
            {
                flowerPrice = flowerNum * 2.8;
                if (flowerNum > 80)
                {
                    flowerPrice *= 0.85;
                }
            }

            else if (flowerType == "Narcissus")
            {
                flowerPrice = flowerNum * 3.0;
                if (flowerNum < 120)
                {
                    flowerPrice *= 1.15;
                }
            }

            else if (flowerType == "Gladiolus")
            {
                flowerPrice = flowerNum * 2.50;
                if (flowerNum < 80)
                {
                    flowerPrice *= 1.20;
                }
            }
            double moneyLeft = budget - flowerPrice;
            string output = string.Empty;

            if (budget >= flowerPrice)
            {
                output = $"Hey, you have a great garden with {flowerNum} {flowerType} and {Math.Abs(moneyLeft):f2} leva left.";
            }
            else
            {
                output = $"Not enough money, you need {Math.Abs(moneyLeft):f2} leva more.";
            }

            Console.WriteLine(output);
        }
    }
}
