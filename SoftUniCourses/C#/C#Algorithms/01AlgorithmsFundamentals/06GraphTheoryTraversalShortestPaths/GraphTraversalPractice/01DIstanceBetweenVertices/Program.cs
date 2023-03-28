using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace _01DIstanceBetweenVertices
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int numberOfPairs = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);

            for (int i = 0; i < numberOfPairs; i++)
            {
                string[] pairs = Console.ReadLine().Split('-').ToArray();

                int from = int.Parse(pairs[0]);
                int to = int.Parse(pairs[1]);

                int steps = BFS(from, to);

                Console.WriteLine($"{{{from}, {to}}} -> {steps}");
            }
        }

        private static int BFS(int @from, int to)
        {
            Queue<int> q = new Queue<int>();

            q.Enqueue(from);

            Dictionary<int, int> nodesSteps = new Dictionary<int, int>() { { @from, 0 } };

            while (q.Count > 0)
            {
                int parentNode = q.Dequeue();

                if (parentNode == to)
                {
                    return nodesSteps[parentNode];
                }

                foreach (var childNode in graph[parentNode])
                {
                    if (nodesSteps.ContainsKey(childNode))
                    {
                        continue;
                    }

                    q.Enqueue(childNode);

                    nodesSteps[childNode] = nodesSteps[parentNode] + 1;

                }
            }


            return -1;
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            Dictionary<int, List<int>> graphToReturn = new Dictionary<int, List<int>>();


            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split(':').ToArray();

                int parentNode = int.Parse(input[0]);

                List<int> childreNodes = ExtractChildrenNodes(input[1]);

                graphToReturn[parentNode] = childreNodes;
            }

            return graphToReturn;

        }

        private static List<int> ExtractChildrenNodes(string inputNodes)
        {

            return string.IsNullOrEmpty(inputNodes) ? new List<int>() : inputNodes.Split(' ').Select(int.Parse).ToList();
        }
    }
}
