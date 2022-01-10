using System;
using System.Collections.Generic;
using System.Linq;

namespace _1DistanceBetweenVertices
{

    class Program
    {

        private static Dictionary<int, List<int>> graph;
        private static bool[] visited;
        private static int[] parrents;

        private static int maxCapacity;



        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            graph = CreateGraph(n);


            for (int i = 0; i < p; i++)
            {
                int[] fromToLocations = Console
                    .ReadLine()
                    .Split("-")
                    .Select(int.Parse)
                    .ToArray();

                int from = fromToLocations[0];
                int to = fromToLocations[1];

                visited = new bool[maxCapacity + 1];
                parrents = new int[maxCapacity + 1];
                Array.Fill(parrents, -1);

                int pathDistance = GetPathDistance(from, to);

                Console.WriteLine($"{{{from}, {to}}} -> {pathDistance}");
            }




        }

        private static int GetPathDistance(int from, int to)
        {
            Queue<int> q = new Queue<int>();

            q.Enqueue(from);

            visited[from] = true;

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                if (node == to)
                {
                    var path = ReconstructPath(to);

                    return path.Count - 1;
                }

                foreach (var child in graph[node])
                {
                    if (visited[child])
                    {
                        continue;
                    }

                    parrents[child] = node;
                    q.Enqueue(child);
                    visited[child] = true;
                }

            }
            return -1;

        }

        private static Stack<int> ReconstructPath(int destination)
        {

            Stack<int> path = new Stack<int>();

            int index = destination;

            while (index != -1)
            {
                path.Push(index);
                index = parrents[index];

            }

            return path;

        }

        private static Dictionary<int, List<int>> CreateGraph(int p)
        {
            Dictionary<int, List<int>> toReturn = new Dictionary<int, List<int>>();

            for (int j = 0; j < p; j++)
            {
                string[] inputData = Console
                    .ReadLine()
                    .Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int node = int.Parse(inputData[0]);

                if (node > maxCapacity)
                {
                    maxCapacity = node;
                }

                if (inputData.Length > 1)
                {
                    int[] children = inputData.Skip(1)
                        .Select(int.Parse)
                        .ToArray();

                    if (!toReturn.ContainsKey(node))
                    {
                        toReturn.Add(node, new List<int>());
                    }

                    toReturn[node].AddRange(children);
                }
                else
                {
                    toReturn[node] = new List<int>();
                }
            }
            return toReturn;
        }
    }
}
