using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Paths
{
    class Program
    {
        private static Dictionary<int, List<int>> graphDic;

        private static HashSet<int> visited;



        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine()) - 1;

            visited = new HashSet<int>();


            graphDic = ReadGraph(n);

            List<int> path = new List<int>();

            foreach (var node in graphDic.Keys)
            {
                FindingPaths(node, path);

            }

        }

        private static void FindingPaths(int node, List<int> path)
        {


            if (visited.Contains(node))
            {
                return;
            }

            path.Add(node);


            if (isPath(node) && path.Count > 1)
            {
                Console.WriteLine(string.Join(" ", path));
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
            var last = graphDic.LastOrDefault(n => n.Value.Count == 0);

            return node == last.Key;
        }



        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            Dictionary<int, List<int>> toReturn = new Dictionary<int, List<int>>();

            for (int i = 0; i <= n; i++)
            {
                if (i != n)
                {
                    List<int> inputData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                    if (inputData.Count > 0)
                    {
                       

                        toReturn[i] = inputData;
                    }
                    else
                    {
                        toReturn[i] = new List<int>();

                    }

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
