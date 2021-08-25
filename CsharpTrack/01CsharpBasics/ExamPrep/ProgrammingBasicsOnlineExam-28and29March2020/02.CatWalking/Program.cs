using System;

namespace _02.CatWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            double minutesWalk = double.Parse(Console.ReadLine());
            double numberOfWalks = double.Parse(Console.ReadLine());
            double amountCalories = double.Parse(Console.ReadLine());

            double caloriesBurned = (numberOfWalks * minutesWalk) * 5;

            if (caloriesBurned >= amountCalories / 2)

            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {caloriesBurned}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {caloriesBurned}.");
            }
        }
    }
}
