using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentionsOfSets = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstSetSize = dimentionsOfSets[0];
            int secondSetSize = dimentionsOfSets[1];

            HashSet<int> firstHashSet = new HashSet<int>();
            HashSet<int> secondHashSet = new HashSet<int>();

            for (int i = 0; i < firstSetSize; i++)
            {
                int numberToAdd = int.Parse(Console.ReadLine());

                firstHashSet.Add(numberToAdd);
            }

            for (int i = 0; i < secondSetSize; i++)
            {
                int numberToAdd = int.Parse(Console.ReadLine());

                secondHashSet.Add(numberToAdd);
            }


            firstHashSet.IntersectWith(secondHashSet);

            foreach (var num in firstHashSet)
            {
                Console.Write(num+ " ");
            }

            Console.WriteLine();

        }
    }
}
