using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            List<Animal> animals = new List<Animal>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalData = input.Split();

                string[] foodData = Console.ReadLine().Split();

                Animal animal = GetAnimal(animalData);

                Food food = GetFood(foodData);

                try
                {
                    Console.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food GetFood(string[] foodData)
        {
            Food foodToReturn = null;

            string type = foodData[0];
            int quantity = int.Parse(foodData[1]);

            if (type == nameof(Vegetable))
            {
                foodToReturn = new Vegetable(quantity);

            }
            else if (type == nameof(Fruit))
            {
                foodToReturn = new Fruit(quantity);

            }
            else if (type == nameof(Seeds))
            {
                foodToReturn = new Seeds(quantity);

            }
            else if (type == nameof(Meat))
            {
                foodToReturn = new Meat(quantity);

            }

            return foodToReturn;
        }

        private static Animal GetAnimal(string[] animalData)
        {
            Animal animalToRetur = null;

            string type = animalData[0];
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);

            if (type == nameof(Hen))
            {
                animalToRetur = new Hen(name, weight, double.Parse(animalData[3]));
            }
            else if (type == nameof(Owl))
            {
                animalToRetur = new Owl(name, weight, double.Parse(animalData[3]));

            }
            else if (type == nameof(Mouse))
            {
                animalToRetur = new Mouse(name, weight, animalData[3]);

            }
            else if (type == nameof(Dog))
            {
                animalToRetur = new Dog(name, weight, animalData[3]);

            }
            else if (type == nameof(Cat))
            {
                animalToRetur = new Cat(name, weight, animalData[3], animalData[4]);

            }
            else if (type == nameof(Tiger))
            {
                animalToRetur = new Tiger(name, weight, animalData[3], animalData[4]);

            }

            return animalToRetur;



        }
    }
}
