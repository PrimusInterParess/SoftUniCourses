using System;

namespace _03.Generating01Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console
                .ReadLine());

            int[] array = new int[n];

            RecursivVector(array, 0, n);


        }

        private static void RecursivVector(int[] array,int index, int n)
        {

            if (index == array.Length)
            {
                Console.WriteLine(string.Join(" ",array));
                return;
            }

            for (int i = 0; i <=1; i++)
            {
                array[index] = i;

                RecursivVector(array,index+1,n);
            }
        }
    }
}
