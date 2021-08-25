using System;

namespace _05.EasterBake
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEasterBread = int.Parse(Console.ReadLine());
            int maxSugar = 0;
            int maxFlour = 0;
            double sumSugar = 0;
            double sumFlour = 0;


            for (int i = 0; i < numberOfEasterBread; i++)
            {
                int sugarUsed = int.Parse(Console.ReadLine());
                int flourUsed = int.Parse(Console.ReadLine());

                sumSugar += sugarUsed;
                sumFlour += flourUsed;

                if (sugarUsed > maxSugar)
                {
                    maxSugar = sugarUsed;
                }

                if (flourUsed > maxFlour)
                {
                    maxFlour = flourUsed;
                }
            }

            double neededSugarPacks = Math.Ceiling(sumSugar / 950);
            double neededFlourPacks = Math.Ceiling(sumFlour / 750);

            Console.WriteLine($"Sugar: {neededSugarPacks}");
            Console.WriteLine($"Flour: {neededFlourPacks}");
            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");
        }
    }
}
