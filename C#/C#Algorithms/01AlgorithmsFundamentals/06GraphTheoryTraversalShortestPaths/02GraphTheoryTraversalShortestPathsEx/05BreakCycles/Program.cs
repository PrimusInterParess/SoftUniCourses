namespace _05BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private class Edge
        {
            public string From { get; set; }

            public string To { get; set; }
            public override string ToString()
            {
                return $"{From} {To}";
            }
        }

        private static Dictionary<string, List<string>> graph;

        private static List<Edge> edgesList;


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            edgesList = ExtractEdges()
                .OrderBy(e => e.From)
                .ThenBy(e => e.To)
                .ToList();


            List<Edge> removedEdges = new List<Edge>();

            foreach (var kvp in edgesList)
            {

                string from = kvp.From;
                string to = kvp.To;

                bool removed =
                    graph[from].Remove(to) &&
                    graph[to].Remove(from);

                if (!removed)
                {
                    continue;
                }

                if (BFS(from, to))
                {
                    removedEdges.Add(kvp);
                }
                else
                {
                    graph[from].Add(to);
                    graph[to].Add(from);
                }


            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");

            foreach (var edge in removedEdges)
            {
                Console.WriteLine($"{edge.From} - {edge.To}");
            }

        }

        private static bool BFS(string @from, string to)
        {
            Queue<string> q = new Queue<string>();

            q.Enqueue(@from);

            var visited = new HashSet<string>() { @from };
            while (q.Count > 0)
            {
                var current = q.Dequeue();

                if (current == to)
                {
                    return true;
                }

                foreach (var child in graph[current])
                {
                    if (visited.Contains(child))
                    {
                        continue;

                    }

                    visited.Add(child);

                    q.Enqueue(child);
                }
            }

            return false;
        }

        private static List<Edge> ExtractEdges()
        {
            List<Edge> edgesToReturn = new List<Edge>();


            foreach (var kvp in graph)
            {
                string parent = kvp.Key;

                foreach (var child in graph[parent])
                {
                    Edge edge = new Edge()
                    {
                        From = parent,
                        To = child
                    };

                    edgesToReturn.Add(edge);
                }
            }

            return edgesToReturn;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            Dictionary<string, List<string>> graphToReturn = new Dictionary<string, List<string>>();

            for (int i = 1; i <= n; i++)
            {
                string[] inputData = Console.ReadLine().Split(" -> ").ToArray();

                string parentNode = inputData[0];

                List<string> children = inputData[1].Split(' ').ToList();

                if (!graphToReturn.ContainsKey(parentNode))
                {
                    graphToReturn.Add(parentNode, new List<string>());
                }

                graphToReturn[parentNode].AddRange(children);
            }

            return graphToReturn;
        }
    }
}
