using System;

namespace _04.GameNumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayer = Console.ReadLine();
            string secondPlayer = Console.ReadLine();

            bool gameEnd = false;
            int firstPlayerPoints = 0;
            int secondPlayerPoints = 0;

            string command = Console.ReadLine();


            while (command != "End of game")
            {

                if (command == "End of game")
                {
                    gameEnd = true;
                    break;
                }

                int firstPlayerCard = int.Parse(command);
                int secondPlayerCard = int.Parse(Console.ReadLine());

                if (firstPlayerCard > secondPlayerCard)
                {
                    firstPlayerPoints += firstPlayerCard - secondPlayerCard;
                }
                else if (secondPlayerCard > firstPlayerCard)
                {
                    secondPlayerPoints += secondPlayerCard - firstPlayerCard;
                }
                else if (firstPlayerCard == secondPlayerCard)
                {
                    Console.WriteLine("Number wars!");

                    firstPlayerCard = int.Parse(Console.ReadLine());
                    secondPlayerCard = int.Parse(Console.ReadLine());

                    if (firstPlayerCard > secondPlayerCard)
                    {
                        Console.WriteLine($"{firstPlayer} is winner with {firstPlayerPoints} points");

                        break;
                    }
                    else if (secondPlayerCard > firstPlayerCard)
                    {
                        Console.WriteLine($"{secondPlayer} is winner with {secondPlayerPoints} points");


                        break;
                    }
                }
                command = Console.ReadLine();
            }
            if (command == "End of game")
            {
                Console.WriteLine($"{firstPlayer} has {firstPlayerPoints} points");
                Console.WriteLine($"{secondPlayer} has {secondPlayerPoints} points");
            }

        }
    }
}
