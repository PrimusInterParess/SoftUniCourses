using System;
using System.Linq;

namespace _02.PermutationswithRepetition
{
    class Program
    {

        private static int[] elements;


        static void Main(string[] args)
        {
            elements  = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Permute(0);
        }

        private static void Permute(int permitationIndex)
        {
            if (permitationIndex >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(permitationIndex + 1);

            for (int i = permitationIndex + 1; i < elements.Length; i++)
            {
                Swap(permitationIndex, i);
                Permute(permitationIndex + 1);
                Swap(permitationIndex, i);

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
