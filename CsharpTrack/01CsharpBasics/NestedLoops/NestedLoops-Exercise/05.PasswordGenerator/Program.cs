using System;

namespace _05.PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int x1 = 1; x1 < n; x1++)
            {
                for (int x2 = 1; x2 < n; x2++)
                {
                    for (char x3 = 'a'; x3 < 'a' + l; x3++)
                    {
                        for (char x4 = 'a'; x4 < 'a' + l; x4++)
                        {
                            for (int x5 = Math.Max(x1, x2) + 1; x5 <= n; x5++)
                            {

                                Console.Write($"{x1}{x2}{x3}{x4}{x5} ");


                            }
                        }
                    }
                }
            }
        }
    }
}
