using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+\.?\d*)\$";

            Regex regex = new Regex(pattern);

            double total = 0;

            string input = string.Empty;

            while (((input=Console.ReadLine())!="end of shift"))
            {
                Match purchase = regex.Match(input);

                if (purchase.Success)
                {

                    string customer = purchase.Groups[1].Value;
                    string product = purchase.Groups[2].Value;
                    int quantity =int.Parse(purchase.Groups[3].Value);
                    double price = double.Parse(purchase.Groups[4].Value);

                    double currentSum = quantity * price;

                    Console.WriteLine($"{customer}: {product} - {currentSum:f2}");

                    total += currentSum;
                }
                
            }

            Console.WriteLine($"Total income: {total:f2}");


        }
    }
}
