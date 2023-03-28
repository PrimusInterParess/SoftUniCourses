using System;
using System.Collections.Generic;
using System.Linq;

namespace _01DistanceBetweenVertices
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;

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

                int pathDistance = GetPathDistance(from, to);

                Console.WriteLine($"{{{from}, {to}}} -> {pathDistance}");
            }

        }

        private static int GetPathDistance(int @from, int to)
        {

            Queue<int> q = new Queue<int>();

            Dictionary<int, int> steps = new Dictionary<int, int>() { { from, 0 } };

            q.Enqueue(from);


            while (q.Count > 0)
            {
                int node = q.Dequeue();

                if (node == to)
                {
                    return steps[node];
                }

                foreach (var child in graph[node])
                {
                    if (steps.ContainsKey(child))
                    {
                        continue;
                    }
                    q.Enqueue(child);
                    steps[child] = steps[node] + 1;

                }

            }

            return -1;
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
