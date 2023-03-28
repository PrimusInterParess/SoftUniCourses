using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Co
{
    class Program
    {
        private static List<int>[] graph;

        private static bool[] visited;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];


            visited = new bool[n];

            for (int node = 0; node < n ; node++)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    graph[node] = new List<int>();
                 
                }
                else
                {
                    var children = input.Split(" ").Select(int.Parse).ToList();

                    graph[node] = children;
                }


            }

            for (int node = 0; node < graph.Length; node++)
            {

                if (visited[node])  
                {
                    continue;
                }

                var componentList = new List<int>();

                DFS(node, componentList);

                Console.WriteLine($"Connected component: {string.Join(" ", componentList)}");
            }
        }

        private static void DFS(int node, List<int> components)
        {
            if (visited[node])
            {
                return;

            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, components);
            }

            components.Add(node);
        }
    }
}
