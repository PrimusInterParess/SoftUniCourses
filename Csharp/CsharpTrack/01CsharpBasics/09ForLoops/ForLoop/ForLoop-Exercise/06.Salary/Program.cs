using System;

namespace _06.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            for (int i = 0; i < tabs; i++)
            {
                string webSite = Console.ReadLine();

                if (webSite == "Facebook")
                {
                    salary -= 150;
                }
                if (webSite == "Instagram")
                {
                    salary -= 100;
                }
                if (webSite == "Reddit")
                {
                    salary -= 50;
                }

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            if (salary > 0)
            {
                Console.WriteLine(salary);

            }
        }
    }
}
