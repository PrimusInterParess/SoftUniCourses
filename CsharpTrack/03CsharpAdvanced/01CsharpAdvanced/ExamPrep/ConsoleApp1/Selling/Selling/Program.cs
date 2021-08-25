using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            int[] playerPosition = LoadingMatrix(matrix);

            int sum = 0;

            bool isOver = false;

            bool hasWon = false;

            string input = String.Empty; ;

            while (sum <= 50)
            {

                string command = Console.ReadLine();

                matrix[playerPosition[0]][playerPosition[1]] = '-';

                Movement(matrix, playerPosition, command);

                isOver = ChecksIsInMatrix(playerPosition, n);

                if (isOver)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");


                    break;

                }

                if (char.IsDigit(matrix[playerPosition[0]][playerPosition[1]]))
                {
                    string str = matrix[playerPosition[0]][playerPosition[1]].ToString();


                    sum += int.Parse(str);
                    matrix[playerPosition[0]][playerPosition[1]] = 'S';

                }

                else if (matrix[playerPosition[0]][playerPosition[1]] == 'O')
                {
                    matrix[playerPosition[0]][playerPosition[1]] = '-';

                    CheckForOther(playerPosition,matrix);
                }



                matrix[playerPosition[0]][playerPosition[1]] = 'S';


            }

            if (!isOver)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {sum}");

            PrintMatrix(matrix);

        }

        private static void CheckForOther(int[] playerPosition, char[][] matrix)
        {
            bool isFound = false;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(0); c++)
                {
                    if (matrix[r][c] == 'O')
                    {
                        playerPosition[0] = r;
                        playerPosition[1] = c;
                        isFound = true;
                        break;

                    }
                }

                if (isFound)
                {
                    break;

                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool ChecksIsInMatrix(int[] position, int n)
        {

            if (position[0] < 0 || position[1] < 0)
            {
                return true;
            }

            if (position[0] >= n || position[1] >= n)
            {
                return true;
            }

            return false;
        }

        private static void Movement(char[][] matrix, int[] beePosition, string command)
        {
            int row = 0;
            int col = 0;

            if (command == "up")
            {
                row--;
            }

            if (command == "down")
            {
                row++;
            }

            if (command == "left")
            {
                col--;
            }

            if (command == "right")
            {
                col++;
            }

            beePosition[0] += row;
            beePosition[1] += col;


        }

        private static int[] LoadingMatrix(char[][] matrix)
        {
            int[] position = new int[2];

            bool isFound = false;

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                matrix[row] = data;

                if (!isFound)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'S')
                        {
                            position[0] = row;
                            position[1] = col;

                            isFound = true;

                            break;
                        }
                    }
                }

            }

            return position;
        }
    }
}
