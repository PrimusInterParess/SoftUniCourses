using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected double Modifier { get; set; }

        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity, double modifier)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Modifier = modifier;
        }

        public double TankCapacity
        {
            get => this.tankCapacity;
           private set => this.tankCapacity = value;

        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;

                }

            }
        }

        public double FuelConsumption
        {
            get => this.fuelConsumption;
            private set => this.fuelConsumption = value;
        }

        public virtual void Drive(double distance)
        {
            var result = distance * (this.FuelConsumption + this.Modifier);

            if (result > this.FuelQuantity)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.fuelQuantity -= result;
        }

        public virtual void Refuel(double amountFuel)
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
              
                
                    this.FuelQuantity += amountFuel;

                
            }
           

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
