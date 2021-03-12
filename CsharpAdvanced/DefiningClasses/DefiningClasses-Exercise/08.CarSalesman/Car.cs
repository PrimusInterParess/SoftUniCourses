using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {

        private string model;

        private int weight; //optional

        private string color; //optional

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = 0;
            Color = "";

        }

        public Car(string model, Engine engine, int weight)
        : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, string color, int weight)
            : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }



        public Engine Engine { get; set; }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public int Weight
        {
            get => this.weight;
            set => this.weight = value;
        }

        public string Color
        {
            get => this.color;
            set => this.color = value;
        }
    }
}
