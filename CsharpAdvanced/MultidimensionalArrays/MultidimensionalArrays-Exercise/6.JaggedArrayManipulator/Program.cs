using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArrays = new int[rows][];

            for (int row = 0; row < rows; row++)
            {

                jaggedArrays[row] = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < rows - 1; row++)
            {
                int[] first = jaggedArrays[row];
                int[] second = jaggedArrays[row + 1];

                if (first.Length == second.Length)
                {
                    jaggedArrays[row] = first.Select(x => x * 2).ToArray();
                    jaggedArrays[row + 1] = second.Select(x => x * 2).ToArray();
                }
                else
                {
                    jaggedArrays[row] = first.Select(x => x / 2).ToArray();
                    jaggedArrays[row + 1] = second.Select(x => x / 2).ToArray();

                }

            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split().ToArray();

                string action = command[0];

                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (!(row >= 0 &&
                    col >= 0 &&
                    row < jaggedArrays.Length &&
                    col < jaggedArrays[row].Length))
                {
                    continue;
                }

                if (action=="Add")
                {
                    jaggedArrays[row][col] += value;
                }
                else if (action== "Subtract")
                {
                    jaggedArrays[row][col] -= value;

                }

            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArrays[i]));
            }
        }
    }
}
