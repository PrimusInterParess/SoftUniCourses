using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Dots.Export;
using CarDealer.Dots.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {


        public static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var suppliersXml = File.ReadAllText("suppliers.xml");

            //var partsXml = File.ReadAllText("parts.xml");

            //var carsXml = File.ReadAllText("cars.xml");

            //var customersXml = File.ReadAllText("customers.xml");

            //var salesXml = File.ReadAllText("sales.xml");

            //string suppliersImport = ImportSuppliers(db, suppliersXml);

            //string partsImport = ImportParts(db, partsXml);

            //string carsImport = ImportCars(db, carsXml);

            //string customersImport = ImportCustomers(db, customersXml);

            //string salesImport = ImportSales(db, salesXml);

            // string carsWithDistance = GetCarsWithDistance(db);

            // string carsFormMakeBmw = GetCarsFromMakeBmw(db);

            //  string localSuppliers = GetLocalSuppliers(db);

          //  string carsWithListOfParts = GetCarsWithTheirListOfParts(db);

            //string totalSalesByCustomers = GetTotalSalesByCustomer(db);


            string salesWithAppliedDiscount = GetSalesWithAppliedDiscount(db);

           

        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(s => new SaleWithAppliedDiscountExportModel()
                {
                    Car = new CarExportModel()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Select(p => p.Part.Price).Sum(),
                    PriceWithDiscount = (s.Car.PartCars.Select(p => p.Part.Price).Sum() -
                                         ((s.Car.PartCars.Select(p => p.Part.Price).Sum()
                                           * s.Discount) / 100))

                })
                .ToList();

            var xmlSerializer =
                new XmlSerializer(typeof(List<SaleWithAppliedDiscountExportModel>), new XmlRootAttribute("sales"));

            var textWriter = new StringWriter();

            var xmlSerializerNameSpace = new XmlSerializerNamespaces((new[] { XmlQualifiedName.Empty }));

            
            xmlSerializer.Serialize(textWriter, sales, xmlSerializerNameSpace);

            string result = textWriter.ToString();

            return result;
        }
                


    


        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSalseByCusptomers = context
                .Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new 
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales
                        .SelectMany(s => s.Car.PartCars)
                        .Sum(cp => cp.Part.Price)
                })
                .OrderByDescending(cr => cr.SpentMoney)
                .ToList();

            var xmlSerializer =
                new XmlSerializer(typeof(List<CustomerExportModel>), new XmlRootAttribute("customers"));

            var textWriter = new StringWriter();

            var xmlSerializerNameSpace = new XmlSerializerNamespaces((new[] { XmlQualifiedName.Empty }));


            xmlSerializer.Serialize(textWriter, totalSalseByCusptomers, xmlSerializerNameSpace);

            string result = textWriter.ToString();

            return result;


        }


        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {

            var carsWithListParts = context
                .Cars
                .Include(c => c.PartCars)
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new CarsWithListOfParstExportModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDisntace = c.TravelledDistance,
                    Parts = c.PartCars.Select(p => new PartExportModel()
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                        .OrderByDescending(p => p.Price).ToList()
                }).ToList();




            var xmlSerializer =
                new XmlSerializer(typeof(List<CarsWithListOfParstExportModel>), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var xmlSerializerNameSpace = new XmlSerializerNamespaces((new[] { XmlQualifiedName.Empty }));


            xmlSerializer.Serialize(textWriter, carsWithListParts, xmlSerializerNameSpace);

            string result = textWriter.ToString();

            return result;

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new SupplierExportModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count

                })
                .ToList();


            var xmlSerializer =
                new XmlSerializer(typeof(List<SupplierExportModel>), new XmlRootAttribute("suppliers"));

            var textWriter = new StringWriter();

            var xmlSerializerNameSpace = new XmlSerializerNamespaces((new[] { XmlQualifiedName.Empty }));


            xmlSerializer.Serialize(textWriter, suppliers, xmlSerializerNameSpace);

            string result = textWriter.ToString();

            return result;


        }



        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {

            var carsBmw = context.Cars
                .Where(c => c.Make.ToLower() == "bmw")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarBmwExportModel()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            var xmlSerializer =
                new XmlSerializer(typeof(List<CarBmwExportModel>), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var xmlSerializerNameSpace = new XmlSerializerNamespaces();
            xmlSerializerNameSpace.Add("", "");

            xmlSerializer.Serialize(textWriter, carsBmw, xmlSerializerNameSpace);

            string result = textWriter.ToString();

            return result;

        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {

            var cars = context.Cars.Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(cr => new CarWithDistanceExportModel()
                {
                    Make = cr.Make,
                    Model = cr.Model,
                    TravelledDistance = cr.TravelledDistance
                }).ToList();


            var xmlSerializer =
                new XmlSerializer(typeof(List<CarWithDistanceExportModel>), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var xmlSerializerNameSpace = new XmlSerializerNamespaces();
            xmlSerializerNameSpace.Add("", "");

            xmlSerializer.Serialize(textWriter, cars, xmlSerializerNameSpace);

            // var cars = context.Cars.Where(c => c.TravelledDistance >1000000000).ToArray().Take(10);



            /*
             * Get all cars with distance more than 2,000,000. Order them by make, then by model alphabetically.
             * Take top 10 records.
             */
            string result = textWriter.ToString();

            return result;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            XmlSerializer serializer =
                new XmlSerializer(typeof(SaleInputModel[]), new XmlRootAttribute("Sales"));

            var reader = new StringReader(inputXml);

            var saleDto = (SaleInputModel[])serializer.Deserialize(reader);

            int[] carIds = context.Cars.Select(c => c.Id).ToArray();

            saleDto = saleDto.Where(s => carIds.Contains(s.CarId)).ToArray();

            var sales = mapper.Map<Sale[]>(saleDto);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            XmlSerializer serializer =
                new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));

            var reader = new StringReader(inputXml);

            var customersDto = (CustomerInputModel[])serializer.Deserialize(reader);

            var customers = mapper.Map<Customer[]>(customersDto).ToArray();

            context.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            List<int> partsIds = context.Parts.Select(p => p.Id).ToList();

            var serializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));

            var reader = new StringReader(inputXml);

            CarInputModel[] carsDto = (CarInputModel[])serializer.Deserialize(reader);

            foreach (var carInputModel in carsDto)
            {
                var newCar = new Car()
                {
                    Make = carInputModel.Make,
                    Model = carInputModel.Model,
                    TravelledDistance = carInputModel.TraveledDistance
                };

                foreach (var partId in carInputModel.Parts)
                {
                    if (partsIds.Contains(partId.Id))
                    {
                        var carPart = new PartCar()
                        {
                            PartId = partId.Id
                        };

                        newCar.PartCars.Add(carPart);
                    }
                }

                context.Cars.Add(newCar);
            }


            context.SaveChanges();

            return $"Successfully imported {carsDto.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            List<int> supplierId = context.Suppliers.Select(s => s.Id).ToList();

            var serializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));

            StringReader reader = new StringReader(inputXml);

            PartInputModel[] partsDto = (PartInputModel[])serializer.Deserialize(reader);

            ICollection<Part> parts = mapper.Map<Part[]>(partsDto).Where(p => supplierId.Contains(p.SupplierId)).ToArray();

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }


        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {

            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));

            StringReader reader = new StringReader(inputXml);

            SupplierInputModel[] supplierDbo = (SupplierInputModel[])serializer.Deserialize(reader);

            ICollection<Supplier> suppliers = mapper.Map<Supplier[]>(supplierDbo);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";


            /*
             * 
                 var serializer = new XmlSerializer(typeof(UserInputModel[]), new XmlRootAttribute("Users"));
                
                 StringReader reader = new StringReader(inputXml);
                
                 UserInputModel[] usersDbo = (UserInputModel[])serializer.Deserialize(reader);
                
                 ICollection<User> users = mapper.Map<User[]>(usersDbo);
                
                 context.Users.AddRange(users);
                
                 context.SaveChanges();
                
                 return $"Successfully imported {users.Count}";

             */
        }


        private static void InitializeAutoMapper()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}