using System;

namespace _06.FavoriteMovie
{
    class Program
    {
        static void Main(string[] args)
        {

            int movieCounter = 0;
            int bestMovie = int.MinValue;
            string theBestMovie = string.Empty;

            while (movieCounter != 7)
            {
                string movies = Console.ReadLine();


                if (movies == "STOP")
                {
                    break;
                }

                int sum = 0;
                movieCounter++;


                for (int i = 0; i < movies.Length; i++)
                {
                    sum += movies[i];

                    if (Char.IsUpper(movies[i]))
                    {
                        sum -= movies.Length;
                    }
                    else if (char.IsLower(movies[i]))
                    {
                        sum -= (movies.Length * 2);
                    }
                }
                if (sum > bestMovie)
                {
                    bestMovie = sum;
                    theBestMovie = movies;
                }
            }
            if (movieCounter == 7)
            {
                Console.WriteLine($"The limit is reached.");
                Console.WriteLine($"The best movie for you is {theBestMovie} with {bestMovie} ASCII sum.");
            }
            else
            {
                Console.WriteLine($"The best movie for you is {theBestMovie} with {bestMovie} ASCII sum.");

            }
        }
    }
}
