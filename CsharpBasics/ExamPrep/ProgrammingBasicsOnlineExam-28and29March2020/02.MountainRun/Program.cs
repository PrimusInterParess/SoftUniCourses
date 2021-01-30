using System;

namespace _02.MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double lenghtInMeters = double.Parse(Console.ReadLine());
            double secondsForOneMeter = double.Parse(Console.ReadLine());

            double secsClimbing = lenghtInMeters * secondsForOneMeter;
            double delay = Math.Floor(lenghtInMeters / 50) * 30;
            double totalSeconds = secsClimbing + delay;


            if (totalSeconds >= recordInSeconds)
            {
                double slower = totalSeconds - recordInSeconds;

                Console.WriteLine($"No! He was {slower:f2} seconds slower.");

            }
            else
            {

                Console.WriteLine($" Yes! The new record is {totalSeconds:f2} seconds.");

            }
        }
    }
}
