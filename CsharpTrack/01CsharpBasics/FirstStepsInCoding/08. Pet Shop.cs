using System;

namespace _08._Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsNumber = int.Parse(Console.ReadLine());
            int otherAnimals = int.Parse(Console.ReadLine());
            double endSum = dogsNumber * 2.5;
            double endSumA = otherAnimals * 4;

            double total = endSum + endSumA;
           
            Console.WriteLine($"{total} lv.");
        }
    }
}
