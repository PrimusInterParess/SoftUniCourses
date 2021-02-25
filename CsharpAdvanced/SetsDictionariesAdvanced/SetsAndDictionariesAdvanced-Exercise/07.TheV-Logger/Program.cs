using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggersDictionary =
                new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = string.Empty;



            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] data = input.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = data[1];
                string whoToAdd = data[0];


                switch (command)
                {
                    case "joined":
                        Joining(vloggersDictionary, whoToAdd);
                        break;
                    case "followed":
                        string whoIsFollowing = data[2];
                        Following(vloggersDictionary, whoToAdd, whoIsFollowing);
                        break;
                }

            }

            Console.WriteLine($"The V-Logger has a total of {vloggersDictionary.Count} vloggers in its logs.");

            int count = 1;

            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedDictionary = vloggersDictionary
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (KeyValuePair<string,Dictionary<string,SortedSet<string>>> pair in sortedDictionary)
            {
                Console.WriteLine($"{count}. {pair.Key} : {pair.Value["followers"].Count} followers, {pair.Value["following"].Count} following");

                if (count == 1)
                {
                    foreach (var followers in pair.Value["followers"])
                    {

                        Console.WriteLine($"*  {followers}");
                    }
                }
                count++;


            }


        }

        private static void Following(Dictionary<string, Dictionary<string, SortedSet<string>>> vloggersDictionary,
            string whoToAdd, string whoIsFollowing)
        {
            if (vloggersDictionary.ContainsKey(whoIsFollowing) && vloggersDictionary.ContainsKey(whoToAdd))
            {
                if (whoIsFollowing != whoToAdd)
                {
                    vloggersDictionary[whoIsFollowing]["followers"].Add(whoToAdd);



                    vloggersDictionary[whoToAdd]["following"].Add(whoIsFollowing);

                }

            }



        }

        private static void Joining(Dictionary<string, Dictionary<string, SortedSet<string>>> vloggersDictionary, string whoToAdd)
        {
            if (!vloggersDictionary.ContainsKey(whoToAdd))
            {
                vloggersDictionary.Add(whoToAdd, new Dictionary<string, SortedSet<string>>());
                vloggersDictionary[whoToAdd].Add("followers", new SortedSet<string>());
                vloggersDictionary[whoToAdd].Add("following", new SortedSet<string>());
            }



        }
    }
}
