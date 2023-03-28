using System;

namespace _4.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] data = new char[n, n];

            for (int row = 0; row < data.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < data.GetLength(1); col++)
                {
                    data[row, col] = input[col];
                }
            }

            char toFind = char.Parse(Console.ReadLine());

            bool hasAccured = false;

            int toPrintRow = 0;
            int toPrintCol = 0;

            for (int row = 0; row < data.GetLength(0); row++)
            {

                for (int col = 0; col < data.GetLength(1); col++)
                {
                    if (data[row, col] == toFind)
                    {
                        toPrintRow = row;
                        toPrintCol = col;
                        hasAccured = true;
                        break;
                    }

                }

                if (hasAccured)
                {
                    break;
                }
            }

            if (hasAccured)
            {
                Console.WriteLine($"({toPrintRow}, {toPrintCol})");

            }
            else
            {
                Console.WriteLine($"{toFind} does not occur in the matrix");
            }
        }
    }
}
