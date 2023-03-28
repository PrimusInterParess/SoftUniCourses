using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class Program
    {
        private  static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        static void Main(string[] args)
        {
            int nNodes = int.Parse(Console.ReadLine());

            int nPairs = int.Parse(Console.ReadLine());

            graph = ReadGraph(nNodes);

            for (int i = 0; i < nPairs; i++)
            {
                int[] inputPairs = Console.ReadLine().Split('-').Select(int.Parse).ToArray();

                visited = new HashSet<int>();
                int from = inputPairs[0];
                int to = inputPairs[1];
                int steps = BFS(from, to); 

            }
        }
       
        private static int BFS(int @from, int to)
        {
            Queue<int> q = new Queue<int>();

            q.Enqueue(from);

            Dictionary<int, int> steps = new Dictionary<int, int>() { { from, 0 } };

            while (q.Count > 0)
            {
                var currentNode = q.Dequeue();

                if (currentNode==to)
                {
                    return steps[currentNode];
                }

                foreach (var child in graph[currentNode])
                {

                    if (steps.ContainsKey(child))
                    {
                        continue;
                        
                    }

                    steps[child] =steps[currentNode]+1;

                }
            }

            return -1;
        }

      

        private static Dictionary<int, List<int>> ReadGraph(int nNodes)
        {
            Dictionary<int, List<int>> dicToReturn = new Dictionary<int, List<int>>();

            for (int i = 1; i <= nNodes; i++)
            {
                string[] inputData = Console.ReadLine().Split(":").ToArray();

                int parentNode = int.Parse(inputData[0]);

                if (string.IsNullOrEmpty(inputData[1]))
                {
                    dicToReturn.Add(parentNode, new List<int>());
                }
                else
                {
                    List<int> children = inputData[1].Split(' ').Select(int.Parse).ToList();

                    dicToReturn.Add(parentNode, children);
                }


            }

            return dicToReturn;
        }
    }
}
