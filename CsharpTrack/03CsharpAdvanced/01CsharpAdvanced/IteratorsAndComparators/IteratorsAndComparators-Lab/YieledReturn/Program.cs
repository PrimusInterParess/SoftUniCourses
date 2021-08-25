using System;
using System.Collections.Generic;

namespace YieledReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var name in GetNames() )
            {
                
            }
        }

        public static IEnumerable<string> GetNames()
        {
            yield return "Goshka";
            yield return "Peshka";
            yield return "Sled Peshka sum";
            yield return "Dimitrichka";
        }
    }

}
