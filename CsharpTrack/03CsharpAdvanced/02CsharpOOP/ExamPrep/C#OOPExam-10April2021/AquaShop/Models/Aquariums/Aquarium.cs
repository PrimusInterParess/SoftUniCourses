using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly ICollection<IDecoration> decorations;
        private readonly ICollection<IFish> fish;
        private int capacity;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            decorations = new List<IDecoration>();
            fish = new List<IFish>();
        }


        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }
        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public int Comfort
        {
            get => this.Decorations.Sum(d => d.Comfort);
        }
        public ICollection<IDecoration> Decorations
        {
            get => this.decorations;
        }

        public ICollection<IFish> Fish
        {
            get => this.fish;
        }
        public void AddFish(IFish fish)
        {
            if (this.capacity > this.fish.Count)
            {
                this.fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.NotEnoughCapacity);
            }
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {string.Join(new string(", "), this.fish)}");
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return this.fish.Count == 0 ? "None" : sb.ToString().TrimEnd();
        }
    }
}
