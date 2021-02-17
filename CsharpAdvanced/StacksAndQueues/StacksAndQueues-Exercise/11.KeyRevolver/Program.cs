using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {





            // starts to shoot the locks front-to - back, while going through the bullets back-to - front.
            //  If the bullet has a smaller or equal size to the current lock, print “Bang!”, then remove the lock.
            // If not, print "Ping!",
            // leaving the lock intact.The bullet is removed in both cases.
            //    If Sam runs out of bullets in his barrel, print "Reloading!" on the console,
            // then continue shooting.If there aren’t any bullets left, don’t print it.
            //    The program ends when Sam either runs out of bullets, or the safe runs out of locks.


            int bulletPrice = int.Parse(Console.ReadLine());

            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int reword = int.Parse(Console.ReadLine());

            Stack<int> bulletStack = new Stack<int>(bullets);

            Queue<int> locksQueue = new Queue<int>(locks);

            bool finishedBullets = false;

            int barelLimit = gunBarrelSize;

            int usedBullets = 0;

            while (locksQueue.Count != 0)
            {
                if (bulletStack.Count == 0)
                {
                    break;
                }

                int currentBullet = bulletStack.Pop();

                usedBullets++;
                barelLimit--;



                if (locksQueue.Peek() >= currentBullet)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();

                    if (barelLimit == 0)
                    {
                        if (bulletStack.Count == 0)
                        {
                            finishedBullets = true;

                            break;
                        }
                        else
                        {
                            barelLimit = gunBarrelSize;

                            Console.WriteLine("Reloading!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ping!");


                    if (barelLimit == 0)
                    {
                        if (bulletStack.Count == 0)
                        {
                            finishedBullets = true;

                            break;
                        }
                        else
                        {
                            barelLimit = gunBarrelSize;

                            Console.WriteLine("Reloading!");
                        }
                    }
                }
            }

            int earnings = reword - (bulletPrice * usedBullets);

            if (locksQueue.Count == 0)
            {
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${earnings}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }

        }
    }
}
