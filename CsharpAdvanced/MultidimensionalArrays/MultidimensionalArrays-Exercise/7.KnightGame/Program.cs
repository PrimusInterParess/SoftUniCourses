using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            char[,] KnightMatrix = new char[dimensions, dimensions];

            for (int row = 0; row < dimensions; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < dimensions; col++)
                {
                    KnightMatrix[row, col] = data[col];
                }
            }

            int maxHit = 0;
            int rowK = -1;
            int colK = -1;
            int removed = 0;

            for (int row = 0; row < dimensions; row++)
            {
                for (int col = 0; col < dimensions; col++)
                {
                    int hit = 0;

                    if (KnightMatrix[row, col] == 'K')
                    {

                        if (row + 2 < dimensions && col - 1 >= 0)
                        {
                            if (KnightMatrix[row, col] == KnightMatrix[row + 2, col - 1])
                            {
                                hit++;
                            }
                        }

                        if (row + 2 < dimensions && col + 1 < dimensions)
                        {
                            if (KnightMatrix[row, col] == KnightMatrix[row + 2, col + 1])
                            {
                                hit++;
                            }
                        }



                        if (row + 1 < dimensions && col + 2 < dimensions)
                        {
                            if (KnightMatrix[row, col] == KnightMatrix[row + 1, col + 2])
                            {
                                hit++;
                            }
                        }


                        if (row + 1 < dimensions && col - 2 >= 0)
                        {
                            if (KnightMatrix[row, col] == KnightMatrix[row + 1, col - 2])
                            {
                                hit++;
                            }
                        }


                        if (row - 2 >= 0 && col + 1 < dimensions)
                        {
                            if (KnightMatrix[row, col] == KnightMatrix[row - 2, col + 1])
                            {
                                hit++;
                            }
                        }

                        if (row - 2 >= 0 && col - 1 >= 0)
                        {
                            if (KnightMatrix[row, col] == KnightMatrix[row - 2, col - 1])
                            {
                                hit++;
                            }
                        }

                        if (row - 1 >= 0 && col - 2 >= 0)
                        {
                            if (KnightMatrix[row, col] == KnightMatrix[row - 1, col - 2])
                            {
                                hit++;
                            }
                        }

                        if (row - 1 >= 0 && col + 2 < dimensions)
                        {
                            if (KnightMatrix[row, col] == KnightMatrix[row - 1, col + 2])
                            {
                                hit++;
                            }
                        }

                        if (hit > maxHit)
                        {
                            maxHit = hit;
                            rowK = row;
                            colK = col;


                        }
                    }
                }

                if (row == dimensions - 1 && maxHit > 0)
                {
                    KnightMatrix[rowK, colK] = '0';
                    removed++;
                    row = 0;
                    rowK = -1;
                    colK = -1;

                    maxHit = 0;
                }
            }

            Console.WriteLine(removed);
        }



    }
}

