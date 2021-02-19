using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            int[,] diagonalDifference = new int[dimentions, dimentions];

            int leftToRight = 0;
            int rightToLeft = 0;


            for (int row = 0; row < dimentions; row++)
            {
                int[] numbersToAdd = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < dimentions; col++)
                {
                    diagonalDifference[row, col] = numbersToAdd[col];
                }
            }

            for (int row = 0; row < dimentions; row++)
            {
                for (int col = 0; col < dimentions; col++)
                {
                    if (row == 0)
                    {
                        leftToRight += diagonalDifference[row, col];
                        row++;
                    }

                    else if (col < dimentions)
                    {
                        leftToRight += diagonalDifference[row, col];
                        if (row < dimentions)
                        {
                            row++;
                        }

                    }
                }
            }

            for (int row = 0; row < dimentions; row++)
            {
                for (int col = dimentions - 1; col >= 0; col--)
                {
                    if (col == dimentions - 1)
                    {
                        rightToLeft += diagonalDifference[row, col];
                        row++;
                    }

                    else if (col >= 0)
                    {
                        rightToLeft += diagonalDifference[row, col];

                        if (row < dimentions)
                        {
                            row++;
                        }

                    }
                }
            }

            Console.WriteLine(Math.Abs(leftToRight-rightToLeft));


        }
    }
}
