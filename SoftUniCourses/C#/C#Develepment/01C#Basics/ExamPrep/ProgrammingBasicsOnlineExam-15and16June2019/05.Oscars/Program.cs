using System;

namespace _05.Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorsName = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int numberJudges = int.Parse(Console.ReadLine());
            double sumPoints = 0;
            double totalPoints = 0;


            for (int i = 0; i < numberJudges; i++)
            {

                string judgeName = Console.ReadLine();
                double points = double.Parse(Console.ReadLine());

                sumPoints += (judgeName.Length * points) / 2;

                totalPoints = sumPoints + academyPoints;

                if (totalPoints > 1250.5)
                {
                    break;
                }
            }

            if (totalPoints > 1250.5)
            {

                Console.WriteLine($"Congratulations, {actorsName} got a nominee for leading role with {totalPoints:f1}!");
            }
            else
            {
                double neededPoints = 1250.5 - totalPoints;
                Console.WriteLine($"Sorry, {actorsName} you need {neededPoints:f1} more!");
            }
        }
    }
}
