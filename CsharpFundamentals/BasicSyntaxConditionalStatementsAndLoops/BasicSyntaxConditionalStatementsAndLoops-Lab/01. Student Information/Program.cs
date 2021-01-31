using System;

namespace _01._Student_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            tring studentName = Console.ReadLine();
            int studentAge = int.Parse(Console.ReadLine());
            double studentGrade = double.Parse(Console.ReadLine());


            Console.WriteLine($"Name: {studentName}, Age: {studentAge}, Grade: {studentGrade:F2}");
        }
    }
}
