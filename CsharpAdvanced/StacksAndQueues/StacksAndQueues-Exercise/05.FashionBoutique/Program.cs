using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> clothesStack = new Stack<int>(clothes);

            int sum = 0;

            int rackCount = 0;

            while (clothesStack.Count != 0)
            {
                rackCount++;

                if (sum + clothesStack.Peek() <= rackCapacity)
                {
                    sum += clothesStack.Pop();

                    if (clothesStack.Count != 0)
                    {
                        rackCount--;

                    }
                }
                else
                {
                    sum = 0;
                }

            }

            Console.WriteLine(rackCount);
        }
    }
}
