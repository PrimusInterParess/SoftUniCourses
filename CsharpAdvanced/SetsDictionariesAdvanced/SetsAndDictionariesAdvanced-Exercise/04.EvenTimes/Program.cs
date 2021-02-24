using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDigits = int.Parse(Console.ReadLine());

            HashSet<int> numbers = new HashSet<int>();

            Dictionary<int, int> numbersAndItsApearences = new Dictionary<int, int>();

            for (int i = 0; i < numberOfDigits; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (!numbersAndItsApearences.ContainsKey(input))
                {
                    numbersAndItsApearences.Add(input, 0);
                }

                numbersAndItsApearences[input]++;

            }

            foreach (var pair in numbersAndItsApearences)
            {
                if (pair.Value % 2 == 0)
                {
                    Console.WriteLine(pair.Key);
                }
            }
        }
    }
}
