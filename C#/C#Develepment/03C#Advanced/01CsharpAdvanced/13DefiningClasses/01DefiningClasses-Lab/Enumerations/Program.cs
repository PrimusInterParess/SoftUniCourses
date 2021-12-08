using System;

namespace Enumerations
{
    class Program
    {
        static void Main(string[] args)
        {
            Size shirtSize = Size.M;

            Console.WriteLine(shirtSize);

            Shirt shirt = new Shirt();

            shirt.Size = (0);
        }
    }
}
