using System;

namespace _06.TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kilometars = double.Parse(Console.ReadLine());

            double salary = 0;

            if (kilometars <= 5000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    salary = (kilometars * 0.75) * 4;
                }
                else if (season == "Summer")
                {
                    salary = (kilometars * 0.90) * 4;
                }
                else
                {
                    salary = (kilometars * 1.05) * 4;
                }
            }
            else if (kilometars > 5000 && kilometars <= 10000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    salary = (kilometars * 0.95) * 4;
                }
                else if (season == "Summer")
                {
                    salary = (kilometars * 1.10) * 4;
                }
                else
                {
                    salary = (kilometars * 1.25) * 4;
                }
            }
            else
            {
                salary = (kilometars * 1.45) * 4;
            }
            double total = salary - (salary * 0.10);

            Console.WriteLine($"{total:f2}");
        }
    }
}
