using System;

namespace _08.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grades = double.Parse(Console.ReadLine());
            double minimalIncome = double.Parse(Console.ReadLine());

            double socialPrice = Math.Floor(minimalIncome * 0.35);
            double excellentPrice = Math.Floor(grades * 25);

            if (grades >= 5.5)
            {
                if (excellentPrice >= socialPrice || income > minimalIncome)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {excellentPrice} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {socialPrice} BGN");
                }
            }
            else if (grades > 4.5 && income < minimalIncome)
            {
                Console.WriteLine($"You get a Social scholarship {socialPrice} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
