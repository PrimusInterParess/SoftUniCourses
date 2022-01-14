using System;
using System.Collections.Generic;
using System.Linq;

namespace _05BreackCycles
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
            int p = int.Parse(Console.ReadLine());

            graph = ReadGraph(n,p);
            edgesList = ExtractEdges()
                .OrderBy(e => e.From)
                .ThenBy(e => e.To)
                .ToList();

           
            List<Edge> removedEdges = new List<Edge>();

            foreach (var kvp in edgesList)
            {

                string from = kvp.From;
                string to = kvp.To;


                graph[from].Remove(to);
                    graph[to].Remove(from);


                    DFS(0);
                
                    graph[from].Add(to);
                    graph[to].Add(from);
                


            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");

            foreach (var edge in removedEdges)
            {
                Console.WriteLine($"{edge.From} - {edge.To}");
            }

        }

        private static void DFS(int i)
        {
           
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

        private static Dictionary<string, List<string>> ReadGraph(int n,int p)
        {
            Dictionary<string, List<string>> graphToReturn = new Dictionary<string, List<string>>();

            for (int i = 0; i < p; i++)
            {
                string[] inputData = Console.ReadLine().Split(" - ").ToArray();

                
                
                    string parentNode = inputData[0];

                    string children = inputData[1];

                    if (!graphToReturn.ContainsKey(parentNode))
                    {
                        graphToReturn.Add(parentNode, new List<string>());
                    }

                    graphToReturn[parentNode].Add(children);

                    if (!graphToReturn.ContainsKey(children))
                    {
                        graphToReturn.Add(children,new List<string>());
                    }

                    if (!graphToReturn[children].Contains(parentNode))
                    {
                        graphToReturn[children].Add(parentNode);
                    }
                
            }

            return graphToReturn;
        }
    }
}
