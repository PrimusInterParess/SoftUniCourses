using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
   public class Bus:Vehicle
   {
       private const double FUEL_MODIFIER = 1.4;
       private const double FUEL_M_Zer0 = 0;

        public Bus(double fuelQuantity, double fuelConsumption,double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity,FUEL_MODIFIER)
        {
        }

        public void OnModifier()
        {
            this.Modifier = FUEL_MODIFIER;
        }

        public void OffModifier()
        {
            this.Modifier = FUEL_M_Zer0;
        }
    }
}
