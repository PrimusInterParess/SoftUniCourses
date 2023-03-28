using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> citiesToPlunder =
                new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;

            while ((input =Console.ReadLine()) != "Sail")
            {
                string[] data = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string city = data[0];

                int populationNumber = int.Parse(data[1]);

                int availableGold = int.Parse(data[2]);

                if (!citiesToPlunder.ContainsKey(data[0]))
                {
                    citiesToPlunder.Add(city, new Dictionary<string, int>());
                    citiesToPlunder[city].Add("population", populationNumber);
                    citiesToPlunder[city].Add("gold", availableGold);
                }
                else
                {
                    citiesToPlunder[city]["population"] += populationNumber;
                    citiesToPlunder[city]["gold"] += availableGold;
                }

            }

            string nextIput = string.Empty;

            while ((nextIput = Console.ReadLine()) != "End")
            {
                string[] actions = nextIput
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = actions[0];

                string town = actions[1];

                switch (command)
                {
                    case "Plunder":
                        int gold = int.Parse(actions[3]);
                        int peopleKilled = int.Parse(actions[2]);

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {peopleKilled} citizens killed.");
                        citiesToPlunder[town]["population"] -= peopleKilled;
                        citiesToPlunder[town]["gold"] -= gold;

                        if (citiesToPlunder[town]["population"] <= 0 || citiesToPlunder[town]["gold"] <= 0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");

                            citiesToPlunder.Remove(town);
                        }
                        break;

                    case "Prosper":
                        int prosperosGold = int.Parse(actions[2]);

                        if (prosperosGold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            break;
                        }

                        citiesToPlunder[town]["gold"] += prosperosGold;

                        Console.WriteLine($"{prosperosGold} gold added to the city treasury. {town} now has {citiesToPlunder[town]["gold"]} gold.");

                        break;
                }
            }

            Console.WriteLine($"Ahoy, Captain! There are {citiesToPlunder.Count} wealthy settlements to go to:");

            foreach (var pair in citiesToPlunder
                .OrderByDescending(x=>x.Value["gold"])
                .ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{pair.Key} -> Population: {pair.Value["population"]} citizens, Gold: {pair.Value["gold"]} kg");
            }
        }
    }
}
