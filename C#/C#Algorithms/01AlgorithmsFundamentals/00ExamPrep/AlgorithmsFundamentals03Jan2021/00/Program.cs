using System;
using System.Collections.Generic;
using System.Linq;

namespace _00
{
    class Program
    {


        private static Dictionary<string, List<string>> graph;

        private static HashSet<string> visited;

        private static Stack<string> paths;


        static void Main(string[] args)
        {
            graph = ReadGraph();
            visited = new HashSet<string>();
            paths = new Stack<string>();

            foreach (var key in graph.Keys)
            {
                Dfs(key);
            }

            Console.WriteLine(string.Join(" ",paths));


        }

        private static void Dfs(string key)
        {
            if (visited.Contains(key))
            {
                return;
            }

            visited.Add(key);


            foreach (var child in graph[key])
            {
                Dfs(child);
            }

            paths.Push(key);


        }


        private static Dictionary<string, List<string>> ReadGraph()
        {
            Dictionary<string, List<string>> toReturn = new Dictionary<string, List<string>>();

            //  for (int i = 0; i < n; i++)
            // {

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputData = input.Split("->").ToArray();

                var key = inputData[0].Trim();

                if (inputData.Length > 1)
                {
                    var children = inputData[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    toReturn.Add(key, new List<string>());

                    toReturn[key].AddRange(children);
                }
                else
                {
                    toReturn[key] = new List<string>();

                }

                input = Console.ReadLine();
            }
            // }

            return toReturn;
        }
    }
}
