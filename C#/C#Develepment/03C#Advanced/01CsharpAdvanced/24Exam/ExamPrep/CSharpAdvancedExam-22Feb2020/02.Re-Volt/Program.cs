using System;

namespace _02.Re_Volt
{
    class Program
    {

        static void Main(string[] args)
        {
            int mSize = int.Parse(Console.ReadLine());

            int nCommands = int.Parse(Console.ReadLine());


            char[][] matrix = new char[mSize][];

            bool isFound = false;

            bool finished = false;

            int fRow = -1;

            int fCol = -1;

            LoadingMatrixWithData(mSize, isFound, matrix, ref fRow, ref fCol);

            for (int i = 0; i < nCommands; i++)
            {
                string command = Console.ReadLine();

                int nextRow = -1;

                int nextCol = -1;

                if (command == "up")
                {
                    nextRow = fRow - 1;
                    nextCol = fCol;

                    MovingUp(matrix, ref fRow, ref fCol, nextRow, nextCol, ref finished);
                }
                else if (command == "down")
                {
                    nextRow = fRow + 1;
                    nextCol = fCol;

                    MovingDown(matrix, ref fRow, ref fCol, ref finished, nextRow, nextCol);
                }
                else if (command == "right")
                {
                    nextRow = fRow;
                    nextCol = fCol + 1;

                    MovingRight(matrix, ref fRow, ref fCol, ref finished, nextRow, nextCol);
                }
                else if (command == "left")
                {
                    nextRow = fRow;
                    nextCol = fCol - 1;

                    MovingLeft(matrix, ref fRow, ref fCol, ref finished, nextRow, nextCol);
                }

                if (finished)
                {
                    break;
                }
            }

            if (finished)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(matrix);


        }

        private static void MovingLeft(char[][] matrix, ref int fRow, ref int fCol, ref bool finished, int nextRow, int nextCol)
        {

            if (nextCol < 0)
            {
                char nextPositon = matrix[nextRow][matrix.Length - 1];

                if (nextPositon == 'F')
                {
                    finished = true;

                    matrix[fRow][fCol] = '-';

                    matrix[fRow][matrix.Length - 1] = 'f';

                    fCol = matrix.Length - 1;


                }
                else if (nextPositon == 'B')
                {
                    matrix[fRow][fCol] = '-';

                    matrix[fRow][matrix.Length - 2] = 'f';

                    fCol = matrix.Length - 2;

                }
                else if (nextPositon == '-')
                {
                    matrix[fRow][fCol] = '-';
                    matrix[fRow][matrix.Length - 1] = 'f';

                    fCol = matrix.Length - 1;

                }


            }
            else
            {
                char nexPosition = matrix[nextRow][nextCol];

                if (nexPosition == 'F')
                {
                    finished = true;

                    matrix[fRow][fCol] = '-';

                    matrix[nextRow][nextCol] = 'f';

                    fCol = nextCol;

                }
                else if (nexPosition == 'B')
                {

                    matrix[fRow][fCol] = '-';

                    if (fCol - 2 < 0)
                    {
                        matrix[fRow][matrix.Length - 1] = 'f';

                        fCol = matrix.Length - 1;
                    }
                    else
                    {
                        matrix[fRow][fCol - 2] = 'f';

                        fCol -= 2;
                    }



                }
                else if (nexPosition == '-')
                {
                    matrix[fRow][fCol] = '-';
                    matrix[fRow][fCol - 1] = 'f';

                    fCol -= 1;

                }
            }



        }

        private static void MovingRight(char[][] matrix, ref int fRow, ref int fCol, ref bool finished, int nextRow, int nextCol)
        {
            if (nextCol >= matrix.Length)
            {
                char nextPositon = matrix[0][fCol];

                if (nextPositon == 'F')
                {
                    finished = true;

                    matrix[fRow][fCol] = '-';

                    matrix[fRow][0] = 'f';

                    fCol = 0;


                }
                else if (nextPositon == 'B')
                {
                    matrix[fRow][fCol] = '-';

                    matrix[fRow][0] = 'f';

                    fCol = 0;

                }
                else if (nextPositon == '-')
                {
                    matrix[fRow][fCol] = '-';
                    matrix[fRow][0] = 'f';

                    fCol = 0;

                }


            }
            else
            {
                char nexPosition = matrix[nextRow][nextCol];

                if (nexPosition == 'F')
                {
                    finished = true;

                    matrix[fRow][fCol] = '-';

                    matrix[nextRow][nextCol] = 'f';

                    fCol = nextCol;

                }
                else if (nexPosition == 'B')
                {

                    matrix[fRow][fCol] = '-';

                    if (matrix.Length < fCol + 2)
                    {
                        matrix[fRow][0] = 'f';

                        fCol = 1;
                    }
                    else
                    {
                        matrix[fRow][fCol + 2] = 'f';

                        fCol += 2;
                    }



                }
                else if (nexPosition == '-')
                {
                    matrix[fRow][fCol] = '-';
                    matrix[fRow][fCol + 1] = 'f';

                    fCol = +1;

                }
            }


        }

