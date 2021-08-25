using System;
using System.Collections.Generic;
using System.Text;

namespace Ctors
{
     class Employee
    {

        public Employee(string name,int salary)
        {
            this.Name = name;
            this.Salary = salary;

            Console.WriteLine("In employee");
        }

        public string Name { get; set; }

        public int Salary { get; set; }

    }
}
