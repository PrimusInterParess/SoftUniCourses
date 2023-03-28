using System;

namespace _04.Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            int startPoints = 301;

            int sucsessfull = 0;
            int failure = 0;
            string command = Console.ReadLine();


            while (command != "Retire")
            {

                int score = int.Parse(Console.ReadLine());

                if (command == "Single")
                {
                    if (score <= startPoints)
                    {
                        startPoints -= score;
                        sucsessfull++;

                    }
                    else
                    {
                        failure++;
                    }
                }
                else if (command == "Double")
                {
                    if ((score * 2) <= startPoints)
                    {
                        startPoints -= score * 2;
                        sucsessfull++;

                    }
                    else
                    {
                        failure++;
                    }
                }
                else if (command == "Triple")
                {
                    if ((score * 3) <= startPoints)
                    {
                        startPoints -= score * 3;
                        sucsessfull++;

                    }
                    else
                    {
                        failure++;
                    }
                }
                else if (command == "Retire")
                {

                    break;
                }
                if (startPoints == 0)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (startPoints == 0)
            {
                Console.WriteLine($"{playerName} won the leg with {sucsessfull} shots.");
            }
            else if (command == "Retire")
            {
                Console.WriteLine($"{playerName} retired after {failure} unsuccessful shots.");
            }

        }
    }
}
