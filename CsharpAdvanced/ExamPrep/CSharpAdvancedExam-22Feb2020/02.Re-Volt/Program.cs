using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int numberOfCommands = int.Parse(Console.ReadLine());

            char[,] board = new char[matrixSize, matrixSize];

            int[] playerPosition = new int[2] { -1, -1 };

            for (int row = 0; row < matrixSize; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    board[row, col] = data[col];

                    if (data[col] == 'f')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                }
            }

            for (int i = 0; i < matrixSize; i++)
            {
                string direction = Console.ReadLine();

                switch (direction)
                {
                    case "up":
                        MovingUp(board, playerPosition);
                        break;
                    case "down":
                        break;
                    case "left":
                        break;
                    case "right":
                        break;
                }
            }
        }

        private static void MovingUp(char[,] board, int[] position)
        {
            int row = position[0];
            int col = position[1];
            int rowToMove = row--;

            if (rowToMove < 0)
            {
                int rowToGo = board.GetLength(0);

                char funk = IsPositon(rowToGo, col, board);


                if (funk == 'B')
                {
                    funk = IsPositon(rowToGo + 1, col, board);

                    
                     if (funk == 'T')
                    {

                    }
                    else if (funk == '-')
                    {

                    }
                    else if (funk == 'F')
                    {
                        
                    }


                }
                else if (funk == 'T')
                {

                }
                else if (funk == 'F')
                {

                }
                else if (funk == '-')
                {

                }

            }

        }

        private static char IsPositon(int rowToGo, int col, char[,] board)
        {

            if (board[rowToGo, col] == 'B')
            {
                return 'B';
            }
            else if (board[rowToGo, col] == 'T')
            {
                return 'T';
            }
            else if (board[rowToGo, col] == 'F')
            {
                return 'F';
            }
            else
            {
                return '-';
            }

        }


    }
}

