using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            char[,] bunnyLair = new char[rows, cols];

            List<int[]> bunniesPositions = new List<int[]>();

            int[] position = new int[2];

            for (int row = 0; row < rows; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    bunnyLair[row, col] = data[col];

                    if (bunnyLair[row, col] == 'P')
                    {
                        position[0] = row;
                        position[1] = col;
                    }

                }
            }

            Queue<char> directions = new Queue<char>(Console.ReadLine().ToCharArray());

            bool dead = false;

            bool win = false;

            while (true)
            {
                char direction = directions.Dequeue();

                if (direction == 'R')
                {
                    if (position[1] + 1 > bunnyLair.GetLength(1))
                    {
                        bunnyLair[position[0], position[1]] = '.';

                        win = true;

                    }

                    else if (bunnyLair[position[0], position[1] + 1] == '.' && position[1] < bunnyLair.GetLength(1))
                    {
                        bunnyLair[position[0], position[1] + 1] = 'P';

                        bunnyLair[position[0], position[1]] = '.';

                        position[1] += 1;

                    }
                    else if (bunnyLair[position[0], position[1] + 1] == 'B' && position[1] < bunnyLair.GetLength(1))
                    {
                        dead = true;

                        bunnyLair[position[0], position[1]] = '.';

                        position[1] += 1;


                    }

                    FindingBunnies(bunnyLair, bunniesPositions);
                    PopulatiingLairWithBunnies(bunnyLair, position, win, bunniesPositions);

                }
                else if (direction == 'L')
                {
                    if (position[1] - 1 < 0)
                    {
                        bunnyLair[position[0], position[1]] = '.';

                        win = true;

                    }

                    else if (bunnyLair[position[0], position[1] - 1] == '.')
                    {
                        bunnyLair[position[0], position[1] - 1] = 'P';

                        bunnyLair[position[0], position[1]] = '.';

                        position[1] -= 1;

                    }
                    else if (bunnyLair[position[0], position[1] - 1] == 'B')
                    {
                        dead = true;

                        bunnyLair[position[0], position[1]] = '.';

                        position[1] -= 1;


                    }

                    FindingBunnies(bunnyLair, bunniesPositions);
                    PopulatiingLairWithBunnies(bunnyLair, position, win, bunniesPositions);

                }
                else if (direction == 'U')
                {
                    if (position[0] - 1 < 0)
                    {
                        bunnyLair[position[0], position[1]] = '.';

                        win = true;

                    }
                    else if (bunnyLair[position[0] - 1, position[1]] == '.')
                    {
                        bunnyLair[position[0] - 1, position[1]] = 'P';

                        bunnyLair[position[0], position[1]] = '.';

                        position[0] -= 1;

                    }
                    else if (bunnyLair[position[0] - 1, position[1]] == 'B')
                    {
                        dead = true;

                        bunnyLair[position[0], position[1]] = '.';

                        position[0] -= 1;


                    }

                    FindingBunnies(bunnyLair, bunniesPositions);
                    PopulatiingLairWithBunnies(bunnyLair, position, win, bunniesPositions);

                }
                else if (direction == 'D')
                {
                    if (position[0] + 1 > bunnyLair.GetLength(0))
                    {
                        bunnyLair[position[0], position[1]] = '.';

                        win = true;

                    }

                    else if (bunnyLair[position[0] + 1, position[1]] == '.')
                    {
                        bunnyLair[position[0] + 1, position[1]] = 'P';

                        bunnyLair[position[0], position[1]] = '.';

                        position[0] += 1;

                    }
                    else if (bunnyLair[position[0] + 1, position[1]] == 'B')
                    {
                        dead = true;

                        bunnyLair[position[0], position[1]] = '.';

                        position[0] += 1;


                    }

                    FindingBunnies(bunnyLair, bunniesPositions);
                    PopulatiingLairWithBunnies(bunnyLair, position, win, bunniesPositions);

                }

                if (win || dead)
                {
                    break;

                }


            }



            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(bunnyLair[row, col]);
                }

                Console.WriteLine();
            }

            if (win)
            {
                Console.WriteLine($"won: {position[0]} {position[1]}");
            }
            else if (dead)
            {
                Console.WriteLine($"dead: {position[0]} {position[1]}");

            }

        }

        private static void FindingBunnies(char[,] bunnyLair, List<int[]> bunniesPositions)
        {
            for (int row = 0; row < bunnyLair.GetLength(0); row++)
            {


                for (int col = 0; col < bunnyLair.GetLength(1); col++)
                {


                    if (bunnyLair[row, col] == 'B')
                    {
                        bunniesPositions.Add(new[] { row, col });
                    }
                }
            }
        }

        static bool PopulatiingLairWithBunnies(char[,] bunnyLair, int[] positions, bool win, List<int[]> bunnIntsList)
        {
            bool gameOver = false;

            foreach (var bunnyPosition in bunnIntsList)
            {

                int row = bunnyPosition[0];
                int col = bunnyPosition[1];


                if (row - 1 >= 0 && bunnyLair[row - 1, col] == 'P')
                {
                    bunnyLair[row - 1, col] = 'B';
                    gameOver = true;
                }
                else if (row - 1 >= 0 && bunnyLair[row - 1, col] == '.')
                {
                    bunnyLair[row - 1, col] = 'B';
                }

                if (row + 1 < bunnyLair.GetLength(0) && bunnyLair[row + 1, col] == 'P')
                {
                    bunnyLair[row + 1, col] = 'B';
                    gameOver = true;
                }
                else if (row + 1 < bunnyLair.GetLength(0) && bunnyLair[row + 1, col] == '.')
                {
                    bunnyLair[row + 1, col] = 'B';
                }


                if (col + 1 < bunnyLair.GetLength(1) && bunnyLair[row, col + 1] == 'P')
                {
                    bunnyLair[row, col + 1] = 'B';
                    gameOver = true;
                }
                else if (col + 1 < bunnyLair.GetLength(1) && bunnyLair[row, col + 1] == '.')
                {
                    bunnyLair[row, col + 1] = 'B';
                }

                if (col - 1 >= 0 && bunnyLair[row, col - 1] == 'P')
                {
                    bunnyLair[row, col - 1] = 'B';
                    gameOver = true;
                }
                else if (col - 1 >= 0 && bunnyLair[row, col - 1] == '.')
                {
                    bunnyLair[row, col - 1] = 'B';
                }




            }

            if (win)
            {
                return win;
            }
            else if (gameOver)
            {
                return gameOver;
            }

            return gameOver;
        }
    }
}
