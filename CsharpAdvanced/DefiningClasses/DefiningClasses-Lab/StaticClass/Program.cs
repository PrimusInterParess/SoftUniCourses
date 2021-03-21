using System;

namespace StaticClass
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftUniMath mathsSoftUniMath = new SoftUniMath();

            SoftUniMath.Add(5, 6);

            mathsSoftUniMath.PI = 3;

            mathsSoftUniMath.Multiply(5, 6);

            
        }
    }
}
