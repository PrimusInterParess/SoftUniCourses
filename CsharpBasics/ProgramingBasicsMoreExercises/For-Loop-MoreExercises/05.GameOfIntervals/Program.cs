using System;

namespace _05.GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameLoops = int.Parse(Console.ReadLine());

            double p1Counter = 0;

            double p2Counter = 0;

            double p3Counter = 0;

            double p4Counter = 0;

            double p5Counter = 0;

            double sumPoints = 0;

            double ivalidNumbsCounter = 0;


            for (int i = 1; i <= gameLoops; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (number >= 0 && number < 10)
                {
                    p1Counter++;

                    sumPoints += number * 0.20;
                }
                if (number >= 10 && number < 20)
                {
                    p2Counter++;

                    sumPoints += number * 0.30;
                }
                if (number >= 20 && number < 30)
                {
                    p3Counter++;

                    sumPoints += number * 0.40;
                }
                if (number >= 30 && number < 40)
                {
                    p4Counter++;
                    sumPoints += 50;
                }
                if (number >= 40 && number <= 50)
                {
                    p5Counter++;
                    sumPoints += 100;
                }
                if (number < 0 || number > 50)
                {
                    ivalidNumbsCounter++;
                    sumPoints /= 2;

                }
            }

            double p1Percentage = (p1Counter / gameLoops) * 100;
            double p2Percentage = (p2Counter / gameLoops) * 100;
            double p3Percentage = (p3Counter / gameLoops) * 100;
            double p4Percentage = (p4Counter / gameLoops) * 100;
            double p5Percentage = (p5Counter / gameLoops) * 100;
            double invalidNumbersPercentage = (ivalidNumbsCounter / gameLoops) * 100;

            Console.WriteLine($"{sumPoints:f2}");
            Console.WriteLine($"From 0 to 9: {p1Percentage:f2}%");
            Console.WriteLine($"From 10 to 19: {p2Percentage:f2}%");
            Console.WriteLine($"From 20 to 29: {p3Percentage:f2}%");
            Console.WriteLine($"From 30 to 39: {p4Percentage:f2}%");
            Console.WriteLine($"From 40 to 50: {p5Percentage:f2}%");
            Console.WriteLine($"Invalid numbers: {invalidNumbersPercentage:f2}%");

        }
    }
}
