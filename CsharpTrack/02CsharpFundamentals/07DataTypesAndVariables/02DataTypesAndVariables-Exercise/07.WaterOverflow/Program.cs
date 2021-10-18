using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPours = int.Parse(Console.ReadLine());
            int capacity = 255;
            int sumOfPours = 0;


            for (int i = 1; i <= numberOfPours; i++)
            {
                int pour = int.Parse(Console.ReadLine());

                if (pour + sumOfPours > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");


                }
                else
                {
                    sumOfPours += pour;
                }


            }

            Console.WriteLine(sumOfPours);
        }
    }
}
