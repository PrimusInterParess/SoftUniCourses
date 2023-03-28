using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services;
using RealEstates.Services.Models;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

                // Console.InputEncoding = Encoding.Unicode;

            var db = new ApplicationDbContext();

            db.Database.Migrate();


            while (true)
            {
                Console.Clear();

                Console.WriteLine("Choose an option");

                Console.WriteLine("1. Property search");

                Console.WriteLine("2. Most expensive districts");
                Console.WriteLine("3. Add tag");
                Console.WriteLine("0. Exit");

                bool parsed = int.TryParse(Console.ReadLine(), out int option);

                if (parsed && option == 0)
                {
                    break;

                }

                if (parsed && option >= 1 && option <= 3)
                {
                    switch (option)
                    {
                        case 1:
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiceDistricts(db);
                            break;

                        case 3:
                            AddTag(db);
                            break;


                    }

                    Console.WriteLine("Press any key to continue...");

                    Console.ReadKey();
                }
            }
        }

        private static void AddTag(ApplicationDbContext dbContext)
        {
            Console.Write("Tag name:");
            string tagName = Console.ReadLine();

            Console.Write("Importance level (optional):");
            bool IsParsed = int.TryParse(Console.ReadLine(),out var importance);

            int? importanceLevel = IsParsed ? importance : null;

            var tag = new Tag()
            {
                Name = tagName,
                Improtance = importanceLevel
            };

            dbContext.Tags.Add(tag);
            dbContext.SaveChanges();
        }

        private static void MostExpensiceDistricts(ApplicationDbContext db)
        {
            Console.Write("Select districts count:");
            int distrcitCount = int.Parse(Console.ReadLine());

            IDistrictService districtService = new DistrictService(db);

            var districts = districtService.GetMostExpensiveDistricts(distrcitCount);

            foreach (var district in districts)
            {
                Console.WriteLine($"District name: {district.Name}  " +
                                  $"=>Average price: {district.AveragePricePerSquareMeter}€/м²" +
                                  $"=> PropertiesCount: {district.PropertiesCount}");
            }
        }

        private static void PropertySearch(ApplicationDbContext db)
        {
            Console.Write("Select minimal price:");
            int minPrice = int.Parse(Console.ReadLine());

            Console.Write("Select maximal price:");
            int maxPrice = int.Parse(Console.ReadLine());

            Console.Write("Select minimal size:");
            int minSize = int.Parse(Console.ReadLine());

            Console.Write("Select maximal size:");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new ProperiesService(db);

            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);

            foreach (var property in properties)
            {
                Console.WriteLine($"District name:{property.DistrictName}," +
                                  $"Building type :{property.BuildingType}," +
                                  $"Price :{property.Price}€," +
                                  $"Property size {property.Size}m²");
            }
        }
    }
}
