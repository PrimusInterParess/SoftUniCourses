using System;
using System.Linq;

namespace _1.PermutationswithoutRepetitions
{
    class Program
    {
        private static int[] elements;
        private static int[] permutations;
        private static bool[] used;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            permutations = new int[elements.Length];

            used = new bool[elements.Length];

            Permute(0);
        }

        private static void Permute(int permitationIndex)
        {
            if (permitationIndex >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int elementsIndex = 0; elementsIndex < elements.Length; elementsIndex++)
            {
                if (!used[elementsIndex])
                {
                    used[elementsIndex] = true;
                    permutations[permitationIndex] = elements[elementsIndex];
                    Permute(permitationIndex + 1);
                    used[elementsIndex] = false;
                }
            }

        }
    }
}
