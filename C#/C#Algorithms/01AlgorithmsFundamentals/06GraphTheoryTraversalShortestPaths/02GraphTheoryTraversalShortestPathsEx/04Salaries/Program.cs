using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Salaries
{
    class Program
    {


        private static List<int>[] graph;

        private static Dictionary<int, int> visited;


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];

            visited = new Dictionary<int, int>();

            ReadGraph(n);

            var salary = 0;

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                salary += DFS(i);

            }

            Console.WriteLine(salary);



        }

        private static int DFS(int currentNode)
        {

            if (visited.ContainsKey(currentNode))
            {
                return visited[currentNode];
            }


            var salary = 0;

            if (graph[currentNode].Count == 0)
            {
                salary = 1;
            }
            else
            {
                foreach (var child in graph[currentNode])
                {

                    salary += DFS(child);
                }
            }



            visited[currentNode] = salary;
            return salary;


        }

        private static void ReadGraph(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var inputData = Console.ReadLine();

                graph[i] = new List<int>();

                for (int j = 0; j < inputData.Length; j++)
                {

                    if (inputData[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }

                }
            }
        }
    }
}
