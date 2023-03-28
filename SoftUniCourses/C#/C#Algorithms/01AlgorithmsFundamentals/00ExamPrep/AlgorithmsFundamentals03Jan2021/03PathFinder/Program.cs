using System;
using System.Collections.Generic;
using System.Linq;

namespace _03PathFinder
{
    class Program
    {
        private static Dictionary<int, List<int>> graphDic;

        private static HashSet<int> visited;

        private static List<List<int>> paths;

        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine()) - 1;
            paths = new List<List<int>>();
            graphDic = ReadGraph(n);
            GeneratingPaths(n);
            ChecksForPathsEquality();

        }

        private static void ChecksForPathsEquality()
        {

            int p = int.Parse(Console.ReadLine());

            for (int i = 0; i < p; i++)
            {
                List<int> inputData = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

                bool hasEquality = paths.Any(l => l.SequenceEqual(inputData));

                Console.WriteLine(hasEquality ? "yes" : "no");
            }
        }

        private static void GeneratingPaths(int n)
        {
            List<int> path = new List<int>();

            var currentNode = 0;

            while (currentNode <= n)
            {
                visited = new HashSet<int>();
                FindingPaths(currentNode, path = new List<int>());
                currentNode += 1;
            }
        }

        private static void FindingPaths(int node, List<int> path)
        {
            if (visited.Contains(node))
            {
                return;
            }

            path.Add(node);

            if (isPath(node))
            {
                paths.Add(new List<int>(path));
                path.RemoveAt(path.Count - 1);
                return;
            }

            visited.Add(node);

            for (int i = 0; i < graphDic[node].Count; i++)
            {
                var current = graphDic[node][i];

                FindingPaths(current, path);

                visited.Remove(current);
            }

            path.RemoveAt(path.Count - 1);

        }

        private static bool isPath(int node)
        {
            return graphDic[node].Count == 0;
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            Dictionary<int, List<int>> toReturn = new Dictionary<int, List<int>>();

            for (int i = 0; i <= n; i++)
            {

                List<int> inputData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                if (inputData.Count > 0)
                {
                    toReturn[i] = inputData;
                }
                else
                {
                    toReturn[i] = new List<int>();
                }
            }
            return toReturn;
        }
    }
}