        private static void MovingDown(char[][] matrix, ref int fRow, ref int fCol, ref bool finished, int nextRow, int nextCol)
        {
            if (nextRow > matrix.Length - 1)
            {
                char nextPositon = matrix[0][fCol];

                if (nextPositon == 'F')
                {
                    finished = true;

                    matrix[fRow][fCol] = '-';

                    matrix[0][fCol] = 'f';

                    fRow = 0;


                }
                else if (nextPositon == 'B')
                {
                    matrix[fRow][fCol] = '-';

                    matrix[1][fCol] = 'f';

                    fRow = 1;

                }
                else if (nextPositon == '-')
                {
                    matrix[fRow][fCol] = '-';
                    matrix[1][fCol] = 'f';

                    fRow = 1;

                }


            }
            else
            {
                char nexPosition = matrix[nextRow][nextCol];

                if (nexPosition == 'F')
                {
                    finished = true;

                    matrix[fRow][fCol] = '-';

                    matrix[nextRow][nextCol] = 'f';

                    fRow = nextRow;

                }
                else if (nexPosition == 'B')
                {

                    matrix[fRow][fCol] = '-';

                    if (nextRow + 1 > matrix.Length - 1)
                    {
                        matrix[0][fCol] = 'f';

                        fRow = 0;
                    }
                    else
                    {
                        matrix[fRow + 2][fCol] = 'f';

                        fRow += 2;
                    }

                   

                }
                else if (nexPosition == '-')
                {
                    matrix[fRow][fCol] = '-';
                    matrix[fRow + 1][fCol] = 'f';

                    fRow = +1;

                }
            }


        }

        private static void MovingUp(char[][] matrix, ref int fRow, ref int fCol, int nextRow, int nextCol, ref bool finished)
        {
            if (nextRow < 0)
            {
                char nextPositon = matrix[matrix.Length - 1][fCol];

                if (nextPositon == 'F')
                {
                    finished = true;

                    matrix[fRow][fCol] = '-';

                    matrix[matrix.Length - 1][fCol] = 'f';

                    fRow = matrix.Length - 1;


                }
                else if (nextPositon == 'B')
                {
                    matrix[fRow][fCol] = '-';

                    matrix[matrix.Length - 2][fCol] = 'f';

                    fRow = matrix.Length - 2;

                }
                else if (nextPositon == '-')
                {
                    matrix[fRow][fCol] = '-';
                    matrix[matrix.Length - 1][fCol] = 'f';

                    fRow = matrix.Length - 1;

                }


            }
            else
            {
                char nexPosition = matrix[nextRow][fCol];

                if (nexPosition == 'F')
                {
                    finished = true;

                    matrix[fRow][fCol] = '-';

                    matrix[nextRow][fCol] = 'f';

                    fRow = nextRow;

                }
                else if (nexPosition == 'B')
                {

                    matrix[fRow][fCol] = '-';

                    if (nextRow - 2 < 0)
                    {
                        matrix[matrix.Length - 1][fCol] = 'f';

                        fRow = matrix.Length - 1;
                    }
                    else
                    {
                        matrix[fRow - 2][fCol] = 'f';

                        fRow -= 2;
                    }



                }
                else if (nexPosition == '-')
                {
                    matrix[fRow][fCol] = '-';
                    matrix[fRow - 1][fCol] = 'f';

                    fRow -= 1;

                }
            }



        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(string.Join("", matrix[i][j]));
                }

                Console.WriteLine();
            }
        }


        private static void LoadingMatrixWithData(int mSize, bool isFound, char[][] matrix, ref int fRow, ref int fCol)
        {
            for (int row = 0; row < mSize; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                matrix[row] = data;

                if (!isFound)
                {
                    for (int col = 0; col < mSize; col++)
                    {
                        if (matrix[row][col] == 'f')
                        {
                            fRow = row;
                            fCol = col;

                            isFound = true;
                            break;
                        }
                    }
                }

            }
        }
    }
}
