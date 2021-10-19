using System;

namespace _04.FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            const int springPrice = 3000;
            const int summeraAndAutumn = 4200;
            const int winterPrice = 2600;


            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numOfFisherman = int.Parse(Console.ReadLine());
            double totalMoney = 0.0;


            switch (season)
            {
                case "Spring":
                    totalMoney = springPrice;
                    break;
                case "Summer":
                    totalMoney = summeraAndAutumn;
                    break;
                case "Autumn":
                    totalMoney = summeraAndAutumn;
                    break;
                case "Winter":
                    totalMoney = winterPrice;
                    break;
            }
            if (numOfFisherman <= 6)
            {
                totalMoney -= totalMoney * 0.10;
            }
            else if (numOfFisherman > 7 && numOfFisherman <= 11)
            {
                totalMoney -= totalMoney * 0.15;
            }
            else
            {
                totalMoney -= totalMoney * 0.25;
            }
            if (numOfFisherman % 2 == 0 && season != "Autumn")
            {
                totalMoney -= totalMoney * 0.05;
            }
            if (budget >= totalMoney)
            {
                double moneyLeft = budget - totalMoney;
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else
            {
                double neededMOney = totalMoney - budget;
                Console.WriteLine($"Not enough money! You need {neededMOney:f2} leva.");
            }
        }
    }
}
