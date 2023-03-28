using System;

namespace _01.Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int dishSoapBottles = int.Parse(Console.ReadLine());


            double amountOfSoap = 0;
            double soapUsed = 0;
            int dishRounds = 0;
            double platesCount = 0;
            double potsCount = 0;
            bool notEnough = false;

            string command = Console.ReadLine();
            while (command != "End")
            {
                double dishes = double.Parse(command);

                dishRounds++;

                if (dishRounds % 3 == 0)
                {
                    potsCount += dishes;
                    soapUsed += dishes * 15;
                }
                else
                {
                    platesCount += dishes;
                    soapUsed += dishes * 5;
                }

                amountOfSoap = dishSoapBottles * 750;

                if (amountOfSoap <= soapUsed)
                {
                    notEnough = true;
                    break;
                }


                command = Console.ReadLine();
            }
            if (notEnough)
            {
                double more = soapUsed - amountOfSoap;
                Console.WriteLine($"Not enough detergent, {more} ml. more necessary!");
            }
            else
            {

                double left = amountOfSoap - soapUsed;
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{platesCount} dishes and {potsCount} pots were washed.");
                Console.WriteLine($"Leftover detergent {left} ml.");
            }
        }
    }
}
