using System;

namespace _05.FitnessCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int backCount = 0;
            int chestCount = 0;
            int legsCount = 0;
            int absCount = 0;
            int proteinBarCount = 0;
            int proteinShakeCount = 0;


            for (int i = 0; i < numberOfPeople; i++)
            {
                string activity = Console.ReadLine();

                switch (activity)
                {
                    case "Back":
                        backCount++;
                        break;
                    case "Chest":
                        chestCount++;
                        break;
                    case "Legs":
                        legsCount++;
                        break;
                    case "Abs":
                        absCount++;
                        break;
                    case "Protein shake":
                        proteinShakeCount++;
                        break;
                    case "Protein bar":
                        proteinBarCount++;
                        break;
                }
            }

            double peopleTrained = backCount + chestCount + legsCount + absCount;
            double peoplePurchase = proteinBarCount + proteinShakeCount;
            double trainedPercentage = (peopleTrained / numberOfPeople) * 100;
            double purchasedPeople = (peoplePurchase / numberOfPeople) * 100;

            Console.WriteLine($"{backCount} - back");
            Console.WriteLine($"{chestCount} - chest");
            Console.WriteLine($"{legsCount} - legs");
            Console.WriteLine($"{absCount} - abs");
            Console.WriteLine($"{proteinShakeCount} - protein shake");
            Console.WriteLine($"{proteinBarCount} - protein bar");
            Console.WriteLine($"{trainedPercentage:f2}% - work out");
            Console.WriteLine($"{purchasedPeople:f2}% - protein");
        }
    }
}
