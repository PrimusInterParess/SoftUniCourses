using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            Predicate<string> filter = str => str.Length <= length;

            foreach (var s in names.Where(n=>filter(n)))
            {
                Console.WriteLine(s);
            }
        }
    }
}
