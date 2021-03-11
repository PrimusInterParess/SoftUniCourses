using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();


            for (int i = 0; i < n; i++)
            {
                string[] personInputData = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = personInputData[0];

                int age = int.Parse(personInputData[1]);

                Person person = new Person(name,age);

                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");

        }
    }
}
