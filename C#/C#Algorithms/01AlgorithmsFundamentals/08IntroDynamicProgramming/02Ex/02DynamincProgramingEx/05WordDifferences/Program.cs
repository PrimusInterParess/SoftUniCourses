using System;

namespace _05WordDifferences
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstWord = Console.ReadLine();
            var secondWord = Console.ReadLine();

            var dp = new int[firstWord.Length + 1, secondWord.Length + 1];

            for (int row = 1; row < dp.GetLength(1); row++)
            {
                dp[row, 0] = row;
            }

            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = col;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (firstWord[row - 1] == secondWord[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }
                    else
                    {
                        dp[row, col] = Math.Min(dp[row-1, col ], dp[row, col-1])+1;
                    }
                }
            }

            Console.WriteLine($"Deletions and Insertions: {dp[firstWord.Length, secondWord.Length]}");



        }
    }
}
