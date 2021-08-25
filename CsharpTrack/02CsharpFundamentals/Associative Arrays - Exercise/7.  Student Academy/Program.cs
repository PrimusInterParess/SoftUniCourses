using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.__Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string studentsName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                

                if (students.ContainsKey(studentsName))
                {
                    students[studentsName].Add(grade);
                }
                else
                {
                    students.Add(studentsName, new List<double>());
                    students[studentsName].Add(grade);
                }
                
            }

            var averageGradeStudents = new Dictionary<string, double>();

            foreach (var item in students)
            {            
                    averageGradeStudents.Add(item.Key,item.Value.Average());               
            }

            foreach (var item in averageGradeStudents.Where(x => x.Value >= 4.50).OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");
            }

             
            
        }
    }
}
