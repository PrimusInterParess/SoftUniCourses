using System;
using System.Text.RegularExpressions;

namespace Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPasswords = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPasswords; i++)
            {

                string input = Console.ReadLine();

                string pattern = @"^(\W+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1$";

                Regex newRegex = new Regex(pattern);

                Match m = newRegex.Match(input);

                if (m.Success)
                {
                    string password = string.Concat(m.Groups[2],m.Groups[3],m.Groups[4],m.Groups[5]);

                    Console.WriteLine($"Your password is {password}");
                }
                else
                {
                    Console.WriteLine("Try another password");
                }

            }
        }
    }
}
