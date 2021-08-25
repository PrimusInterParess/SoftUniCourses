using System;

namespace _03.MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractLenght = Console.ReadLine();
            string contractType = Console.ReadLine();
            string addInternet = Console.ReadLine();
            double monthsToPay = double.Parse(Console.ReadLine());
            double discount = 0;

            double monthlyFee = 0;

            if (contractLenght == "one")
            {
                switch (contractType)
                {
                    case "Small":
                        monthlyFee = 9.98;
                        break;
                    case "Middle":
                        monthlyFee = 18.99;
                        break;
                    case "Large":
                        monthlyFee = 25.98;
                        break;
                    case "ExtraLarge":
                        monthlyFee = 35.99;
                        break;
                }
            }
            else if (contractLenght == "two")
            {
                switch (contractType)
                {
                    case "Small":
                        monthlyFee = 8.58;
                        break;
                    case "Middle":
                        monthlyFee = 17.09;
                        break;
                    case "Large":
                        monthlyFee = 23.59;
                        break;
                    case "ExtraLarge":
                        monthlyFee = 31.79;
                        break;
                }
            }
            if (addInternet == "yes")
            {
                if (monthlyFee <= 10)
                {
                    monthlyFee += 5.50;
                }
                else if (monthlyFee > 10 && monthlyFee <= 30)
                {
                    monthlyFee += 4.35;
                }
                else if (monthlyFee > 30)
                {
                    monthlyFee += 3.85;

                }
            }

            if (contractLenght == "two")
            {
                discount = monthlyFee * 0.0375;
            }
            double total = (monthlyFee - discount) * monthsToPay;

            Console.WriteLine($"{total:F2} lv.");
        }


    }
}