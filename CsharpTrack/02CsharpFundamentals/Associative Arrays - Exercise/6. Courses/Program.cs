using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Courses
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = string.Empty;

            Dictionary<string, List<string>> courseRegistration = new Dictionary<string, List<string>>();

            while (!((input = Console.ReadLine()) == "end"))
            {
                string[] data = input.Split(" : ",StringSplitOptions.RemoveEmptyEntries).ToArray();

                string courseName = data[0];
                string studentsName = data[1];

                if (!courseRegistration.ContainsKey(courseName))
                {
                    courseRegistration.Add(courseName, new List<string>());
                    courseRegistration[courseName].Add(studentsName);
                }
                else
                {
                    courseRegistration[courseName].Add(studentsName);
                }
            }

            foreach (var item in courseRegistration.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach (var student in item.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
