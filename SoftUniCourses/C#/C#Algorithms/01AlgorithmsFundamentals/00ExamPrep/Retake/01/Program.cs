using System;
using System.Linq;

namespace _06.CombinationsWithRepetiotion
{
    class Program
    {
        private static string elements;
        private static int k;
        private static char[] elementsChars;
        private static char[] combinations;


        static void Main(string[] args)
        {
            elements = Console.ReadLine();
            
            k = int.Parse(Console.ReadLine());
            combinations = new Char[k];
            elementsChars = elements.OrderBy(e => e).ToArray();
            Combinations(0, 0);

        }

        private static void Combinations(int combIndex, int elementsStartIndex)
        {
            if (combIndex >= combinations.Length)
            {
                Console.WriteLine(string.Join("", combinations));
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                combinations[combIndex] = elementsChars[i];
                Combinations(combIndex + 1, i);
            }
        }
    }
}