using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {

            get => this.length;
            private set
            {
                ChecksIfValueIsValid(value, nameof(this.Length));

                this.length = value;
            }
        }

        public double Width
        {

            get => this.width;
            private set
            {
                ChecksIfValueIsValid(value, nameof(this.Width));

                this.width = value;
            }
        }

        public double Height
        {

            get => this.height;
            private set
            {
                ChecksIfValueIsValid(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;


        }

        public double CalculateLateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;


        }

        public double CalculateVolume()
        {
            return this.Width * this.Length * this.Height;


        }

        private void ChecksIfValueIsValid(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
    }
}
