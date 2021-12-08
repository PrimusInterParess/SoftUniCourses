using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace JSON
{
    class StartUp
    {


        static void Main(string[] args)
        {
            var car = new Car
            {
                Extras = new List<string> { "klimatronik", "4x4", "farove" },
                ManufacturedOn = DateTime.Now,
                Model = "Golf",
                Vendor = "VW",
                Price = 12345.65m,
                Engine = new Engine
                {
                    Volume = 1.6m,
                    HorsePower = 80

                }
            };

           //File.WriteAllText("myCar.json",JsonSerializer.Serialize(car));

           //var options = new JsonSerializerOptions {WriteIndented = true};

           var jason = File.ReadAllText("myCar.json");

           Car car = JsonSerializer.Deserialize<Car>(jason);


        }
    }
}
