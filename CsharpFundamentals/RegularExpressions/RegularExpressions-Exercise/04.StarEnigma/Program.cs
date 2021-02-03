using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string starPattern = @"[starSTAR]";
            Regex starRegex = new Regex(starPattern);

            string planetPattern =
                @"[^@!:>-]*?@[^@!:>-]*?(?<planetName>[A-Z][a-z]+)[^@!:>-]*?:[^@!:>-]*?(?<planetPopulation>\d+)[^@!:>-]*?!(?<action>[AD])[^@!:>-]*?!->[^@!:>-]*?(?<solders>\d+)[^@!:>-]*?";
            Regex planetRegex = new Regex(planetPattern);

            int numberOfMasseges = int.Parse(Console.ReadLine());

            

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < numberOfMasseges; i++)
            {
                string massege = Console.ReadLine();

                MatchCollection encryptedCollection = starRegex.Matches(massege);

                int code = encryptedCollection.Count;

                string decrypted = string.Empty;

                for (int j = 0; j < massege.Length; j++)
                {
                    decrypted += (char)(massege[j] - code);

                }

                Match dataCollection = planetRegex.Match(decrypted);

                if (dataCollection.Success)
                {
                    if (dataCollection.Groups["action"].Value == "A")
                    {
                        
                        attackedPlanets.Add(dataCollection
                            .Groups["planetName"]
                            .Value);
                    }
                    else
                    {
                        
                        destroyedPlanets.Add(dataCollection.Groups["planetName"].Value);

                    }
                }


            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var VARIABLE in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {VARIABLE}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            {
                foreach (var VARIABLE in destroyedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {VARIABLE}");
                }

            }

        }
    }
}