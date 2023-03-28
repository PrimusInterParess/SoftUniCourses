using System;
using System.Linq;

namespace PermutationWithoutRepetition
{
    class Program
    {
        private static string[] elements;
        private static string[] permutations;
        private static bool[] used;

        static void Main(string[] args)
        {
            elements = Console.ReadLine()
               .Split(" ")
               .ToArray();

            permutations = new string[elements.Length];
            used = new bool[elements.Length];

            Permute(0);

        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(index + 1);

            for (int i = index+1; i < elements.Length; i++)
            {
               
                
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);

                
            }
        }


        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
