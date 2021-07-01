using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquid = GetQueue();
            Stack<int> ingredient = GetStack();

            Dictionary<string, int> backed = new Dictionary<string, int>()
            {
                {"Bread" ,0},
                {"Cake" ,0},
                {"Pastry" ,0},
                {"Fruit Pie" ,0}
            };

            bool isEmpty = false;

            while (!CheckIfEmpty(liquid, ingredient))
            {
                bool baked = false;

                int sum = liquid.Peek() + ingredient.Peek();

                switch (sum)
                {
                    case 25:
                        backed["Bread"]++;
                        baked = true;
                        break;
                    case 50:
                        backed["Cake"]++;
                        baked = true;
                        break;
                    case 75:
                        backed["Pastry"]++;
                        baked = true;
                        break;
                    case 100:
                        backed["Fruit Pie"]++;
                        baked = true;
                        break;
                }

                if (baked)
                {
                    Remove(ingredient, liquid);
                }
                else
                {
                    liquid.Dequeue();
                    int decreasedIngredient = ingredient.Pop() + 3;
                    ingredient.Push(decreasedIngredient);
                }
            }

            if (CheckIfAllIsCooked(backed))
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (CheckIfLiqidsEmpty(liquid))
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {


                Console.WriteLine($"Liquids left: " + string.Join(", ", liquid));
            }

            if (CheckIfIngredientsEmpty(ingredient))
            {
                Console.WriteLine($"Ingredients left: none");
            }
            else
            {

                Console.WriteLine($"Ingredients left: " + string.Join(", ", ingredient));

            }

            foreach (var pair in backed.OrderBy(p => p.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
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
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

            return data;

        }
    }
}
