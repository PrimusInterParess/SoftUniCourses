using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> mariasShop = new Dictionary<string, Dictionary<string, double>>();

            string input = String.Empty;

            mariasShop.Add("buyer", new Dictionary<string, double>());

            mariasShop.Add("deliver", new Dictionary<string, double>());

            double total = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Deliver")
                {
                    if (!mariasShop["deliver"].ContainsKey(command[1]))
                    {
                        mariasShop["deliver"].Add(command[1], double.Parse(command[2]));
                    }
                    else
                    {
                        mariasShop["deliver"][command[1]] += double.Parse(command[2]);
                    }
                }

                if (command[0] == "Return")
                {
                    if (mariasShop["deliver"].ContainsKey(command[1]))
                    {
                        if (mariasShop["deliver"][command[1]] >= double.Parse(command[2]))
                        {
                            mariasShop["deliver"][command[1]] -= double.Parse(command[2]);

                            if (mariasShop["deliver"][command[1]] == 0)
                            {
                                mariasShop["deliver"].Remove(command[1]);
                            }
                        }
                    }
                }

                if (command[0] == "Sell")
                {
                    if (!mariasShop["buyer"].ContainsKey(command[1]))
                    {

                        mariasShop["buyer"].Add(command[1], double.Parse(command[2]));
                        total += double.Parse(command[2]);
                    }
                    else
                    {
                        mariasShop["buyer"][command[1]] += double.Parse(command[2]);

                        total += double.Parse(command[2]);

                    }
                }


            }

            var clients = mariasShop["buyer"]
                .OrderBy(c => c.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            var vendors = mariasShop["deliver"].OrderBy(d => d.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            foreach (var pair in clients)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value:F2}");
            }

            Console.WriteLine("-----------");

            foreach (var vendor in vendors)
            {
                Console.WriteLine($"{vendor.Key}: {vendor.Value:F2}");
            }

            Console.WriteLine("-----------");


            Console.WriteLine($"Total Income: {total:f2}");


        }

    }
}
