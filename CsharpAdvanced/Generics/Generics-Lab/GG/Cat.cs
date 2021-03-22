using System;
using System.Collections.Generic;
using System.Text;

namespace GG
{
    public class Cat : Animal
    {

        public Cat(string name)
        {
            this.Name = name;
        }
       
        public string SayHello()
        {
            return "Mew!";
        }

        public override bool Equals(object obj)
        {
            if (obj is Cat cat)
            {
                return this.Name == cat.Name;
            }

            return false;
        }
    }
}
