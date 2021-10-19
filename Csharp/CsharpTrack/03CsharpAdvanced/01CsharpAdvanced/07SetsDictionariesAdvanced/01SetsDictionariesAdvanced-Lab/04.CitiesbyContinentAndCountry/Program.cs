using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CitiesbyContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCountries = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentDictionary =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numberOfCountries; i++)
            {
                string[] data = Console.ReadLine().Split();

                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (!continentDictionary.ContainsKey(continent))
                {
                    continentDictionary.Add(continent,new Dictionary<string, List<string>>());
                }

                if (!continentDictionary[continent].ContainsKey(country))
                {
                    continentDictionary[continent].Add(country,new List<string>());
                }

                continentDictionary[continent][country].Add(city);
            }
            foreach (var continent in continentDictionary)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.Write($"    {country.Key} -> ");

                    for (int i = 0; i < country.Value.Count; i++)
                    {
                        if (i != 0)
                        {
                            Console.Write(", ");
                        }

                        Console.Write($"{country.Value[i]}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
