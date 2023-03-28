using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Tire
    {
        private int year;

        private double pressure;

        public Tire(double pressure, int year)
        {
            Pressure = pressure;
            Year = year;
        }

        public int Year
        {
            get => this.year;
            set => this.year = value;
        }

        public double Pressure
        {
            get => this.pressure;
            set => this.pressure = value;
        }

    }
}
