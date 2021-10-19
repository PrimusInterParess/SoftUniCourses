using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();

            ListyIterator<string> listy = new ListyIterator<string>(data);

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string command = input;

                if (command == "Move")
                {
                    Console.WriteLine(listy.Move());
                }

                if (command == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }

                if (command == "Print")
                {
                    try
                    {
                        listy.Print();
                    }
                    catch (InvalidOperationException exeption)
                    {
                        Console.WriteLine(exeption.Message);
                    }
                }

                if (command == "PrintAll")
                {


                    foreach (string item in listy)
                    {
                        Console.Write(item + " ");
                    }

                    Console.WriteLine();

                }
            }




        }
    }
}
