using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> 09d122f1daa097e79ea3709b8fe3e138d175333d
using System.Linq;

namespace _01.ActionPrint
{
    class Program
    {
<<<<<<< HEAD
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string[]> print =  PrintNames;

            print(names);

        }

        static void PrintNames(string[] names)
        {

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
=======

>>>>>>> 09d122f1daa097e79ea3709b8fe3e138d175333d
    }
}
