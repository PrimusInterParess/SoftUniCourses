using System;

namespace _01.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeProjection = Console.ReadLine();
            int numRolls = int.Parse(Console.ReadLine());
            int numCollons = int.Parse(Console.ReadLine());

            double income = 0.0;

            if (typeProjection == "Premiere")
            {
                income = numCollons * numRolls * 12;
            }
            else if (typeProjection == "Normal")
            {
                income = numCollons * numRolls * 7.50;

            }
            else if (typeProjection == "Discount")
            {
                income = numCollons * numRolls * 5;

            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
