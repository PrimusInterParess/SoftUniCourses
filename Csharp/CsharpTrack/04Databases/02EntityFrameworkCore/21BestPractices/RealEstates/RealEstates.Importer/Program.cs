using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RealEstates.Data;
using RealEstates.Importer.JsonModels;
using RealEstates.Services;
using RealEstates.Services.Models;

namespace RealEstates.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            

           //ImportJsonFile("imot.bg-houses-Sofia-raw-data-2021-03-18.json");
           ImportJsonFile("imot.bg-raw-data-2021-03-18.json");

           //propertiesService.Add();
        }

        public static void ImportJsonFile(string Json)
        {

            var dbContext = new ApplicationDbContext();

            IPropertiesService propertiesService = new ProperiesService(dbContext);

            var properties = JsonSerializer
                .Deserialize<IEnumerable<PropertyAsJson>>(File.ReadAllText(Json));

            foreach (var jsonProperty in properties)
            {
                propertiesService
                    .Add(jsonProperty.District, jsonProperty.Floor, jsonProperty.TotalFloors
                        , jsonProperty.Size, jsonProperty.YardSize, jsonProperty.Year, jsonProperty.Type
                        , jsonProperty.BuildingType, jsonProperty.Price);

                Console.WriteLine(".");
            }
        }
    }
}
