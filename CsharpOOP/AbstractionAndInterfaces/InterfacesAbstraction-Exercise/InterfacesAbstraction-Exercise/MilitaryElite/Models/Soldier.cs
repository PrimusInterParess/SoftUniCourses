<<<<<<< HEAD
﻿namespace MilitaryElite.Models
{
    public class Soldier
    {
        
=======
﻿using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public abstract class Soldier :ISoldier
    {
        protected Soldier(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            
        }

        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }


        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
>>>>>>> 1da4f0a59048628ece27fd6c16b820c840615a92
    }
}