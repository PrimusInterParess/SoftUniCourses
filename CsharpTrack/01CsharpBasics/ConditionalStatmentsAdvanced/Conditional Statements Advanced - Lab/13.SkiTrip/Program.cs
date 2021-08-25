using System;

namespace _13.SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int night = days - 1;

            string roomType = Console.ReadLine();
            string rating = Console.ReadLine();

            double pricePerNight = 0;

            if (roomType == "room for one person")
            {
                pricePerNight = 18;
            }
            else if (roomType == "apartment")
            {
                pricePerNight = 25;
            }
            else
            {
                pricePerNight = 35;
            }
            double discountPercentage = 0;

            if (roomType == "apartment")
            {
                if (days < 10)
                {
                    discountPercentage = 30;
                }
                if (days >= 10 && days <= 15)
                {
                    discountPercentage = 35;
                }
                else if (days > 15)
                {
                    discountPercentage = 50;
                }
            }
            else if (roomType == "president apartment")
            {
                if (days < 10)
                {
                    discountPercentage = 10;
                }
                if (days >= 10 && days <= 15)
                {
                    discountPercentage = 15;
                }
                else if (days > 15)
                {
                    discountPercentage = 20;
                }

            }
            double totalPrice = night * pricePerNight;
            if (discountPercentage != 0)
            {
                totalPrice = totalPrice * (100 - discountPercentage) / 100.0;

            }
            if (rating == "positive")
            {
                totalPrice = totalPrice * 1.25;

            }
            else
            {
                totalPrice = totalPrice * 0.90;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
