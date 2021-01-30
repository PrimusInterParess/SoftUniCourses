using System;

namespace _04.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double total = 0;
            bool noSeats = false;

            while (command != "Movie time!")
            {

                int numberOfPeople = int.Parse(command);

                capacity -= numberOfPeople;

                if (capacity < 0)
                {
                    noSeats = true;
                    break;
                }

                total += numberOfPeople * 5;


                if (numberOfPeople % 3 == 0)
                {
                    total -= 5;
                }

                command = Console.ReadLine();
            }
            if (noSeats)
            {
                Console.WriteLine("The cinema is full.");

            }
            else if (capacity == 0)
            {
                Console.WriteLine($"There are {capacity} seats left in the cinema.");
            }
            else
            {
                Console.WriteLine($"There are {capacity} seats left in the cinema.");
            }
            Console.WriteLine($"Cinema income - {total} lv.");
        }
    }
}
