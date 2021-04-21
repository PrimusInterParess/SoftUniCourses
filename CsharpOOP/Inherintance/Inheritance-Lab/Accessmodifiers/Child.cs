using System;
using System.Collections.Generic;
using System.Text;
using AccessModifiers;

namespace Accessmodifiers
{
     class Child : Base
    {

        public Child()
        {
        }

        public double Weight { get; set; }

        public override void BaseMethod()
        {
            base.BaseMethod();
            Console.WriteLine("I'm the Child method");
        }

    }
}
