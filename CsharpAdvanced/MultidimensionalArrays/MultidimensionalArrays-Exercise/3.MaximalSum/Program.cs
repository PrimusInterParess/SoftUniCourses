using System;
using System.Linq;

namespace _3.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            int size = 3;


            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            int maxSum = int.MinValue;

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
                    }

                    if (maxSum < sum)
                    {
                        maxSum = sum;

                        rowToPrint = row;
                        colToPrint = col;
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);

            for (int row = rowToPrint; row < rowToPrint + size; row++)
            {
                for (int col = colToPrint; col < colToPrint + size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }


        }
    }
}
