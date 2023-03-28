using System;

namespace _12.TheSongOfTheWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlValue = int.Parse(Console.ReadLine());

            int A = 0;
            int B = 0;
            int C = 0;
            int D = 0;

            int counter = 0;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (controlValue == a * b + d * c)
                            {
                                if (a < b && c > d)
                                {
                                    Console.Write($"{a}{b}{c}{d} ");

                                    counter++;

                                    if (counter == 4)
                                    {
                                        A = a;
                                        B = b;
                                        C = c;
                                        D = d;

                                    }

                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();

            if (counter >= 4)
            {
                Console.WriteLine($"Password: {A}{B}{C}{D}");
            }
            else
            {
                Console.WriteLine("No!");
            }
        }
    }
}
