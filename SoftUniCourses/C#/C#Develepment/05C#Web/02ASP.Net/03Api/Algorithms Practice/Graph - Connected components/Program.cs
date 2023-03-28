using System;

namespace Graph_Connected_Components
{
    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            int levels = int.Parse(Console.ReadLine());

            graph = ReadGraph(levels);

            visited = new bool[levels];

            for (int i = 0; i < levels; i++)
            {
                var connects = new List<int>();
                Dfs(i, connects);
                if (connects.Count != 0)
                {
                    Console.WriteLine($"Connected components: {string.Join(" ", connects)}");
                }
            }
            ;
        }

        static void Dfs(int node, List<int> connects)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                Dfs(child, connects);
            }

            connects.Add(node);
        }

        static List<int>[] ReadGraph(int levels)
        {
            var toReturn = new List<int>[levels];

            for (int i = 0; i < levels; i++)
            {
                var input = Console.ReadLine();


                if (string.IsNullOrEmpty(input))
                {
                    toReturn[i] = new List<int>();
                    continue;
                }
                toReturn[i] = input.Split().Select(int.Parse).ToList();

            }

            return toReturn;
        }
    }
}