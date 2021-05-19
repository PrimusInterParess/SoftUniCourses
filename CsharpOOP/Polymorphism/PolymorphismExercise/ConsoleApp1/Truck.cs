using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
   public class Truck:Vehicle
   {
       private const double FUEL_MODIFIER = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption,double tankCapacity)
            : base(fuelQuantity, fuelConsumption,tankCapacity, FUEL_MODIFIER)
        { }

        public override void Refuel(double amountFuel)
        {
            base.Refuel(amountFuel*0.95);
        }
    }
}
