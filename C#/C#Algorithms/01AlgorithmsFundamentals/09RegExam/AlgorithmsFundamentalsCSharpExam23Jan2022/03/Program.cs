using System;

namespace _03.VariationsWithoutRepetition
{
    internal class Program
    {
        private static Char[] arr;
        private static Char[] variations;

        static void Main(string[] args)
        {
            var elements = Console.ReadLine();
            arr = elements.ToCharArray();

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(String.Join("", arr));
                return;
            }

            Permute(index + 1);

            if (char.IsLetter(arr[index]))
            {
                for (int i = 0; i < 1; i++)
                {
                    arr[index] = Swap(index);
                    Permute(index + 1);
                    arr[index] = Swap(index);
                }
            }

          
        }

        private static char Swap(int index)
        {
            return char.IsLower(arr[index]) ? char.ToUpper(arr[index]) : char.ToLower(arr[index]);
        }
    }
}