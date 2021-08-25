using System;

namespace _02.LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char n1 = char.Parse(Console.ReadLine());
            char n2 = char.Parse(Console.ReadLine());
            char n3 = char.Parse(Console.ReadLine());

            int combinationCounter = 0;

            for (char i = n1; i <= n2; i++)
            {
                for (char j = n1; j <= n2; j++)
                {
                    for (char k = n1; k <= n2; k++)
                    {
                        if (i != n3 && j != n3 && k != n3)
                        {
                            Console.Write($"{i}{j}{k} ");
                            combinationCounter++;
                        }
                    }
                }
            }
            Console.WriteLine($"{combinationCounter}");
        }
    }
}
