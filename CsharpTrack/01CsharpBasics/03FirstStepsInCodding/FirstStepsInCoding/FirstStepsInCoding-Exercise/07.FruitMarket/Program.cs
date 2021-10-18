using System;

namespace _07.FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberryPriceLV = double.Parse(Console.ReadLine());

            double amountBananasKG = double.Parse(Console.ReadLine());

            double amountOrangesKG = double.Parse(Console.ReadLine());

            double amountRaspberriesKG = double.Parse(Console.ReadLine());

            double amountStrawberiesKG = double.Parse(Console.ReadLine());

            double raspberiesPrice = strawberryPriceLV / 2;

            double orangesPrice = raspberiesPrice * 0.60;

            double bananaPrice = raspberiesPrice * 0.20;

            double sumRaspberies = raspberiesPrice * amountRaspberriesKG;

            double sumOranges = orangesPrice * amountOrangesKG;

            double sumBananas = bananaPrice * amountBananasKG;

            double sumStrawberries = strawberryPriceLV * amountStrawberiesKG;

            double total = sumRaspberies + sumOranges + sumBananas + sumStrawberries;


            Console.WriteLine(total);
        }
    }
}
