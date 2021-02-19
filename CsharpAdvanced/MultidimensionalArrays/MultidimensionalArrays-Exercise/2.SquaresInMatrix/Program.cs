using System;
using System.Linq;

namespace _2.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 2;

            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            char[,] charMatrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] charArray = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    charMatrix[row, col] = charArray[col];
                }
            }

            int squareCount = 0;

            for (int row = 0; row < rows - size + 1; row++)
            {
                for (int col = 0; col < cols - size + 1; col++)
                {
                    if (charMatrix[row, col] == charMatrix[row, col + 1] &&
                        charMatrix[row + 1, col] == charMatrix[row + 1, col + 1] && 
                        charMatrix[row,col]==charMatrix[row+1,col])

                    {
                        squareCount++;
                    }

                }
            }

            Console.WriteLine(squareCount);

        }
    }
}
