using System;

namespace GalaxyTravel
{


    class Program
    {
        private const int MIN_STAR_POWER_NEEDED = 50;

        private static char[][] galaxy;

        private static int playerRow;

        private static int playerCol;

        private static int collectedEnergy;

        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            FillingGalaxy(n);


            while (collectedEnergy < MIN_STAR_POWER_NEEDED)
            {
                string direction = Console.ReadLine();

                int nextRow = playerRow;

                int nextCol = playerCol;

                DetermineNextCoordinatesByDirection(direction);

                bool isOutSideOfTheGalaxy = CheckIfPlayerIsOutSideOfTheGalaxy(nextRow, n, nextCol);

                if (isOutSideOfTheGalaxy)
                {
                    galaxy[playerRow][playerCol] = '-';

                    break;
                    ;
                }

                ProceedMove(nextRow, nextCol, n);
            }

            PrintOutput(n);
        }

        private static void PrintOutput(int n)
        {

            if (collectedEnergy >= MIN_STAR_POWER_NEEDED)
            {
                Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
            }
            else
            {
                Console.WriteLine($"Bad news,the spaceship went to the void.");
            }

            Console.WriteLine($"StarPower collected {collectedEnergy}");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join("", galaxy[i]));
            }
        }

        private static bool CheckIfPlayerIsOutSideOfTheGalaxy(int nextRow, int n, int nextCol)
        {

            return (nextRow >= 0 && nextRow < n && nextCol >= 0 && nextCol < n);
        }

        private static void DetermineNextCoordinatesByDirection(string direction)
        {

            int nextRow;
            int nextCol;
            if (direction == "up")
            {


                nextRow = playerRow - 1;

                nextCol = playerCol;




            }
            else if (direction == "down")
            {


                nextRow = playerRow++;
                nextCol = playerCol;

            }
            else if (direction == "left")
            {


                nextRow = playerRow;
                nextCol = playerCol - 1;


            }
            else if (direction == "right")
            {
                nextRow = playerRow;
                nextCol = playerCol - +1;
            }
        }

        private static void ProceedMove(int nextRow, int nextCol, int n)
        {

            char nextSymbol = galaxy[nextRow][playerCol];

            if (char.IsDigit(nextSymbol))
            {
                int startEnergy = (int)nextSymbol - 48;

                collectedEnergy += startEnergy;
            }
            else if (nextSymbol == 'O')
            {
                TravelThroughBlackHoles(nextRow, nextCol, n);
            }


            galaxy[nextRow][nextCol] = 'S';
            galaxy[playerRow][playerCol] = '-';

            playerRow = nextRow;
            playerCol = nextCol;
        }

        private static void TravelThroughBlackHoles(int nextRow, int nextCol, int n)
        {

            galaxy[nextRow][nextCol] = '-';

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    char interSymbol = galaxy[row][col];

                    if (interSymbol == 'O')
                    {
                        nextRow = row;
                        nextCol = col;
                    }
                }
            }
        }

        private static void FillingGalaxy(int n)
        {
            galaxy = new char[n][];


            bool found = false;

            for (int row = 0; row < n; row++)
            {
                char[] curRow = Console.ReadLine().ToCharArray();

                if (!found)
                {
                    for (int col = 0; col < curRow.Length; col++)
                    {
                        if (curRow[col] == 'S')
                        {
                            playerRow = row;
                            playerCol = col;

                            found = true;
                            break;

                        }
                    }
                }

                galaxy[row] = curRow;
            }
        }
    }
}
