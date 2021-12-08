using System;
using System.Collections.Generic;
using System.Linq;

namespace EfCoreLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<Student>()
            {
                new Student { Name="Dani",Marks = new List<int>(){2,3,4,2,4,5,6,5,4}},
                new Student { Name="Mosho",Marks = new List<int>(){2,3,4,2,4,5,6,5,4}},
                new Student { Name="Ivo",Marks = new List<int>(){2,3,4,2,4,5,6,5,4}}
            };


            var newCollection = collection.Select(s => new StudentProjection()
            {
                Name = s.Name,
                Initials = s.Name.Substring(0,1),
                AverageGrade = s.Marks.Average()
            });


            foreach (var objProjection in newCollection)
            {
                
            }

        }

        class StudentProjection
        {
            public string Name { get; set; }
            public string Initials { get; set; }
            public double AverageGrade { get; set; }
        }

        class Student
        {
            public string Name { get; set; }
            public List<int> Marks { get; set; }

        }
    }
}
