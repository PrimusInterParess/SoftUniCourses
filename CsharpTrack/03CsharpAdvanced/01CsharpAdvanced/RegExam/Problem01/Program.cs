using System;
using System.Collections.Generic;
using System.Linq;

namespace Proble01
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredient = GetQueue();
            Stack<int> freshness = GetStack();

            Dictionary<string, int> backed = new Dictionary<string, int>()
            {
                {"Dipping sauce" ,0},
                {"Green salad" ,0},
                {"Chocolate cake" ,0},
                {"Lobster" ,0}
            };

            bool isEmpty = false;

            while (!CheckIfEmpty(ingredient, freshness))
            {
                bool baked = false;

                if (ingredient.Peek() == 0)
                {
                    ingredient.Dequeue();
                    continue;
                }

                int sum = ingredient.Peek() * freshness.Peek();

                switch (sum)
                {
                    case 150:
                        backed["Dipping sauce"]++;
                        baked = true;
                        break;
                    case 250:
                        backed["Green salad"]++;
                        baked = true;
                        break;
                    case 300:
                        backed["Chocolate cake"]++;
                        baked = true;
                        break;
                    case 400:
                        backed["Lobster"]++;
                        baked = true;
                        break;
                }

                if (baked)
                {
                    Remove(freshness, ingredient);
                }
                else
                {
                    freshness.Pop();
                    int decreasedIngredient = ingredient.Dequeue() + 5;
                    ingredient.Enqueue(decreasedIngredient);
                }
            }

            if (CheckIfAllIsCooked(backed))
            {
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (!CheckIfLiqidsEmpty(ingredient))
            {
                Console.WriteLine($"Ingredients left: {ingredient.Sum()}");
            }



            foreach (var pair in backed.OrderBy(p => p.Key))
            {
                if (pair.Value > 0)
                {
                    Console.WriteLine($" # {pair.Key} --> {pair.Value}");

                }

            }

        }

        private static bool CheckIfIngredientsEmpty(Stack<int> ingredient)
        {
            if (ingredient.Count == 0)
            {
                return true;
            }

            return false;
        }

        private static bool CheckIfLiqidsEmpty(Queue<int> liquid)
        {
            if (liquid.Count == 0)
            {
                return true;
            }

            return false;
        }

        private static bool CheckIfAllIsCooked(Dictionary<string, int> backed)
        {
            foreach (var pair in backed)
            {
                if (pair.Value == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckIfEmpty(Queue<int> liquid, Stack<int> ingredient)
        {
            if (ingredient.Count == 0)
            {
                return true;
            }
            else if (liquid.Count == 0)
            {
                return true;
            }

            return false;
        }

        private static void Remove(Stack<int> ingredient, Queue<int> liquid)
        {
            ingredient.Pop();
            liquid.Dequeue();
        }

        private static Stack<int> GetStack()
        {
            Stack<int> toRet = new Stack<int>();

            int[] data = ReadIntArray();

            for (int i = 0; i < data.Length; i++)
            {
                toRet.Push(data[i]);
            }

            return toRet;
        }

        private static Queue<int> GetQueue()
        {
            Queue<int> toRet = new Queue<int>();

            int[] data = ReadIntArray();

            for (int i = 0; i < data.Length; i++)
            {
                toRet.Enqueue(data[i]);
            }

            return toRet;
        }

        private static int[] ReadIntArray()
        {
            int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            return data;

        }
    }
}
