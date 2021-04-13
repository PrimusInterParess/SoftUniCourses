using System;
using System.Collections.Generic;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> topStudents = new List<Student>();

            SortedDictionary<Student, string> topSchools = new SortedDictionary<Student, string>();


            for (int i = 0; i < 10; i++)
            {
                topSchools.Add(new Student(), "Shcool" + i % 3);
            }

            foreach (var item in topSchools)
            {
                Console.WriteLine($"{item.Key.Name} {item.Value}");
            }


            int minIndex = 0;

            IComparer<Student> comparer = new StudentsCoparer();


            for (int i = 0; i < topStudents.Count; i++)
            {
                for (int j = i; j < topStudents.Count; j++)
                {


                    if (comparer.Compare(topStudents[minIndex], topStudents[j]) > 0)
                    {
                        minIndex = j;

                    }
                }

                Student temp = topStudents[minIndex];
                topStudents[minIndex] = topStudents[i];
                topStudents[i] = temp;
            }

            foreach (var student in topStudents)
            {
                Console.WriteLine($"{student.Name} - {student.Grade}");
            }
        }
    }
}
