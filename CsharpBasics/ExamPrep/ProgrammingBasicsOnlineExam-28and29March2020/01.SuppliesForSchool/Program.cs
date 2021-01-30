using System;

namespace _01.SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            double pensPacks = double.Parse(Console.ReadLine());
            double markersPacks = double.Parse(Console.ReadLine());
            double detergentLitters = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double pensTotal = pensPacks * 5.80;
            double markersTotal = markersPacks * 7.20;
            double detergentTotal = detergentLitters * 1.20;

            double total = pensTotal + markersTotal + detergentTotal;
            double priceWithDisocunt = (total - (total * discount / 100));

            Console.WriteLine($"{priceWithDisocunt:f3}");
        }
    }
}
