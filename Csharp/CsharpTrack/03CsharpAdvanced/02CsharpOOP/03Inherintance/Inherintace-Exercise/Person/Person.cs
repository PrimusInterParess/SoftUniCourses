using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Person
{
    public class Person
    {

        private string name { get; set; }
        private int age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual string Name
        {
            get => this.name;
            set => this.name = value.Length > 3
                ? this.name = value
                : throw new InvalidOperationException("Name length should be more than 3 characters");

        }

        public virtual int Age
        {
            get => this.age;
            set => this.age = value > 0 && this.age > 15
                ? this.age = value
                : throw new ArgumentException("Age should not be negative and should be larger thatn 15");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));

            return sb.ToString();
        }
    }
}
