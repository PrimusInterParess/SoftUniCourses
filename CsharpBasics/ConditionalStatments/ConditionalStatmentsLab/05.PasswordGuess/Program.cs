using System;

namespace _05.PasswordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = (Console.ReadLine());
            string b = "s3cr3t!P@ssw0rd";
            if (a == b)
            {
                Console.WriteLine("Welcome");

            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
