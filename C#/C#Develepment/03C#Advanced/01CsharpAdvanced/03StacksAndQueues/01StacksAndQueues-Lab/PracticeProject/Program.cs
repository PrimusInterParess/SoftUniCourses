using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = string.Empty;

            Queue<string> carsQueue = new Queue<string>();

            int passed = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                string car = input;

                if (car == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (carsQueue.Count != 0)
                        {
                            Console.WriteLine(carsQueue.Dequeue() + " passed!");
                            passed++;
                        }

                    }
                }

                else
                {
                    carsQueue.Enqueue(car);
                }

            }

            Console.WriteLine(passed + " cars passed the crossroads.");
        }
    }
}
