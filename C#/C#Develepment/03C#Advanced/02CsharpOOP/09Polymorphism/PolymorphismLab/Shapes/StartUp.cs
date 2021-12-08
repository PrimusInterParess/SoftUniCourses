using System;

namespace Shapes
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rect = new Rectangle(3.0, 4.0);

            Shape circle = new Circle(5.4);

            Console.WriteLine(rect.CalculateArea());

            Console.WriteLine(circle.CalculateArea());
        }
    }
}
