using System;
using System.Collections.Generic;
using System.Text;

namespace ConstraintsG
{
    class EmptyConstructorConstraint<T>
        where T : new()
    {
        public EmptyConstructorConstraint()
        {
            T x = new T();
        }
    }
}
