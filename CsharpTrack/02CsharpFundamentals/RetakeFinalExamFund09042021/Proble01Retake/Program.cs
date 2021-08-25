using System;
using System.Linq;

namespace Proble01Retake
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


                if (commands.Length == 1)
                {
                    if (commands[0] == "Pass")
                    {

                    }
                    else if (commands[0] == "Play")
                    {

                    }
                }

                if (commands.Length == 2)
                {
                    if (commands[0] == "Move")
                    {
                        word = MovingLetter(word, int.Parse(commands[1]));
                    }
                    else if (commands[0] == "Reverse")
                    {
                        word = Reversing(word, commands[1]);

                    }
                }

                if (commands.Length == 3)
                {
                    string command = string.Join(" ", commands.Take(2));

                    if (command == "Exchange Tiles")
                    {

                    }
                    else if (command == "Insert Space")
                    {
                        word = InsertingSpace(word, int.Parse(commands[1]));
                    }
                }

            }
        }

        private static string Reversing(string word, string command)
        {
            int index = word.IndexOf(command);

            char[] sub = word.Substring(index, command.Length - 1).ToCharArray();

            Array.Reverse(sub);

            word = word.Remove(index, command.Length - 1);

            
        }

        private static string InsertingSpace(string word, int parse)
        {
            word = word.Insert(parse, " ");

            return word;
        }

        private static string MovingLetter(string word, int index)
        {


            if (index >= 0 && index <= word.Length - 1)
            {
                char toInsert = word[index];

                word = word += toInsert;

                word = word.Remove(index, 1);

                return word;
            }

            return word;
        }
    }
}
