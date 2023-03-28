using System;
using System.Collections.Generic;

namespace EightQ
{
    class Program
    {

        static HashSet<int> occupiedRows = new HashSet<int>();
        static HashSet<int> occupiedCols = new HashSet<int>();
        static HashSet<int> occupiedrightDiagonals = new HashSet<int>();
        static HashSet<int> occupiedleftDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            bool[,] board = new bool[8, 8];

            PlaceQueens(board, 0);
        }

        private static void PlaceQueens(bool[,] board, int row)
        {
            if (row == board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (!IsOccupied(row, col))
                {
                    board[row, col] = true;
                    occupiedRows.Add(row);
                    occupiedCols.Add(col);
                    occupiedleftDiagonals.Add(row - col);
                    occupiedrightDiagonals.Add(row + col);

                    PlaceQueens(board, row + 1);

                    board[row, col] = false;
                    occupiedRows.Remove(row);
                    occupiedCols.Remove(col);
                    occupiedleftDiagonals.Remove(row - col);
                    occupiedrightDiagonals.Remove( row + col);

                   
                }


            }
        }

        private static bool IsOccupied(int row, int col)
        {
            return occupiedRows.Contains(row) ||
                   occupiedCols.Contains(col) ||
                   occupiedleftDiagonals.Contains(row - col) ||
                   occupiedrightDiagonals.Contains(row + col);


        }

        private static void PrintBoard(bool[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i,j])
                    {
                        Console.Write($"* ");
                    }
                    else
                    {
                        Console.Write($"- ");
                    }

                   
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
    }
}
