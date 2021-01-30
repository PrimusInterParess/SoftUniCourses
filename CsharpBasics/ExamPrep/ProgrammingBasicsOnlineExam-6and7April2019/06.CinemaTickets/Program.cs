using System;

namespace _06.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentTicketCounter = 0;
            int standardTicketCounter = 0;
            int kidsTicketCounter = 0;
            int totalTickets = 0;

            while (true)
            {
                string movieName = Console.ReadLine();

                if (movieName == "Finish")
                {
                    break;
                }

                int freeSeats = int.Parse(Console.ReadLine());
                double ticketCounter = 0;

                while (true)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }

                    switch (ticketType)
                    {
                        case "student":
                            studentTicketCounter++;
                            break;
                        case "standard":
                            standardTicketCounter++;
                            break;
                        case "kid":
                            kidsTicketCounter++;
                            break;
                    }

                    ticketCounter++;
                    totalTickets++;

                    if (ticketCounter == freeSeats)
                    {
                        break;
                    }
                }

                double projectionCapacity = ((ticketCounter * 1.0) / freeSeats) * 100;
                Console.WriteLine($"{movieName} - {projectionCapacity:f2}% full.");
            }

            double studentOccupied = ((studentTicketCounter * 1.0) / totalTickets) * 100;
            double standardOccupied = ((standardTicketCounter * 1.0) / totalTickets) * 100;
            double kidsOccupied = ((kidsTicketCounter * 1.0) / totalTickets) * 100;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentOccupied:f2}% student tickets.");
            Console.WriteLine($"{standardOccupied:f2}% standard tickets.");
            Console.WriteLine($"{kidsOccupied:F2}% kids tickets.");

        }
    }
}
