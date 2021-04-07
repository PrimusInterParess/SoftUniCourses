using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, List<string>> usersData = new Dictionary<string, List<string>>();

            while (!((input = Console.ReadLine()) == "Lumpawaroo"))
            {
                string[] data = input.Split(new string[] { " -> ", " | " }, StringSplitOptions.RemoveEmptyEntries).ToArray();


                if (input.Contains("->"))
                {
                    AddUsersToTeams(data, usersData);

                }
                else if (input.Contains("|"))
                {
                    CreatesTeams(data, usersData);
                }

            }

            PrintOutput(usersData);


        }

        private static void PrintOutput(Dictionary<string, List<string>> usersData)
        {
            Dictionary<string, List<string>> sortedData = usersData
                                .Where(data => data.Value.Count > 0)
                                .OrderByDescending(u => u.Value.Count)
                                .ThenBy(d => d.Key)
                                .ToDictionary(a => a.Key, b => b.Value);

            foreach (var item in sortedData)
            {
                string team = item.Key;
                List<string> users = item.Value.OrderBy(u => u).ToList();

                Console.WriteLine($"Side: {team}, Members: {users.Count}");

                foreach (var user in users)
                {
                    Console.WriteLine($"! {user}");
                }

            }
        }

        private static void AddUsersToTeams(string[] input, Dictionary<string, List<string>> usersData)
        {

            string team = input[1];
            string name = input[0];

            foreach (var item in usersData)
            {
                if (item.Value.Contains(name))
                {
                    item.Value.Remove(name);
                }

                if (!usersData.ContainsKey(team))
                {
                    usersData.Add(team, new List<string>());
                    usersData[team].Add(name);
                }


            }

            usersData[team].Add(name);


            Console.WriteLine($"{name} joins the {team} side!");
        }

        private static void CreatesTeams(string[] input, Dictionary<string, List<string>> usersData)
        {


            string team = input[0];
            string name = input[1];

            if (!usersData.Keys.Contains(team))
            {
                usersData.Add(team, new List<string>());
                usersData[team].Add(name);
            }

            if (!usersData.Values.Any(l => l.Contains(name)))
            {
                usersData[team].Add(name);
            }
        }
    }

}
