using System;

namespace _03.FilmPremiere
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            string food = Console.ReadLine();
            int numberTickets = int.Parse(Console.ReadLine());
            double price = 0;

            switch (projection)
            {
                case "John Wick":
                    switch (food)
                    {
                        case "Drink":
                            price = 12;
                            break;
                        case "Popcorn":
                            price = 15;
                            break;
                        case "Menu":
                            price = 19;
                            break;

                    }
                    break;
                case "Star Wars":
                    switch (food)
                    {
                        case "Drink":
                            price = 18;
                            break;
                        case "Popcorn":
                            price = 25;
                            break;
                        case "Menu":
                            price = 30;
                            break;

                    }
                    break;
                case "Jumanji":
                    switch (food)
                    {
                        case "Drink":
                            price = 9;
                            break;
                        case "Popcorn":
                            price = 11;
                            break;
                        case "Menu":
                            price = 14;
                            break;

                    }
                    break;
            }

            double totalPrice = numberTickets * price;

            if (projection == "Star Wars" && numberTickets >= 4)
            {
                totalPrice *= 0.70;
            }

            if (projection == "Jumanji" && numberTickets == 2)
            {
                totalPrice *= 0.85;
            }

            Console.WriteLine($"Your bill is {totalPrice:F2} leva.");
        }
    }
}
