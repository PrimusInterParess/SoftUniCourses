using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            SortedDictionary<string, List<string>> idList = new SortedDictionary<string, List<string>>();

            while (!((input=Console.ReadLine())=="End"))
            {
                string[] data = input.Split(" -> ").ToArray();

                string companyName = data[0];

                string employeeID = data[1];

                if (idList.ContainsKey(companyName))
                {
                    if (!idList[companyName].Contains(employeeID))
                    {
                        idList[companyName].Add(employeeID);
                    }
                }
                else
                {
                    idList.Add(companyName, new List<string>());
                    idList[companyName].Add(employeeID);
                }
            }

            foreach (var item in idList)
            {
                Console.WriteLine($"{item.Key}");

                foreach (var value in item.Value)
                {
                    Console.WriteLine($"-- {value}");
                }
            }
        }
    }
}
