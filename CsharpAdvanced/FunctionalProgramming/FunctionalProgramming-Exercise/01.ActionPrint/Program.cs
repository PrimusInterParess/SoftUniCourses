using System;
using System.Linq;

namespace _01.ActionPrint
{
    class Program
    {
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
    }
}
