using System;

namespace _06.Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int suits = int.Parse(Console.ReadLine());

            for (int f = floors; 1 <= f; f--)
            {
                for (int s = 0; s < suits; s++)
                {
                    string prefix = "";

                    if (floors == f)
                    {
                        prefix = "L";
                    }
                    else if (f % 2 == 0)
                    {
                        prefix = "O";
                    }
                    else
                    {
                        prefix = "A";
                    }
                    Console.Write($"{prefix}{f}{s} ");
                }
                Console.WriteLine();
            }
        }
    }
}
