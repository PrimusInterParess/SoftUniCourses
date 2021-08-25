using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string input = string.Empty;

           

            while (true)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = data[0];


                if (data.Length == 2)
                {
                    if (data[0] == "Move")
                    {
                        int index = int.Parse(data[1]);
                        word = MovingLetter(word, index);
                    }

                    if (data[0] == "Reverse")
                    {
                        word = Reverse(word, data[1]);
                    }
                }
                else if (data.Length == 3)
                {
                    if (data[0] == "Insert" && data[1] == "Space")
                    {
                        word = InsertSpace(word, int.Parse(data[2]));
                    }

                    if (data[0] == "Exchange" && data[1] == "Tiles")
                    {
                        word = Exchange(word, data[2]);

                        char[] arr = word.ToCharArray();

                        Console.WriteLine(string.Join(' ', arr));



                        return;
                    }
                }
                else if (data.Length == 1)
                {
                    if (data[0] == "Pass")
                    {
                        

                        char[] arr = word.ToCharArray();

                        Console.WriteLine(string.Join(' ', arr));

                        return;
                    }

                    if (data[0] == "Play")
                    {
                        word = CheckForSpace(word);

                        Console.WriteLine($"You are playing with the word {word}.");
                        return;
                    }
                }


            }



        }

        private static string CheckForSpace(string word)
        {
            bool hasSpace = word.Contains(" ");

            if (hasSpace)
            {
                string[] words = word.Split(" ");

                return words[0];
            }


            return word;

        }

        private static string Exchange(string word, string s)
        {
            word = word.Remove(0, s.Length);

            word = word.Insert(0, s);

            return word;
        }

        private static string Reverse(string word, string s)
        {
            if (word.Contains(s))
            {
                int index = word.IndexOf(s);

                char[] charArr = word.Substring(index, s.Length).ToCharArray();

                word = word.Remove(index, s.Length);

                Array.Reverse(charArr);

                string reversed = string.Join("", charArr);

                word = word.Insert(word.Length, reversed);

            }


            return word;


        }

        private static string InsertSpace(string word, int parse)
        {
            word = word.Insert(parse, " ");

            return word;
        }

        private static string MovingLetter(string word, int index)
        {


            if (index >= 0 && index <= word.Length - 1)
            {
                char toInsert = word[index];

                word = word += toInsert;

                word = word.Remove(index, 1);

                return word;
            }



            return word;
        }


    }



}
