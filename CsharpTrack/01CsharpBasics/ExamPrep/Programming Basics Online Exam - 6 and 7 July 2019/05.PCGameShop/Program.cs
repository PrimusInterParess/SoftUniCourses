using System;

namespace _05.PCGameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGames = int.Parse(Console.ReadLine());
            int gameOne = 0;
            int gameTwo = 0;
            int gameThree = 0;
            int otherGames = 0;


            for (int i = 1; i <= numberOfGames; i++)
            {
                string nameOfGame = Console.ReadLine();

                switch (nameOfGame)
                {
                    case "Hearthstone":
                        gameOne++;
                        break;
                    case "Fornite":
                        gameTwo++;
                        break;
                    case "Overwatch":
                        gameThree++;
                        break;
                    default:
                        otherGames++;
                        break;
                }
            }
            double gameOnePercentage = (gameOne * 1.0 / numberOfGames) * 100;
            double gameTwoPercentage = (gameTwo * 1.0 / numberOfGames) * 100;
            double gameThreePercentage = (gameThree * 1.0 / numberOfGames) * 100;
            double otherGamesPercentage = (otherGames * 1.0 / numberOfGames) * 100;

            Console.WriteLine($"Hearthstone - {gameOnePercentage:f2}%");
            Console.WriteLine($"Fornite - {gameTwoPercentage:F2}%");
            Console.WriteLine($"Overwatch - {gameThreePercentage:f2}%");
            Console.WriteLine($"Others - {otherGamesPercentage:F2}%");
        }
    }
}
