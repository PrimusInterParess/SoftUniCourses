using System;

namespace _04.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());
            double musalaMembers = 0;
            double montBlankMembers = 0;
            double KilimandjaroMembers = 0;
            double k2Members = 0;
            double everestMembers = 0;
            double climbersSum = 0;

            for (int i = 0; i < numberOfGroups; i++)
            {
                int groupMembers = int.Parse(Console.ReadLine());
                climbersSum += groupMembers;

                if (groupMembers > 0 && groupMembers <= 5)
                {
                    musalaMembers += groupMembers;
                }
                else if (groupMembers >= 6 && groupMembers <= 12)
                {
                    montBlankMembers += groupMembers;
                }
                else if (groupMembers >= 13 && groupMembers <= 25)
                {
                    KilimandjaroMembers += groupMembers;
                }
                else if (groupMembers >= 26 && groupMembers <= 40)
                {
                    k2Members += groupMembers;
                }
                else
                {
                    everestMembers += groupMembers;
                }
            }
            double musalaPercentage = (musalaMembers / climbersSum) * 100;
            double montBlankPercentage = (montBlankMembers / climbersSum) * 100;
            double kilimandjaroPercentage = (KilimandjaroMembers / climbersSum) * 100;
            double k2Percentage = (k2Members / climbersSum) * 100;
            double everestPercentage = (everestMembers / climbersSum) * 100;

            Console.WriteLine($"{musalaPercentage:f2}%");
            Console.WriteLine($"{montBlankPercentage:f2}%");
            Console.WriteLine($"{kilimandjaroPercentage:f2}%");
            Console.WriteLine($"{k2Percentage:f2}%");
            Console.WriteLine($"{everestPercentage:f2}%");
        }
    }
}
