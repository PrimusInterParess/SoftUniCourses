using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[] snake = Console.ReadLine().ToCharArray();

            Queue<char> charrQueue = new Queue<char>(snake);


            int rows = dimentions[0];
            int cols = dimentions[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        char toAdd = charrQueue.Dequeue();
                        matrix[row, col] = toAdd;
                        charrQueue.Enqueue(toAdd);
                    }
                }
                else
                {

                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        char toAdd = charrQueue.Dequeue();
                        matrix[row, col] = toAdd;
                        charrQueue.Enqueue(toAdd);
                    }
                }


            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

        }
    }
}
