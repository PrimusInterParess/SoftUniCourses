using System;
using System.Linq;
using System.Text;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string decrypted = Console.ReadLine();

            string input = string.Empty;


            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] command = input.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (command[0])
                {
                    case "Move":
                        decrypted = Move(decrypted, int.Parse(command[1]));
                        break;
                    case "Insert":
                        decrypted = Insert(int.Parse(command[1]), command[2], decrypted);
                        break;
                    case "ChangeAll":
                        decrypted = (Channge(char.Parse(command[1]), char.Parse(command[2]), decrypted));
                        break;


                }
            }

            Console.WriteLine($"The decrypted message is: {decrypted}");


        }

        static string Channge(char toReplace, char replacement, string decrypted)
        {

            decrypted = decrypted.Replace(toReplace, replacement);

            return decrypted;


        }

        static string Insert(int index, string toInsert, string decrypted)
        {
            decrypted = decrypted.Insert(index, toInsert);

            return decrypted;

        }

        static string Move(string decrypted, int numberOfLetters)
        {


            for (int i = 0; i < numberOfLetters; i++)
            {
                decrypted += decrypted[i];
            }


            decrypted = decrypted.Remove(0, numberOfLetters);



            return decrypted;
        }
    }
}
