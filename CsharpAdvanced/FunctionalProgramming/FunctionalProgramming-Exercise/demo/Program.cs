using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> namesList = Console.ReadLine().Split().ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] command = input.Split(' ').ToArray();

                string action = command[0];

                string[] args = command.Skip(1).ToArray();

                Predicate<string>
            }


        }

    }
}
