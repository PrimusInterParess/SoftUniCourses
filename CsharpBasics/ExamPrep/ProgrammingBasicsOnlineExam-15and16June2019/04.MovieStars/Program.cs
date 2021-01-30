using System;

namespace _04.MovieStars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string actorsName = Console.ReadLine();
            double expences = 0;


            while (actorsName != "ACTION")
            {


                if (actorsName.Length > 15)
                {

                    expences = budget * 0.20;
                }
                else if (actorsName.Length <= 15)
                {
                    double salary = double.Parse(Console.ReadLine());
                    expences = salary;
                }


                budget -= expences;


                if (budget <= 0)
                {
                    break;
                }

                actorsName = Console.ReadLine();
            }

            if (actorsName == "ACTION")
            {
                Console.WriteLine($"We are left with {budget:F2} leva.");
            }
            else
            {
                Console.WriteLine($"We need {Math.Abs(budget):f2} leva for our actors.");
            }
        }
    }
}
