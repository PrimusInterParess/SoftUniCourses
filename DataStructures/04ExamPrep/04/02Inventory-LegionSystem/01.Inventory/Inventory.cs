using System.Linq;

namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private List<IWeapon> weapons;

        public Inventory()
        {
            this.weapons = new List<IWeapon>();

        }

        public int Capacity => this.weapons.Count;

        public void Add(IWeapon weapon)
        {
            this.weapons.Add(weapon);

        }

        public void Clear()
        {
            this.weapons.Clear();

        }

        public bool Contains(IWeapon weapon)
        {
            return this.weapons.Contains(weapon);
        }

        public void EmptyArsenal(Category category)
        {
            
            for (int i = 0; i < this.weapons.Count; i++)
            {
                if (weapons[i].Category.Equals(category))
                {
                    weapons[i].Ammunition = 0;
                }
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            int indexOFWeapon = weapons.IndexOf(weapon);

            this.CheckForExistance(indexOFWeapon);

            if (weapons[indexOFWeapon].Ammunition >= ammunition)
            {
                this.weapons[indexOFWeapon].Ammunition -= ammunition;
                return true;

            }

            return false;

        }

        public IWeapon GetById(int id)
        {
            IWeapon weapon = null;

            for (int i = 0; i < this.weapons.Count; i++)
            {
                if (weapons[i].Id == id)
                {
                    weapon = weapons[i];
                    break;
                }
            }

            return weapon;

            //IWeapon toReturn = null;

            //if (this.weaponsById.ContainsKey(id))
            //{
            //    toReturn = this.weaponsById[id];
            //}

            //return toReturn;
        }



        public int Refill(IWeapon weapon, int ammunition)
        {
            int index = this.weapons.IndexOf(weapon);

            this.CheckForExistance(index);

            int toRefill = weapons[index].MaxCapacity - weapons[index].Ammunition;

            int all = toRefill + ammunition;

            if (toRefill <= ammunition)
            {
                weapons[index].Ammunition = weapon.MaxCapacity;
                return weapons[index].MaxCapacity;

            }

            weapons[index].Ammunition +=ammunition;

            return weapons[index].Ammunition;

        }

        public IWeapon RemoveById(int id)
        {

            IWeapon weapon = null;
            for (int i = 0; i < this.weapons.Count; i++)
            {
                if (weapons[i].Id == id)
                {
                    weapon = weapons[i];
                    this.weapons.RemoveAt(i);
                    break;
                }
            }

            if (weapon == null)
            {
                this.CheckForExistance(-1);
            }

            return weapon;

            //if (!this.weaponsById.ContainsKey(id))
            //{
            //    throw new InvalidOperationException("Weapon does not exist in inventory!");
            //}
            //var toReturn = this.weaponsById[id];

            //this.weaponsById.Remove(id);
            //this.weapons.Remove(toReturn);

            //return toReturn;
        }

        public int RemoveHeavy()
        {
            int removed = this.weapons.RemoveAll(w => w.Category.Equals(Category.Heavy));

            return removed;
        }

        public List<IWeapon> RetrieveAll()
        {
            return new List<IWeapon>(this.weapons);
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            List<IWeapon> inRange = new List<IWeapon>(this.Capacity);

            foreach (var weapon in weapons)
            {
                if (weapon.Category >= lower && weapon.Category <= upper)
                {
                    inRange.Add(weapon);
                }
            }

            return inRange;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            int indexOfFirst = this.weapons.IndexOf(firstWeapon);
            int indexOfSecond = this.weapons.IndexOf(secondWeapon);

            this.CheckForExistance(indexOfFirst);
            this.CheckForExistance(indexOfSecond);

            this.SwapWeapons(indexOfFirst, indexOfSecond);
        }

        private void SwapWeapons(int firstWeapon, int secondWeapon)
        {
            if ((int)weapons[firstWeapon].Category == (int)weapons[secondWeapon].Category)
            {
                var temp = this.weapons[firstWeapon];
                this.weapons[firstWeapon] = this.weapons[secondWeapon];
                this.weapons[secondWeapon] = temp;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.weapons.GetEnumerator();
        }

        private void CheckForExistance(int index)
        {
            if (index < 0)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }
    }
}
