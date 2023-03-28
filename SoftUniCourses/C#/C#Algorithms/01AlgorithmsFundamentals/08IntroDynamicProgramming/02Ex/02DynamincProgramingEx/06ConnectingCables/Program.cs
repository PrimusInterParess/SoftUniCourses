using System;
using System.Linq;

namespace _06ConnectingCables
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] positions = Enumerable
                .Range(1, numbArray.Length)
                .ToArray();

            var lcs = new int[numbArray.Length + 1, positions.Length + 1];

            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (numbArray[r - 1] == positions[c - 1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: {lcs[numbArray.Length, positions.Length]}");
        }
    }
}
