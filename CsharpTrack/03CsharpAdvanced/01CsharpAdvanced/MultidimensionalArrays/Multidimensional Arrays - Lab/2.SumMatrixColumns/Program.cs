using System;
using System.Linq;

namespace _2.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimetions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[matrixDimetions[0], matrixDimetions[1]];

            for (int row = 0; row < matrixDimetions[0]; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrixDimetions[1]; col++)
                {
                    matrix[row, col] = input[col];

                }

            }

            for (int col = 0; col < matrixDimetions[1]; col++)
            {
                int sum = 0;

                for (int row = 0; row < matrixDimetions[0]; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }
        }
    }
}
