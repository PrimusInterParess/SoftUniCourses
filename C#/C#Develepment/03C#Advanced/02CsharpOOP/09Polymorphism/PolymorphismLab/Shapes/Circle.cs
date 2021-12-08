using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;


        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            private set => this.radius = value;

        }



        public override double CalculatePerimeter()
        {
            double result = 2 * Math.PI * this.Radius;

            return result;
        }

        public override double CalculateArea()
        {
            double result = Math.PI * Math.Pow(this.Radius, 2);

            return result;
        }

        public override string Draw()
        {
            return nameof(Circle);
        }
    }
}
