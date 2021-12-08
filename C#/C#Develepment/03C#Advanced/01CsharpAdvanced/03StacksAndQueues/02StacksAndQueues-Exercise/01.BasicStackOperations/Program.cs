using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> intStack = new Stack<int>(numbers);

            int s = NSX[1];

            for (int i = 0; i < s; i++)
            {
                intStack.Pop();
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
