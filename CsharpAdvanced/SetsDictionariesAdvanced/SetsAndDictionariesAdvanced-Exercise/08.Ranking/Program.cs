using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestDictionary = new Dictionary<string, string>();

            Dictionary<string, Dictionary<string, int>> userData = new Dictionary<string, Dictionary<string, int>>();

            ContestLoading(contestDictionary);

            string input = String.Empty;

            bool isValid = true;

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] data = input.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                isValid = ChecksIfContestIsValid(contestDictionary, data);

                if (isValid)
                {
                    AddDataToUserData(data, userData);
                }

            }

            KeyValuePair<string, Dictionary<string, int>> first = userData.OrderByDescending(x => x.Value.Values.Sum())
                .First();

            Console.WriteLine($"Best candidate is {first.Key} with total {first.Value.Values.Sum()} points.");

            Console.WriteLine("Ranking");

        }

        private static void AddDataToUserData(string[] data, Dictionary<string, Dictionary<string, int>> userData)
        {
            string contest = data[0];
            string password = data[1];
            string userName = data[2];
            int points = int.Parse(data[3]);

            if (!userData.ContainsKey(userName))
            {
                userData.Add(userName, new Dictionary<string, int>());
                userData[userName].Add(contest, 0);
            }
            else
            {
                if (!userData[userName].ContainsKey(contest))
                {
                    userData[userName].Add(contest, 0);

                }

            }

            if (userData[userName].ContainsKey(contest) && userData[userName][contest] < points)
            {
                userData[userName][contest] = points;
            }
        }

        private static bool ChecksIfContestIsValid(Dictionary<string, string> contestDictionary, string[] data)
        {

            string contest = data[0];
            string password = data[1];

            if (contestDictionary.ContainsKey(contest) && contestDictionary[contest] == password)
            {
                return true;

            }

            return false;


        }

        private static void ContestLoading(Dictionary<string, string> contestDictionary)
        {

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestData = input.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string password = contestData[1];
                string contestName = contestData[0];

                contestDictionary.Add(contestName, password); //?

            }
        }
    }
}
