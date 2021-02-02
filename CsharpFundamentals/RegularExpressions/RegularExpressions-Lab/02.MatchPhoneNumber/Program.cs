using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359([ -])2\1\d{3}\1\d{4}\b";

           

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection phoneNCollection = regex.Matches(input);

            List<string> phnList = new List<string>();

            foreach (Match match in phoneNCollection)
            {
                phnList.Add(match.Value);
            }


            Console.WriteLine(string.Join(", ",phnList));
        }
    }
}
