using System;

namespace RevoltRecap
{
    class Position
    {
        public Position(int row, int col)

        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public bool isSafe(int rowCount, int colCount)
        {
            if (Row < 0 || Col < 0)
            {
                return false;
            }

            if (Row >= rowCount || Col >= colCount)
            {
                return false;
            }

            return true;
        }

        public void CheckOtherSideMovement(int rowCount, int colCount)
        {

            if (Row < 0)
            {
                Row = rowCount - 1;
            }

            if (Col < 0)
            {
                Col = colCount - 1;
            }

            if (Row >= rowCount)
            {
                Row = 0;
            }

            if (Col >= colCount)
            {
                Col = 0;
            }
        }

        public static Position GetDirection(string command)
        {
            int row = 0;
            int col = 0;

            if (command == "left")
            {
                col = -1;
            }

            if (command == "right")
            {
                col = 1;
            }

            if (command == "up")
            {
                row = -1;
            }

            if (command == "down")
            {
                row = 1;
            }

            return new Position(row, col);


        }


    }

    class Program
    {

        static void Main(string[] args)
        {
            int nSize = int.Parse(Console.ReadLine());

            int nCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[nSize, nSize];

            Position playerP = GetPlayerPositionAndLoadingMatrix(matrix);


            if (nCommands > 0)
            {
                matrix[playerP.Row, playerP.Col] = '-';
            }

            for (int i = 0; i < nCommands; i++)
            {
                string command = Console.ReadLine();

                MovePlayer(playerP, command, nSize);

                while (matrix[playerP.Row, playerP.Col] == 'B')
                {
                    MovePlayer(playerP, command, nSize);
                }

                while (matrix[playerP.Row, playerP.Col] == 'T')
                {
                    Position direction = Position.GetDirection(command);

                    playerP.Row += direction.Row * -1;

                    playerP.Col += direction.Col * -1;

                }

                if (matrix[playerP.Row, playerP.Col]=='F')
                {
                    Console.WriteLine("Player won!");

                    matrix[playerP.Row, playerP.Col] = 'f';

                    PrintMatrix(matrix);

                    return;
                }

            }

            Console.WriteLine("Player lost!");

            matrix[playerP.Row, playerP.Col] = 'f';

            PrintMatrix(matrix);

        }

        private static void MovePlayer(Position playerP, string command, int nSize)
        {
            Position movement = Position.GetDirection(command);

            playerP.Row += movement.Row;

            playerP.Col += movement.Col;

            playerP.CheckOtherSideMovement(nSize, nSize);


        }

        private static Position GetPlayerPositionAndLoadingMatrix(char[,] matrix)
        {
            Position pPositon = null;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currChar = data[col];

                    matrix[row, col] = currChar;

                    if (currChar == 'f')
                    {
                        pPositon = new Position(row, col);

                    }
                }

            }

            return pPositon;

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
