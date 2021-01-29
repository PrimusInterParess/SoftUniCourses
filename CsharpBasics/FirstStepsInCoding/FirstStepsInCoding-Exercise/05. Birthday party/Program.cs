using System;

namespace _05._Birthday_party
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallRent = double.Parse(Console.ReadLine());

            double cake = hallRent * 20 / 100;

            double drinks = cake * 0.55;

            double animator = hallRent / 3;

            double summury = hallRent + cake + drinks + animator;

            Console.WriteLine(summury);
        }
    }
}
