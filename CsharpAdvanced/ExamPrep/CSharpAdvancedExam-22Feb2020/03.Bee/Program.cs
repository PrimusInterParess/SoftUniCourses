using System;

namespace _03.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[][] matrix = new char[n][];

            int[] beePosition = LoadingMatrix(matrix);

            int pollinated = 0;

            bool isOver = false;

            bool hasWon = false;

            string input = String.Empty; ;

            while ((input = Console.ReadLine()) != "End")
            {

                string command = input;

                matrix[beePosition[0]][beePosition[1]] = '.';

                Movement(matrix, beePosition, command);

                isOver = ChecksIsBeeInMatrix(beePosition, n);

                if (isOver)
                {
                    Console.WriteLine("The bee got lost!");


                    break;

                }

                if (matrix[beePosition[0]][beePosition[1]] == 'f')
                {
                    matrix[beePosition[0]][beePosition[1]] = 'B';

                    pollinated++;
                }

                if (matrix[beePosition[0]][beePosition[1]] == 'O')
                {
                    matrix[beePosition[0]][beePosition[1]] = '.';

                    Movement(matrix, beePosition, command);

                    isOver = ChecksIsBeeInMatrix(beePosition, n);

                    if (isOver)
                    {
                        Console.WriteLine("The bee got lost!");


                        break;

                    }

                    if (matrix[beePosition[0]][beePosition[1]] == 'f')
                    {
                        matrix[beePosition[0]][beePosition[1]] = 'B';

                        pollinated++;
                    }
                }



                matrix[beePosition[0]][beePosition[1]] = 'B';


            }

            Console.WriteLine(pollinated >=5
                ? $"Great job, the bee managed to pollinate {pollinated} flowers!"
                : $"The bee couldn't pollinate the flowers, she needed {5 - pollinated} flowers more");

            PrintMatrix(matrix);

        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool ChecksIsBeeInMatrix(int[] beePosition, int n)
        {

            if (beePosition[0] < 0 || beePosition[1] < 0)
            {
                return true;
            }

            if (beePosition[0] >= n || beePosition[1] >= n)
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
            int[] beePosition = new int[2];

            bool isFound = false;

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                matrix[row] = data;

                if (!isFound)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'B')
                        {
                            beePosition[0] = row;
                            beePosition[1] = col;

                            isFound = true;

                            break;
                        }
                    }
                }

            }

            return beePosition;
        }
    }
}
