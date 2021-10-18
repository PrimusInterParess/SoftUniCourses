using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfClothes = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wordrobe = new Dictionary<string, Dictionary<string, int>>();

          

           

            for (int i = 0; i < numberOfClothes; i++)
            {
                string[] data = Console.ReadLine().Split(new String[]{" -> ",","},StringSplitOptions.RemoveEmptyEntries);

                string color = data[0];

                var clothes = string.Join(",", data).Substring(color.Length+1).Split(",").ToArray();


                if (!wordrobe.ContainsKey(color))
                {
                    wordrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var cloth in clothes)
                {
                    string cl = cloth;

                    if (!wordrobe[color].ContainsKey(cl))
                    {
                        wordrobe[color].Add(cl, 0);

                    }

                    wordrobe[color][cl]++;
                }

            }

            string[] find = Console.ReadLine().Split();

            string colorr = find[0];
            string clot = find[1];

            foreach (var pair in wordrobe)
            {
                Console.WriteLine($"{pair.Key} clothes:");

                if (pair.Key == colorr)
                {
                    foreach (var pairr in pair.Value)
                    {
                        if (pairr.Key == clot)
                        {
                            Console.WriteLine($"* {pairr.Key} - {pairr.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {pairr.Key} - {pairr.Value}");
                        }
                    }
                }
                else
                {
                    foreach (var pairr in pair.Value)
                    {


                        Console.WriteLine($"* {pairr.Key} - {pairr.Value}");

                    }
                }
            }
        }
    }
}
