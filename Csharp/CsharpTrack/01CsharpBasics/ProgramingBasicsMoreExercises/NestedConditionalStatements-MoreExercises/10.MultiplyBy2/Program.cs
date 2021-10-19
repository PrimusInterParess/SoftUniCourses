using System;

namespace _10.MultiplyBy2
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            if (number < 0)
            {
                Console.WriteLine("Negative number!");
                break;
            }
            double result = number * 2;
            Console.WriteLine($"Result: {result:f2}");
        }
    }
}
