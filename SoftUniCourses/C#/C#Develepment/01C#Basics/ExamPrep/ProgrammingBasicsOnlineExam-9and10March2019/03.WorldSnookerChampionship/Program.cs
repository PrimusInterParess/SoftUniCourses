using System;

namespace _03.WorldSnookerChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            string leagueStage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            string pictureWithTrophy = Console.ReadLine();
            double ticketPrice = 0;



            switch (leagueStage)
            {
                case "Quarter final":
                    switch (ticketType)
                    {
                        case "Standard":
                            ticketPrice = 55.50;
                            break;
                        case "Premium":
                            ticketPrice = 105.20;
                            break;
                        case "VIP":
                            ticketPrice = 118.90;
                            break;

                    }
                    break;


                case "Semi final":
                    switch (ticketType)
                    {
                        case "Standard":
                            ticketPrice = 75.88;
                            break;
                        case "Premium":
                            ticketPrice = 125.22;
                            break;
                        case "VIP":
                            ticketPrice = 300.40;
                            break;
                    }
                    break;

                case "Final":
                    switch (ticketType)
                    {
                        case "Standard":
                            ticketPrice = 110.10;
                            break;
                        case "Premium":
                            ticketPrice = 160.66;
                            break;
                        case "VIP":
                            ticketPrice = 400;
                            break;
                    }
                    break;
            }

            double sum = ticketPrice * numberOfTickets;
            double pictureTotal = numberOfTickets * 40;

            if (sum > 4000)
            {
                sum *= 0.75;

            }
            else if (sum > 2500)
            {
                sum *= 0.90;
                if (pictureWithTrophy == "Y")
                {
                    sum += pictureTotal;
                }
            }
            else if (pictureWithTrophy == "Y")
            {
                sum += pictureTotal;
            }

            Console.WriteLine($"{sum:f2}");

        }
    }
}
