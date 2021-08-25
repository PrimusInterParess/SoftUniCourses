using System;

namespace _03.LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int x1 = 1; x1 < 10; x1++)
            {
                for (int x2 = 1; x2 < 10; x2++)
                {
                    for (int x3 = 1; x3 < 10; x3++)
                    {
                        for (int x4 = 1; x4 < 10; x4++)
                        {
                            if ((x1 + x2) == (x3 + x4) && number % (x1 + x2) == 0)
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
