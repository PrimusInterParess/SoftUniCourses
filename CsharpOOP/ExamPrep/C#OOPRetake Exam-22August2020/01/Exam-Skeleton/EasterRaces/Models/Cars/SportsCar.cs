using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public class SportsCar : Car
    {
        private const int minHorsePower = 250;
        private const int maxHorsePower = 450;
        private const double cubicCentimeters = 3000;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}
