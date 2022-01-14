using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ArraysInMatrixakaGraph
{
    class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(rows, cols);
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (visited[row, col])
                    {
                        continue;
                    }

                    char nodeValue = matrix[row, col];

                    DFS(row, col, nodeValue);

                    if (areas.ContainsKey(nodeValue))
                    {
                        areas[nodeValue] += 1;
                    }
                    else
                    {
                        areas.Add(nodeValue,1);
                    }
                }
            }

            int areasCount = areas.Sum(a=>a.Value);

            Console.WriteLine($"Areas: {areasCount}");


            foreach (var kvp in areas)
            {
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
            }


        }

        private static void DFS(int row, int col, char nodeValue)
        {
            if (IsOutSide(row, col))
            {
                return;
            }

            if (NotEqual(row, col, nodeValue))
            {
                return;
            }

            if (IsVisited(row, col))
            {
                return;
            }

            visited[row, col] = true;

            DFS(row + 1, col, nodeValue);
            DFS(row - 1, col, nodeValue);
            DFS(row, col + 1, nodeValue);
            DFS(row, col - 1, nodeValue);
        }

        private static bool IsVisited(int row, int col)
        {
            return visited[row, col];
        }

        private static bool NotEqual(int row, int col, char nodeValue)
        {
            return matrix[row, col] != nodeValue;
        }

        private static bool IsOutSide(int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) || col < 0 || col >=matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] toReturnMatrix = new char[rows, cols];

            for (int row = 0; row < toReturnMatrix.GetLength(0); row++)
            {
                string inputData = Console.ReadLine();

                for (int col = 0; col < toReturnMatrix.GetLength(1); col++)
                {
                    toReturnMatrix[row, col] = inputData[col];
                }
            }

            return toReturnMatrix;
        }
    }
}
