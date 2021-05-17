using System;
using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] data = input.Split();

                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);

                IResident newPerson = new Person(name, country, age);
                IPerson same = new Person(name, country, age);

                Console.WriteLine(same.GetName());
                Console.WriteLine(newPerson.GetName());

            }
        }
    }
}
