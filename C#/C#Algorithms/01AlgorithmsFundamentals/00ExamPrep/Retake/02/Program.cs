using System;
using System.Collections.Generic;
using System.Linq;

namespace _05ShortestPath
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static bool[] visited;
        private static int[] parrents;
        private static HashSet<int> visitedDestination;
        private static List<Edge> edges;

        private class Edge
        {
            public int From { get; set; }
            public int To { get; set; }

            public override string ToString()
            {
                return $"{From} -- {To}";
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            edges = new List<Edge>();
            visitedDestination = new HashSet<int>();
            parrents = new int[n + 1];
            Array.Fill(parrents, -1);
            visited = new bool[n + 1];

            graph = ReadGraphExtractingEdges(e);

            edges = edges.OrderBy(E => E.From).ThenBy(E => E.To).ToList();

            var sourse = int.Parse(Console.ReadLine());

            for (int i = 1; i <=n; i++)
            {
                int destination =i;

                if (visitedDestination.Contains(destination))
                {
                    continue;
                }

                visitedDestination.Add(destination);

                int result = BFS(sourse, destination, visited);

                if (result == -1)
                {
                    continue;
                }

                if (result == 0)
                {
                    continue;
                }

                Console.WriteLine($"{sourse} -> {destination} ({result})");
            }
            
              
            

        }

        private static int BFS(int source, int destination, bool[] visited)
        {
            visited = new bool[graph.Count + 1];

            var q = new Queue<int>();

            q.Enqueue(source);

            visited[source] = true;

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                if (node == destination)
                {
                    var path = ReconstructPath(destination);

                    return path.Count - 1;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parrents[child] = node;
                        q.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }

            return -1;
        }

        private static Stack<int> ReconstructPath(int destinationNode)
        {
            var path = new Stack<int>();

            var index = destinationNode;

            while (index != -1)
            {
                path.Push(index);
                index = parrents[index];
            }

            return path;
        }

        private static Dictionary<int, List<int>> ReadGraphExtractingEdges(int n)
        {
            Dictionary<int, List<int>> toReturnGraph = new Dictionary<int, List<int>>();

            for (int j = 1; j <= n; j++)
            {
                string[] inputData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int parent = int.Parse(inputData[0]);
                int child = int.Parse(inputData[1]);

                if (!toReturnGraph.ContainsKey(parent))
                {
                    toReturnGraph.Add(parent, new List<int>());
                }

                toReturnGraph[parent].Add(child);


                if (!toReturnGraph.ContainsKey(child))
                {
                    toReturnGraph.Add(child, new List<int>());
                }

                toReturnGraph[child].Add(parent);
              
                ExtractingEdges(parent, child);
            }

            return toReturnGraph;
        }

        private static void ExtractingEdges(int parent, int child)
        {
            edges.Add(new Edge() { From = parent, To = child });
        }
    }
}