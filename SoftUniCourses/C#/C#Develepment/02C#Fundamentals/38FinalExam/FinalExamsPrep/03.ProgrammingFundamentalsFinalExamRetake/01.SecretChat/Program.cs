using System;
using System.Linq;
using System.Text;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMassege = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] command = input.Split(new[] { ':', '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (command[0])
                {
                    case "InsertSpace":
                        encryptedMassege = InsertSpace(encryptedMassege, int.Parse(command[1]));
                        break;
                    case "Reverse":
                        encryptedMassege = ReverseSubstring(encryptedMassege, command[1]);
                        break;
                    case "ChangeAll":
                        encryptedMassege = ChangeAllAcurances(encryptedMassege, command[1], command[2]);
                        break;

                }
            }

            Console.WriteLine($"You have a new text message: {encryptedMassege}");

        }

        private static string ChangeAllAcurances(string encryptedMassege, string old, string newStr)
        {
            if (encryptedMassege.Contains(old))
            {
                encryptedMassege = encryptedMassege.Replace(old, newStr);

                Console.WriteLine(encryptedMassege);
            }

            return encryptedMassege;
        }



        private static string ReverseSubstring(string encryptedMassege, string substring)
        {
            if (encryptedMassege.Contains(substring))
            {
                char[] charr = substring.ToCharArray();

                StringBuilder reversed = new StringBuilder();

                for (int i = charr.Length - 1; i >= 0; i--)
                {
                    reversed.Append(charr[i]);
                }

                int index = encryptedMassege.IndexOf(substring);

                encryptedMassege = encryptedMassege.Remove(index, substring.Length);

                encryptedMassege = encryptedMassege.Insert(encryptedMassege.Length, reversed.ToString());

                Console.WriteLine(encryptedMassege);
            }
            else
            {
                Console.WriteLine("error");
            }

            return encryptedMassege;
        }

        private static string InsertSpace(string encryptedMassege, int indexToInsert)
        {

            if (indexToInsert >= 0 && indexToInsert <= encryptedMassege.Length-1)
            {
                encryptedMassege = encryptedMassege.Insert(indexToInsert, " ");

                Console.WriteLine(encryptedMassege);
            }
            

            return encryptedMassege;
        }
    }
}
