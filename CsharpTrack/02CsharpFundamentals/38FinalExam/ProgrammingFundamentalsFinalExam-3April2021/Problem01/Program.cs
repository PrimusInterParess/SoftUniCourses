using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem01
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();

            string input = string.Empty;

            List<int> encrypted = new List<int>();

            while ((input = Console.ReadLine()) != "Complete")
            {

                string[] options = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = string.Join(" ", options);

                if (command.Contains("Make Upper"))
                {
                    data = data.ToUpper();

                    Console.WriteLine(data);
                }
                else if (command.Contains("Make Lower"))
                {
                    data = data.ToLower();

                    Console.WriteLine(data);

                }
                else if (command.Contains("GetDomain"))
                {
                    string domain = data.Substring(data.Length - 3);

                    Console.WriteLine(domain);
                }
                else if (command.Contains("GetUsername"))
                {
                    int index = data.IndexOf('@');
                    if (index < 0)
                    {
                        Console.WriteLine($"The email {data} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        string userName = data.Substring(0, index);

                        Console.WriteLine(userName);
                    }

                   
                }
                else if (command.Contains("Replace"))
                {
                    char charToReplace = char.Parse(options[1]);

                    data = data.Replace(charToReplace, '-');

                    Console.WriteLine(data);
                }
                else if (command.Contains("Encrypt"))
                {
                    

                    for (int i = 0; i < data.Length; i++)
                    {
                        int encyptedChar = (int) data[i];

                        encrypted.Add(encyptedChar);
                    }
                }


            }

            Console.WriteLine(string.Join(" ", encrypted));


        }
    }
}
