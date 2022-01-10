using System;
using System.Collections.Generic;
using System.Linq;

namespace _03CyclesInAGraph
{

    class Program
    {

        private static Dictionary<string, List<string>> graph;

        private static HashSet<string> visited;
        static void Main(string[] args)
        {

            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();

            ReadGraph();

            var first = graph.FirstOrDefault().Key;
            var result = GraphPaths(false, first);


            var toPrint = result == true ? "No" : "Yes";

            Console.WriteLine($"Acyclic: {toPrint}");

        }

        private static bool GraphPaths(bool assumption, string node)
        {
            if (visited.Contains(node))
            {
                assumption = true;
                return assumption;
            }


            Queue<string> q = new Queue<string>();

            visited.Add(node);
            q.Enqueue(node);


            while (q.Count > 0)
            {
                var currentNode = q.Dequeue();

                foreach (var child in graph[currentNode])
                {
                    if (visited.Contains(child))
                    {
                        assumption = true;
                        return assumption;
                    }

                    q.Enqueue(child);
                    visited.Add(child);
                }


            }


            assumption = false;
            return assumption;
        }

        private static void ReadGraph()
        {


            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] edge = input.Split("-").ToArray();

                string from = edge[0];
                string to = edge[1];

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<string>());
                }

                graph[from].Add(to);

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<string>());
                }

                input = Console.ReadLine();

            }
        }
    }
}
