using System;

namespace _04.EasterShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEggs = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int soldEggs = 0;

            while (true)
            {
                if (command == "Close")
                {
                    break;
                }

                int eggs = int.Parse(Console.ReadLine());

                if (command == "Buy")
                {
                    if (numberOfEggs < eggs)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {numberOfEggs}.");
                        break;
                    }
                    else
                    {
                        soldEggs += eggs;
                        numberOfEggs -= eggs;
                    }

                }
                else if (command == "Fill")
                {
                    numberOfEggs += eggs;
                }



                command = Console.ReadLine();
            }
            if (command == "Close")
            {
                Console.WriteLine("Store is closed!");
                Console.WriteLine($"{soldEggs} eggs sold.");
            }
        }
    }
}
