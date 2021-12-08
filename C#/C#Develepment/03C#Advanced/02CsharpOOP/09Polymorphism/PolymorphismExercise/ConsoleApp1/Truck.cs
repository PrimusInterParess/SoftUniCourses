using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double FUEL_MODIFIER = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, FUEL_MODIFIER)
        {
        }

        public override void Refuel(double amountFuel)
        {
            if (amountFuel <= 0)
            {
                throw new InvalidOperationException($"Fuel must be a positive number");
            }
            else
            {
                var fuelToAdd = amountFuel + this.FuelQuantity;

                if (fuelToAdd > this.TankCapacity)
                {
                    throw new InvalidOperationException($"Cannot fit {amountFuel} fuel in the tank");
                }


                this.FuelQuantity += amountFuel*0.95;
            }
        }
    }
}
