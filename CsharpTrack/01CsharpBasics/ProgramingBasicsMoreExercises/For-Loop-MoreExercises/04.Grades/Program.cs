using System;

namespace _04.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            double fail = 0;
            double good = 0;
            double veryGood = 0;
            double excellent = 0;

            double sumFailGrades = 0;
            double sumGoodGrades = 0;
            double sumVeryGoodGrades = 0;
            double sumExcellentGrades = 0;


            for (int i = 1; i <= numberOfStudents; i++)
            {
                double grades = double.Parse(Console.ReadLine());

                if (grades >= 2 && grades < 3)
                {
                    fail++;
                    sumFailGrades += grades;

                }
                else if (grades >= 3 && grades < 4)
                {
                    good++;
                    sumGoodGrades += grades;
                }
                else if (grades >= 4 && grades < 5)
                {
                    veryGood++;
                    sumVeryGoodGrades += grades;
                }
                else // grades >5
                {
                    excellent++;
                    sumExcellentGrades += grades;
                }
            }
            double excellentStudentsPercetage = (excellent / numberOfStudents) * 100;
            double verryGoodStudentsPercentage = (veryGood / numberOfStudents) * 100;
            double goodStudentsPercentage = (good / numberOfStudents) * 100;
            double failStudentsPercentage = (fail / numberOfStudents) * 100;
            double averageGrade = (sumExcellentGrades + sumVeryGoodGrades + sumGoodGrades + sumFailGrades) / numberOfStudents;

            Console.WriteLine($"Top students: {excellentStudentsPercetage:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {verryGoodStudentsPercentage:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {goodStudentsPercentage:f2}%");
            Console.WriteLine($"Fail: {failStudentsPercentage:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}
