using System;

namespace _06.WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char last = char.Parse(Console.ReadLine());
            int rowsNumber = int.Parse(Console.ReadLine());
            int seatsOddNumber = int.Parse(Console.ReadLine());
            int seatCounter = 0;
            int factor = 0;

            for (char sector = 'A'; sector <= last; sector++, rowsNumber++)
            {
                for (int rows = 1; rows <= rowsNumber; rows++)
                {
                    if (rows % 2 == 0)
                    {
                        factor = 2;
                    }
                    else
                    {
                        factor = 0;
                    }

                    for (char letter = 'a'; letter < 'a' + seatsOddNumber + factor; letter++)
                    {

                        Console.WriteLine($"{sector}{rows}{letter}");
                        seatCounter++;

                    }
                }
            }
            Console.WriteLine(seatCounter);
        }
    }
}
