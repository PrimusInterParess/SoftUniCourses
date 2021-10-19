using System;
using System.Linq;

namespace _02.KnightsHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split().ToArray();

            Action<string> honor = name => { Console.WriteLine($"Sir {name}"); };


            Console.ReadLine().Split().ToList().ForEach(honor);

        }
    }
}
