using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentsListDictionary = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] data = Console.ReadLine().Split().ToArray();

                string name = data[0];
                decimal grade = decimal.Parse(data[1]);

                if (!studentsListDictionary.ContainsKey(name))
                {
                    studentsListDictionary.Add(name, new List<decimal>());
                    studentsListDictionary[name].Add(grade);
                }
                else
                {
                    studentsListDictionary[name].Add(grade);
                }


            }

            foreach (var pair in studentsListDictionary)
            {
                Console.Write($"{pair.Key} -> ");

                foreach (var value in pair.Value)
                {
                    Console.Write($"{value:F2} ");
                }

                Console.WriteLine($"(avg: {pair.Value.Average():F2})");
            }
        }
    }
}
