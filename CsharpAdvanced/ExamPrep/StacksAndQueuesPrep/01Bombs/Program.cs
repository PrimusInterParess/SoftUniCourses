using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Bombs
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> materialsDictionary = new Dictionary<string, int>()

            {
                {"Datura Bombs",40},
                {"Cherry Bombs",60},
                {"Smoke Decoy Bombs",120}

            };
            Dictionary<string, int> bombPoch = new Dictionary<string, int>()
            {
                {"Datura Bombs",0},
                {"Cherry Bombs",0},
                {"Smoke Decoy Bombs",0}
            };

            int[] bombEffects = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] bombCasings = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> effects = FillingEffectsQ(bombEffects);
            Stack<int> casing = FillingCasingsS(bombCasings);

            bool isFull = false;

            while (true)
            {

                if (PorchIsFull(bombPoch))
                {
                    isFull = true;
                    break;
                }

                if (!IsAnyStorageEmpty(casing, effects))
                {
                    break;

                }

                int currentSum = effects.Peek() + casing.Peek();

                bool createdBomb = false;

                foreach (var pair in materialsDictionary)
                {
                    if (pair.Value == currentSum)
                    {
                        createdBomb = CreatingBomb(bombPoch, pair.Key, pair.Value);

                        PopDequeue(casing, effects);

                        break;

                    }

                }
                if (!createdBomb)
                {
                    int decreasedCasing = DecereasingCasing(casing);

                   
                        PushInStack(casing, decreasedCasing);

                    

                }
            }

            Console.WriteLine(
                isFull
                ? "Bene! You have successfully filled the bomb pouch!"
                : "You don't have enough materials to fill the bomb pouch.");

            Console.WriteLine(
                effects.Count == 0 ? "Bomb Effects: empty" : "Bomb Effects: " + string.Join(", ", effects));
            Console.WriteLine(casing.Count == 0 ? "Bomb Casings: empty" : "Bomb Casings: " + string.Join(", ", casing));

            foreach (var pair in bombPoch.OrderBy(b => b.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

        }

        private static bool PorchIsFull(Dictionary<string, int> bombPoch)
        {
            bool isPorchFilled = false;

            foreach (var pair in bombPoch)
            {
                if (pair.Value >= 3)
                {
                    isPorchFilled = true;
                }
                else
                {
                    isPorchFilled = false;
                    break;
                }
            }

            return isPorchFilled;
        }

        private static void PopDequeue(Stack<int> casing, Queue<int> effects)
        {
            casing.Pop();
            effects.Dequeue();

        }

        private static void PushInStack(Stack<int> casing, int decreasedCasing)
        {
            casing.Push(decreasedCasing);
        }

        private static int DecereasingCasing(Stack<int> casing)
        {
            int casingToDecreease = casing.Pop() - 5;

            if (casingToDecreease < 0)
            {
                casingToDecreease = 0;
            }

            return casingToDecreease;
        }

        private static bool CreatingBomb(Dictionary<string, int> bombPoch, string key, int value)
        {

            bombPoch[key]++;

            return true;
        }

        private static bool IsAnyStorageEmpty(Stack<int> casing, Queue<int> effects)
        {
            if (casing.Count == 0)
            {
                return false;
            }

            if (effects.Count == 0)
            {
                return false;
            }

            return true;
        }


        private static Stack<int> FillingCasingsS(int[] bombCasings)
        {
            Stack<int> toReturnS = new Stack<int>();

            for (int i = 0; i < bombCasings.Length; i++)
            {
                toReturnS.Push(bombCasings[i]);
            }

            return toReturnS;
        }

        private static Queue<int> FillingEffectsQ(int[] bombEffects)
        {
            Queue<int> toReturnQ = new Queue<int>();

            for (int i = 0; i < bombEffects.Length; i++)
            {
                toReturnQ.Enqueue(bombEffects[i]);
            }

            return toReturnQ;
        }
    }
}
