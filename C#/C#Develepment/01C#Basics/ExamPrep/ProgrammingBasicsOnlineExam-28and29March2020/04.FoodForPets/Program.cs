using System;

namespace _04.FoodForPets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double amountOfFood = double.Parse(Console.ReadLine());

            double dogFoodSum = 0;
            double catFoodSum = 0;
            int dayCount = 0;
            double dayFoodSum = 0;
            double biscuitsEaten = 0;
            double thirdDay = 0;

            for (int i = 0; i < days; i++)
            {
                dayCount++;
                double dogFood = double.Parse(Console.ReadLine());
                double catFood = double.Parse(Console.ReadLine());

                dogFoodSum += dogFood;
                catFoodSum += catFood;


                if (dayCount % 3 == 0)
                {
                    thirdDay += dogFood + catFood;

                    biscuitsEaten = thirdDay * 0.10;
                }
                dayFoodSum = dogFoodSum + catFoodSum;

            }
            double foodPercentage = (dayFoodSum / amountOfFood) * 100;
            double dogPercentage = (dogFoodSum / dayFoodSum) * 100;
            double catPercentage = (catFoodSum / dayFoodSum) * 100;



            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuitsEaten)}gr.");
            Console.WriteLine($"{foodPercentage:f2}% of the food has been eaten.");
            Console.WriteLine($"{dogPercentage:f2}% eaten from the dog.");
            Console.WriteLine($"{catPercentage:f2}% eaten from the cat.");
        }
    }
}
