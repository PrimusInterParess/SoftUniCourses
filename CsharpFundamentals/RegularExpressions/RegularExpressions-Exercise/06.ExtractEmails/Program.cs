using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\s)(?<user>[A-Za-z0-9]+[.-]*\w)*@(?<host>[a-z]+?([.-][a-z]*)*(\.[a-z]{2,3}))";

            string input = Console.ReadLine();

            MatchCollection emailCollection = Regex.Matches(input, pattern);

            Console.WriteLine(string.Join(Environment.NewLine,emailCollection));
        }
    }
}
