using System;

namespace _06.HighJump
{
    class Program
    {
        static void Main(string[] args)
        {
            double goalHight = double.Parse(Console.ReadLine());
            double startPoint = goalHight - 30;
            int failedCounter = 0;

            int jumpsCounter = 0;
            double lastJump = 0;

            while (true)
            {
                jumpsCounter++;

                double tries = double.Parse(Console.ReadLine());
                lastJump = startPoint;


                if (tries > startPoint)
                {
                    failedCounter = 0;

                    if (startPoint >= goalHight)
                    {
                        Console.WriteLine($"Tihomir succeeded, he jumped over {goalHight}cm after {jumpsCounter} jumps.");
                        break;

                    }
                    else
                    {
                        startPoint += 5;
                        continue;

                    }
                }


                else
                {
                    failedCounter++;

                    if (failedCounter == 3)
                    {
                        Console.WriteLine($"Tihomir failed at {lastJump}cm after {jumpsCounter} jumps.");
                        break;
                    }

                }


            }

        }
    }
}
