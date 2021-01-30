using System;

namespace _02.Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            double checkPointMinutes = double.Parse(Console.ReadLine());
            double checkPointSeconds = double.Parse(Console.ReadLine());
            double leghtOfTrack = double.Parse(Console.ReadLine());
            double secondsForHundredMeters = double.Parse(Console.ReadLine());

            double checkPointInSeconds = checkPointMinutes * 60 + checkPointSeconds;
            double timeCut = leghtOfTrack / 120;
            double delay = timeCut * 2.5;
            double time = (leghtOfTrack / 100) * secondsForHundredMeters - delay;

            if (time <= checkPointInSeconds)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {time:F3}.");
            }
            else
            {
                double neededSeconds = Math.Abs(checkPointInSeconds - time);
                Console.WriteLine($"No, Marin failed! He was {neededSeconds:f3} second slower.");
            }
        }
    }
}
