<<<<<<< HEAD
﻿namespace MilitaryElite.Models
{
    public class Private
    {
        
=======
﻿using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return$"{base.ToString()} Salary: {this.Salary:f2}";
        }
>>>>>>> 1da4f0a59048628ece27fd6c16b820c840615a92
    }
}