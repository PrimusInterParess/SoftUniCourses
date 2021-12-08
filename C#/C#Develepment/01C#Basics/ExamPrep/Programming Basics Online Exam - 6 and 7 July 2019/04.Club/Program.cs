using System;

namespace _04.Club
{
    class Program
    {
        static void Main(string[] args)
        {

            double goal = double.Parse(Console.ReadLine());
            string coctailType = Console.ReadLine();
            double totalSum = 0;

            while (coctailType != "Party!")
            {

                int numberOfCoctails = int.Parse(Console.ReadLine());
                double sum = 0;

                sum += numberOfCoctails * coctailType.Length;


                if (sum % 2 != 0)
                {
                    sum -= (sum * 25) / 100;
                }

                totalSum += sum;

                if (totalSum >= goal)
                {
                    Console.WriteLine("Target acquired.");
                    break;
                }


                coctailType = Console.ReadLine();
            }
            if (coctailType == "Party!")
            {
                double notEnough = goal - totalSum;
                Console.WriteLine($"We need {notEnough:f2} leva more.");

            }

            Console.WriteLine($"Club income - {totalSum:f2} leva.");

        }
    }
}
