using System;

namespace _04.EvenPowersOf2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 2;

            for (int i = 0; i <= n; i += 2)

                if (i % 2 == 0)
                {
                    Console.WriteLine(Math.Pow(num, i));
                }
        }
    }
}
