using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] gardenSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] garden = new int[gardenSize[0], gardenSize[1]];

            string input = string.Empty;

            Dictionary<int, int[]> flowersPositions = new Dictionary<int, int[]>();

            int key = 1;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] data = input.Split().Select(int.Parse).ToArray();

                int row = data[0];
                int col = data[1];

                if (!IndexValidation(row, col, gardenSize[0]))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                flowersPositions[key] = new int[2];

                flowersPositions[key] = data;
                key++;


            }

            BloomingGarden(garden, flowersPositions);

            PrintGardern(garden);


        }

        private static void PrintGardern(int[,] garden)
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write(garden[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void BloomingGarden(int[,] garden, Dictionary<int, int[]> flowersPositions)
        {
            for (int i = 0; i < flowersPositions.Count; i++)
            {
                int row = flowersPositions[i + 1][0];
                int col = flowersPositions[i + 1][1];

                Blooming(garden, row, col);

            }

           
        }

        private static void Blooming(int[,] garden, int row, int col)
        {
            int currRow = row;
            int currCol = col;
            
            //down

            while (currRow < garden.GetLength(0))
            {
                if (garden[currRow, col] == 0)
                {
                    garden[currRow, col]++;

                }
                else
                {
                    garden[currRow, col]++;
                }

                currRow++;
            }

            currRow = row;

            //up
            while (currRow > 0)
            {

                if (garden[currRow - 1, col] == 0)
                {
                    garden[currRow - 1, col]++;

                }
                else
                {
                    garden[currRow - 1, col]++;
                }

                currRow--;


            }

            



            while (currCol > 0)
            {
                if (garden[row, currCol - 1] == 0)
                {
                    garden[row, currCol - 1] = 1;

                }
                else
                {
                    garden[row, currCol - 1]++;
                }

                currCol--;

            }

            

            currCol = col;

            while (currCol < garden.GetLength(1) - 1)
            {



                if (garden[row, currCol + 1] == 0)
                {
                    garden[row, currCol + 1] = 1;

                }
                else
                {
                    garden[row, currCol + 1]++;
                }

                currCol++;


            }

            
        }


        private static bool IndexValidation(int row, int col, int i)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }

            if (row >= i || col >= i)
            {
                return false;
            }

            return true;
        }
    }
}
