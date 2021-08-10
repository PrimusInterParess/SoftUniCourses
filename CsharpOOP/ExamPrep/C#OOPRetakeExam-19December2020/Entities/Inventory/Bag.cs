using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private const int constCapacity = 100;
        private int capacity;
        private readonly List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }
        public int Capacity
        {
            get => this.capacity;
            set
            {
                if (value == 0)
                {
                    value = constCapacity;
                }

                this.capacity = value;
            }
        }

        public int Load
        {
            get
            {
                int totalWeight = 0;

                foreach (var item in this.items)
                {
                    totalWeight += item.Weight;
                }

                return totalWeight;
            }

        }
        public IReadOnlyCollection<Item> Items
        {
            get => this.items.AsReadOnly();
        }
        public void AddItem(Item item)
        {
            int totalLoad = this.Load + item.Weight;

            if (totalLoad > capacity)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(Constants.ExceptionMessages.EmptyBag);
            }

            Item item = null;

            foreach (var it in items)
            {
                if (it.GetType().Name == name)
                {
                    item = it;
                    break;

                }
            }

            if (item == null)
            {
                throw new ArgumentException(string.Format(Constants.ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(item);

            return item;
        }
    }
}
