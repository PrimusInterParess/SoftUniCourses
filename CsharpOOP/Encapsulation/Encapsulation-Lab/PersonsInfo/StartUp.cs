using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            Team team = new Team("SoftUni");

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string firstName = data[0];

                string lastName = data[1];

                int age = int.Parse(data[2]);

                decimal salaDecimal = decimal.Parse(data[3]);

                try
                {
                    Person newPerson = new Person(firstName, lastName,age, salaDecimal);

                   persons.Add(newPerson);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                   
                }
            }

            

          

            foreach (var person in persons)
            {
                team.AddPlayer(person);
            }


            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

        }
    }
}
