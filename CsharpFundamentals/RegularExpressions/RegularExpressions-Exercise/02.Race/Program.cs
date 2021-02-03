using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePattern = "[A-Za-z]";
            string digitPattern = @"\d";

            string[] participants = Console.ReadLine().Split(", ");

            string input = string.Empty;

            Dictionary<string, int> raceDictionary = new Dictionary<string, int>();

            while (((input = Console.ReadLine()) != "end of race"))
            {
                MatchCollection nameCollection = Regex.Matches(input, namePattern);
                MatchCollection digitCollection = Regex.Matches(input, digitPattern);

                string name = String.Concat(nameCollection);
                int sum = digitCollection.Select(x => int.Parse(x.Value)).Sum();

                if (participants.Contains(name))
                {
                    if (raceDictionary.ContainsKey((name)))
                    {
                        raceDictionary[name] += sum;
                    }
                    else
                    {
                        raceDictionary.Add(name, sum);

                    }

                }
            }

            var sortedDictionary = raceDictionary.OrderByDescending(x => x.Value).Select(x=>x.Key).Take(3).ToList();

            Console.WriteLine($"1st place {sortedDictionary[0]}");
            Console.WriteLine($"2nd place {sortedDictionary[1]}");
            Console.WriteLine($"3rd place {sortedDictionary[2]}");
        }
    }
}
