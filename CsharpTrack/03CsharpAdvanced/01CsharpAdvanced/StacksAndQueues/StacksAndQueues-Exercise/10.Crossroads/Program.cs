using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());

            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> carQueue = new Queue<string>();

            string hit = string.Empty;

            bool crash = false;

            int passedCars = 0;

            string currentCar = String.Empty;

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string car = input;

                if (car == "green")
                {
                    int currentGreenLight = greenLightDuration;

                    int currentFree = freeWindow;


                    while (currentGreenLight != 0)
                    {

                        if (carQueue.Count == 0)
                        {

                            break;
                        }

                        Queue<char> carPassing = new Queue<char>(carQueue.Dequeue().ToCharArray());

                        currentCar = new string(carPassing.ToArray());

                        while (carPassing.Count != 0)
                        {
                            if (currentGreenLight == 0)
                            {
                                while (currentFree != 0)
                                {
                                    carPassing.Dequeue();
                                    currentFree--;

                                    if (carPassing.Count == 0)
                                    {

                                        passedCars++;
                                        break;

                                    }

                                }

                                if (carPassing.Count != 0)
                                {
                                    hit = carPassing.Dequeue().ToString();
                                    crash = true;
                                }
                            }
                            else
                            {
                                carPassing.Dequeue();
                                currentGreenLight--;

                                if (carPassing.Count == 0)
                                {
                                    passedCars++;
                                }
                            }

                            if (crash)
                            {
                                break;
                            }


                        }

                        if (crash)
                        {
                            break;

                        }


                    }

                }
                else
                {
                    carQueue.Enqueue(car);
                }

                if (crash)
                {
                    break;
                }


            }

            if (crash)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{currentCar} was hit at {hit}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }
    }
}
