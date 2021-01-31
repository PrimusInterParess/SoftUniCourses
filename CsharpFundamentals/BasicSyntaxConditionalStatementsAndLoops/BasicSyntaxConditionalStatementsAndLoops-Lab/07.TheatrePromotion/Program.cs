using System;

namespace _07.TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            var price = 0;

            if (day == "weekday")
            {
                if (age <= 18 && age >= 0 || age <= 122 && age > 64)
                {
                    price = 12;
                }
                else if (age <= 64 && age > 18)
                {
                    price = 18;
                }

            }
            else if (day == "weekend")
            {
                if (age <= 18 && age >= 0 || age <= 122 && age > 64)
                {
                    price = 15;
                }
                else if (age <= 64 && age > 18)
                {
                    price = 20;
                }
            }
            else if (day == "holiday")
            {
                if (age <= 18 && age >= 0)
                {
                    price = 5;
                }
                else if (age <= 122 && age > 64)
                {
                    price = 10;
                }
                else if (age <= 64 && age > 18)
                {
                    price = 12;
                }
            }

            if (price > 0)
            {
                Console.WriteLine($"{price}$");
            }

            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
