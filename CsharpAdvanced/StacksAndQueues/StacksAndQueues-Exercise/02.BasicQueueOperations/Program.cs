using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> intStack = new Queue<int>(numbers);

            int s = NSX[1];

            for (int i = 0; i < s; i++)
            {
                intStack.Dequeue();
            }

            if (intStack.Contains(NSX[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(intStack.Count != 0 ? intStack.Min() : 0);
            }
        }
    }
}
