using System.Collections.Generic;

namespace Exam.MobileX
{
    public class Vehicle
    {
        public Vehicle(string id, string brand, string model, string location, string color, int horsepower, double price, bool isVIP)
        {
            this.Id = id;
            this.Brand = brand;
            this.Model = model;
            this.Location = location;
            this.Color = color;
            this.Horsepower = horsepower;
            this.Price = price;
            this.IsVIP = isVIP;
        }

      
        public string SellerName { get; set; }

        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Location { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }

        public double Price { get; set; }

        public bool IsVIP { get; set; }
    }
}
