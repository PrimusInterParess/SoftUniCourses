using System;

namespace _02.FootballResults
{
    class Program
    {
        static void Main(string[] args)
        {
            int win = 0;
            int lost = 0;
            int draw = 0;

            for (int game = 1; game <= 3; game++)
            {
                string result = Console.ReadLine();

                char scoreOne = result[0];
                char scoreTwo = result[2];

                if (scoreOne > scoreTwo)
                {
                    win++;
                }
                else if (scoreTwo > scoreOne)
                {
                    lost++;
                }
                else
                {
                    draw++;
                }
            }

            Console.WriteLine($"Team won {win} games.");
            Console.WriteLine($"Team lost {lost} games.");
            Console.WriteLine($"Drawn games: {draw}");
        }
    }
}
