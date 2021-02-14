using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songQueue = new Queue<string>(songs);



            while (songQueue.Count != 0)
            {
                string[] command = Console.ReadLine().Split().ToArray();


                switch (command[0])
                {
                    case "Play":
                        songQueue.Dequeue();
                        break;
                    case "Add":
                        string songToCheck = String.Join(" ", command).Substring(4);

                        if (songQueue.Contains(songToCheck))
                        {
                            Console.WriteLine($"{songToCheck} is already contained!");
                        }
                        else
                        {
                            songQueue.Enqueue(songToCheck);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songQueue));
                        break;

                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
