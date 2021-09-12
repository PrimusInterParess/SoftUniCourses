using System;
using System.Collections.Generic;
using System.Linq;

namespace _05PathInLabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            char[,] matrix = GenerateMatrix(row, col);
            List<char> directions = new List<char>();

            FindingPaths(matrix, 0,0, directions, '\0');
        }

        private static void FindingPaths(char[,] matrix, int row, int col, List<char> directions, char direction)
        {
            if (IsOutside(matrix, row, col) ||
                IsWall(matrix,row,col) ||
                IsVisited(matrix,row,col))
            {
                return;
                
            }

            directions.Add(direction);


            if (IsPath(matrix,row,col))
            {
               // voidPrintLabirint(matrix);

               Console.WriteLine(string.Join("",directions));
                directions.RemoveAt(directions.Count - 1);

                return;
            }
            matrix[row, col] = 'v';

            FindingPaths(matrix, row, col + 1,directions, 'R');
            FindingPaths(matrix, row, col - 1, directions, 'L');
            FindingPaths(matrix, row - 1, col,directions, 'U');
            FindingPaths(matrix, row + 1, col,directions, 'D');

            directions.RemoveAt(directions.Count - 1);
            matrix[row, col] = '-';
        }

        private static bool IsPath(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == 'e';
        }

        private static bool IsVisited(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == 'v';
        }

        private static bool IsWall(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutside(char[,] matrix, int row, int col)
        {
          return  row >= matrix.GetLength(0) || 
                  row < 0 || 
                  col < 0 || 
                  col >= matrix.GetLength(1);


        }

        private static char[,] GenerateMatrix(int row, int col)
        {
            char[,] toReturn = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                string rowstring = Console.ReadLine();

                for (int j = 0; j < col; j++)
                {
                    toReturn[i, j] = rowstring[j];
                }
            }

            return toReturn;
        }

        private static void  voidPrintLabirint(char[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

           
        }
    }
}
