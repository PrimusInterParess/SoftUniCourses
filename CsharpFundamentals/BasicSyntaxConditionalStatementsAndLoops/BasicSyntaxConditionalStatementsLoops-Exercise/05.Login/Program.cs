using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            int passCounter = 0;

            string password = "";

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                password += userName[i];
            }

            for (int k = 0; k < 3; k++)
            {
                string inputPass = Console.ReadLine();

                if (password == inputPass)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }

            string lastTryPassword = Console.ReadLine();

            if (password == lastTryPassword)
            {
                Console.WriteLine($"User {userName} logged in.");

            }
            else
            {
                Console.WriteLine($"User {userName} blocked!");
            }
        }
    }
}
