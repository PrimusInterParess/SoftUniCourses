using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Graph
{
    class Program
    {
        private static Dictionary<int, List<int>> graphDic;

        private static HashSet<int> visited;

        static void Main(string[] args)
        {

            visited = new HashSet<int>();

            //graphDic = new Dictionary<int, List<int>>()
            //{
            //    {1,new List<int>(){19,21,14}},
            //    {19,new List<int>(){7,12,31}},
            //    {7,new List<int>(){1}},
            //    {12,new List<int>()},
            //    {31,new List<int>(){21}},
            //    {21,new List<int>(){14}},
            //    {14,new List<int>(){23,6}},
            //    {23,new List<int>(){21}},
            //    {6,new List<int>()},
            //};


            //graphDic = new Dictionary<int, List<int>>()
            //{
            //    {0,new List<int>(){1}},
            //    {1,new List<int>(){2,3}},
            //    {2,new List<int>(){3}},
            //    {3,new List<int>(){4}},
            //    {4,new List<int>()}

            //};

            List<int> path = new List<int>();


            int n = int.Parse(Console.ReadLine()) - 1;

            graphDic = ReadGraph(n);



            foreach (var node in graphDic.Keys)
            {

                var result = new List<int>();
                BFS(node, result);

            }

        }

        private static void BFS(int node, List<int> result)
        {
            if (visited.Contains(node))
            {
                
                return;
            }

            if (isPath(node))
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            Queue<int> q = new Queue<int>();

            q.Enqueue(node);

            visited.Add(node);

            while (q.Count > 0)
            {
                var current = q.Dequeue();

                result.Add(current);

                foreach (var child in graphDic[node])
                {

                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    q.Enqueue(child);

                    visited.Add(child);
                }
            }

        }

        private static void DFS(int node, List<int> path)
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


            foreach (var child in graphDic[node])
            {

                DFS(child, path);

                visited.Remove(child);
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
                    string[] inputData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (inputData.Length > 0)
                    {
                        var children = inputData[0].Split(", ").Select(int.Parse).ToList();

                        toReturn[i] = children;
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
