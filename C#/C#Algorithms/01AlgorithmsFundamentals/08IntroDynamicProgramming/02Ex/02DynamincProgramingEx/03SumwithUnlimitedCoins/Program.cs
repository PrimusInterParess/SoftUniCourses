using System;
using System.Linq;

namespace _03SumwithUnlimitedCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbs = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var targetSum = int.Parse(Console.ReadLine());

            var result = CountSums(numbs, targetSum);

            Console.WriteLine(result);
        }

        private static int CountSums(int[] numbs, int targetSum)
        {
            var sums = new int[targetSum + 1];

            sums[0] = 1;

            foreach (var num in numbs)
            {

                for (int sum = num; sum <= targetSum; sum++)
                {
                    sums[sum] += sums[sum - num];

                }

            }

            return sums[targetSum];
        }
    }
}
