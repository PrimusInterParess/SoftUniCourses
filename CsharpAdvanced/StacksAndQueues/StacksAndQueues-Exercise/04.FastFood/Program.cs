using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ordersQueue = new Queue<int>(orders);

            if (ordersQueue.Count != 0)
            {

                Console.WriteLine(ordersQueue.Max());

            }

            while (true)
            {

                if (quantityFood >= ordersQueue.Peek())
                {
                    quantityFood -= ordersQueue.Dequeue();

                    if (quantityFood == 0 || ordersQueue.Count == 0)
                    {
                        Console.WriteLine("Orders complete");
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("Orders left: " + string.Join(" ", ordersQueue));
                    break;
                }


            }

        }
    }
}
