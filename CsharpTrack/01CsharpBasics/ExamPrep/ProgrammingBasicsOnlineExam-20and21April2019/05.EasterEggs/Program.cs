using System;

namespace _05.EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEggs = int.Parse(Console.ReadLine());

            int maxEggs = 0;
            string favColor = string.Empty;

            int redCounter = 0;
            int orangeCounter = 0;
            int blueCounter = 0;
            int greenCounter = 0;

            for (int i = 0; i < numberOfEggs; i++)
            {
                string colors = Console.ReadLine();

                switch (colors)
                {
                    case "red":
                        redCounter++;
                        break;
                    case "orange":
                        orangeCounter++;
                        break;
                    case "blue":
                        blueCounter++;
                        break;
                    case "green":
                        greenCounter++;
                        break;
                }
            }

            if (redCounter > maxEggs)
            {
                maxEggs = redCounter;
                favColor = "red";
            }
            if (orangeCounter > maxEggs)
            {
                maxEggs = orangeCounter;
                favColor = "orange";
            }
            if (blueCounter > maxEggs)
            {
                maxEggs = blueCounter;
                favColor = "blue";
            }
            if (greenCounter > maxEggs)
            {
                maxEggs = greenCounter;
                favColor = "green";
            }

            Console.WriteLine($"Red eggs: {redCounter}");
            Console.WriteLine($"Orange eggs: {orangeCounter}");
            Console.WriteLine($"Blue eggs: {blueCounter}");
            Console.WriteLine($"Green eggs: {greenCounter}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {favColor}");
        }
    }
}
