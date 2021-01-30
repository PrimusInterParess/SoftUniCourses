using System;

namespace _06.NameGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int points = 0;
            int namePoints = 0;
            int maxPoints = int.MinValue;
            string winName = string.Empty;

            while (name != "Stop")
            {
                if (name == "Stop")
                {

                    break;
                }



                for (int i = 0; i < name.Length; i++)
                {
                    int number = int.Parse(Console.ReadLine());

                    namePoints = name[i];

                    if (namePoints == number)
                    {
                        points += 10;
                    }
                    else
                    {
                        points += 2;
                    }
                }

                if (maxPoints <= points)
                {
                    maxPoints = points;
                    winName = name;
                }
                points = 0;

                name = Console.ReadLine();
            }
            Console.WriteLine($"The winner is {winName} with {maxPoints} points!");
        }
    }
}
