using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
  public class MuscleCar:Car
  {
      private const int minHorsePower = 400;
      private const int maxHorsePower = 600;
      private const double cubicCentimeters = 5000;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}
