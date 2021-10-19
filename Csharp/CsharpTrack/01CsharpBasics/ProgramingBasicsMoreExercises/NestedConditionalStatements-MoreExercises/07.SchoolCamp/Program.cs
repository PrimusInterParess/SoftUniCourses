using System;

namespace _07.SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string typeOfGroup = Console.ReadLine();

            double numberOfStudents = double.Parse(Console.ReadLine());
            double numberOfNights = double.Parse(Console.ReadLine());

            double cost = 0;
            string typeOfSport = string.Empty;

            if (season == "Winter")
            {
                if (typeOfGroup == "boys" || typeOfGroup == "girls")
                {
                    cost = (numberOfNights * 9.60) * numberOfStudents;
                    if (typeOfGroup == "boys")
                    {
                        typeOfSport = "Judo";
                    }
                    else
                    {
                        typeOfSport = "Gymnastics";
                    }
                }
                else
                {
                    typeOfSport = "Ski";
                    cost = (numberOfNights * 10) * numberOfStudents;
                }

            }
            else if (season == "Spring")
            {
                if (typeOfGroup == "boys" || typeOfGroup == "girls")
                {
                    cost = (numberOfNights * 7.20) * numberOfStudents;
                    if (typeOfGroup == "boys")
                    {
                        typeOfSport = "Tennis";
                    }
                    else
                    {
                        typeOfSport = "Athletics";
                    }
                }
                else
                {
                    typeOfSport = "Cycling";
                    cost = (numberOfNights * 9.50) * numberOfStudents;
                }

            }
            else
            {
                if (typeOfGroup == "boys" || typeOfGroup == "girls")
                {
                    cost = (numberOfNights * 15) * numberOfStudents;
                    if (typeOfGroup == "boys")
                    {
                        typeOfSport = "Football";
                    }
                    else
                    {
                        typeOfSport = "Volleyball";
                    }
                }
                else
                {
                    typeOfSport = "Swimming";
                    cost = (numberOfNights * 20) * numberOfStudents;
                }

            }
            if (numberOfStudents > 50)
            {
                cost *= 0.50;
            }
            else if (numberOfStudents >= 20 && numberOfStudents < 50)
            {
                cost *= 0.85;
            }
            else if (numberOfStudents >= 10 && numberOfStudents < 20)
            {
                cost *= 0.95;
            }


            Console.WriteLine($"{typeOfSport} {cost:f2} lv.");
        }
    }
}
