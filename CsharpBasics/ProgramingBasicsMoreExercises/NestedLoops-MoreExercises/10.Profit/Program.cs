using System;

namespace _10.Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int oneCoins = int.Parse(Console.ReadLine());
            int twoCoins = int.Parse(Console.ReadLine());
            int fiveBill = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i <= oneCoins; i++)
            {
                for (int j = 0; j <= twoCoins; j++)
                {
                    for (int k = 0; k <= fiveBill; k++)
                    {
                        if (i * 1 + j * 2 + k * 5 == sum)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
