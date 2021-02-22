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
                    if (bunnyLair[position[0], position[1] + 1] == '.')
                    {
                        bunnyLair[position[0], position[1] + 1] = 'P';

                        bunnyLair[position[0], position[1]] = '.';

                        position[1] += 1;

                    }
                    else if (bunnyLair[position[0], position[1] + 1] == 'B')
                    {
                        dead = true;

                        bunnyLair[position[0], position[1]] = '.';

                        position[1] += 1;


                    }
                    else if (position[1] + 1 == cols)
                    {
                        bunnyLair[position[0], position[1]] = '.';

                        win = true;
                        break;

                    }

                    dead = PopulatiingLairWithBunnies(bunnyLair, position);

                    if (dead)
                    {
                        break;

                    }

                }
                else if (direction == 'L')
                {
                    if (bunnyLair[position[0], position[1] - 1] == '.')
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

                        break;
                    }
                    else if (position[1] - 1 < 0)
                    {
                        bunnyLair[position[0], position[1]] = '.';

                        win = true;
                        break;

                    }

                    dead = PopulatiingLairWithBunnies(bunnyLair, position);

                    if (dead)
                    {
                        break;

                    }

                }
                else if (direction == 'U')
                {
                    if (bunnyLair[position[0] - 1, position[1]] == '.')
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

                        break;
                    }
                    else if (position[0] - 1 < 0)
                    {
                        bunnyLair[position[0], position[1]] = '.';

                        win = true;
                        break;

                    }

                    dead = PopulatiingLairWithBunnies(bunnyLair, position);

                    if (dead)
                    {
                        break;

                    }

                }
                else if (direction == 'D')
                {
                    if (bunnyLair[position[0] + 1, position[1]] == '.')
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

                        break;
                    }
                    else if (position[0] - 1 < 0)
                    {
                        bunnyLair[position[0], position[1]] = '.';

                        win = true;
                        break;

                    }

                    dead = PopulatiingLairWithBunnies(bunnyLair, position);

                    if (dead)
                    {
                        break;

                    }

                }

            }





        }

        static bool PopulatiingLairWithBunnies(char[,] bunnyLair, int[] positions)
        {

            bool gameOver = false;

            for (int row = 0; row < bunnyLair.GetLength(0); row++)
            {
                for (int col = 0; col < bunnyLair.GetLength(1); col++)
                {
                    if (bunnyLair[row, col] == 'B')
                    {
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

                }
            }

            return gameOver;
        }
    }
}
