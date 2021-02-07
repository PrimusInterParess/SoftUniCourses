using System;
using System.Diagnostics;
using System.Linq;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] command = input.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (command[0])
                {
                    case "Add Stop":
                        data = Add(data, int.Parse(command[1]), command[2]);
                        Console.WriteLine(data);
                        break;
                    case "Remove Stop":
                        data = Remove(data, int.Parse(command[1]), int.Parse(command[2]));
                        Console.WriteLine(data);
                        break;
                    case "Switch":data= SwitchStop(data, command[1], command[2]);
                        Console.WriteLine(data);
                        break;
                        
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {data}");
        }

        private static string SwitchStop(string data, string oldString, string newString)
        {
            if (data.Contains(oldString))
            {
               data= data.Replace(oldString, newString);
            }

            return data;
        }

        private static string Remove(string data, int start, int end)
        {
            if (start >= 0 && end <= data.Length - 1 && start < end)
            {
                int toRemove = end - start + 1;

                int stop = 0;

                for (int i = start; i <=end; i++)
                {
                    data = data.Remove(i, 1);
                    stop++;
                    i--;

                    if (stop== toRemove)
                    {
                        break;
                    }
                }
            }

            return data;
        }

        private static string Add(string data, int index, string stop)
        {
            if (index >= 0 && index <= data.Length - 1)
            {
                data = data.Insert(index, stop);

            }

            return data;
        }
    }
}
