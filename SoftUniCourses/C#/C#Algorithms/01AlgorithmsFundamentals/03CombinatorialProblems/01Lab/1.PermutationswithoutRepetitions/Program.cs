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

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutations[index] = elements[i];
                    Permute(index + 1);
                    used[i] = false;
                }
            }

        }
    }
}
