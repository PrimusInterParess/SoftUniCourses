using System;

namespace _02NestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            RecursiveLoop(array, 0, n);
        }

        private static void RecursiveLoop(int[] array, int index, int N)
        {
            if (array.Length == index)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }


            for (int i = 1; i <= N; i++)
            {
                array[index] = i;

                RecursiveLoop(array, index + 1, N);
            }
        }
    }
}
