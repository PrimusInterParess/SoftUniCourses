using System;

namespace _05.ChallengeTheWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int numberTables = int.Parse(Console.ReadLine());
            int tableCounter = 0;
            bool noFreeTables = false;

            for (int m = 1; m <= men; m++)
            {
                for (int w = 1; w <= women; w++)
                {
                    tableCounter++;
                    Console.Write($"({m} <-> {w}) ");

                    if (numberTables == tableCounter)
                    {
                        noFreeTables = true;
                        break;
                    }
                }
                if (noFreeTables)
                {
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
