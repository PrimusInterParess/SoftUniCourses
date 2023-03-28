using System;
using System.Linq;

namespace _3.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {

                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row == 0)
                    {
                        sum += matrix[row, col];
                        row++;
                    }
                    else if (col < n)
                    {
                        sum += matrix[row, col];
                        if (row < n)
                        {
                            row++;
                        }
                        
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
