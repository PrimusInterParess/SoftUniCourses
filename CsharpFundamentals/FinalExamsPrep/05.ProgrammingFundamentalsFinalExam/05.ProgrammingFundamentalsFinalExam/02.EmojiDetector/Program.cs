using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([:]{2}|[*]{2})(?<letters>[A-Z]{1}[a-z]{2,})(\1)";

            string patternDigits = @"([0-9])";

            string text = Console.ReadLine();

            if (text.Length < 5)
            {
                return;
            }

            Regex emmjopattern = new Regex(pattern);

            Regex digitspatternRegex = new Regex(patternDigits);

            MatchCollection emojiMatchCollection = emmjopattern.Matches(text);

            MatchCollection digitsCollection = digitspatternRegex.Matches(text);

            BigInteger digits = digitsCollection.Cast<Match>()
                .Select(m => m.Value)
                .ToArray()
                .Select(BigInteger.Parse)
                .ToArray().Aggregate((result, x) => result * x);

            List<string> cooList = new List<string>();


            foreach (Match match in emojiMatchCollection)
            {
                string word = match.Groups["letters"].ToString();

                int sumOfdigits = word.Sum(ch => (int)ch);

                if (sumOfdigits >= digits)
                {
                    cooList.Add(match.ToString());
                }
            }

            Console.WriteLine($"Cool threshold: {digits}");

            Console.WriteLine($"{emojiMatchCollection.Count} emojis found in the text. The cool ones are:");

            if (cooList.Count != 0)
            {
                foreach (var cool in cooList)
                {
                    Console.WriteLine(cool);
                }
            }


        }
    }
}
