using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int squareSize = 2;

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            int totalSum = 0;
            int rowToPrint = 0;
            int colToPrint = 0;


            for (int row = 0; row < rows; row++)
            {
                int[] numbersToAdd = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbersToAdd[col];
                }
            }


            for (int row = 0; row < rows - squareSize + 1; row++)
            {

                for (int col = 0; col < cols - squareSize + 1; col++)
                {
                    int sum = 0;

                    for (int innerRow = row; innerRow < row + squareSize; innerRow++)
                    {
                        for (int innerCol = col; innerCol < col + squareSize; innerCol++)
                        {
                            sum += matrix[innerRow, innerCol];
                        }
                    }

                    if (sum > totalSum)
                    {

                        totalSum = sum;
                        rowToPrint = row;
                        colToPrint = col;

                    }
                }
            }

            for (int row = rowToPrint; row < rowToPrint + squareSize; row++)
            {
                for (int col = colToPrint; col < colToPrint + squareSize; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(totalSum);
        }
    }
}
