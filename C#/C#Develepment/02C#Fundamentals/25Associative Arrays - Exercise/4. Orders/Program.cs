using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, Product> productsList = new Dictionary<string, Product>();

            while (!((input = Console.ReadLine()) == "buy"))
            {
                string[] products = input.Split().ToArray();

                Product product = new Product(products[0], double.Parse(products[1]), int.Parse(products[2]));

                if (!productsList.ContainsKey(products[0]))
                {
                    productsList.Add(products[0], product);
                }
                else
                {
                    productsList[products[0]].Price = double.Parse(products[1]);
                    productsList[products[0]].Quantity += int.Parse(products[2]);

                }
            }

            foreach (var item in productsList)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Price*item.Value.Quantity:f2}");
            }

        }
    }

    public class Product
    {
        public string Name { get; set; }
        public double price;
        public int quantity;

        public Product(string name, double price, int quantity)
        {
            Name = name;
            this.price = price;
            this.quantity = quantity;
            
        }

        public int Quantity 
        {
            get 
            { 
                return quantity;
            }
            set
            {
                quantity = value; 
            }
        }

        public double Price
        {

            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
    }
}
