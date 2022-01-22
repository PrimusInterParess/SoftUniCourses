using System;

namespace _07MinimumEditDistance
{
    class Program
    {
        static void Main(string[] args)
        {

            int replaceCost = int.Parse(Console.ReadLine());
            int insertCost = int.Parse(Console.ReadLine());
            int deleteCost = int.Parse(Console.ReadLine());

            var firstWord = Console.ReadLine();
            var secondWord = Console.ReadLine();

            var dp = new int[firstWord.Length + 1, secondWord.Length + 1];

            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = dp[0, col - 1] + insertCost;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = dp[row - 1,0] + deleteCost;

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
                        var replace = dp[row - 1, col - 1] + replaceCost;
                        var delete = dp[row - 1, col ] + deleteCost;
                        var insert = dp[row, col - 1] + insertCost;

                        var toInsert = Math.Min(Math.Min(replace, delete), insert);

                        dp[row, col] = toInsert;
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: {dp[firstWord.Length, secondWord.Length]}");
        }
    }
}
