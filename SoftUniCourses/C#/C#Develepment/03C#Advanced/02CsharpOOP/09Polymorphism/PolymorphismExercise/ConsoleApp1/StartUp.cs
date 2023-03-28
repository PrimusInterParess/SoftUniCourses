using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car = GetVehicle();
            Vehicle truck = GetVehicle();
            Vehicle bus = GetVehicle();

            int numberOfOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] inputData = Console.ReadLine().Split();

                string action = inputData[0];
                string typeOfVehicle = inputData[1];
                double amountDistance = double.Parse(inputData[2]);

                try
                {
                    if (typeOfVehicle == nameof(Car))
                    {
                        ProceedCommand(car, action, amountDistance);
                    }
                    if (typeOfVehicle == nameof(Truck))
                    {
                        ProceedCommand(truck, action, amountDistance);
                    }
                    if (typeOfVehicle == nameof(Bus))
                    {
                        ProceedCommand(bus, action, amountDistance);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                  
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

        }

        private static void ProceedCommand(Vehicle vehicle,string command,double parameter)
        {
            if (command=="Drive")
            {
               
                
                    vehicle.Drive(parameter);

                    Console.WriteLine($"{vehicle.GetType().Name} travelled {parameter} km");
                
               
            }
            else if (command == "DriveEmpty")
            {
               
                    ((Bus)vehicle).OffModifier();

                    vehicle.Drive(parameter);

                    ((Bus)vehicle).OnModifier();

                    Console.WriteLine($"{vehicle.GetType().Name} travelled {parameter} km");


            }
            else
            {
                vehicle.Refuel(parameter);
            }
        }

        private static Vehicle GetVehicle()
        {
            string[] data = Console.ReadLine().Split();

            string type = data[0];
            double fuelQuantity = double.Parse(data[1]);
            double fuelConsumption = double.Parse(data[2]);
            double tankCapacity = double.Parse(data[3]);

            Vehicle vehicle = null;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);

            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            return vehicle;
        }
    }
}
