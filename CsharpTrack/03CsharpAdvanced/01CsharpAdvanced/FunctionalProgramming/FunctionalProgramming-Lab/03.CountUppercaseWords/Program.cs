using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);


            Func<string[], List<string>> sortingText = SortingUpperCaseWords;

            var res = sortingText(text);

            foreach (var aRe in res)
            {
                Console.WriteLine(aRe);
            }

        }

        static List<string> SortingUpperCaseWords(string[] textArray)
        {
            List<string> sortedList = new List<string>();

            foreach (var word in textArray)
            {

                if (char.IsUpper(word[0]))
                {
                    sortedList.Add(word);
                }
            }

            return sortedList;

        }

    }
}
