using System;

namespace _05.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            double total = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "NoMoreMoney")
                {
                    break;
                }
                double number = double.Parse(input);

                if (number < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                total += number;
                Console.WriteLine($"Increase: {number:f2}");
            }


            Console.WriteLine($"Total: {total:F2}");
        }
    }
}
