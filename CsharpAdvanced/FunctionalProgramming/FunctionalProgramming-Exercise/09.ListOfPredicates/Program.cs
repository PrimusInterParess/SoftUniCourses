using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            List<int> numbers = Enumerable.Range(1, end).ToList();

            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();


            Func<int, int, bool> predicateFunc = (num, divider) => num % divider == 0;

            foreach (var num in numbers)
            {
                if (dividers.All(d => predicateFunc(num, d)))
                {
                    Console.Write(num + " ");

                }
            }
        }
    }
}
