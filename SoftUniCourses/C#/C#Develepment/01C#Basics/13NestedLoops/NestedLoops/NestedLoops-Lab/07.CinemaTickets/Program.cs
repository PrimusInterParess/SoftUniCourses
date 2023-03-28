using System;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentTicketsCounter = 0;
            int standardTicketsCounter = 0;
            int kidTicketsCounter = 0;

            while (true)
            {
                string movieName = Console.ReadLine();

                if (movieName == "Finish")
                {
                    break;
                }

                int freeSeats = int.Parse(Console.ReadLine());
                int ticketCounter = 0;

                while (true)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }

                    ticketCounter++;

                    if (ticketType == "student")
                    {
                        studentTicketsCounter++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardTicketsCounter++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidTicketsCounter++;
                    }

                    if (ticketCounter == freeSeats)
                    {
                        break;
                    }

                }
                double teatherCapacityPercentage = (ticketCounter * 1.0 / freeSeats) * 100;
                Console.WriteLine($"{movieName} - {teatherCapacityPercentage:f2}% full.");
            }

            int totalTickets = studentTicketsCounter + standardTicketsCounter + kidTicketsCounter;
            double studentTicketsPercentage = (studentTicketsCounter * 1.0 / totalTickets) * 100;
            double standardTicketsPercentage = (standardTicketsCounter * 1.0 / totalTickets) * 100;
            double kidTicketsPercentage = (kidTicketsCounter * 1.0 / totalTickets) * 100;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentTicketsPercentage:f2}% student tickets.");
            Console.WriteLine($"{standardTicketsPercentage:f2}% standard tickets.");
            Console.WriteLine($"{kidTicketsPercentage:f2}% kids tickets.");
        }
    }
}
