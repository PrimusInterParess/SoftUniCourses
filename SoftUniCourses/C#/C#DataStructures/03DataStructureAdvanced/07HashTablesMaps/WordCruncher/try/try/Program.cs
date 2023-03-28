using System;
using System.Collections.Generic;
using System.Linq;

namespace failed
{
    class Program
    {
        static void Main(string[] args)
        {
            


            string[] input = Console.ReadLine().Split(new Char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            SortedSet<string> sorting = new SortedSet<string>(input);

            Console.WriteLine(string.Join(' ',sorting));

        }
    }
}
