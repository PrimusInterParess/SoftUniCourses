using System;
using System.Collections.Generic;
using System.Linq;

namespace _02DividingPresents
{
    class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


            var allSums = GetSums(presents);

            var totalSum = presents.Sum();

            var alanSum = totalSum / 2;

            while (true)
            {
                if (allSums.ContainsKey(alanSum))
                {
                    var alanPresants = FindSubset(alanSum, allSums);

                    var bobSum = totalSum - alanSum;

                    var diff = bobSum - alanSum;

                    Console.WriteLine($"Difference: {diff}");
                    Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
                    Console.WriteLine($"Alan takes: {string.Join(' ', alanPresants)}");
                    Console.WriteLine("Bob takes the rest.");
                    break;
                }

                alanSum -= 1;
            }



        }

        private static List<int> FindSubset(int target, Dictionary<int, int> sums)
        {
            var toReturnLinst = new List<int>();

            while (target != 0)
            {
                var current = sums[target];

                toReturnLinst.Add(current);

                target -= current;

            }



            return toReturnLinst;
        }

        private static Dictionary<int, int> GetSums(int[] elements)
        {
            var dicToReturn = new Dictionary<int, int>() { { 0, 0 } };

            foreach (var element in elements)
            {
                var sums = dicToReturn.Keys.ToArray();

                foreach (var sum in sums)
                {
                    var currentSum = sum + element;

                    if (dicToReturn.ContainsKey(currentSum))
                    {
                        continue;
                    }

                    dicToReturn.Add(currentSum, element);
                }

            }

            return dicToReturn;

        }
    }
}
