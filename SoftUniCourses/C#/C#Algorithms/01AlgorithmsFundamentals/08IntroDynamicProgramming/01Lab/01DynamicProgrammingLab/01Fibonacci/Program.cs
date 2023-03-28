using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace _01Fibonacci
{
    class Program
    {
        private static Dictionary<int, long> memo;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            memo = new Dictionary<int, long>();
            Console.WriteLine(GetFibonacci(n));

        }

        private static long GetFibonacci(int fib)
        {

            if (memo.ContainsKey(fib))
            {
                return memo[fib];
            }

            if (fib <= 2)
            {
                return 1;
            }


            var result = GetFibonacci(fib - 1) + GetFibonacci(fib - 2);

            memo[fib] = result;

            return result;
        }
    }
}
