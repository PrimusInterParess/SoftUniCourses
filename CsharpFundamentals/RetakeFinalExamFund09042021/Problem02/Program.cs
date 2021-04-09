using System;
using System.Text.RegularExpressions;

namespace Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@]+|[#]+|[@#]+|[#@])(?<color>[]a-z]{3,})([@|#]|[@#]|[#@])([^A-Za-z0-9]+)?(\/+)(?<digits>[0-9]+)(\/+)"; ;

            string text = Console.ReadLine();

            Regex patterntRegex = new Regex(pattern);

            MatchCollection mathes = patterntRegex.Matches(text);

            bool succses = mathes.Count != 0;

            if (succses)
            {
                foreach (Match match in mathes)
                {
                    string eggColor = match.Groups[6].Value;
                    string eggCount = match.Groups[7].Value;

                    Console.WriteLine($"You found {eggCount} {eggColor} eggs!");
                }
            }

          


        }
    }
}
