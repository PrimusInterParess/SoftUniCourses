using System;
using System.Collections;
using System.Collections.Generic;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] childern = Console.ReadLine().Split();

            int n = int.Parse(Console.ReadLine());

            Queue<string> potatoQueue = new Queue<string>(childern);

            int potatoTosses = 0;

            while (potatoQueue.Count > 1)
            {
                potatoTosses++;
                string kid = potatoQueue.Dequeue();

                if (potatoTosses == n)
                {
                    potatoTosses = 0;
                    Console.WriteLine("Removed " + kid);
                }
                else
                {
                    potatoQueue.Enqueue(kid);

                }
            }

            Console.WriteLine("Last is "+ potatoQueue.Dequeue());
        }
    }
}
