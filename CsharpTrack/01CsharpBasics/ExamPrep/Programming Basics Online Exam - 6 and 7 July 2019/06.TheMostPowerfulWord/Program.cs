using System;

namespace _06.TheMostPowerfulWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            decimal charSum = 0;
            decimal character = 0;
            decimal sum = 0;
            decimal maxNumber = decimal.MinValue;
            string mostPowerfullWord = "";

            while (word != "End of words")
            {
                for (int i = 0; i < word.Length; i++)
                {
                    character = word[i];
                    charSum += character;
                }

                if ((word[0] == 'a' || word[0] == 'A' || word[0] == 'e' || word[0] == 'E' || word[0] == 'i' || word[0] == 'I' || word[0] == 'o' || word[0] == 'O' || word[0] == 'u' || word[0] == 'U' || word[0] == 'y' || word[0] == 'Y'))
                {
                    sum = charSum * word.Length;
                }
                else
                {
                    sum = Math.Floor(charSum / word.Length);
                }

                if (sum > maxNumber)
                {
                    maxNumber = sum;
                    mostPowerfullWord = word;
                }

                word = Console.ReadLine();
                charSum = 0;
                sum = 0;
            }


            Console.WriteLine($"The most powerful word is {mostPowerfullWord} - {maxNumber}");
        }
    }
}
