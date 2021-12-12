using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SumofCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputCoints = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int targetAmount = int.Parse(Console.ReadLine());

            SortedSet<int> sortedCoints = new SortedSet<int>(inputCoints);

            int result = 0;

            while (targetAmount > 0 && sortedCoints.Count > 0)
            {
                var maxCoin = sortedCoints.Max;

                if (maxCoin>targetAmount)
                {
                    continue;
                    
                }


                sortedCoints.Remove(maxCoin);

                var counter = targetAmount / maxCoin;

                result += counter;


                targetAmount = targetAmount * counter;

            }

            if (targetAmount>0)
            {
                
            }
            else
            {
                
            }
        }
    }
}
