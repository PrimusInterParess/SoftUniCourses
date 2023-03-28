using System;

namespace _05.MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMovies = int.Parse(Console.ReadLine());
            double MaxValue = double.MinValue;
            double minValue = double.MaxValue;
            string highestRatedMovie = string.Empty;
            string lowestRatedMovie = string.Empty;
            double sumRating = 0;


            for (int i = 1; i <= numberOfMovies; i++)
            {
                string movieName = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());
                sumRating += rating;


                if (rating > MaxValue)
                {
                    MaxValue = rating;
                    highestRatedMovie = movieName;
                }
                else if (rating < minValue)
                {
                    minValue = rating;
                    lowestRatedMovie = movieName;
                }
            }
            double averageRating = sumRating / numberOfMovies;

            Console.WriteLine($"{highestRatedMovie} is with highest rating: {MaxValue:f1}");
            Console.WriteLine($"{lowestRatedMovie} is with lowest rating: {minValue:f1}");
            Console.WriteLine($"Average rating: {averageRating:f1}");
        }
    }
    }
}
