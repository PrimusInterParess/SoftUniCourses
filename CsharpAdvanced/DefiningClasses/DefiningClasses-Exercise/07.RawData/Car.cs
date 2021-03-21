using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Car
    {
        private string model;

        public Car(string model, Engine engine, Tire[] tires, Cargo cargo)
        {
            MODEL = model;
            Engine = engine;
            Tires = tires;
            Cargo = cargo;
        }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public Cargo Cargo { get; set; }

        public string MODEL
        {
            get => this.model;
            set => this.model = value;
        }
    }
}
