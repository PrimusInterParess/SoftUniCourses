using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ReconstructPath
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public override string ToString()
        {
            return $"{From} {To}";
        }

        public override bool Equals(object? obj)
        {
            var edge = (Edge)obj;

            return this.From == edge.To && this.To == edge.From;
        }

        public override int GetHashCode()
        {
            return this.From.GetHashCode() + this.To.GetHashCode();
        }
    }

    class Program
    {
        private static List<int>[] graph;
        private static bool[] positions;
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            edges = new List<Edge>();

            graph = ReadGraph(n, e);

            //  List<Edge> edges = ExtractEdges(0);


            var importantEdges = new HashSet<Edge>();

            foreach (var edge in edges)
            {
                graph[edge.From].Remove(edge.To);
                graph[edge.To].Remove(edge.From);

                positions = new bool[n];

                DFS(0);

                if (positions.Contains(false))
                {
                    importantEdges.Add(new Edge()
                    {
                        From = Math.Min(edge.From, edge.To),
                        To = Math.Max(edge.From, edge.To)
                    });

                }

                graph[edge.From].Add(edge.To);
                graph[edge.To].Add(edge.From);
            }

            Console.WriteLine($"Important streets:");
            foreach (var edge in importantEdges)
            {
                Console.WriteLine(edge);
            }
        }

        private static void DFS(int node)
        {
            if (positions[node])
            {
                return;
            }

            positions[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }


        }

        private static List<Edge> ExtractEdges(int node)
        {

            List<Edge> edges = new List<Edge>();


            for (int i = 0; i < graph.GetLength(0); i++)
            {
                foreach (var child in graph[i])
                {
                    edges.Add(new Edge() { From = i, To = child });
                }
            }

            return edges;

            //List<Edge> edges = new List<Edge>();

            //Queue<int> q = new Queue<int>();

            //q.Enqueue(node);

            //while (q.Count > 0)
            //{
            //    var current = q.Dequeue();

            //    foreach (var child in graph[current])
            //    {
            //        q.Enqueue(child);

            //        edges.Add(new Edge()
            //        {
            //            From = current,
            //            To = child
            //        });

            //    }
            //}

        }

        private static List<int>[] ReadGraph(int n, int e)
        {
            List<int>[] graphToReturn = new List<int>[n];

            for (int g = 0; g < graphToReturn.Length; g++)
            {
                graphToReturn[g] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var inpuData = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToList();

                var firstNode = inpuData[0];
                var secondNode = inpuData[1];

                graphToReturn[firstNode].Add(secondNode);
                graphToReturn[secondNode].Add(firstNode);

                edges.Add(new Edge() { From = firstNode, To = secondNode });
            }

            return graphToReturn;
        }
    }
}
