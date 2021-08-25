using System;

namespace _01.ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {

            int meters = int.Parse(Console.ReadLine());

            decimal kilometers = meters / 1000.0M;

            Console.WriteLine($"{kilometers:F2}");
        }
    }
}
