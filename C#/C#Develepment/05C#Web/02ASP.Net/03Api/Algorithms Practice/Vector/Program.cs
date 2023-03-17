using System;

namespace _03.Generating01Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            RecursivVector(arr, 0);
        }

        private static void RecursivVector(int[] arr, int i)
        {


            if (i == arr.Length)
            {
                Console.WriteLine(string.Join("", arr));

                return;
            }

            for (int j = 0; j <= 1; j++)
            {
                arr[i] = j;
                RecursivVector(arr, i + 1);
            }

        }
    }
}