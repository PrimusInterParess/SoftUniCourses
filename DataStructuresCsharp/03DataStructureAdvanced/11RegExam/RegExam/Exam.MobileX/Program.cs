using System;
using System.Collections.Generic;

namespace Exam.MobileX
{
    public class Program
    {
        static void Main(string[] args)
        {

            VehicleRepository repo = new VehicleRepository();

            Vehicle car1 = new Vehicle("a", "VW", "Passat", "Germany", "navy blue", 105, 15000, false);
            Vehicle car2 = new Vehicle("b", "VW", "Golf", "Bulgaria", "blue", 150, 20000, false);
            Vehicle car3 = new Vehicle("c", "VW", "T-Rock", "Germany", "orange", 180, 17000, false);
            Vehicle car4 = new Vehicle("d", "VW", "Arteon", "France", "green", 250, 55000, true);
            Vehicle car5 = new Vehicle("e", "VW", "Toareg", "Germany", "white", 200, 45000, true);
            Vehicle car6 = new Vehicle("f", "Audi", "A4", "France", "navy blue", 135, 10000, false);
            Vehicle car7 = new Vehicle("g", "Audi", "A8", "Spain", "gold", 250, 60000, true);
            Vehicle car8 = new Vehicle("h", "Audi", "A4", "Germany", "grey", 125, 8000, false);
            Vehicle car9 = new Vehicle("j", "Mazzerati", "SpaceShip", "Italy", "chamelion", 1000, 100000, true);


            string sellerName1 = "Gosho Motikata";
            string sellerName2 = "Ivan Teneketo";
            string sellerName3 = "Grozdan Livadata";

            List<Vehicle> cars1 = new List<Vehicle> { car1, car3, car8 };
            List<Vehicle> cars2 = new List<Vehicle> { car2, car6, car7 };
            List<Vehicle> cars3 = new List<Vehicle> { car4, car5, car9 };

            foreach (var ccar in cars1)
            {
                repo.AddVehicleForSale(ccar, sellerName1);
            }

            foreach (var carr in cars2)
            {
                repo.AddVehicleForSale(carr, sellerName2);
            }

            foreach (var caar in cars3)
            {
                repo.AddVehicleForSale(caar, sellerName3);
            }

            Vehicle car = repo.BuyCheapestFromSeller(sellerName1);

            IEnumerable<Vehicle> returned = repo.GetVehiclesInPriceRange(10000, 21000);

            Dictionary<string, List<Vehicle>> returnedDic = repo.GetAllVehiclesGroupedByBrand();

            IEnumerable<Vehicle> loong = repo.GetAllVehiclesOrderedByHorsepowerDescendingThenByPriceThenBySellerName();

            List<string> funds = new List<string> {"VW", "A4", "Italy", "Bulgaria"};

            IEnumerable<Vehicle> sett = repo.GetVehicles(funds);

        }
    }
}
