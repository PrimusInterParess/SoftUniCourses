using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimetntions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();


            int[,] matrix = new int[matrixDimetntions[0], matrixDimetntions[1]];
            int sum = 0;

            for (int row = 0; row < matrixDimetntions[0]; row++)
            {
                int[] toAdd = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrixDimetntions[1]; col++)
                {
                    matrix[row, col] = toAdd[col];
                    sum += toAdd[col];

                }
            }


            Console.WriteLine(matrixDimetntions[0]);
            Console.WriteLine(matrixDimetntions[1]);
            Console.WriteLine(sum);
        }
    }
}
