using System;

namespace _03.OscarsWeekInCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            string theaterType = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            double ticketPrice = 0;

            switch (movieName)
            {
                case "A Star Is Born":
                    switch (theaterType)
                    {
                        case "normal":
                            ticketPrice = 7.50;
                            break;
                        case "luxury":
                            ticketPrice = 10.50;
                            break;
                        case "ultra lucury":
                            ticketPrice = 13.50;
                            break;
                    }
                    break;
                case "Bohemian Rhapsody":
                    switch (theaterType)
                    {
                        case "normal":
                            ticketPrice = 7.35;
                            break;
                        case "luxury":
                            ticketPrice = 9.45;
                            break;
                        case "ultra luxury":
                            ticketPrice = 12.75;
                            break;
                    }
                    break;
                case "Green Book":
                    switch (theaterType)
                    {
                        case "normal":
                            ticketPrice = 8.15;
                            break;
                        case "luxury":
                            ticketPrice = 10.25;
                            break;
                        case "ultra luxury":
                            ticketPrice = 13.25;
                            break;
                    }
                    break;
                case "The Favourite":
                    switch (theaterType)
                    {
                        case "normal":
                            ticketPrice = 8.75;
                            break;
                        case "luxury":
                            ticketPrice = 11.55;
                            break;
                        case "ultra luxury":
                            ticketPrice = 13.95;
                            break;
                    }
                    break;
            }

            double income = Math.Abs(ticketPrice * numberOfTickets);

            Console.WriteLine($"{movieName} -> {income:f2} lv.");
        }
    }
}
