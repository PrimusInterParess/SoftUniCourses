using System;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowBalls = int.Parse(Console.ReadLine());

            BigInteger mostValuableSnowBall = 0;
            int snowBallWinner = 0;
            int timeWinner = 0;
            int snowBallQualityWinner = 0;



            for (int i = 0; i < numberOfSnowBalls; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                int snowBallResult = snowballSnow / snowballTime;

                BigInteger snowBallValue = BigInteger.Pow(snowBallResult, snowballQuality);

                if (mostValuableSnowBall < snowBallValue)
                {
                    snowBallWinner = snowballSnow;
                    timeWinner = snowballTime;
                    mostValuableSnowBall = snowBallValue;
                    snowBallQualityWinner = snowballQuality;
                }
            }
            Console.WriteLine($"{snowBallWinner} : {timeWinner} = {mostValuableSnowBall} ({snowBallQualityWinner})");
        }
    }
}
