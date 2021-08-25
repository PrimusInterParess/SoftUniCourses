using System;

namespace _01.PoolDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            double poolFee = double.Parse(Console.ReadLine());
            double deckChairPrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());

            double deckChairsNumber = Math.Ceiling(numberOfPeople * 0.75);
            double umbrellaNumber = Math.Ceiling(numberOfPeople * 0.50);
            double poolPrice = numberOfPeople * poolFee;
            double deckChairTotalPrice = deckChairsNumber * deckChairPrice;
            double umbrellaTotalPrice = umbrellaNumber * umbrellaPrice;

            double totalPrice = poolPrice + deckChairTotalPrice + umbrellaTotalPrice;

            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
