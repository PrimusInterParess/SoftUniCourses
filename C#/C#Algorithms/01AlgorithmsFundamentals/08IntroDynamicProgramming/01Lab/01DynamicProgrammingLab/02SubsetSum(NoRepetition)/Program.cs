using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SubsetSum_NoRepetition_
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 3, 5, 1, 4, 2 };

            var possibleSums = GetAllPossibleSumsWithNumbersToFormIt(nums);

            int target = 6;

            var subsetNumbers = GetSubsetNumbers(possibleSums, target);

            Console.WriteLine(string.Join(" ", subsetNumbers));
        }

        private static List<int> GetSubsetNumbers(Dictionary<int,int> possibleSums, int target)
        {
            List<int> listToReturn = new List<int>();

            if (!possibleSums.ContainsKey(target))
            {
                Console.WriteLine("The sum does not exists.");

                return new List<int>();
            }

            while (target > 0)
            {
                var current = possibleSums[target];

                listToReturn.Add(current);

                target -= current;
            }

            return listToReturn;
        }

        private static HashSet<int> GetAllPossibleSums(int[] nums)
        {
            HashSet<int> sums = new HashSet<int>() { 0 };

            foreach (var numb in nums)
            {
                var currentHashset = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var currSum = numb + sum;

                    currentHashset.Add(currSum);
                }

                sums.UnionWith(currentHashset);
            }
            return sums;
        }

        private static Dictionary<int, int> GetAllPossibleSumsWithNumbersToFormIt(int[] nums)
        {
            Dictionary<int, int> sums = new Dictionary<int, int>() { { 0, 0 } };

            foreach (var num in nums)
            {
                var currentSums = sums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;

                    }

                    sums.Add(newSum, num);

                }
            }
            return sums;
        }


    }
}
