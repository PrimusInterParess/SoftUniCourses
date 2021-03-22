using System;
using System.Collections.Generic;
using System.Text;

namespace GG
{
    public class MyComperator
    {

        public static bool Copare<T>(T first, T second)
        {
            return first.Equals(second);
        }
    }
}
