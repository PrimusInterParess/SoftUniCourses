using System;
using System.Collections.Generic;
using System.Text;

namespace AccessModifiers
{
     class Base
    {

        private int privateField;

        protected int protectedField; //child

        internal int internalField; //in the assembly

        public int publicField; // all projects


        public Base()
        {
            
        }
    }
}
