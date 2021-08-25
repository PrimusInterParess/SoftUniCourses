using System;
using System.Linq;

namespace _03.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int entryPoint = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            string possition = string.Empty;

            int topSum = 0;

            if (input == "cheap")
            {
                int leftSum = 0;
                int rightSum = 0;

                int entryPointItem = numbers[entryPoint];

                for (int left = 0; left < entryPoint; left++)
                {
                    if (numbers[left] < entryPointItem)
                    {
                        leftSum += numbers[left];

                    }
                }

                for (int right = entryPoint + 1; right < numbers.Length; right++)
                {
                    if (numbers[right] < entryPointItem)
                    {
                        rightSum += numbers[right];

                    }


                }

                if (leftSum > topSum)
                {
                    topSum = leftSum;
                    possition = "Left";
                }

                if (rightSum > topSum)
                {
                    topSum = rightSum;
                    possition = "Right";
                }

                if (rightSum == leftSum)
                {
                    topSum = leftSum;
                    possition = "Left";
                }



            }
            else if (input == "expensive")
            {
                int leftSum = 0;
                int rightSum = 0;

                int entryPointItem = numbers[entryPoint];

                for (int left = 0; left < entryPoint; left++)
                {
                    if (numbers[left] >= entryPointItem)
                    {
                        leftSum += numbers[left];

                    }
                }

                for (int right = entryPoint + 1; right < numbers.Length; right++)
                {
                    if (numbers[right] >= entryPointItem)
                    {
                        rightSum += numbers[right];

                    }


                }

                if (leftSum > topSum)
                {
                    topSum = leftSum;
                    possition = "Left";
                }

                if (rightSum > topSum)
                {
                    topSum = rightSum;
                    possition = "Right";
                }

                if (rightSum == leftSum)
                {
                    topSum = leftSum;
                    possition = "Left";
                }

            }

            Console.WriteLine($"{possition} - {topSum}");
        }
    }
}
