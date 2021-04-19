using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine()
                .Split(new char[]{' ',',',' '},StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();

            Stack<string> custom = new Stack<string>(data);


            string command = Console.ReadLine();

            while (command!="END")
            {
                string[] action = command.Split();

                if (action[0]=="Pop")
                {
                    try
                    {
                        custom.Pop();
                    }
                    catch (InvalidOperationException exeException)
                    {
                        Console.WriteLine(exeException.Message);

                    }
                }

                if (action[0]=="Push")
                {
                    custom.Push(action[1]);

                }

                command = Console.ReadLine();
            }


            foreach (var item in custom)
            {
                Console.WriteLine(item);
            }

            foreach (var item in custom)
            {
                Console.WriteLine(item);
            }




        }
    }
}
