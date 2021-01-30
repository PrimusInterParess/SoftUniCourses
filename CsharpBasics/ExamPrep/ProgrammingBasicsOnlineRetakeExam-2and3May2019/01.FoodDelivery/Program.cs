using System;

namespace _01.FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberChickenMenus = int.Parse(Console.ReadLine());
            int numberFishMenus = int.Parse(Console.ReadLine());
            int numberVegetarianMenus = int.Parse(Console.ReadLine());

            double totalChikenMenus = numberChickenMenus * 10.35;
            double totalFishMenus = numberFishMenus * 12.40;
            double totalVegetarianMenus = numberVegetarianMenus * 8.15;
            double sumMenus = totalChikenMenus + totalFishMenus + totalVegetarianMenus;
            double dessert = sumMenus * 0.20;
            double total = sumMenus + dessert + 2.5;

            Console.WriteLine($"Total: {total:F2}");
        }
    }
}
