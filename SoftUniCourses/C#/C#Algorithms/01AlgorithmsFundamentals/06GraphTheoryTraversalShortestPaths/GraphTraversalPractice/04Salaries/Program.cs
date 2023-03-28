using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Salaries
{
    class Program
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> salaries;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            salaries = new Dictionary<int, int>();

            int totalSalary = 0;

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                totalSalary += DFS(i);
            }

            Console.WriteLine(totalSalary);
        }

        private static int DFS(int node)
        {
            if (salaries.ContainsKey(node))
            {
                return salaries[node];
            }

            int salary = 0;


            if (graph[node].Count == 0)
            {
                salary = 1;
            }
            else
            {
                foreach (var child in graph[node])
                {
                    salary += DFS(child);
                }
            }

            salaries[node] = salary;

            return salary;

        }


        private static List<int>[] ReadGraph(int n)
        {
            List<int>[] graphToReturn = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                string inputData = Console.ReadLine();

                graphToReturn[i] = new List<int>();

                for (int j = 0; j < n; j++)
                {
                    if (inputData[j] == 'N')
                    {
                        continue;
                    }

                    graphToReturn[i].Add(j);
                }
            }

            return graphToReturn;
        }
    }
}
