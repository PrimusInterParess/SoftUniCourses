using System;
using System.Collections.Generic;
using System.Linq;

namespace _05ShortestPath
{
    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parrents;

        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            graph = ReadGraph(n, e);
            visited = new bool[graph.Length];
            parrents = new int[graph.Length];
            Array.Fill(parrents, -1);

            var sourse = int.Parse(Console.ReadLine());

            var destination = int.Parse(Console.ReadLine());

           
            
                BFS(sourse, destination);

            

        }

        private static void BFS(int source, int destination)
        {
            if (visited[source])
            {
                return;
            }

            var q = new Queue<int>();

            q.Enqueue(source);


            visited[source] = true;

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                if (node == destination)
                {
                    var path = ReconstructPath(destination);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));
                    return;
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

        private static List<int>[] ReadGraph(int n, int e)
        {
            var result = new List<int>[n + 1];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new List<int>();
            }

            for (int node = 0; node < e; node++)
            {
                int[] edge = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();


                var from = edge[0];
                var to = edge[1];

                if (result[from] == null)
                {
                    result[from] = new List<int>();
                }

                result[from].Add(to);
            }

            return result;
        }
    }
}
