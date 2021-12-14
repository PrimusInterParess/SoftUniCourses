using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Climbing
{
    class Program
    {
        private static bool[,] visited;

        private static List<List<int>> paths;

        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());

            int col = int.Parse(Console.ReadLine());

            int[,] matrix = PopulateMatrix(row, col);

            visited = new bool[row, col];

            paths = new List<List<int>>();

            var path = new List<int>();

            FindingPaths(matrix, matrix.GetLength(0) - 1, matrix.GetLength(1) - 1, path);

            var topPath = paths.OrderByDescending(p => p.Sum()).First();

            Console.WriteLine(topPath.Sum());
            Console.WriteLine(string.Join(" ",topPath));
            ;
        }

        private static bool IsOutside(int[,] matrix, int row, int col)
        {
            return row >= matrix.GetLength(0) ||
                   row < 0 ||
                   col < 0 ||
                   col >= matrix.GetLength(1);


        }

        private static int[,] PopulateMatrix(int row, int col)
        {
            int[,] matrixToPopulate = new int[row, col];

            for (int r = 0; r < matrixToPopulate.GetLength(0); r++)
            {
                var elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int c = 0; c < matrixToPopulate.GetLength(1); c++)
                {
                    matrixToPopulate[r, c] = elements[c];
                }
            }

            return matrixToPopulate;
        }


        private static void FindingPaths(int[,] matrix, int row, int col, List<int> path)
        {

            if (IsOutside(matrix, row, col) ||
                visited[row, col])
            {
                return;
            }


            path.Add(matrix[row, col]);


            if (IsPath( row, col))
            {
                paths.Add(new List<int>(path));
                path.RemoveAt(path.Count - 1);

                return;
            }
            visited[row, col] = true;

           
            FindingPaths(matrix, row - 1, col, path);
            FindingPaths(matrix, row , col - 1, path);

            path.RemoveAt(path.Count - 1);
            visited[row, col] = false;
        }

        private static bool IsPath(int row, int col)
        {
            return row == 0 && col == 0;
        }
    }
}
