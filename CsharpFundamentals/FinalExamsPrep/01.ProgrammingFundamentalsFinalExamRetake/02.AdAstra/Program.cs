using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            // •	Calculate the total calories of all food items and then determine how many
            // days you can last with the food you have.
            // Keep in mind that you need 2000kcal a day.

            string input = Console.ReadLine();

            string pattern = @"(?<separator>[#|])(?<product>[A-z][a-z\s?]+([A-Z]?[a-z]*))\2(?<date>[\d]{2}\/\d{2}\/\d{2})\2(?<calories>\d{1,5})\2";

            Regex regex = new Regex(pattern);

            MatchCollection supplies = regex.Matches(input);

            int totalCalories = 0;

            foreach (Match supply in supplies)
            {
                totalCalories += int.Parse(supply.Groups["calories"].Value);
            }

            int countDays = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {countDays} days!");

            foreach (Match supply in supplies)
            {
                Console.WriteLine($"Item: {supply.Groups["product"].Value}, Best before: {supply.Groups["date"].Value}, Nutrition: {supply.Groups["calories"].Value}");
            }


        }
    }
}