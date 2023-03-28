using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Cinema
{
    class Program
    {
        private static List<string> elements;

        private static HashSet<int> occupied;

        private static string[] permitation;

        static void Main(string[] args)
        {

            elements = Console.ReadLine().Split(", ").ToList();
            occupied = new HashSet<int>();
            permitation = new string[elements.Count];

            while (true)
            {
                string inputData = Console.ReadLine();

                if (inputData == "generate")
                {
                    break;
                }

                var parts = inputData.Split(" - ").ToArray();

                string name = parts[0];
                int position = int.Parse(parts[1])-1;

                occupied.Add(position);

                elements.Remove(name);
                permitation[position] = name;
            }

            Permute(0);
        }

        //      0  1
        // el = 2 ,3

       // 2
       // 0+ 1 =>
       // 1 +1 =>
       // 2 =>

       // 0 1 2 3
       // 1 - - 4

       //0? C
       //1? = 2
       //2? = 3
       //3? C =>

       //1 2 3 4


        // 2+1=>
        // 3>=2



        private static void Permute(int permitationIndex)
        {
            if (permitationIndex >= elements.Count)
            {
                int index = 0;

                for (int i = 0; i < permitation.Length; i++)
                {
                    if (occupied.Contains(i))
                    {
                        continue;
                    }

                    permitation[i] = elements[index];
                    index += 1;

                }

                Console.WriteLine(string.Join(" ", permitation));

                return;
            }

            Permute(permitationIndex + 1);

            for (int i = permitationIndex + 1; i < elements.Count; i++)
            {
                Swap(permitationIndex, i);
                Permute(permitationIndex + 1);
                Swap(permitationIndex, i);

            }
        }

        private static void Swap(int first, int second)
        {
            (elements[first], elements[second]) = (elements[second], elements[first]);
        }
    }
}
