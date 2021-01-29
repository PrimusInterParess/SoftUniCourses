using System;

namespace _07._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            double numPuzzels = double.Parse(Console.ReadLine());
            double numDolls = double.Parse(Console.ReadLine());
            double numStuffedBears = double.Parse(Console.ReadLine());
            double numMinions = double.Parse(Console.ReadLine());
            double numTrucks = double.Parse(Console.ReadLine());

            double totalPuzzlesIncome = numPuzzels * 2.60;
            double totalDollsIncome = numDolls * 3;
            double totalStuffedBearsIncome = numStuffedBears * 4.10;
            double totalMinionsIncome = numMinions * 8.20;
            double totalTrucksIncome = numTrucks * 2;
            double totalIncome = totalPuzzlesIncome + totalDollsIncome + totalStuffedBearsIncome + totalMinionsIncome + totalTrucksIncome;


            double totalToyNum = numPuzzels + numDolls + numMinions + numStuffedBears + numTrucks;

            if (totalToyNum >= 50)
            {
                totalIncome = totalIncome * 0.75;
            }

            totalIncome = totalIncome * 0.90;

            if (totalIncome >= tripPrice)
            {
                double remainingMoney = totalIncome - tripPrice;
                Console.WriteLine($"Yes! {remainingMoney:F2} lv left.");
            }
            else
            {
                double neededMoney = tripPrice - totalIncome;
                Console.WriteLine($"Not enough money! {neededMoney:F2} lv needed.");
            }

        }
    }
}
