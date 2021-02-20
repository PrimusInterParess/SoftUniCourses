using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your program should then receive commands in format:
            // "swap row1 col1 row2c col2" where row1, row2, col1, col2 are coordinates in the matrix.
            // In order for a command to be valid, it should start with the "swap" keyword along with four valid coordinates(no more, no less).
            // You should swap the values at the given coordinates(cell[row1, col1] with cell[row2, col2]) and print the matrix at each step
            // (thus you'll be able to check if the operation was performed correctly). 
            // If the command is not valid(doesn't contain the keyword "swap", has fewer or more coordinates entered or the given coordinates do not exist),
            // print "Invalid input!" and move on to the next command.
            // Your program should finish when the string "END" is entered.


            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();


                if (command.Length != 5 ||
                    command[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;

                }

                int oldRow = int.Parse(command[1]);
                int oldCol = int.Parse(command[2]);
                int newRow = int.Parse(command[3]);
                int newCol = int.Parse(command[4]);

                if (oldRow >= 0 &&
                    oldCol >= 0 &&
                    newCol >= 0 &&
                    newRow >= 0 &&
                    oldRow < matrix.GetLength(0) &&
                    oldCol < matrix.GetLength(1) && 
                    newRow < matrix.GetLength(0) &&
                    newCol < matrix.GetLength(1))
                {
                    string old = matrix[oldRow, oldCol];
                    string nEWW = matrix[newRow, newCol];

                    matrix[newRow, newCol] = old;
                    matrix[oldRow, oldCol] = nEWW;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row,col] + " ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    
                }


            }






        }
    }
}
