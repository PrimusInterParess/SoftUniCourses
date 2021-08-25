using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection names = regex.Matches(input);

            foreach (Match match in names)
            {
                Console.Write(match.Groups[0] + " ");
            }
        }
    }
}
