using System;

namespace Snake
{
    class Position
    {


        class Program
        {
            static void Main(string[] args)
            {

                int n = int.Parse(Console.ReadLine());

                char[,] matrix = new char[n, n];

                int[] snakePosition = GetPlayerPositionAndLoadingMatrix(matrix);

                int snakeRow = snakePosition[0];
                int snakeCol = snakePosition[1];

                int fBRow = snakePosition[2];
                int fBCol = snakePosition[3];

                int sBRow = snakePosition[4];
                int sBCol = snakePosition[5];

                matrix[snakeRow, snakeCol] = '.';

                int foodCount = 0;

                while (true)
                {

                    if (foodCount >= 10)
                    {
                        Console.WriteLine($"You won! You fed the snake.");
                        matrix[snakeRow, snakeCol] = 'S';
                        break;

                    }

                    string command = Console.ReadLine();


                    if (command == "up")
                    {
                        snakeRow--;
                    }
                    if (command == "down")
                    {
                        snakeRow++;
                    }
                    if (command == "left")
                    {
                        snakeCol--;
                    }
                    if (command == "right")
                    {
                        snakeCol++;
                    }

                    if (!isSafe(matrix, snakeRow, snakeCol))
                    {
                        Console.WriteLine($"Game over!");
                        break;
                    }

                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        foodCount++;
                    }

                    if (matrix[snakeRow, snakeCol] == 'B')
                    {
                        matrix[snakeRow, snakeCol] = '.';

                        if (fBRow == snakeRow && fBCol == snakeCol)
                        {
                            snakeRow = sBRow;

                            snakeCol = sBCol;
                        }
                        else
                        {
                            snakeRow = fBRow;

                            snakeCol = fBCol;
                        }

                    }

                    matrix[snakeRow, snakeCol] = '.';


                }

                Console.WriteLine($"Food eaten: {foodCount}");


                PrintMatrix(matrix);
            }

            public static bool isSafe(char[,] matrix, int row, int col)
            {
                if (row < 0 || col < 0)
                {
                    return false;
                }

                if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
                {
                    return false;
                }

                return true;
            }



            private static int[] GetPlayerPositionAndLoadingMatrix(char[,] matrix)
            {
                int[] sPosition = new int[6];

                sPosition[2] = -1;
                sPosition[3] = -1;
                sPosition[4] = -1;
                sPosition[5] = -1;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    string data = Console.ReadLine();

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        char currChar = data[col];

                        matrix[row, col] = currChar;

                        if (currChar == 'S')
                        {
                            sPosition[0] = row;

                            sPosition[1] = col;

                        }

                        if (sPosition[2] == -1 && currChar == 'B')
                        {
                            sPosition[2] = row;
                        }

                        if (sPosition[3] == -1 && currChar == 'B')
                        {
                            sPosition[3] = col;

                            continue;
                        }

                        if (sPosition[4] == -1 && currChar == 'B')
                        {
                            sPosition[4] = row;
                        }

                        if (sPosition[5] == -1 && currChar == 'B')
                        {
                            sPosition[5] = col;
                        }
                    }

                }

                return sPosition;

            }

            static void PrintMatrix(char[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
