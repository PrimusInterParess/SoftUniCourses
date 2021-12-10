using System.Collections.Generic;
using static System.Console;
using static System.Text.Encoding;

namespace _03PErmutationWithRepetition
{
    class Program
    {

        private static string[] elements;
        private static HashSet<string> swapped;

        static void Main(string[] args)
        {
            OutputEncoding = UTF8;\

            elements = ReadLine().Split(" ");

            Permute(0);
        }

        private static void Permute(int permitationIndex)
        {
            if (permitationIndex >= elements.Length)
            {
                WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(permitationIndex + 1);

            swapped = new HashSet<string> {elements[permitationIndex]};

            for (int i = permitationIndex + 1; i < elements.Length; i++)
            {

                if (!swapped.Contains(elements[i]))
                {
                    Swap(permitationIndex, i);
                    Permute(permitationIndex + 1);
                    Swap(permitationIndex, i);
                    swapped.Add(elements[i]);
                }
              

            }

        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}

