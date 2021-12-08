using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCruncher
{
    class Program
    {
        static void Main(string[] args)
        {

            SortedSet<string> sorting = new SortedSet<string>();


            string[] input = Console.ReadLine().Split(new Char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
