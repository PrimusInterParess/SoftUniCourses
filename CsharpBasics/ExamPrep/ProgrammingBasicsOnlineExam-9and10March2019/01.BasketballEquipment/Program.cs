using System;

namespace _01.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double anualTax = double.Parse(Console.ReadLine());

            double Sneakers = anualTax * 0.60;
            double outfit = Sneakers * 0.80;
            double basketball = outfit / 4;
            double accsessories = basketball / 5;

            double totalPrice = Sneakers + anualTax + outfit + basketball + accsessories;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
