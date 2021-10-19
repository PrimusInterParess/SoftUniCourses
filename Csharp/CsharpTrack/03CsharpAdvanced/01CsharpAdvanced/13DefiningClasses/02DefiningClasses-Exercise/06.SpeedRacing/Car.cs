using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        private string model;

        private double fuelAmount;

        private double fuelConsumptionPerKilometer;

        private double traveleddistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;

            FuelAmount = fuelAmount;

            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;

            TraveledDistance = 0;
        }

        public string Model
        {
            get => this.model;

            set => this.model = value;
        }

        public double FuelAmount
        {
            get => this.fuelAmount;

            set => this.fuelAmount = value;
        }

        public double FuelConsumptionPerKilometer
        {
            get => this.fuelConsumptionPerKilometer;

            set => this.fuelConsumptionPerKilometer = value;
        }

        public double TraveledDistance { get; set; }


        public bool Drive(double amountOfKm)
        {
            double fuelAmountNeeded = FuelConsumptionPerKilometer * amountOfKm;

            if (fuelAmountNeeded <= FuelAmount)
            {
                FuelAmount -= fuelAmountNeeded;
                TraveledDistance += amountOfKm;

                return true;
            }

            return false;
                
            
        }




    }
}
