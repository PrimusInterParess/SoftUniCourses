using System;
using System.Linq;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personalData = Console.ReadLine().Split().ToArray();

            string name = $"{personalData[0]} {personalData[1]}";
            string address = personalData[2];
            string town = string.Join(' ', personalData.Skip(3));

            string[] beerAmount = Console.ReadLine().Split().ToArray();

            string drinkerName = beerAmount[0];
            int amountOfBeer = int.Parse(beerAmount[1]);
            string condition = beerAmount[2];

            bool isDrunk = condition == "drunk";

            string[] intDouble = Console.ReadLine().Split().ToArray();

            string integer =intDouble[0];
            double doubleN = double.Parse(intDouble[1]);
            string initials = intDouble[2];

            Tuple<string, string,string> nameAndAddress = new Tuple<string, string,string>(name, address,town);

            Tuple<string, int,bool> drinker = new Tuple<string, int,bool>(drinkerName, amountOfBeer, isDrunk);

            Tuple<string, double,string> doubleInt = new Tuple<string, double,string>(integer,doubleN, initials);

            Console.WriteLine(nameAndAddress);
            Console.WriteLine(drinker);
            Console.WriteLine(doubleInt);





        }
    }
}
