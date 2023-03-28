using System;
using System.Collections.Generic;
using System.Linq;

namespace _04SumWithLimitedCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int target = int.Parse(Console.ReadLine());

            int count = CountSums(target,numbers);

            Console.WriteLine(count);
        }

        private static int CountSums(int target, int[] numbers)
        {
            var hashSet = new HashSet<int>(){0};
            int counter = 0;

            foreach (var number in numbers)
            {
                var currentHashset = new HashSet<int>();
                foreach (var sum in hashSet)
                {
                    int newSum = number + sum;

                    if (newSum==target)
                    {
                        counter+=1;
                    }

                    currentHashset.Add(newSum);

                }

                hashSet.UnionWith(currentHashset);
            }

            return counter;
        }
    }
}
