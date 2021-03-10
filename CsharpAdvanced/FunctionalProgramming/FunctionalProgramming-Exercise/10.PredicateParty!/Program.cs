using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guestList = Console.ReadLine().Split().ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] cmdArgs = command
                    .Split(' ')
                    .ToArray();

                string cmdType = cmdArgs[0];
                string[] predicateArgs = cmdArgs
                    .Skip(1)
                    .ToArray();

                Predicate<string> predicate = GetPredicate(predicateArgs);

                if (cmdType == "Remove")
                {

                }
                else if (cmdType == "Double")
                {

                }
            }
        }

        static Predicate<string> GetPredicate(string[] predicateArgs)
        {
            string prType = predicateArgs[0];
            string prArg = predicateArgs[1];

            Predicate<string> predicate = null;

            if (prType == "StartsWith")
            {
                predicate = new Predicate<string>(name =>
                {
                    return name.StartsWith(prArg);
                });
            }
            else if (prType == "EndsWith")
            {
                predicate = new Predicate<string>(name =>
                {
                    return name.EndsWith(prArg);
                });
            }
            else if (prType == "Length")
            {
                predicate = new Predicate<string>(name =>
                {
                    return name.Length == int.Parse(prArg);
                });
            }

            return predicate;


        }
    }
}
