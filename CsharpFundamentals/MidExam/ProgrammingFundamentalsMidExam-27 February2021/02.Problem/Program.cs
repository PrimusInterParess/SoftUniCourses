using System;
using System.Linq;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string input = String.Empty;

            int blackListedNames = 0;

            int countLostNames = 0;

            while ((input = Console.ReadLine()) != "Report")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "Blacklist":
                        bool found = false;
                        int indd = -1;

                        for (int i = 0; i < names.Length; i++)
                        {
                            if (names[i] == command[1])
                            {
                                indd = i;
                                found = true;
                                blackListedNames++;
                                break;
                            }
                            
                        }

                        if (found)
                        {
                            Console.WriteLine($"{names[indd]} was blacklisted.");
                            names[indd] = "Blacklisted";

                        }
                        else
                        {
                            Console.WriteLine($"{command[1]} was not found.");
                        }
                        break;
                    case "Error":
                        int index = int.Parse(command[1]);

                        if (names[index] != "Blacklisted" &&  names[index] != "Lost")
                        {

                            Console.WriteLine($"{names[index]} was lost due to an error.");
                            names[index] = "Lost";

                            countLostNames++;
                        }
                        break;
                    case "Change":
                        int ind = int.Parse(command[1]);
                        string newName = command[2];


                        if (ind >= 0 && ind < names.Length)
                        {
                            Console.WriteLine($"{names[ind]} changed his username to {newName}.");

                            names[ind] = newName;
                        }

                        break;
                        ;

                }

              

            }

            Console.WriteLine($"Blacklisted names: {blackListedNames} ");
            Console.WriteLine($"Lost names: {countLostNames}");

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
