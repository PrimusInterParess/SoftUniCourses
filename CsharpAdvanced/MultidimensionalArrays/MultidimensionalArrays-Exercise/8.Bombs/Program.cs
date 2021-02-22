using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            int rows = dimentions;
            int cols = dimentions;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbersToAdd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbersToAdd[col];
                }
            }

            Queue<string> bombQueue = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray());

            bool isAlive = false;

            while (bombQueue.Count != 0)
            {
                int[] bombInfo = bombQueue.Dequeue().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int bombRow = bombInfo[0];

                int bombCol = bombInfo[1];

                if (bombRow >= 0 && bombRow < rows && bombCol >= 0 && bombCol < cols)
                {

                    if ((matrix[bombRow, bombCol] > 0))
                    {
                        int bomb = matrix[bombRow, bombCol];

                        if (bombRow - 1 >= 0 && matrix[bombRow - 1, bombCol] > 0)
                        {
                            matrix[bombRow - 1, bombCol] -= bomb;
                        }

                        if (bombRow - 1 >= 0 && bombCol + 1 < cols && matrix[bombRow - 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol + 1] -= bomb;
                        }

                        if (bombRow - 1 >= 0 && bombCol - 1 >= 0 && matrix[bombRow - 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow - 1, bombCol - 1] -= bomb;
                        }

                        if (bombCol - 1 >= 0 && matrix[bombRow, bombCol - 1] > 0)
                        {
                            matrix[bombRow, bombCol - 1] -= bomb;
                        }

                        if (bombCol + 1 < cols && matrix[bombRow, bombCol + 1] > 0)
                        {
                            matrix[bombRow, bombCol + 1] -= bomb;
                        }

                        if (bombRow + 1 < rows && matrix[bombRow + 1, bombCol] > 0)
                        {
                            matrix[bombRow + 1, bombCol] -= bomb;
                        }

                        if (bombRow + 1 < rows && bombCol + 1 < cols && matrix[bombRow + 1, bombCol + 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol + 1] -= bomb;
                        }

                        if (bombRow + 1 < rows && bombCol - 1 >= 0 && matrix[bombRow + 1, bombCol - 1] > 0)
                        {
                            matrix[bombRow + 1, bombCol - 1] -= bomb;
                        }

                        matrix[bombRow, bombCol] = 0;
                    }

                }

                if (!(ChecksIfThereArePositiveValuesInMatrix(matrix, rows, cols, isAlive)))
                {
                    break;
                }

            }

            int counter = AliveCellsCounter(matrix, rows, cols);


            int sum = SumOFCells(matrix, rows, cols);




            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");

            for (int i = 0; i < rows; i++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[i, col] + " ");
                }

                Console.WriteLine();
            }

        }


        private static int SumOFCells(int[,] matrix, int rows, int cols)
        {
            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > 0)
                    {

                        sum += matrix[row, col];
                    }
                }
            }

            return sum;
        }

        private static int AliveCellsCounter(int[,] matrix, int rows, int cols)
        {
            int alive = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        alive++;
                    }
                }
            }

            return alive;

        }


        static bool ChecksIfThereArePositiveValuesInMatrix(int[,] matrix, int rows, int cols, bool isAlive)
        {

            for (int rrow = 0; rrow < rows; rrow++)
            {
                for (int cool = 0; cool < cols; cool++)
                {
                    if (matrix[rrow, cool] > 0)
                    {
                        isAlive = true;
                        break;
                    }
                }

                if (isAlive)
                {
                    break;
                }
            }

            return isAlive;
        }
    }
}
