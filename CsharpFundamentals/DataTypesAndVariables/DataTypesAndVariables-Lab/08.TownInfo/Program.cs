using System;

namespace _08.TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string townName = Console.ReadLine();
            decimal population = decimal.Parse(Console.ReadLine());
            double areaInKilometars = double.Parse(Console.ReadLine());

            Console.WriteLine($"Town {townName} has population of {population} and area {areaInKilometars} square km.");
        }
    }
}
