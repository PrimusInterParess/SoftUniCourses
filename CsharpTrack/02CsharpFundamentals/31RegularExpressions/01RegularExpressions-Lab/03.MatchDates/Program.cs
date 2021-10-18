using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>\d{2})([\/.-])(?<month>\w{3})\1(?<year>\d{4})\b";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection dateCollection = regex.Matches(input);

            foreach (Match match in dateCollection)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}
