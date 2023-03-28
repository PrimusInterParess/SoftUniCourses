using System.Linq;

namespace _01.Microsystem
{
    using System;
    using System.Collections.Generic;

    public class Microsystems : IMicrosystem
    {
        private Dictionary<int, Computer> computersByNumber;
        private Dictionary<Enum, List<Computer>> byBrand;

        public Microsystems()
        {
            this.byBrand = new Dictionary<Enum, List<Computer>>();
            this.computersByNumber = new Dictionary<int, Computer>();
        }

        public void CreateComputer(Computer computer)
        {
            if (this.computersByNumber.ContainsKey(computer.Number))
                throw new ArgumentException();

            if (!this.byBrand.ContainsKey(computer.Brand))
            {
                this.byBrand.Add(computer.Brand, new List<Computer>());
            }

            this.byBrand[computer.Brand].Add(computer);
            this.computersByNumber.Add(computer.Number, computer);
        }

        public bool Contains(int number)
        {
            return this.computersByNumber.ContainsKey(number);
        }

        public int Count()
        {
            return this.computersByNumber.Count;
        }

        public Computer GetComputer(int number)
        {
            if (!this.computersByNumber.ContainsKey(number))
                throw new ArgumentException();

            return this.computersByNumber[number];

        }

        public void Remove(int number)
        {
            if (!this.computersByNumber.ContainsKey(number))
                throw new ArgumentException();

            Computer toRemove = this.computersByNumber[number];


            this.computersByNumber.Remove(number);


        }

        public void RemoveWithBrand(Brand brand)
        {
            if (!this.byBrand.ContainsKey(brand))
                throw new ArgumentException();

            foreach (var comp in byBrand[brand])
            {
                if (this.computersByNumber.ContainsKey(comp.Number))
                {
                    this.computersByNumber.Remove(comp.Number);
                }
            }

            this.byBrand.Remove(brand);


        }

        public void UpgradeRam(int ram, int number)
        {
            if (!this.computersByNumber.ContainsKey(number))
                throw new ArgumentException();

            if (this.computersByNumber[number].RAM < ram)
            {
                this.computersByNumber[number].RAM = ram;
            }

        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
        {
            if (!this.byBrand.ContainsKey(brand))
                return new List<Computer>();

            return this.byBrand[brand].OrderByDescending(c => c.Price);


        }

        public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
        {
            return this.computersByNumber.Values.Where(c => c.ScreenSize == screenSize)
                .OrderByDescending(c => c.Number);

        }

        public IEnumerable<Computer> GetAllWithColor(string color)
        {
            return this.computersByNumber.Values.Where(c => c.Color == color).OrderByDescending(c => c.Price);
        }

        public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
        {
            return this.computersByNumber.Values.Where(c => c.Price >= minPrice && c.Price <= maxPrice)
                .OrderByDescending(c => c.Price);
        }
    }
}
