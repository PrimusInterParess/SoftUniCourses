using System;

namespace _07.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSec = double.Parse(Console.ReadLine());
            double lenghtInM = double.Parse(Console.ReadLine());
            double timeMeterPerSec = double.Parse(Console.ReadLine());

            double swimmingSecLength = lenghtInM * timeMeterPerSec;
            double delay = Math.Floor(lenghtInM / 15) * 12.5;
            double sumTime = swimmingSecLength + delay;



            if (sumTime < recordInSec)
            {

                Console.WriteLine($"Yes, he succeeded! The new world record is {sumTime:f2} seconds.");
            }


            else
            {
                double slower = sumTime - recordInSec;
                Console.WriteLine($"No, he failed! He was {slower:f2} seconds slower.");
            }
        }
    }
}
