using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    class SkiRental
    {
        private Ski[] skies;

        private int counter = 0;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.skies = new Ski[capacity];
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return counter; }
        }

        public void Add(Ski ski)
        {
            if (counter < this.Capacity)
            {
                this.skies[counter] = ski;
                counter++;
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            for (int i = 0; i < counter; i++)
            {
                if (skies[i].Manufacturer == manufacturer && skies[i].Model == model)
                {
                    this.skies[i] = null;
                    this.counter -= 1;

                    return true;
                }
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            Ski newestSki = null;
            int newest = 0;

            if (this.skies.Length == 0)
            {
                return newestSki;
            }

            for (int i = 0; i < counter; i++)
            {
                if (skies[i].Year > newest)
                {
                    newest = skies[i].Year;
                    newestSki = skies[i];
                }
            }

            return newestSki;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            for (int i = 0; i <= counter; i++)
            {
                if (skies[i].Manufacturer == manufacturer && skies[i].Model == model)
                {
                    return skies[i];
                }
            }

            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");

            for (int i = 0; i < counter; i++)
            {
                sb.AppendLine(skies[i].ToString());
            }


            return sb.ToString().TrimEnd();
        }
    }
}
