using System;

namespace _05Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] maze = new string[]
            {
                "010001",
                "01010E",
                "010100",
                "000000"
               
            };

            //string[] maze = new string[]
            //{
            //    "000",
            //    "010",
            //    "00E",

            //};

            FindPaths(maze, 0, 0, new bool[maze.Length, maze[0].Length], "");
        }

        private static void FindPaths(string[] maze, int row, int col, bool[,] visited, string path)
        {
            if (maze[row][col] == 'E')
            {
                Console.WriteLine(path);
                return;
            }

            visited[row, col] = true;

            if (IsSafe(maze, row + 1, col, visited))
            {
                FindPaths(maze, row + 1, col, visited, path + "D");
            }


            if (IsSafe(maze, row - 1, col, visited))
            {
                FindPaths(maze, row - 1, col, visited, path + "U");
            }

            if (IsSafe(maze, row, col + 1, visited))
            {
                FindPaths(maze, row, col + 1, visited, path + "R");
            }

            if (IsSafe(maze, row, col - 1, visited))
            {
                FindPaths(maze, row, col - 1, visited, path + "L");
            }

        }

        private static bool IsSafe(string[] mze, int row, int col, bool[,] visited)
        {
            if (row < 0 || col < 0 || row >= mze.Length || col >= mze[0].Length)
            {
                return false;
            }

            if (mze[row][col] == '1' || visited[row, col])
            {
                return false;
            }

            return true;
        }
    }
}
