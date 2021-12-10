using System;
using System.Collections.Generic;
using System.Linq;

namespace _05SchoolTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputDataGirls = Console.ReadLine().Split(", ").ToArray();
            string[] inputDataBoys = Console.ReadLine().Split(", ").ToArray();

            List<string[]> combinationsGirls = new List<string[]>();
            List<string[]> combinationsBoys= new List<string[]>();

            string[] destinationGirls = new string[3];
            string[] destinationBoys = new string[2];

            Combinations(0, 0, inputDataGirls, destinationGirls, combinationsGirls);
            Combinations(0, 0, inputDataBoys, destinationBoys, combinationsBoys);

            foreach (var girslList in combinationsGirls)
            {
                foreach (var boysList in combinationsBoys)
                {
                    Console.WriteLine($"{string.Join(", ",girslList)}, {string.Join(", ",boysList)}");
                }
            }

        }

        private static void Combinations(int combIndex, int elementsStartIndex, string[] elements, string[] destination, List<string[]> combinations)
        {
            if (combIndex >= destination.Length)
            {
                combinations.Add(destination.ToArray());
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                destination[combIndex] = elements[i];
                Combinations(combIndex + 1, i + 1, elements, destination,combinations);
            }
        }

    }
}
