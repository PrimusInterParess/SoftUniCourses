using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsPattern = @"(?<separator>[#@])(?<wordOne>[A-Za-z]{3,})\1{2}(?<wordTwo>[A-Za-z]{3,})\1";

            string input = Console.ReadLine();

            Regex wordRegex = new Regex(wordsPattern);

            MatchCollection matchCollection = wordRegex.Matches(input);

            List<string> validPairs = new List<string>();

            foreach (Match match in matchCollection)
            {
                bool isValid = false;

                string wordOne = match.Groups["wordOne"].Value;
                string wordTwo = match.Groups["wordTwo"].Value;

                if (wordOne.Length == wordTwo.Length)
                {
                    int indexTwo = wordTwo.Length - 1;

                    for (int i = 0; i < wordOne.Length; i++)
                    {

                        for (int j = indexTwo; j >= 0; j--)
                        {
                            if (wordOne[i] == wordTwo[j])
                            {
                                isValid = true;
                                indexTwo--;
                                break;

                            }
                            else
                            {
                                isValid = false;
                                break;

                            }
                        }

                        if (isValid == false)
                        {
                            break;

                        }
                    }

                    if (isValid)
                    {
                        validPairs.Add($"{wordOne} <=> {wordTwo}");
                    }
                }

            }

            



            if (matchCollection.Count!=0)
            {
                Console.WriteLine($"{matchCollection.Count} word pairs found!");

                if (validPairs.Count!=0)
                {
                    Console.WriteLine("The mirror words are:");

                    Console.WriteLine(string.Join(", ",validPairs));
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }

        }
    }
}
