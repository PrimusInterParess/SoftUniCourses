using System;
using System.Collections.Generic;

namespace _01TBC
{
    public class Area
    {
        public int Size { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());

            int col = int.Parse(Console.ReadLine());

            char[,] matrix = PopulateMatrix(row, col);

            bool[,] visited = new bool[row, col];

            List<Area> areas = new List<Area>();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 'd')
                    {
                        continue;
                    }

                    if (visited[r, c])
                    {
                        continue;
                    }

                    int size = GettingAreaSize(matrix, visited, r, c);

                    Area area = new Area()
                    {
                        Row = r,
                        Col = c,
                        Size = size
                    };

                    areas.Add(area);

                }
            }


            Console.WriteLine(areas.Count);



        }

        private static int GettingAreaSize(char[,] matrix, bool[,] visited, int row, int col)
        {

            if (IsOutside(matrix, row, col) ||
                visited[row, col] ||
                matrix[row, col] == 'd')
            {
                return 0;
            }

            visited[row, col] = true;

            return GettingAreaSize(matrix, visited, row + 1, col) +
                   GettingAreaSize(matrix, visited, row - 1, col) +
                   GettingAreaSize(matrix, visited, row, col - 1) +
                   GettingAreaSize(matrix, visited, row, col + 1) +
                   GettingAreaSize(matrix, visited, row + 1, col + 1) +
                   GettingAreaSize(matrix, visited, row + 1, col - 1) +
                   GettingAreaSize(matrix, visited, row - 1, col + 1) +
                   GettingAreaSize(matrix, visited, row - 1, col - 1) + 1;
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
                    matrixToPopulate[r, c] = elemets[c];
                }
            }

            return matrixToPopulate;
        }
    }
}
