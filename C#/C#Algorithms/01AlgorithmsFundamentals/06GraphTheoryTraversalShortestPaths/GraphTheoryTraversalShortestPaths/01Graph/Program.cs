using System;
using System.Collections.Generic;

namespace _01Graph
{
    class Program
    {
        private static Dictionary<int, List<int>> graphDic;

        private static HashSet<int> visited;

        static void Main(string[] args)
        {

            visited = new HashSet<int>();

            graphDic = new Dictionary<int, List<int>>()
            {
                {1,new List<int>(){19,21,14}},
                {19,new List<int>(){7,12,31}},
                {7,new List<int>(){1}},
                {12,new List<int>()},
                {31,new List<int>(){21}},
                {21,new List<int>(){14}},
                {14,new List<int>(){23,6}},
                {23,new List<int>(){21}},
                {6,new List<int>()},
            };


            foreach (var node in graphDic.Keys)
            {
                BFS(node);
            }

        }

        private static void BFS(int node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            Queue<int> q = new Queue<int>();

            q.Enqueue(node);

            visited.Add(node);

            while (q.Count > 0)
            {
                var current = q.Dequeue();

                Console.WriteLine(current);

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

        private static void DFS(int node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graphDic[node])
            {
                DFS(child);
            }

            Console.WriteLine(node);
        }
    }
}
