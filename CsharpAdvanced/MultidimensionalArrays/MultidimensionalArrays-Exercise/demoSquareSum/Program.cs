using System;
using System.Linq;

namespace demoSquareSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 2;

            int[] dimetions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = dimetions[0];
            int cols = dimetions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbersToAdd = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbersToAdd[col];
                }
            }


            int maxSum = 0;
            int rowToPrint = 0;
            int colToPrint = 0;


            for (int row = 0; row < rows - size + 1; row++)
            {
                for (int col = 0; col < cols - size + 1; col++)
                {
                    int sum = 0;

                    for (int innerRow = row; innerRow < row + size; innerRow++)
                    {
                        for (int innerCol = col; innerCol < col + size; innerCol++)
                        {
                            sum += matrix[innerRow, innerCol];
                        }

                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            rowToPrint = row;
                            colToPrint = col;
                        }
                    }
                }
            }


            for (int row = rowToPrint; row < rowToPrint + size; row++)
            {
                for (int col = colToPrint; col < colToPrint + size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
