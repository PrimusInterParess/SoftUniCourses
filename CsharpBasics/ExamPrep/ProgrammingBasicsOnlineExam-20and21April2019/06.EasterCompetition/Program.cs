using System;

namespace _06.EasterCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int chefsNumber = int.Parse(Console.ReadLine());

            int maxPoints = 0;
            string numberOneChef = string.Empty;

            for (int i = 0; i < chefsNumber; i++)
            {

                string chefsName = Console.ReadLine();
                string command = Console.ReadLine();
                int sumPoints = 0;

                while (true)
                {
                    if (command == "Stop")
                    {
                        break;
                    }
                    int score = int.Parse(command);

                    sumPoints += score;

                    command = Console.ReadLine();

                }

                Console.WriteLine($"{chefsName} has {sumPoints} points.");

                if (sumPoints > maxPoints)
                {
                    maxPoints = +sumPoints;
                    numberOneChef = chefsName;

                    Console.WriteLine($"{numberOneChef} is the new number 1!");
                }
            }
            Console.WriteLine($"{numberOneChef} won competition with {maxPoints} points!");
        }
    }
}
