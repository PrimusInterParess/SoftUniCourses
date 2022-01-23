using System;

namespace _03.VariationsWithoutRepetition
{
    internal class Program
    {
        private static Char[] arr;
        private static Char[] variations;
        private static bool[] used;
        private static int k;

        static void Main(string[] args)
        {
            var elements = Console.ReadLine();
            arr = elements.ToCharArray();
            k = elements.Length;

            variations = new Char[k];
            used = new bool[elements.Length];

            Variations();
        }

        private static void Variations(int index = 0)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(String.Join("", variations));
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (used[i] == false)
                {
                    used[i] = true;
                    variations[index] = char.ToUpper(arr[i]);
                    Variations(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}