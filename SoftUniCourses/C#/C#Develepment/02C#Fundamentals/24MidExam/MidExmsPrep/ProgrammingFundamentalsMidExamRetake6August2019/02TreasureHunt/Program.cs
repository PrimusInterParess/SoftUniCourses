using System;
using System.Collections.Generic;
using System.Linq;

namespace _02TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                string[] command = input.Split();

                string action = command[0];

                switch (action)
                {
                    case "Loot":
                        string[] loot = command.Skip(1).ToArray();
                        for (int i = 0; i < loot.Length; i++)
                        {
                            if (!data.Contains(loot[i]))
                            {
                                data.Insert(0, loot[i]);
                            }
                        }
                        break;
                    case "Drop":
                        int index = int.Parse(command[1]);

                        if (!(index < 0 || index > data.Count)) //?
                        {
                            string toPick = data[index];

                            data.RemoveAt(index);

                            data.Add(toPick);
                        }
                        break;

                    case "Steal":
                        int count = int.Parse(command[1]);

                        if (count > data.Count)
                        {
                            List<string> stolen = data.ToList();

                            Console.WriteLine(string.Join(", ", stolen));

                            data.Clear();
                        }
                        else
                        {
                            List<string> stolen = data.GetRange(data.Count - count, count);
                            data.RemoveRange(data.Count - count, count);
                            Console.WriteLine(string.Join(", ", stolen));
                        }
                        break;
                }


            }

            


            

            if (data.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double sum = 0;

                for (int i = 0; i < data.Count; i++)
                {
                    sum += data[i].Length;
                }

                double total = sum / data.Count;

                Console.WriteLine($"Average treasure gain: {total:f2} pirate credits.");
            }
        }
    }
}
