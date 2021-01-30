using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double changeInCoints = Math.Floor(change * 100);

            int count = 0;

            while (changeInCoints != 0)
            {
                if (changeInCoints >= 200)
                {
                    changeInCoints -= 200;
                    count++;
                }
                else if (changeInCoints >= 100)
                {
                    changeInCoints -= 100;
                    count++;
                }
                else if (changeInCoints >= 50)
                {
                    changeInCoints -= 50;
                    count++;
                }
                else if (changeInCoints >= 20)
                {
                    changeInCoints -= 20;
                    count++;
                }
                else if (changeInCoints >= 10)
                {
                    changeInCoints -= 10;
                    count++;
                }
                else if (changeInCoints >= 5)
                {
                    changeInCoints -= 5;
                    count++;
                }
                else if (changeInCoints >= 2)
                {
                    changeInCoints -= 2;
                    count++;
                }
                else if (changeInCoints >= 1)
                {
                    changeInCoints -= 1;
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
