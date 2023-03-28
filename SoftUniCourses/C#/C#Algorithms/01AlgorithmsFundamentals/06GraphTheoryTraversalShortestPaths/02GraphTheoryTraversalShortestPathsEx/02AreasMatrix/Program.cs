using System;
using System.Collections.Generic;
using System.Linq;

namespace _02AreasMatrix
{
    public class Area
    {
        public int Size { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }



    class Program
    {

        private static Dictionary<char, int> areas;
        private static List<char> toForeachList;
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());

            int col = int.Parse(Console.ReadLine());

            areas = new Dictionary<char, int>();

            toForeachList = new List<char>();

            char[,] matrix = PopulateMatrix(row, col);

            bool[,] visited = new bool[row, col];


            foreach (var kvp in toForeachList)
            {
                var node = kvp;

                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        if (matrix[r, c] != node)
                        {
                            continue;
                        }

                        if (visited[r, c])
                        {
                            continue;
                        }

                        int size = GettingAreaSize(matrix, visited, r, c, node);


                        if (size>0)
                        {
                            areas[node] += 1;
                        }

                    }
                }
            }


            int totalAreasCcount = areas.Values.Sum(a => a);

            Console.WriteLine($"Areas: {totalAreasCcount}");

            foreach (var kvp in areas.OrderBy(a=>a.Key))
            {
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
            }

           



        }

        private static int GettingAreaSize(char[,] matrix, bool[,] visited, int row, int col, char node)
        {

            if (IsOutside(matrix, row, col) ||
                visited[row, col] ||
                matrix[row, col] != node)
            {
                return 0;
            }

            visited[row, col] = true;

            return GettingAreaSize(matrix, visited, row + 1, col, node) +
                   GettingAreaSize(matrix, visited, row - 1, col, node) +
                   GettingAreaSize(matrix, visited, row, col - 1, node) +
                   GettingAreaSize(matrix, visited, row, col + 1, node) + 1;
        }

        private static bool IsOutside(char[,] matrix, int row, int col)
        {
            return row >= matrix.GetLength(0) ||
                   row < 0 ||
                   col < 0 ||
                   col >= matrix.GetLength(1);


        }

        private static char[,] PopulateMatrix(int row, int col)
        {
            char[,] matrixToPopulate = new char[row, col];

            for (int r = 0; r < matrixToPopulate.GetLength(0); r++)
            {
                var elemets = Console.ReadLine();

                for (int c = 0; c < matrixToPopulate.GetLength(1); c++)
                {

                    if (!areas.ContainsKey(elemets[c]))
                    {
                        areas.Add(elemets[c], 0);
                        toForeachList.Add(elemets[c]);
                    }

                    matrixToPopulate[r, c] = elemets[c];
                }
            }

            return matrixToPopulate;
        }
    }
}
