using System;

namespace _07._N_Choose_K_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 5;

            var k = 3;

            Console.WriteLine(GetBinom(n, k));
        }

        private static int GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
        }
    }
}
