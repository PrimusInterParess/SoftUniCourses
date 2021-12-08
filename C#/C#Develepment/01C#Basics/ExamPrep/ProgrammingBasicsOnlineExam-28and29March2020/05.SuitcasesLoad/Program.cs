using System;

namespace _05.SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double luggageCompartment = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double suitcases = 0;
            double luggageVolume = 0;

            double counterLuggage = 0;

            while (command != "End")
            {
                suitcases = double.Parse(command);
                counterLuggage++;

                if (counterLuggage % 3 == 0)
                {
                    suitcases *= 1.10;
                }

                luggageCompartment -= suitcases;

                if (luggageCompartment <= 0)
                {
                    counterLuggage--;

                    Console.WriteLine("No more space!");
                    break;
                }
                command = Console.ReadLine();
            }
            if (command == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");

            }

            Console.WriteLine($"Statistic: {counterLuggage} suitcases loaded.");
        }
    }
}
