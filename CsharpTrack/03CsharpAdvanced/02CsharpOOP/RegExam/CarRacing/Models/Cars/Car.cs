using System;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        protected Car(string make,
            string model,
            string VIN,
            int horsePower,
            double fuelAvailable,
            double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.VIN = VIN;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;

        }


        public string Make
        {
            get => this.make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidCarMake);
                }

                this.make = value;
            }
        }
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidCarMake);
                }

                this.model = value;
            }
        }

        public string VIN
        {
            get => this.vin;
            private set
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidCarVIN);
                }

                this.vin = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidCarHorsePower);
                }

                this.horsePower =value;
            }
        }

        public double FuelAvailable
        {
            get => this.fuelAvailable;
            private set
            {
                if (value < 0)
                {
                    this.fuelAvailable = 0;
                }
                else
                {
                    this.fuelAvailable = value;
                }

            }
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumptionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidCarFuelConsumption);
                }


                this.fuelConsumptionPerRace = value;

            }

        }

        public virtual void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
        }
    }
}
