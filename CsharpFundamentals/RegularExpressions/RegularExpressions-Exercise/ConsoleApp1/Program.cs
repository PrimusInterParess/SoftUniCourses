using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace _1._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex furniturePattern = new Regex(@">>(?<furniture>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)");


            string input = string.Empty;

            List<string> boughtFurnitures = new List<string>();

            double total = 0;


            while (((input = Console.ReadLine()) != "Purchase"))
            {
                Match furnitures = furniturePattern.Match(input);

                if (furnitures.Captures.Count == 0)
                {
                    continue;
                }

                boughtFurnitures.Add(furnitures.Groups["furniture"].Value);

                total += double.Parse(furnitures.Groups["price"].Value) * int.Parse(furnitures.Groups["quantity"].Value);
            }




            Console.WriteLine("Bought furniture:");
            foreach (var item in boughtFurnitures)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {total:F2}");

        }

    }
}
