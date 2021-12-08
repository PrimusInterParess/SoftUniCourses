using System;

namespace _11.CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());

            int toyCount = 0;
            double savedMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savedMoney += i * 5;
                    savedMoney--;
                }
                else
                {
                    toyCount++;
                }
            }

            savedMoney += toyCount * toyPrice;
            if (savedMoney >= washingMachinePrice)
            {
                double moneyLeft = savedMoney - washingMachinePrice;
                Console.WriteLine($"Yes! {moneyLeft:f2}");
            }
            else
            {
                double diff = washingMachinePrice - savedMoney;
                Console.WriteLine($"No! {diff:f2}");
            }
        }
    }
}
