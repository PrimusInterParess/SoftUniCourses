using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            SortedSet<string> sorted = new SortedSet<string>();



            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] data = Console.ReadLine().Split();

                for (int j = 0; j < data.Length; j++)
                {
                    sorted.Add(data[j]);
                }
            }


            Console.WriteLine(string.Join(" ",sorted));
        }
    }
}
