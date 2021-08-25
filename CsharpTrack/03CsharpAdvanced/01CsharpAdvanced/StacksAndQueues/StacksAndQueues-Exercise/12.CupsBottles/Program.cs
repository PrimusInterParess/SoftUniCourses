using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsBottles
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] bottlesVolume = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> bottleStack = new Stack<int>(bottlesVolume);

            Queue<int> cupQueue = new Queue<int>(cupsCapacity);

            int wastedWater = 0;

            int bottleCounter = 0;

            int cupCounter = 0;

            while (cupQueue.Count != 0)
            {

                if (bottleStack.Count == 0)
                {
                    break;
                }
                int currentBottle = bottleStack.Pop();

                bottleCounter++;

                int currentCup = cupQueue.Dequeue();

                cupCounter++;

                if (currentCup > currentBottle)
                {
                    while (currentCup > 0)
                    {
                        currentCup -= currentBottle;

                        if (currentCup > 0)
                        {
                            currentBottle = bottleStack.Pop();

                            bottleCounter++;
                        }

                        if (currentCup < 0)
                        {
                            wastedWater += Math.Abs(currentCup);

                        }
                    }
                }
                else
                {
                    wastedWater += currentBottle -= currentCup;
                }

            }

            //  If you have managed to fill up all of the cups, print the remaining water bottles,
            // from the last entered – to the first,
            // otherwise you must print the remaining cups, by order of entrance – from the first entered – to the last.

            if (cupQueue.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottleStack)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupQueue)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");

            }

        }
    }
}
