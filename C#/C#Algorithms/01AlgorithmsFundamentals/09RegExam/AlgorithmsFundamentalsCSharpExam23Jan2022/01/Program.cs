using System;
using System.Collections.Generic;

namespace _01BinomialCoefficients
{
    class Program
    {

        private static Dictionary<string, long> memo;

        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            memo = new Dictionary<string, long>();

            long result = GetBinom(r, c);

            Console.WriteLine(result);
        }

        private static long GetBinom(int row, int col)
        {
            var key = $"{row}-{col}";

            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            if (row == 1 || col == 1 || row==col)
            {
                return 1;
            }

            var result = GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);

            memo.Add(key, result);

            return result;
        }
    }
}