using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MobileX
{
    public class VehicleRepository : IVehicleRepository, IEnumerable<Vehicle>
    {
        private class HorsePowerOrderer : IComparer<Vehicle>
        {
            public int Compare(Vehicle x, Vehicle y)
            {
                int comp = y.Horsepower.CompareTo(x.Horsepower);

                if (comp == 0)
                {
                    comp = x.Id.CompareTo(y.Id);
                }

                return comp;
            }
        }
        private class VipPriceIdComparer : IComparer<Vehicle>
        {
            public int Compare(Vehicle x, Vehicle y)
            {

                int comp = y.IsVIP.CompareTo(x.IsVIP);

                if (comp == 0)
                {
                    comp = x.Price.CompareTo(y.Price);
                }

                if (comp == 0)
                {
                    comp = x.Id.CompareTo(y.Id);
                }

                return comp;
            }
        }
        private class HorsePowerDCSPriceASCSellerASC : IComparer<Vehicle>
        {
            public int Compare(Vehicle x, Vehicle y)
            {
                int comp = y.Horsepower.CompareTo(x.Horsepower);

                if (comp == 0)
                {
                    comp = x.Price.CompareTo(y.Price);
                }

                if (comp == 0)
                {
                    comp = x.SellerName.CompareTo(y.SellerName);
                }

                if (comp == 0)
                {
                    comp = x.Id.CompareTo(y.Id);
                }

                return comp;
            }
        }
        private class brandOrderer : IComparer<Vehicle>
        {
            public int Compare(Vehicle x, Vehicle y)
            {
                int comp = x.Price.CompareTo(y.Price);

                if (comp == 0)
                {
                    comp = x.Id.CompareTo(y.Id);
                }

                return comp;
            }
        }
        private class vipOrderer : IComparer<Vehicle>
        {
            public int Compare(Vehicle x, Vehicle y)
            {
                int comp = x.Price.CompareTo(y.Price);

                if (comp == 0)
                {
                    comp = x.Id.CompareTo(y.Id);
                }

                return comp;
            }
        }
        private class priceOrderer : IComparer<Vehicle>
        {
            public int Compare(Vehicle x, Vehicle y)
            {
                int comp = x.Price.CompareTo(y.Price);

                if (comp == 0)
                {
                    comp = x.Id.CompareTo(y.Id);
                }

                return comp;
            }

        }

        private HashSet<string> sellerName;
        private SortedSet<Vehicle> vipSorted;
        private SortedSet<Vehicle> longSorted;

        private Dictionary<double, SortedSet<Vehicle>> priceHorsepowerOrdered;
        private Dictionary<string, SortedSet<Vehicle>> brandCarsSorted;
        private Dictionary<string, SortedSet<Vehicle>> sellerOrderdCars;

        private Dictionary<string, List<Vehicle>> sellerNameVehicles;
        private Dictionary<string, Vehicle> carsById;


        public VehicleRepository()
        {
            this.sellerName = new HashSet<string>();
            this.vipSorted = new SortedSet<Vehicle>(new vipOrderer());
            this.brandCarsSorted = new Dictionary<string, SortedSet<Vehicle>>();
            this.sellerNameVehicles = new Dictionary<string, List<Vehicle>>();
            this.priceHorsepowerOrdered = new Dictionary<double, SortedSet<Vehicle>>();
            this.sellerOrderdCars = new Dictionary<string, SortedSet<Vehicle>>();
            this.carsById = new Dictionary<string, Vehicle>();
            this.longSorted = new SortedSet<Vehicle>(new HorsePowerDCSPriceASCSellerASC());
        }

        public int Count => this.carsById.Count;

        public void AddVehicleForSale(Vehicle vehicle, string sellerName)
        {
            this.sellerName.Add(sellerName);

            vehicle.SellerName = sellerName;

            if (vehicle.IsVIP)
            {
                this.vipSorted.Add(vehicle);
            }

            if (!this.brandCarsSorted.ContainsKey(vehicle.Brand))
            {
                this.brandCarsSorted[vehicle.Brand] = new SortedSet<Vehicle>(new brandOrderer());
            }

            if (!this.sellerNameVehicles.ContainsKey(sellerName))
            {
                this.sellerNameVehicles[sellerName] = new List<Vehicle>();
                this.sellerOrderdCars[sellerName] = new SortedSet<Vehicle>(new priceOrderer());
            }

            if (!priceHorsepowerOrdered.ContainsKey(vehicle.Price))
            {
                this.priceHorsepowerOrdered[vehicle.Price] = new SortedSet<Vehicle>();
            }

            if (!this.carsById.ContainsKey(vehicle.Id))
            {
                this.carsById.Add(vehicle.Id, vehicle);
            }

            this.longSorted.Add(vehicle);
            this.sellerOrderdCars[sellerName].Add(vehicle);
            this.priceHorsepowerOrdered[vehicle.Price].Add(vehicle);
            this.sellerNameVehicles[sellerName].Add(vehicle);
            this.brandCarsSorted[vehicle.Brand].Add(vehicle);

        }

        public Vehicle BuyCheapestFromSeller(string sellerName)
        {
            if (!this.sellerName.Contains(sellerName))
            {
                throw new ArgumentException();
            }

            if (sellerOrderdCars[sellerName].Count == 0)
            {
                throw new ArgumentException();
            }

            return sellerOrderdCars[sellerName].Min;
        }

        public bool Contains(Vehicle vehicle)
        {
            return this.carsById.ContainsKey(vehicle.Id);
        }

        public Dictionary<string, List<Vehicle>> GetAllVehiclesGroupedByBrand()
        {
            if (brandCarsSorted.Count == 0)
            {
                throw new ArgumentException();
            }

            return this.brandCarsSorted.ToDictionary(x => x.Key, x => x.Value.ToList());
        }

        public IEnumerable<Vehicle> GetAllVehiclesOrderedByHorsepowerDescendingThenByPriceThenBySellerName()
        {
            return this.longSorted;
        }

        public IEnumerable<Vehicle> GetVehicles(List<string> keywords)
        {
            SortedSet<Vehicle> orderd = new SortedSet<Vehicle>(new VipPriceIdComparer());

            foreach (var vehicle in this.longSorted)
            {
                if (vehicle.fundamentals.Intersect(keywords).Any())
                {
                    orderd.Add(vehicle);
                }
            }

            return orderd;
        }

        public IEnumerable<Vehicle> GetVehiclesBySeller(string sellerName)
        {
            if (!this.sellerName.Contains(sellerName))
            {
                throw new ArgumentException();
            }

            return this.sellerNameVehicles[sellerName];
        }

        public IEnumerable<Vehicle> GetVehiclesInPriceRange(double lowerBound, double upperBound)
        {
            SortedSet<Vehicle> toReturn = new SortedSet<Vehicle>(new HorsePowerOrderer());

            foreach (var key in priceHorsepowerOrdered)
            {
                if (key.Key >= lowerBound && key.Key <= upperBound)
                {
                    foreach (var vehicle in key.Value)
                    {
                        toReturn.Add(vehicle);
                    }
                }
            }

            return toReturn;
        }

        public void RemoveVehicle(string vehicleId)
        {
            if (!this.carsById.ContainsKey(vehicleId))
            {
                throw new ArgumentException();
            }

            Vehicle toRemove = this.carsById[vehicleId];

            this.vipSorted.Remove(toRemove);
            this.longSorted.Remove(toRemove);
            this.priceHorsepowerOrdered[toRemove.Price].Remove(toRemove);
            this.brandCarsSorted[toRemove.Brand].Remove(toRemove);
            this.sellerOrderdCars[toRemove.SellerName].Remove(toRemove);
            this.sellerNameVehicles[toRemove.SellerName].Remove(toRemove);
            this.carsById.Remove(vehicleId);

        }

        public IEnumerator<Vehicle> GetEnumerator()
        {
            foreach (var car in carsById.Values)
            {
                yield return car;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
