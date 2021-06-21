using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02FlowerWreaths
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] lillies = ReadsIntArray();
            int[] roses = ReadsIntArray();

            Stack<int> lilliesS = PushLilliesInStack(lillies);
            Queue<int> rosesQ = EnqueRosesInQ(roses);

            int wreaths = 0;


            while (true)
            {
                if (IsStorageEmpty(lilliesS, rosesQ))
                {
                    break;
                }

                int wreath = lilliesS.Peek() + rosesQ.Peek();

                if (wreath == 15)
                {
                    wreaths++;

                    PushAndDeque(lilliesS, rosesQ);
                }
                else if (wreath > 15)
                {
                    bool created = false;

                    while (true)
                    {
                        int wreath = rosesQ.Peek() + lilliesS.Peek() - 2;

                    }
                }




            }
        }

        private static void PushAndDeque(Stack<int> lilliesS,Queue<int> rosesQ)
        {
            lilliesS.Pop();
            rosesQ.Dequeue();
        }

        private static bool IsStorageEmpty(Stack<int> lilies, Queue<int> roses)
        {
            if (lilies.Count == 0 && roses.Count == 0)
            {
                return true;
            }

            return false;
        }

        private static Queue<int> EnqueRosesInQ(int[] roses)
        {
            Queue<int> toReturnQ = new Queue<int>();

            for (int i = 0; i < roses.Length; i++)
            {
                toReturnQ.Enqueue(roses[i]);
            }

            return toReturnQ;
        }

        private static Stack<int> PushLilliesInStack(int[] data)
        {
            Stack<int> toReturn = new Stack<int>();

            for (int i = 0; i < data.Length; i++)
            {
                toReturn.Push(data[i]);
            }

            return toReturn;
        }

        private static int[] ReadsIntArray()
        {
            int[] intArr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            return intArr;
        }
    }
}
