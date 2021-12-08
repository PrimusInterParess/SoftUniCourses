using System;

namespace _04._Vacation_books_list
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPages = int.Parse(Console.ReadLine());

            double pagesPerHour = double.Parse(Console.ReadLine());

            int numDays = int.Parse(Console.ReadLine());

            double sumHours = numPages / pagesPerHour;

            double numHours = sumHours / numDays;

            Console.WriteLine(numHours);
        }
    }
}
