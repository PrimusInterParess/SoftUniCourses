using System;

namespace _04.EasterEggsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerOneEggs = int.Parse(Console.ReadLine());
            int playerTwoEggs = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "End of battle")
            {

                if (command == "one")
                {
                    playerTwoEggs--;

                    if (playerTwoEggs == 0)
                    {
                        Console.WriteLine($"Player two is out of eggs. Player one has {playerOneEggs} eggs left.");
                        break;
                    }
                }
                else
                {
                    playerOneEggs--;

                    if (playerOneEggs == 0)
                    {
                        Console.WriteLine($"Player one is out of eggs. Player two has {playerTwoEggs} eggs left.");
                    }
                }
                command = Console.ReadLine();
            }

            if (command == "End of battle")
            {
                Console.WriteLine($"Player one has {playerOneEggs} eggs left.");
                Console.WriteLine($"Player two has {playerTwoEggs} eggs left.");
            }
        }
    }
}
