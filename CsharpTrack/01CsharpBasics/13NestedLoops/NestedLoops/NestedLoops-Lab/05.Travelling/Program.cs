using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string destination = Console.ReadLine();

                if (destination == "End")
                {
                    break;
                }

                double budget = double.Parse(Console.ReadLine());
                double sum = 0;

                while (sum < budget)
                {
                    double savings = double.Parse(Console.ReadLine());
                    sum += savings;

                }
                Console.WriteLine($"Going to {destination}!");

            }
        }
    }
}
