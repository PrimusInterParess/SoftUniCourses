using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    public class Cat
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public Cat(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCats = int.Parse(Console.ReadLine());

            List<Cat> catList = new List<Cat>();

            for (int i = 0; i < numberOfCats; i++)
            {
                string[] data = Console.ReadLine().Split(", ");

                string name = data[0];

                int age = int.Parse(data[1]);

                catList.Add(new Cat(name, age));
            }

            string filterLimit = Console.ReadLine();

            int ageFilter = int.Parse(Console.ReadLine());

            string printFilter = Console.ReadLine();


            Func<Cat, bool> filter = filterLimit switch
            {
                "older" => c => c.Age >= ageFilter,
                "younger" => c => c.Age <= ageFilter,
                _ => null
            };

            Func<Cat, string> printFunc = printFilter switch
            {
                "name" => c =>$"{c.Name}",
                "age" => c =>$"{c.Age}",
                "name age" => c => $"{c.Name} - {c.Age}",
                _=>null
            };

           catList
               .Where(filter)
               .Select(printFunc).
               .ToList()
               .ForEach(Console.WriteLine).;

        }





    }
}
