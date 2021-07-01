using System;
using System.Linq;

namespace Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] matrix = LoadingMatrix();

            int collectTokens = 0;

            int opponent = 0;

          

            while (true)
            {

                string[] data = GetCommand();

                string command = data[0];

                if (command == "Gong")
                {
                    break;

                }

                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);

                if (command == "Find")
                {


                    if (ValidateIndexes(row, col, matrix))
                    {
                        string symbol = TryToCollect(row, col, matrix);

                        if (symbol == "T")
                        {
                            collectTokens++;
                            matrix[row][col] = "-";
                            
                        }
                    }


                }

                if (command == "Opponent")
                {
                    string direction = data[3];

                    int[] positions = new[] { row, col };

                    if (ValidateIndexes(row, col, matrix))
                    {
                        string symbol = TryToCollect(row, col, matrix);

                        if (symbol == "T")
                        {
                            opponent++;
                            matrix[row][col] = "-";

                        }

                        for (int i = 0; i < 3; i++)
                        {
                            Movement(positions,direction);

                            int rowO = positions[0];
                            int colO = positions[1];

                            if (!ValidateIndexes(rowO,colO,matrix))
                            {
                                break;
                            }

                            symbol = TryToCollect(rowO, colO, matrix);

                            if (symbol == "T")
                            {
                                opponent++;
                                matrix[rowO][colO] = "-";

                            }
                        }


                    }
                }

            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(" ",matrix[i]));
            }

            Console.WriteLine($"Collected tokens: {collectTokens}");
            Console.WriteLine($"Opponent's tokens: {opponent}");





        }

        private static void Movement(int[] positions, string direction)
        {
            int row = 0;
            int col = 0;

            if (direction == "up")
            {
                row--;
            }

            if (direction == "down")
            {
                row++;
            }

            if (direction == "left")
            {
                col--;
            }

            if (direction == "right")
            {
                col++;
            }

            positions[0] += row;
            positions[1] += col;


        }

        private static string TryToCollect(int row, int col, string[][] matrix)
        {
            if (matrix[row][col] == "T")
            {
                return "T";
            }
            else
            {
                return "-";
            }

        }

        private static bool ValidateIndexes(int row, int col, string[][] matrix)
        {
            if((row >= 0 &&
               col >= 0 &&
               row < matrix.Length &&
               col < matrix[row].Length))
                {
                    return true;
                }
            

            return false;
        }

        private static string[] GetCommand()
        {
            return Console.ReadLine().Split();
        }

        private static string[][] LoadingMatrix()
        {
            int n = int.Parse(Console.ReadLine());

            string[][] matrix = new String[n][];

            for (int row = 0; row < n; row++)
            {
                string[] data = Console.ReadLine().Split().ToArray();

                matrix[row] = data;

            }

            return matrix;


        }
    }
}
