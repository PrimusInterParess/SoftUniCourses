using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace _01BinomialCoefficients
{
    class Program
    {

        private static Dictionary<string, long> memo;

        static void Main(string[] args)
        {
            //int r = int.Parse(Console.ReadLine());
            //int c = int.Parse(Console.ReadLine());
            //memo = new Dictionary<string, long>();

            //long result = NumberOfPaths(r, c);

            //Console.WriteLine(result);



            int x1 = 28;
            int v1 = 8;
            int x2 = 96;
            int v2 = 2;


            var res = countApplesAndOranges(x1, v1, x2, v2);

            Console.WriteLine(res);
        }


        public static string countApplesAndOranges(int x1, int v1, int x2, int v2)
        {
            var forwardX1 = x1;
            var forwardX2 = x2;

            bool isBigger = x1 > x2;

            if (x1 < x2 && v1 < v2)
            {
                return "NO";
            }
            else if (x1 > x2 && v1 > v2)
            {
                return "NO";

            }

            while (true)
            {
                if (forwardX1 < forwardX2 && v1 < v2)
                {
                    return "NO";
                }

                if (forwardX1 < forwardX2 && v1 < v2)
                {
                    return "NO";

                }

                forwardX1 += v1;
                forwardX2 += v2;

                if (forwardX2 == forwardX1)
                {
                    return "YES";
                }

                if (isBigger==false)
                {
                    if (forwardX1>forwardX2)
                    {
                        return "NO";
                    }
                }
                
            }


        }


        public static List<int> Grades(int n)
        {
            List<int> grades = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var gradesToChech = int.Parse(Console.ReadLine());

                var result = gradesToChech % 5;

                var toAdd = Math.Abs(result - 5);


                if (gradesToChech > 38)
                {
                    if (toAdd < 3)
                    {
                        gradesToChech += toAdd;
                    }

                }

                grades.Add(gradesToChech);

            }

            return grades;
        }

        public static void diagonalDifference(string s)
        {
            DateTime date = Convert.ToDateTime(s);

            Console.WriteLine(date.ToString("T", CultureInfo.InvariantCulture));

        }




        static int NumberOfPaths(int m, int n)
        {

            int[,] count = new int[m, n];


            for (int i = 0; i < m; i++)
                count[i, 0] = 1;


            for (int j = 0; j < n; j++)
                count[0, j] = 1;


            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)

                    count[i, j] = count[i - 1, j] + count[i, j - 1]; //+ count[i-1][j-1];
            }
            return count[m - 1, n - 1];
        }
    }
}