using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        private decimal total;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            switch (type)
            {
                case "Bread":
                    food = new Bread(name, price);
                    break;
                case "Cake":
                    food = new Cake(name, price);
                    break;
            }

            this.bakedFoods.Add(food);

            return $"Added {name} ({food.GetType().Name}) to the menu";
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            switch (type)
            {
                case "Tea":
                    drink = new Tea(name, portion, brand);
                    break;
                case "Water":
                    drink = new Water(name, portion, brand);
                    break;
            }

            this.drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            switch (type)
            {
                case "OutsideTable":
                    table = new OutsideTable(tableNumber, capacity);
                    break;
                case "InsideTable":
                    table = new InsideTable(tableNumber, capacity);
                    break;

            }

            this.tables.Add(table);

            return $"Added table number {tableNumber} in the bakery";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable toReserve = null;

            foreach (var table in this.tables)
            {
                if (table.IsReserved == false || table.Capacity <= numberOfPeople)
                {
                    toReserve = table;
                    break;
                }
            }

            if (toReserve == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            toReserve.Reserve(numberOfPeople);

            return $"Table {toReserve.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable toOrderTable = null;

            foreach (var table in this.tables)
            {
                if (table.TableNumber == tableNumber)
                {
                    toOrderTable = table;
                    break;
                }
            }

            if (toOrderTable == null)
            {
                return $"Could not find table {tableNumber}";
            }

            IBakedFood addToTableFood = null;

            foreach (var food in bakedFoods)
            {
                if (food.Name == foodName)
                {
                    addToTableFood = food;
                    break;

                }
            }

            if (addToTableFood == null)
            {
                return $"No {foodName} in the menu";
            }

            toOrderTable.OrderFood(addToTableFood);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {

            ITable toOrderTable = null;

            foreach (var table in this.tables)
            {
                if (table.TableNumber == tableNumber)
                {
                    toOrderTable = table;
                    break;
                }
            }

            if (toOrderTable == null)
            {
                return $"Could not find table {tableNumber}";
            }

            IDrink toAddToTable = null;

            foreach (var drink in this.drinks)
            {
                if (drink.Name == drink.Name && drink.Brand == drinkBrand)
                {
                    toAddToTable = drink;
                    break;

                }
            }

            if (toAddToTable == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            toOrderTable.OrderDrink(toAddToTable);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable toClear = null;

            foreach (var table in this.tables)
            {
                if (table.TableNumber == tableNumber)
                {


                    toClear = table;
                }
            }

            decimal bill = toClear.GetBill();

            total += bill;

            toClear.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables)
            {
                if (table.IsReserved == false)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            
          
            return $"Total income: {this.total:F2}";

        }
    }
}
