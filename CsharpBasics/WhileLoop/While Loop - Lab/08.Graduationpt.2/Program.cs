using System;

namespace _08.Graduationpt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string studenstName = Console.ReadLine();
            int grade = 1;
            int failed = 0;
            double totalGrades = 0;

            while (grade <= 12)
            {
                double grades = double.Parse(Console.ReadLine());

                if (grades >= 4)
                {
                    totalGrades += grades;
                    grade++;
                }
                else
                {
                    failed++;

                    if (failed == 2)
                    {
                        Console.WriteLine($"{studenstName} has been excluded at {grade} grade");
                        break;
                    }
                }
            }
            if (grade == 13)
            {
                double averageGrades = totalGrades / 12;

                Console.WriteLine($"{studenstName} graduated. Average grade: {averageGrades:f2}");
            }
        }
    }
}
