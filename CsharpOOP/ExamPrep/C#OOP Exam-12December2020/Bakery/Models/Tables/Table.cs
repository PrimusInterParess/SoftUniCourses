using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public IReadOnlyCollection<IBakedFood> FoodOrders => this.foodOrders;
        public IReadOnlyCollection<IDrink> DrinkOrders => this.drinkOrders;

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new AggregateException(Utilities.Messages.ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; private set; }
        public bool IsReserved { get; private set; }
        public decimal Price { get; private set; }
        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;

            this.IsReserved = true;

        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal foodPrice = this.foodOrders.Sum(c => c.Price);
            decimal drinkPrice = this.drinkOrders.Sum(c => c.Price);
            this.Price = this.NumberOfPeople * PricePerPerson;

            return foodPrice + drinkPrice + Price;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.Price = 0;
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public string GetFreeTableInfo()
        {

            //string result = $"Table: {this.TableNumber}r/n/" +
            //                $"Type: {this.GetType().Name}/r/n/" +
            //                $"Capacity: {this.Capacity}/r/n" +
            //                $"Capacity: {this.PricePerPerson}";


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Capacity: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }
    }


}
