using System;

namespace _01.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int plasticCover = int.Parse(Console.ReadLine());
            int paintLitters = int.Parse(Console.ReadLine());
            int paintTinner = int.Parse(Console.ReadLine());
            int workingHours = int.Parse(Console.ReadLine());

            double paintCoverPrice = 1.50;
            double paintPrice = 14.50;
            double tinnerPrice = 5.00;
            double plasticBagPrice = 0.40;

            double materialsPrice = (paintCoverPrice * (plasticCover + 2)) + (paintPrice * (paintLitters * 1.10)) + (tinnerPrice * paintTinner) + plasticBagPrice;

            double totalPrice = materialsPrice + (((materialsPrice * 30) / 100) * workingHours);

            Console.WriteLine($"Total expenses: {totalPrice:f2} lv.");
        }
    }
}
