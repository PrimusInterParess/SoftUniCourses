using System;

namespace _9.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            double sofiaGames = 0.0;
            double sundayGames = 0.0;
            double hollidayGames = 0.0;
            double sumGames = 0.0;


            if (yearType == "normal")
            {
                sofiaGames = 48 - h;
                sundayGames = sofiaGames * 3.0 / 4.0;
                hollidayGames = p * 2.0 / 3.0;
                sumGames = hollidayGames + sundayGames + h;
                Console.WriteLine(Math.Floor(sumGames));
            }
            else
            {
                sofiaGames = 48 - h;
                sundayGames = sofiaGames * 3.0 / 4.0;
                hollidayGames = p * 2.0 / 3.0;
                sumGames = hollidayGames + sundayGames + h;
                double leapYear = (sumGames * 0.15) + sumGames;
                Console.WriteLine(Math.Floor(leapYear));

            }
        }
    }
}
