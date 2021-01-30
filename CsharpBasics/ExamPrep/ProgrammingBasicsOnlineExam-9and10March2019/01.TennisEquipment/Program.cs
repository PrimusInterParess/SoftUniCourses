using System;

namespace _01.TennisEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double price = double.Parse(Console.ReadLine());
            double numberOfRockets = double.Parse(Console.ReadLine());
            double numberOfSnickers = double.Parse(Console.ReadLine());

            double rocketPrice = price * numberOfRockets;
            double snickersPrice = (price / 6) * numberOfSnickers;
            double otherEquipmentPrice = (rocketPrice + snickersPrice) * 0.2;
            double totalPrice = rocketPrice + snickersPrice + otherEquipmentPrice;
            double JokoToPay = totalPrice / 8;
            double sponsorsToPay = totalPrice * 7 / 8;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(JokoToPay)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsorsToPay)}");
        }
    }
}
