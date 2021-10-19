using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWorm
{
    class Program
    {

        static void Main(string[] args)
        {
            char[] initialWord = Console.ReadLine().ToCharArray();

            Stack<char> word = new Stack<char>(initialWord);

            int n = int.Parse(Console.ReadLine());

            char[][] field = new char[n][];

            bool isFound = false;

            int playerRow = -1;

            int playerCol = -1;

            InitializeField(n, ref isFound, field, ref playerRow, ref playerCol);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {

                if (command == "up")
                {

                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;

                        char symbol = field[playerRow][playerCol];

                        if (Char.IsLetter(symbol))
                        {
                            word.Push(symbol);
                        }

                        field[playerRow][playerCol] = 'P';

                        field[playerRow + 1][playerCol] = '-';
                    }
                    else
                    {
                        Punish(word);
                    }

                }
                else if (command == "down")
                {
                    if (playerRow + 1 < n)
                    {
                        playerRow++;

                        char symbol = field[playerRow][playerCol];

                        if (Char.IsLetter(symbol))
                        {
                            word.Push(symbol);
                        }

                        field[playerRow][playerCol] = 'P';

                        field[playerRow - 1][playerCol] = '-';
                    }
                    else
                    {
                        Punish(word);

                    }
                }
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;

                        char symbol = field[playerRow][playerCol];

                        if (char.IsLetter(symbol))
                        {
                            word.Push(symbol);
                        }

                        field[playerRow][playerCol] = 'P';
                        field[playerRow][playerCol++] = '-';

                    }
                    else
                    {
                        Punish(word);

                    }
                }
                else if (command == "right")
                {
                    if (playerCol++ < n)
                    {
                        playerCol++;

                        char symbol = field[playerRow][playerCol];

                        if (char.IsLetter(symbol))
                        {
                            word.Push(symbol);
                        }

                        field[playerRow][playerCol] = 'P';
                        field[playerRow][playerCol--] = '-';
                    }
                    else
                    {
                        Punish(word);
                    }
                }
            }

            Console.WriteLine(string.Join("",word.Reverse()));

            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }

                Console.WriteLine();
            }

        }

        private static void Punish(Stack<char> word)
        {

            if (word.Count > 0)
            {
                word.Pop();
            }
        }

        private static void InitializeField(int n, ref bool isFound, char[][] field, ref int playerRow, ref int playerCol)
        {

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().ToCharArray();

                if (!isFound)
                {
                    for (int col = 0; col < currRow.Length; col++)
                    {
                        if (currRow[col] == 'P')
                        {
                            playerRow = row;
                            playerCol = col;
                            isFound = true;
                            break;

                        }
                    }
                }

                field[row] = currRow;

            }
        }
    }
}
