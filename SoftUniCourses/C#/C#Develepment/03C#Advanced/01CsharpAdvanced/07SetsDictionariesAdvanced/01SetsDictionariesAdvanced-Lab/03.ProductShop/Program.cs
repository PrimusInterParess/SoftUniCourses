using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, Dictionary<string, double>> shopsDictionary =
                new Dictionary<string, Dictionary<string, double>>();

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] data = input.Split(", ");

                string shopName = data[0];
                string productName = data[1];
                double price = double.Parse(data[2]);

                if (!shopsDictionary.ContainsKey(shopName))
                {
                    shopsDictionary.Add(shopName, new Dictionary<string, double>());
                }

                if (!shopsDictionary[shopName].ContainsKey(productName))
                {
                    shopsDictionary[shopName].Add(productName,price);
                }
            }

            shopsDictionary = shopsDictionary.OrderBy(x => x.Key)
                .ToDictionary(x=>x.Key,v=>v.Value);

            foreach (var pair in shopsDictionary)
            {
                Console.WriteLine($"{pair.Key}->");

                foreach (var prod in pair.Value)
                {
                    Console.WriteLine($"Product: {prod.Key}, Price: {prod.Value}");
                }
            }
        }
    }
}
