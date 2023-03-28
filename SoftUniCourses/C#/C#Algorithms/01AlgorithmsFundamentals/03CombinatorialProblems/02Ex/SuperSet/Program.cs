using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSet
{
    class Program
    {
        private static int[] elements;
        private static int k;

        private static int[] combinations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            k = 1;

            combinations = new int[k];

            while (k <= elements.Length)
            {
                Combinations(0, 0);
                combinations = new int[k += 1];
            }

        }

        private static void Combinations(int combIndex, int elementsStartIndex)
        {
            if (combIndex >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                combinations[combIndex] = elements[i];
                Combinations(combIndex + 1, i + 1);
            }
        }
    }
}
