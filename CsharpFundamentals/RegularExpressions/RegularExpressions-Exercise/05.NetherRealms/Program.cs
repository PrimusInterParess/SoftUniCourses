using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Demon
    {
        public string Name { get; set; }

        public int Health { get; set; }


        public double Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> allDemons = new List<Demon>();

            string pattern = @"[-+]?[0-9]+\.?[0-9]*";

            Regex numbersRegex = new Regex(pattern);

            string[] inputDems = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var demon in inputDems)
            {
                string filter = "0123456789+-*/.";
                int health = demon.Where(c => !filter.Contains(c)).Sum(c => c);
                double damage = CalculatedDamage(numbersRegex, demon);

                allDemons.Add(new Demon { Name = demon, Health = health, Damage = damage });
            }

            foreach (var dem in allDemons.OrderBy(x => x.Name))
            {
                Console.WriteLine(dem);
            }
        }

        private static double CalculatedDamage(Regex numbersRegex, string demon)
        {
            MatchCollection numberMatchCollection = numbersRegex.Matches(demon);

            double damage = 0;

            foreach (Match numbMatch in numberMatchCollection)
            {
                damage += double.Parse(numbMatch.Value);
            }

            foreach (var charr in demon)
            {
                if (charr == '*')
                {
                    damage *= 2.0;
                }
                else if (charr == '/')
                {
                    damage /= 2.0;
                }
            }

            return damage;
        }
    }
}
