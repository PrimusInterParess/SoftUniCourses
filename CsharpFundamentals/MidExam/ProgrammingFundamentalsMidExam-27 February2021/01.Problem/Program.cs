using System;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededAmountExperience = int.Parse(Console.ReadLine());

            int countBattles = int.Parse(Console.ReadLine());

            double totalExperiencedGained = 0;

            bool experienceGainded = false;

            int index = -1;

            for (int i = 1; i <=countBattles; i++)
            {
                double experienceGained = double.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    experienceGained *= 1.15;
                }

                if (i % 5 == 0)
                {
                    experienceGained *= 0.90;
                }

                totalExperiencedGained += experienceGained;

                index = i;

                if (totalExperiencedGained >= neededAmountExperience)
                {
                    experienceGainded = true;
                    break;
                }



            }

            

            if (experienceGainded)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {index} battles.");
            }
            else
            {
                double neededExperience = neededAmountExperience - totalExperiencedGained;

                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience:f2} more needed.");
            }



        }
    }
}
