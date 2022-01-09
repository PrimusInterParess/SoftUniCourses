using System;
using System.Collections.Generic;
using System.Linq;

namespace connectedComponents
{
    class Program
    {
        private static List<int>[] graph;

        private static HashSet<int> visitedNodes;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            visitedNodes = new HashSet<int>();

            graph = ReadGraph(n);

            for (int i = 0; i < graph.GetLength(0); i++)
            {

                if (visitedNodes.Contains(i))
                {
                    continue;

                }

                var connects = new List<int>();

                DFS(i, connects);

                Console.WriteLine($"Connected component: {string.Join(" ",connects)}");
            }
        }

        private static void DFS(int i, List<int> connects)
        {

            if (visitedNodes.Contains(i))
            {
                return;
            }

            visitedNodes.Add(i);

            foreach (var children in graph[i])
            {
                DFS(children, connects);
            }

            connects.Add(i);
        }

        private static List<int>[] ReadGraph(int n)
        {
            List<int>[] toReturnMatrix = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                string nodeChildren = Console.ReadLine();

                toReturnMatrix[i] = new List<int>();

                if (string.IsNullOrEmpty(nodeChildren))
                {

                    continue;
                }

                int[] children = nodeChildren.Split().Select(int.Parse).ToArray();

                toReturnMatrix[i].AddRange(children);
            }

            return toReturnMatrix;
        }
    }
}
