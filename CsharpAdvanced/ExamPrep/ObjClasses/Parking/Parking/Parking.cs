using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{


    public class Parking
    {

        private List<Car> data;


        public Parking(string type, int capacity)
        {

            Type = type;
            Capacity = capacity;

            data = new List<Car>();

        }

        public int Count { get; private set; }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if (Count < this.Capacity)
            {
                this.data.Add(car);

                Count++;
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            return this.CheckForExistance(manufacturer, model);
        }

        public Car GetLatestCar()
        {
            if (this.data.Count > 0)
            {
                Car carToReturn = this.data.OrderByDescending(c => c.Year).FirstOrDefault();
                return carToReturn;


            }

            return null;

        }

        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = CheckForExistance(manufacturer, model);

            if (carToRemove != null)
            {
                this.data.Remove(carToRemove);
                this.Count--;
                return true;
            }

            return false;
        }

        private Car CheckForExistance(string manufacturer, string model)
        {
            foreach (var car in this.data)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    return car;
                }
            }

            return null;

        }

        public string GetStatistics()
        {
            return this.ToString();
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
