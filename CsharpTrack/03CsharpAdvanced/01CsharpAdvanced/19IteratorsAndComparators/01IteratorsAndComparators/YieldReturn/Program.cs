using System;
using System.Collections.Generic;

namespace YieldReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var name in GetNames())
            {
                Console.WriteLine(name);
            }
        }

        public static IEnumerable<string> GetNames()
        {
            yield return "Goshka";
            yield return "Mosto";
            yield return "Proshka";
            yield return "Podlojka";

           

        }
    }
}
