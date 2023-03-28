using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensorOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boundsArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Predicate<int> predicate = command switch
            {

                "odd" => n => n % 2 != 0,
                "even" => n => n % 2 == 0

            };

            List<int> numbs = new List<int>();

            for (int i = boundsArray[0]; i <= boundsArray[1]; i++)
            {
                if (predicate(i))
                {
                    numbs.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbs));
        }

        static Predicate<int> GetPredicate(string query)
        {
            if (query == "odd")
            {
                return new Predicate<int>(n => n % 2 == 0);
            }
            else
            {
                return new Predicate<int>(n => n % 2 == 1);
            }
        }
    }
}
