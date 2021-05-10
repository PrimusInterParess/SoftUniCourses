using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaName = Console.ReadLine().Split()[1];

            string[] doughData = Console.ReadLine().Split();

            string flourType = doughData[1];
            string doughType = doughData[2];
            double doughWeight = double.Parse(doughData[3]);

            try
            {
                Pizza pizza = new Pizza(pizzaName, new Dough(flourType, doughType, doughWeight));

                string input = String.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingData = input.Split();

                    string toppingName = toppingData[1];
                    double toppingWeight = double.Parse(toppingData[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddToppings(topping);

                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalculatingCalories():F2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

            }


        }
    }
}
