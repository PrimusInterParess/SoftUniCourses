using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();

            Dictionary<string, Product> products = new Dictionary<string, Product>();

            try
            {

                people = GetPeople();
                products = GetProducts();

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return;

            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split();

                var person = people[info[0]];
                var product = products[info[1]];


                try
                {
                    person.AddProduct(product);

                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
               
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }

        }

        private static Dictionary<string, Product> GetProducts()
        {
            var result = new Dictionary<string, Product>();

            string[] productData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var product in productData)
            {
                string[] data = product.Split("=", StringSplitOptions.RemoveEmptyEntries);

                var name = data[0];

                var cost = decimal.Parse(data[1]);

                result[name] = new Product(name, cost);
            }


            return result;
        }

        private static Dictionary<string, Person> GetPeople()
        {

            var result = new Dictionary<string, Person>();

            string[] personData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in personData)
            {

                var data = person.Split("=", StringSplitOptions.RemoveEmptyEntries);

                var name = data[0];

                var money = decimal.Parse(data[1]);

                result[name] = new Person(name, money);

            }

            return result;

        }
    }
}
