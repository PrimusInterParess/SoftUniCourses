using System;
using System.Collections.Generic;
using System.Linq;


namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int numberOfPeople = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] data = Console.ReadLine().Split();

                if (data.Length == 4)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    string birthDate = data[3];

                    if (!buyers.ContainsKey(name))
                    {
                        buyers[name] = new Citizen(name, age, id, birthDate);
                    }
                }
                else
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];

                    if (!buyers.ContainsKey(name))
                    {
                        buyers[name] = new Rebel(name, age, group);
                    }
                }
            }
            
            string input = String.Empty;

            while ((input=Console.ReadLine())!="End")
            {
                string name = input;

                if (buyers.ContainsKey(name))
                {
                    buyers[name].BuyFood();
                }
            }

            Console.WriteLine(buyers.Values.Sum(p=>p.Food));











        }
    }
}
