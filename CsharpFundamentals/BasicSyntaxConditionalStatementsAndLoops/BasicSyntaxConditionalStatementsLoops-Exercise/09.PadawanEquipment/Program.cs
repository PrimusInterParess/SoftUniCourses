using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyAmount = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());

            double lightSaberPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double lightSaberPriceTotal = (lightSaberPrice * Math.Ceiling(numberOfStudents * 1.10));
            double robesPriceTotal = robesPrice * numberOfStudents;
            double beltsPriceTotal = beltsPrice * numberOfStudents;

            int freeBelt = numberOfStudents / 6;

            double total = lightSaberPriceTotal + robesPriceTotal + (beltsPriceTotal - (freeBelt * beltsPrice));

            if (moneyAmount >= total)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else if (moneyAmount < total)
            {
                Console.WriteLine($"Ivan Cho will need {total - moneyAmount:f2}lv more.");
            }
        }
    }
}
