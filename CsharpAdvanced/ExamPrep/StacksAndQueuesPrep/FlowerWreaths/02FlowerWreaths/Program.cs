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
            int needed = 5;

            int storedFlowers = 0;

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


                    int rose = rosesQ.Peek();
                    int lily = lilliesS.Peek();

                    while (lily >= 0)
                    {

                        lily -= 2;
                        wreath = rose + lily;
                        if (wreath == 15)
                        {
                            PushAndDeque(lilliesS, rosesQ);

                            wreaths++;

                            break;
                        }
                        else if (wreath < 15)
                        {
                            storedFlowers += wreath;
                            PushAndDeque(lilliesS, rosesQ);
                            break;

                        }

                    }

                }
                else if (wreath < 15)
                {
                    storedFlowers += wreath;
                    PushAndDeque(lilliesS, rosesQ);
                }



            }

            if (storedFlowers >= 15)
            {
                while (storedFlowers > 15)
                {
                    wreaths++;
                    storedFlowers -= 15;
                }
            }

            Console.WriteLine(wreaths >= 5
                ? $"You made it, you are going to the competition with {wreaths} wreaths!"
                : $"You didn't make it, you need {needed - wreaths} wreaths more!");
        }

        private static void PushAndDeque(Stack<int> lilliesS, Queue<int> rosesQ)
        {
            lilliesS.Pop();
            rosesQ.Dequeue();
        }

        private static bool IsStorageEmpty(Stack<int> lilies, Queue<int> roses)
        {
            if (lilies.Count == 0 || roses.Count == 0)
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
