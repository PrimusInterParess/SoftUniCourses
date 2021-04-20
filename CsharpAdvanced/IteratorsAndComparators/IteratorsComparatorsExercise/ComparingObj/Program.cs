using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObj
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            Dictionary<int, Person> peopple = new Dictionary<int, Person>();

            int position = 1;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = data[0];

                int age = int.Parse(data[1]);

                string town = data[2];

                peopple.Add(position, new Person(name, age, town));

                position++;
            }

            int n = int.Parse(Console.ReadLine());

            Person personToCompare = peopple[n];

            int match = 0;

            foreach (var pairPerson in peopple)
            {
                if (personToCompare.CompareTo(pairPerson.Value) == 0)
                {
                    match++;
                }
            }

            if (match <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                int notAMatch = peopple.Count - match;

                Console.WriteLine($"{match} {notAMatch} {peopple.Count}");
            }





        }
    }
}
