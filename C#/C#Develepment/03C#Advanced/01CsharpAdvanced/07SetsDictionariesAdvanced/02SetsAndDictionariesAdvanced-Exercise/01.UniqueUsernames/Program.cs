using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfUsers = int.Parse(Console.ReadLine());

            HashSet<string> data = new HashSet<string>();

            for (int i = 0; i < numberOfUsers; i++)
            {
                string input = Console.ReadLine();

                data.Add(input);

            }

            foreach (var user in data)
            {
                Console.WriteLine(user);
            }
        }
    }
}
