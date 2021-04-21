using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string typeOfAnimal = Console.ReadLine();

                if (typeOfAnimal == "Beast!")
                {
                    break;
                    ;
                }

                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (string.IsNullOrEmpty(data[0]) || int.Parse(data[1]) < 0|| string.IsNullOrEmpty(data[1]))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                if (typeOfAnimal=="Dog")
                {
                    Dog doggy = new Dog(name, age, gender);

                    Console.WriteLine(doggy);
                }
                else if (typeOfAnimal=="Cat")
                {
                    Cat catty = new Cat(name, age, gender);

                    Console.WriteLine(catty);
                }
                else if (typeOfAnimal=="Frog")

                {
                    Frog froggy = new Frog(name, age, gender);

                    Console.WriteLine(froggy);
                }
                else if (typeOfAnimal=="Tomcat")
                {
                    Tomcat tomcatt = new Tomcat(name, age);

                    Console.WriteLine(tomcatt);
                }
                else if (typeOfAnimal == "Kitten")
                {
                    Kitten kittenn = new Kitten(name, age);

                    Console.WriteLine(kittenn);
                }
            }


        }
    }
}
