using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper Mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //string partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //string carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //string customerJson = File.ReadAllText("../../../Datasets/customers.json");
            //string saleJson = File.ReadAllText("../../../Datasets/sales.json");

            //string importSuppliers = ImportSuppliers(db, suppliersJson);
            //string importParts = ImportParts(db, partsJson);
            //string importCars = ImportCars(db, carsJson);
            //string importCustomers = ImportCustomers(db, customerJson);
            //string importSales = ImportSales(db, saleJson);


            string customersOrdered = GetOrderedCustomers(db);

            string carsMakeToyota = GetCarsFromMakeToyota(db);

            string localSuppliers = GetLocalSuppliers(db);

            string carsWithTheirPartsList = GetCarsWithTheirListOfParts(db);

            string totalSalesByCustomers = GetTotalSalesByCustomer(db);

            string salesWithAppliedDiscount = GetSalesWithAppliedDiscount(db);

            Console.WriteLine(salesWithAppliedDiscount);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(s => new
            {
                car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                },
                customerName = s.Customer.Name,
                Discount = s.Discount.ToString("f2"),
                price = s.Car.PartCars.Select(p => p.Part.Price).Sum().ToString("f2"),
                priceWithDiscount = (s.Car.PartCars.Select(p => p.Part.Price).Sum() -
                                        ((s.Car.PartCars.Select(p => p.Part.Price).Sum() * s.Discount) / 100)).ToString("f2")
            })
                .Take(10)
                .ToList();


            string jsontop10 = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return jsontop10;

        }


        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {

            //var totalSales =
            //context
            //    .Customers
            //    .Where(c => c.Sales.Count >= 1)
            //    .Select(c => new
            //    {
            //        fullName = c.Name,
            //        boughtCars = c.Sales.Count,
            //        spentMoney = c.Sales.Select(s => s.Car.PartCars.Sum(p => p.Part.Price))
            //    })
            //    .OrderByDescending(c => c.spentMoney)
            //    .ThenByDescending(c => c.boughtCars)
            //    .ToList();


            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(cp => cp.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();


            string jsonTotalSales = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return jsonTotalSales;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f2")
                    })
                }).ToList();

            string jsonCars = JsonConvert.SerializeObject(cars, Formatting.Indented);


            return jsonCars;

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)

                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();


            string jsonSuppliers = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return jsonSuppliers;

        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            string make = "Toyota";

            var cars = context
                .Cars
                .Where(c => c.Make == make)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();


            string jsonToyotaCars = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return jsonToyotaCars;


        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            string jsonCustomers = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return jsonCustomers;
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {

            InitializeAutoMapper();

            var dtoSales = JsonConvert.DeserializeObject<ICollection<SaleInputModel>>(inputJson);

            var sales = Mapper.Map<ICollection<Sale>>(dtoSales);

            context.Sales.AddRange(sales);

            context.SaveChanges();


            return $"Successfully imported {sales.Count()}.";
        }


        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {

            InitializeAutoMapper();

            var dtoCustomers =
                JsonConvert
                    .DeserializeObject<ICollection<CustomerInputModel>>(inputJson);

            ICollection<Customer> customers =
                Mapper
                    .Map<ICollection<Customer>>(dtoCustomers);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCars = JsonConvert
                .DeserializeObject<ICollection<CarInputModel>>(inputJson);

            foreach (var carInputModel in dtoCars)
            {
                Car car = new Car()
                {
                    Make = carInputModel.Make,
                    Model = carInputModel.Model,
                    TravelledDistance = carInputModel.TravelledDistance
                };

                foreach (var partId in carInputModel.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    car.PartCars.Add(partCar);
                }

                context.Cars.Add(car);

            }

            context.SaveChanges();


            context.SaveChanges();

            return $"Successfully imported {dtoCars.Count()}.";
        }


        public static string ImportParts(CarDealerContext context, string inputJson)
        {

            InitializeAutoMapper();

            var dtoParts = JsonConvert
                .DeserializeObject<ICollection<PartInputModel>>(inputJson);

            var suppliersIds = context.Suppliers.Select(s => s.Id).ToArray();


            ICollection<Part> parts = Mapper
                .Map<ICollection<Part>>(dtoParts)
                .Where(p => suppliersIds.Contains(p.SupplierId))
                .ToList();


            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoSuppliers = JsonConvert
                .DeserializeObject<ICollection<SupplierInputModel>>(inputJson);

            ICollection<Supplier> suppliers =
                Mapper
                .Map<ICollection<Supplier>>(dtoSuppliers);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";

        }

        private static void InitializeAutoMapper()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            Mapper = config.CreateMapper();
        }
    }


}