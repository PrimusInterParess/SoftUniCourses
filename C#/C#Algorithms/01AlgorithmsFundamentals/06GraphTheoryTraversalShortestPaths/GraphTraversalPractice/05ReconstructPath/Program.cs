using System;
using System.Collections.Generic;
using System.Linq;

namespace _05ReconstructPath
{
    class Program
    {
        private class Edge
        {
            public int From { get; set; }

            public int To { get; set; }
            public override string ToString()
            {
                return $"{From} {To}";
            }
        }

        private static List<int>[] graph;

        private static List<Edge> edgesList;
        private static bool[] positions;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            graph = ReadGraph(p);
            edgesList = ExtractEdges()
                .OrderBy(e => e.From)
                .ThenBy(e => e.To)
                .ToList();

            foreach (var edge in edgesList)
            {
                positions = new bool[n];

                graph[edge.From].Remove(edge.To);
                graph[edge.To].Remove(edge.From);

                BFS(0);

            }

        }

        private static void BFS(int start)
        {
            Queue<int> q = new Queue<int>();

           
        }


        private static List<Edge> ExtractEdges()
        {
            List<Edge> edgesToReturn = new List<Edge>();


            foreach (var kvp in graph)
            {
                int parent = kvp.Key;

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

        private static List<int>[] ReadGraph(int p)
        {
            List<int>[] graphToReturn = new List<int>[p];

            for (int i = 0; i < p; i++)
            {
                string[] inputData = Console.ReadLine().Split(" - ").ToArray();

                int parentNode = int.Parse(inputData[0]);

                int child = int.Parse(inputData[1]);

                if (!graphToReturn.ContainsKey(parentNode))
                {
                    graphToReturn.Add(parentNode, new List<int>());
                }

                graphToReturn[parentNode].Add(child);

                if (!graphToReturn.ContainsKey(child))
                {
                    graphToReturn.Add(child,new List<int>());
                }

                graphToReturn[child].Add(parentNode);
               
            }

            return graphToReturn;
        }
    }
}
