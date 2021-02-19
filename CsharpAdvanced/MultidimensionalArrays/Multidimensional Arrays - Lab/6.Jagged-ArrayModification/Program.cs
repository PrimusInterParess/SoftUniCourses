using System;
using System.Linq;

namespace _6.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArrays = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArrays[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split();

                string action = command[0];

                int row = int.Parse(command[1]);

                int col = int.Parse(command[2]);

                int number = int.Parse(command[3]);

                if (action == "Add")
                {
                    if (row < 0 || col < 0 || row > jaggedArrays.Length - 1 || col > jaggedArrays[row].Length - 1)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {

                        jaggedArrays[row][col] += number;

                    }
                }
                else
                {
                    if (row < 0 || col < 0 || row > jaggedArrays.Length - 1 || col > jaggedArrays[row].Length - 1)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {

                        jaggedArrays[row][col] -= number;

                    }
                }
            }


            for (int row = 0; row < jaggedArrays.Length; row++)
            {
                for (int col = 0; col < jaggedArrays[row].Length; col++)
                {
                    Console.Write(jaggedArrays[row][col] + " ");
                }

                Console.WriteLine();

            }
        }
    }
}
