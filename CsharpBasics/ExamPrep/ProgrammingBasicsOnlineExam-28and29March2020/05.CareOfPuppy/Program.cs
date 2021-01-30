using System;

namespace _05.CareOfPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            double dogFoodKg = double.Parse(Console.ReadLine());
            double foodInGrams = dogFoodKg * 1000;

            double eatenFood = 0;

            double foodAmount = 0;
            string input = Console.ReadLine();


            while (input != "Adopted")
            {

                foodAmount = double.Parse(input);
                eatenFood += foodAmount;

                input = Console.ReadLine();
            }
            if (eatenFood <= foodInGrams)
            {
                double leftOver = foodInGrams - eatenFood;
                Console.WriteLine($"Food is enough! Leftovers: {leftOver} grams.");
            }
            else
            {
                double needMoreFood = eatenFood - foodInGrams;
                Console.WriteLine($"Food is not enough. You need {needMoreFood} grams more.");
            }
        }
    }
}
