using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Dictionary<char, int> occurrences = new Dictionary<char, int>();


            for (int i = 0; i < input.Length; i++)
            {
                if (!occurrences.ContainsKey(input[i]))
                {
                    occurrences.Add(input[i], 0);
                }

                occurrences[input[i]]++;
            }


            foreach (var ch in occurrences.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
