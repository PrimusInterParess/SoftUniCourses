using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalGrades = 0;
            int presentationCounter = 0;
            int numberOfGrades = int.Parse(Console.ReadLine());


            while (true)
            {
                string presentationName = Console.ReadLine();

                if (presentationName == "Finish")
                {
                    break;
                }

                double gradeSum = 0;

                for (int i = 0; i < numberOfGrades; i++)
                {
                    double grades = double.Parse(Console.ReadLine());
                    presentationCounter++;
                    gradeSum += grades;

                }
                totalGrades += gradeSum;

                double average = gradeSum / numberOfGrades;
                Console.WriteLine($"{presentationName} - {average:F2}.");
            }

            double final = totalGrades / presentationCounter;

            Console.WriteLine($"Student's final assessment is {final:F2}.");
        }
    }
}
