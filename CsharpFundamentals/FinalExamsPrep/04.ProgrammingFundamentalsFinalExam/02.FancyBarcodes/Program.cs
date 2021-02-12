using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@#+(?<product>[A-Za-z0-9]*[A-Z])@#+";

            int n = int.Parse(Console.ReadLine());

            Regex barcodeRegex = new Regex(pattern);

            Regex digits = new Regex(@"(?<digits>[0-9+])");

            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();

                Match match = barcodeRegex.Match(data);

                if (match.Success)
                {
                    MatchCollection digitMatch = digits.Matches(match.ToString());

                    if (digitMatch.Count != 0)
                    {
                        string concat = string.Concat(digitMatch);

                        Console.WriteLine($"Product group: {concat}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }

        }
    }
}
