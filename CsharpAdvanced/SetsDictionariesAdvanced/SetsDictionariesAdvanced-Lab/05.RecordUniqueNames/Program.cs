using System;
using System.Collections.Generic;

namespace _05.RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());

            HashSet<string> nameSet = new HashSet<string>();

            for (int i = 0; i < numberOfNames; i++)
            {
                string input = Console.ReadLine();

                nameSet.Add(input);
            }

            foreach (var name in nameSet)
            {
                Console.WriteLine(name);
            }
        }
    }
}
