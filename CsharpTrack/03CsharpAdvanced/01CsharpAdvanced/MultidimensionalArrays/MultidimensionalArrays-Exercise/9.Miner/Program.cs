using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            Queue<string> directions = new Queue<string>(Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray());

            int[] startPositionAndCoalCount = new int[3];

            char[,] mineField = PopulatesMatrix(dimentions, startPositionAndCoalCount);

            if (CollectsCoals(directions, mineField, startPositionAndCoalCount))
            {
                Console.WriteLine($"Game over! ({startPositionAndCoalCount[0]}, {startPositionAndCoalCount[1]})");
            }

            else  if (startPositionAndCoalCount[2] == 0)
            {
                Console.WriteLine($"You collected all coals!({ startPositionAndCoalCount[0]}, { startPositionAndCoalCount[1]})");
            }
            else if (directions.Count == 0 && startPositionAndCoalCount[2] != 0)
            {
                Console.WriteLine($"{startPositionAndCoalCount[2]} coals left. ({startPositionAndCoalCount[0]}, {startPositionAndCoalCount[1]})");
            }
            

        }


        static char[,] PopulatesMatrix(int dimentions, int[] startPosition)
        {

            char[,] mineField = new char[dimentions, dimentions];

            for (int row = 0; row < mineField.GetLength(0); row++)
            {
                char[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < mineField.GetLength(1); col++)
                {
                    mineField[row, col] = data[col];

                    if (mineField[row, col] == 's')
                    {
                        startPosition[0] = row;
                        startPosition[1] = col;
                    }

                    if (mineField[row, col] == 'c')
                    {
                        startPosition[2] += 1;
                    }

                }
            }

            return mineField;

        }

        static bool CollectsCoals(Queue<string> directionsQueue, char[,] mineField, int[] startPosition)
        {
            bool gameOver = false;

            while (directionsQueue.Count != 0)
            {
                string direction = directionsQueue.Dequeue();

                int row = startPosition[0];

                int col = startPosition[1];

                if (row >= 0 && col >= 0 && row < mineField.GetLength(0) && col < mineField.GetLength(1))
                {
                    if (direction == "up" && row - 1 >= 0)
                    {
                        if (mineField[row - 1, col] == '*')
                        {
                            mineField[row - 1, col] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row - 1;
                            startPosition[1] = col;
                        }
                        else if (mineField[row - 1, col] == 'c')
                        {
                            startPosition[2]--;
                            mineField[row - 1, col] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row - 1;
                            startPosition[1] = col;

                            if (startPosition[2] == 0)
                            {

                                break;
                            }
                        }
                        else if (mineField[row - 1, col] == 'e')
                        {
                            mineField[row - 1, col] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row - 1;
                            startPosition[1] = col;

                            gameOver = true;
                            break;
                        }
                    }
                    else if (direction == "right" && col + 1 < mineField.GetLength(1))
                    {
                        if (mineField[row, col + 1] == '*')
                        {
                            mineField[row, col + 1] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row;
                            startPosition[1] = col + 1;
                        }
                        else if (mineField[row, col + 1] == 'c')
                        {
                            startPosition[2]--;
                            mineField[row, col + 1] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row;
                            startPosition[1] = col + 1;

                            if (startPosition[2] == 0)
                            {

                                break;
                            }
                        }
                        else if (mineField[row, col + 1] == 'e')
                        {
                            mineField[row, col + 1] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row;
                            startPosition[1] = col + 1;

                            gameOver = true;
                            break;
                        }

                    }
                    else if (direction == "left" && col - 1 >= 0)
                    {
                        if (mineField[row, col - 1] == '*')
                        {
                            mineField[row, col - 1] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row;
                            startPosition[1] = col - 1;
                        }
                        else if (mineField[row, col - 1] == 'c')
                        {
                            startPosition[2]--;
                            mineField[row, col - 1] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row;
                            startPosition[1] = col - 1;

                            if (startPosition[2] == 0)
                            {

                                break;
                            }
                        }
                        else if (mineField[row, col - 1] == 'e')
                        {
                            mineField[row, col - 1] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row;
                            startPosition[1] = col - 1;
                            gameOver = true;
                            break;
                        }

                    }
                    else if (direction == "down" && row + 1 < mineField.GetLength(0))
                    {
                        if (mineField[row + 1, col] == '*')
                        {
                            mineField[row + 1, col] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row + 1;
                            startPosition[1] = col;
                        }
                        else if (mineField[row + 1, col] == 'c')
                        {
                            startPosition[2]--;
                            mineField[row + 1, col] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row + 1;
                            startPosition[1] = col;

                            if (startPosition[2] == 0)
                            {

                                break;
                            }
                        }
                        else if (mineField[row + 1, col] == 'e')
                        {
                            mineField[row + 1, col] = 's';
                            mineField[row, col] = '*';

                            startPosition[0] = row + 1;
                            startPosition[1] = col;
                            gameOver = true;
                            break;
                        }
                    }
                }


            }

            return gameOver;

        }
    }


}
