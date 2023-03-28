using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _03CyclesInGraph
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;

        static void Main(string[] args)
        {
            graph = ReadGraph();
            visited = new HashSet<string>();

            foreach (var kvp in graph)
            {
                var startNode = kvp.Key;
                var destination = kvp.Key;

                int result = BFS(startNode, destination);

                if (result == 1)
                {
                    Console.WriteLine($"Acyclic: No");
                    break;
                }
                else
                {
                    Console.WriteLine($"Acyclic: Yes");
                    break;
                }
            }
        }

        private static int BFS(string source, string destination)
        {
            Queue<string> q = new Queue<string>();

            q.Enqueue(source);

            visited.Add(source);
            while (q.Count > 0)
            {
                var current = q.Dequeue();

                foreach (var child in graph[current])
                {
                    if (child == destination)
                    {
                        return 1;
                    }
                    q.Enqueue(child);
                }
            }

            return -1;
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            Dictionary<string, List<string>> toReturnGraph = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] graphComponents = input.Split('-');

                string parent = graphComponents[0];
                string child = graphComponents[1];

                if (!toReturnGraph.ContainsKey(parent))
                {
                    toReturnGraph.Add(parent, new List<string>());
                }

                toReturnGraph[parent].Add(child);

                if (!toReturnGraph.ContainsKey(child))
                {
                    toReturnGraph.Add(child, new List<string>());
                }

                input = Console.ReadLine();

            }

            return toReturnGraph;
        }
    }
}
