using System;

namespace _09._Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareMeter = double.Parse(Console.ReadLine());
            double SquareMeterPrice = 7.61;
            double Price = squareMeter * SquareMeterPrice;
            double discount = Price * 0.18;
            double TotalPrice = Price - discount;

            Console.WriteLine($"The final price is: {TotalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");


            
        }
    }
}
