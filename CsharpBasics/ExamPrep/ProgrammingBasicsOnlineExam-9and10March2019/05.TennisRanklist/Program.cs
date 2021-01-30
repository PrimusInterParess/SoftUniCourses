using System;

namespace _05.TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTournaments = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());
            int sumPoints = 0;


            int winCounter = 0;

            for (int i = 0; i < numberOfTournaments; i++)
            {
                string symbol = Console.ReadLine();


                switch (symbol)
                {
                    case "W":
                        winCounter++; sumPoints += 2000;
                        break;
                    case "F":
                        sumPoints += 1200;
                        break;
                    case "SF":
                        sumPoints += 720;
                        break;
                }
            }
            int finalPoints = sumPoints + startPoints;
            int averagePoints = sumPoints / numberOfTournaments;
            double winPercentage = winCounter * 1.0 / numberOfTournaments * 100;

            Console.WriteLine($"Final points: {finalPoints}");
            Console.WriteLine($"Average points: {averagePoints}");
            Console.WriteLine($"{winPercentage:f2}%");
        }
    }
}
