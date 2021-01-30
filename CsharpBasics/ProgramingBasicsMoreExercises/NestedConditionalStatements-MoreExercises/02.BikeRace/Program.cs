using System;

namespace _02.BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOfJuniorCyclists = double.Parse(Console.ReadLine());
            double numberOfSeniorCyclists = double.Parse(Console.ReadLine());
            string typeOfTrail = Console.ReadLine();

            double sum = 0;

            if (typeOfTrail == "trail")
            {
                sum = (numberOfJuniorCyclists * 5.5) + (numberOfSeniorCyclists * 7);
            }
            else if (typeOfTrail == "cross-country")
            {
                sum = (numberOfJuniorCyclists * 8) + (numberOfSeniorCyclists * 9.50);
                if (numberOfSeniorCyclists + numberOfJuniorCyclists > 50)
                {
                    sum -= sum * 0.25;
                }
            }
            else if (typeOfTrail == "downhill")
            {
                sum = (numberOfJuniorCyclists * 12.25) + (numberOfSeniorCyclists * 13.75);
            }
            else
            {
                sum = (numberOfJuniorCyclists * 20) + (numberOfSeniorCyclists * 21.50);
            }
            sum -= sum * 0.05;

            Console.WriteLine($"{sum:f2}");

        }
    }
}
