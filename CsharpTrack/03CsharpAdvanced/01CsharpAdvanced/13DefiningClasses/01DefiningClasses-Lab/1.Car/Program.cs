using System;

namespace CarManufacturer
{
     public class StartUp
    {
        static void Main(string[] args)
        {
            Engine v12 = new Engine(580, 3000);

            Tire[] tires = new Tire[]
            {
                new Tire(2018,2.3),
                new Tire(2018,2.5),
                new Tire(2018,2.1),
                new Tire(2018,2.4),
                
            };

            Car bmwCar = new Car("BMW","X6",1993,5003,50, v12,tires);


                

            //car.Make = "VW";
            //car.Model = "MK3";
            //car.Year = 1992;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 200;

            //car.Drive(0.5);

            //Console.WriteLine(car.WhoAmI());
        }
    }
}
