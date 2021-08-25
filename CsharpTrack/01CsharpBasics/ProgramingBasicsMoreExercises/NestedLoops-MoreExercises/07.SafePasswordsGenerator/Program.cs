using System;

namespace _07.SafePasswordsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPasswords = int.Parse(Console.ReadLine());

            int x1 = 35;
            int x2 = 64;

            int passwordCounter = 0;

            for (int d1 = 1; d1 <= a; d1++)
            {
                for (int d2 = 1; d2 <= b; d2++)
                {
                    Console.Write($"{(char)x1}{(char)x2}{d1}{d2}{(char)x2}{(char)x1}|");

                    passwordCounter++;

                    x1++;
                    x2++;

                    if (x1 > 55)
                    {
                        x1 = 35;
                    }
                    if (x2 > 96)
                    {
                        x2 = 64;
                    }

                    if (passwordCounter == maxPasswords)
                    {
                        break;
                    }
                }
                if (passwordCounter == maxPasswords)
                {
                    break;
                }
            }
        }
    }
}
