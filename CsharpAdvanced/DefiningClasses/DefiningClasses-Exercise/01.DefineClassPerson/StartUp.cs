using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();


            for (int i = 0; i < n; i++)
            {
                string[] personInputData = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = personInputData[0];

                int age = int.Parse(personInputData[1]);

                people.Add(new Person(name, age));
            }

            foreach (var person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}
