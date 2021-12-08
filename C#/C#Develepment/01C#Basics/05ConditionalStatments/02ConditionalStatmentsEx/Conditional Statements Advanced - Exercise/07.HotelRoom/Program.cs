using System;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string mounth = Console.ReadLine();
            int numNights = int.Parse(Console.ReadLine());

            double apartment = 0.0;
            double studio = 0.0;

            if (mounth == "May" || mounth == "October")
            {
                studio = 50;
                apartment = 65;
                if (numNights < 7 && numNights <= 14)
                {
                    studio *= 0.95;
                }
                else if (numNights > 14)
                {
                    studio *= 0.70;
                    apartment *= 0.90;
                }

            }
            else if (mounth == "June" || mounth == "September")
            {
                studio = 75.20;
                apartment = 68.70;
                if (numNights > 14)
                {
                    studio *= 0.80;
                    apartment *= 0.90;
                }
            }
            else
            {
                studio = 76;
                apartment = 77;
                if (numNights > 14)
                {
                    apartment *= 0.90;
                }
            }
            double sumS = studio * numNights;
            double sumA = apartment * numNights;
            Console.WriteLine($"Apartment: {sumA:f2} lv.");
            Console.WriteLine($"Studio: {sumS:f2} lv.");
        }
    }
}
