using System;
using System.Collections.Generic;
using System.Text;


namespace PersonInfo
{
    public class Citizen : IBuyer, IBirthdate,IIdentifiable
    {
        private const int DEF_FOOD_AMOUNT = 0;

        public Citizen(string name, int age,string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = DEF_FOOD_AMOUNT;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; private set; }

        public string Birthdate { get; private set; }

        public string Id { get; private set; }

        public void BuyFood()
        {

            this.Food += 10;
        }

       
    }
}
