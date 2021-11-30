using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    class Child :Person
    {

        private int age;

        public Child(string name ,int age)
        :base(name, age)
        {
            
            
        }

        public override int Age
        {
            get => this.age;

            set => this.age = value < 15
                ? this.age = value
                : throw new ArgumentException("Child age should be less then 15");
        }
    }
}
