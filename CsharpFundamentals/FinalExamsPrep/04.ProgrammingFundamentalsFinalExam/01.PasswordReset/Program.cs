using System;
using System.Diagnostics;
using System.Linq;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (command[0])
                {
                    case "TakeOdd":
                        sequence = TakesCharsAtOddPositions(sequence);
                        break;
                    case "Cut":
                        sequence = CutsPartOfSequence(sequence, int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "Substitute":
                        sequence = Substitutes(sequence, command[1], command[2]);
                        break;

                }

            }

            Console.WriteLine($"Your password is: {sequence}");

        }

        private static string Substitutes(string sequence, string oldStr, string newStr)
        {
            if (sequence.Contains(oldStr))
            {
                sequence = sequence.Replace(oldStr, newStr);

                Console.WriteLine(sequence);

            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }

            return sequence;

        }

        private static string CutsPartOfSequence(string sequence, int index, int length)
        {

            sequence = sequence.Remove(index, length);

            Console.WriteLine(sequence);

            return sequence;
        }

        private static string TakesCharsAtOddPositions(string sequence)
        {
            string oddPositioned = string.Empty;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (i % 2 == 1)
                {
                    oddPositioned += (char)sequence[i];
                }
            }

            Console.WriteLine(oddPositioned);

            return oddPositioned;
        }
    }
}
