using System;
using System.Collections.Generic;

namespace yieledR
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var name in GetNames())
            {
                Console.WriteLine(name);

                Console.WriteLine("in the foreach");
            }
        }

        public static IEnumerable<string> GetNames()
        {
            yield return "Goshi";
            yield return "Tosho";
            yield return "Mosho";

            Console.WriteLine("");

            yield return "Dimitrichka";


        }
    }
}
