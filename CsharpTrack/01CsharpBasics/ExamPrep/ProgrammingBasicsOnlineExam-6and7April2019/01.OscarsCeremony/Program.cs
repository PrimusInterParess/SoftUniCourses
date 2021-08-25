using System;

namespace _01.OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallRent = double.Parse(Console.ReadLine());

            double statuesPrice = hallRent * 0.70;
            double cateringPrice = statuesPrice * 0.85;
            double soundSystemePrice = cateringPrice / 2;

            double totalPrice = hallRent + statuesPrice + cateringPrice + soundSystemePrice;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
