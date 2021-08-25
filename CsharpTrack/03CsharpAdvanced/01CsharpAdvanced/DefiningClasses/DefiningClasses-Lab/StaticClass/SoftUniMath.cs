using System;
using System.Collections.Generic;
using System.Text;

namespace StaticClass
{
    public class SoftUniMath
    {
        public int PI { get; set; }


        public static int Add(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b + this.PI;
        }


    }
}
