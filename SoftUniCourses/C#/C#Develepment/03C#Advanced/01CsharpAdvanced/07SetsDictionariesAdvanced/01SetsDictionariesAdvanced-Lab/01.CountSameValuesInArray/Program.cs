using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> doubleDictionary = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!doubleDictionary.ContainsKey(numbers[i]))
                {
                    doubleDictionary.Add(numbers[i],0);
                }

                doubleDictionary[numbers[i]]++;
            }

            foreach (var pair in doubleDictionary)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
