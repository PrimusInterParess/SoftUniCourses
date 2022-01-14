using System;
using System.Collections.Generic;
using System.Linq;

namespace _05ReconstructPath
{
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
