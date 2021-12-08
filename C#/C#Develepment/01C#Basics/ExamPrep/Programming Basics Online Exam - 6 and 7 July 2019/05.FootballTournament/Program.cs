using System;

namespace _05.FootballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int numberOfGames = int.Parse(Console.ReadLine());

            int score = 0;
            int win = 0;
            int draw = 0;
            int lost = 0;

            if (numberOfGames == 0)
            {
                Console.WriteLine($"{teamName} hasn't played any games during this season.");

            }
            else
            {
                for (int i = 0; i < numberOfGames; i++)
                {
                    string result = Console.ReadLine();

                    switch (result)
                    {
                        case "W":
                            win++; score += 3;
                            break;
                        case "D":
                            draw++; score += 1;
                            break;
                        case "L":
                            lost++;
                            break;
                    }
                }
                double winRate = win * 1.0 / numberOfGames * 100;
                Console.WriteLine($"{teamName} has won {score} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {win}");
                Console.WriteLine($"## D: {draw}");
                Console.WriteLine($"## L: {lost}");
                Console.WriteLine($"Win rate: {winRate:f2}%");
            }

        }
    }
}
