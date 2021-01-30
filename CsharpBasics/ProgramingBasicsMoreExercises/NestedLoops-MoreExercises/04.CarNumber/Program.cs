using System;

namespace _04.CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            for (int x1 = numberOne; x1 <= numberTwo; x1++)
            {
                for (int x2 = numberOne; x2 <= numberTwo; x2++)
                {
                    for (int x3 = numberOne; x3 <= numberTwo; x3++)
                    {
                        for (int x4 = numberOne; x4 < numberTwo; x4++)
                        {
                            if (x1 % 2 == 0 && x4 % 2 == 1 && x1 > x4 && (x2 + x3) % 2 == 0 || x1 % 2 == 1 & x4 % 2 == 0 && x1 > x4 && (x2 + x3) % 2 == 0)
                            {
                                Console.Write($"{x1}{x2}{x3}{x4} ");
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
