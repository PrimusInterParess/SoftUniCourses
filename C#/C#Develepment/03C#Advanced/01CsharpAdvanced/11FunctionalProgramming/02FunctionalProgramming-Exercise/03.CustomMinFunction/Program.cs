using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minFunc = (arr) =>
            {
                int minNum = int.MinValue;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < minNum)
                    {
                        minNum = arr[i];
                    }
                }

                return minNum;

            };

            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            Console.WriteLine(minFunc(arr));
        }

    }
}
