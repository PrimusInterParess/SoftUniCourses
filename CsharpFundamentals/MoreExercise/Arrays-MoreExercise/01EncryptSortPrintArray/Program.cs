using System;
using System.Linq;
namespace _01EncryptSortPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());

            int[] sumOfDigits = new int[numberOfNames];

            char[] vowels = new char[] { 'a', 'A', 'e', 'E', 'u', 'U', 'i', 'I', 'o', 'O' };

            //char[] consonants = new char[] { 'Q', 'q', 'W', 'w', 'R', 'r', 'T', 't', 'Y', 'y', 'P', 'p', 'S', 's', 'D', 'd', 'F', 'f', 'G', 'g', 'H', 'h', 'J', 'j', 'K', 'k', 'L', 'l', 'Z', 'z', 'X', 'x', 'C', 'c', 'V', 'v', 'B', 'b', 'N', 'n', 'M', 'm' };

            for (int j = 0; j < numberOfNames; j++)
            {
                string names = Console.ReadLine();

                int vowelsSum = 0;
                int consonantsSum = 0;


                for (int i = 0; i < names.Length; i++)
                {
                    if (vowels.Contains(names[i]))
                    {
                        vowelsSum += (int)names[i] * names.Length;
                    }
                    else
                    {
                        consonantsSum += (int)names[i] / names.Length; ;
                    }
                }

                sumOfDigits[j] = consonantsSum + vowelsSum;

            }

            Array.Sort(sumOfDigits);

            for (int i = 0; i < sumOfDigits.Length; i++)
            {
                Console.WriteLine(sumOfDigits[i]);
            }
        }
    }
}
