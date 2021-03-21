using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;

        private string model;

        private int year;

        private double fuelQuantity;

        private double fuelConsumption;

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(List<Tire> tires) 
            : this()
        {
            Tires = tires;
        }

        public Car(string make, string model, int year, List<Tire> tires)
            : this(tires)
        {
            Make = make;
            Model = model;
            Year = year;

        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, List<Tire> tires)
        : this(make, model, year, tires)
        {
            FuelQuantity = fuelQuantity;

            FuelConsumption = fuelConsumption;

        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,Engine engine, List<Tire> tires)
        : this(make: make, model: model, year: year, fuelQuantity: fuelQuantity, fuelConsumption: fuelConsumption, tires: tires)
        {
            Engine = engine;
            
        }





        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public List<Tire> Tires { get; set; }


        public void Drive(double distance)
        {

            double result = (FuelConsumption / 100) * distance;

            if (result > 0)
            {
                FuelQuantity -= (FuelConsumption / 100) * distance;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }

        }

        public List<Car> ShowSpecial(List<Car> cars)
        {
            List<Car> specialCars = new List<Car>();

            return specialCars;
        }



        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nHorsePower: {this.Engine.HorsePower}\nFuel: {this.FuelQuantity:F2}L";
        }
    }



}
