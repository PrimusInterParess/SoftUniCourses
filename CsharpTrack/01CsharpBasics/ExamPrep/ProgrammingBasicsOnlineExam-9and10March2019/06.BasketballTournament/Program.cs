using System;

namespace _06.BasketballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string tournamentName = Console.ReadLine();
            int winCount = 0;
            int lostCount = 0;
            int totalGames = 0;


            while (tournamentName != "End of tournaments")
            {
                int numberOfGames = int.Parse(Console.ReadLine());
                totalGames += numberOfGames;
                int gamecount = 0;


                for (int i = 0; i < numberOfGames; i++)
                {

                    int result = 0;
                    string prefix = "";
                    gamecount++;

                    int teamAPoints = int.Parse(Console.ReadLine());
                    int teamBPoints = int.Parse(Console.ReadLine());


                    if (teamAPoints > teamBPoints)
                    {
                        prefix = "win";
                        winCount++;
                        result = teamAPoints - teamBPoints;
                        Console.WriteLine($"Game {gamecount} of tournament {tournamentName}: win with {result} points.");

                    }
                    else
                    {
                        lostCount++;
                        prefix = "lost";
                        result = teamBPoints - teamAPoints;
                        Console.WriteLine($"Game {gamecount} of tournament {tournamentName}: lost with {result} points.");
                    }

                }
                tournamentName = Console.ReadLine();
            }
            double winPercentage = winCount * 1.0 / totalGames * 100;
            double lostPercentage = lostCount * 1.0 / totalGames * 100;
            Console.WriteLine($"{winPercentage:f2}% matches win");
            Console.WriteLine($"{lostPercentage:f2}% matches lost");
        }
    }
}
