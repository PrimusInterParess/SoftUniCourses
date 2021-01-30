using System;

namespace _01.ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            double bitcoins = double.Parse(Console.ReadLine());
            double yuans = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine());

            double bitCoinsTotal = bitcoins * 1168;
            double yuanIntoLeva = (yuans * 0.15) * 1.76;
            double totalInToEuro = (yuanIntoLeva + bitCoinsTotal) / 1.95;

            double total = (totalInToEuro - ((commision / 100) * totalInToEuro));
            Console.WriteLine($"{total:f2}");
        }
    }
}
