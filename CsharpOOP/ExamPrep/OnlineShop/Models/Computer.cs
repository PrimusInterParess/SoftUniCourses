using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using OnlineShop.Models.Products;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> iComponents = null;
        private ICollection<IPeripheral> iPeripherals = null;
        private double overallPreform;

        private decimal price;


        protected Computer(
            int id,
            string manufacturer,
            string model,
            decimal price,
            double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.iComponents = new List<IComponent>();
            this.iPeripherals = new List<IPeripheral>();
            this.OverallPerformance = overallPerformance;
            this.Price = price;

        }

        public IReadOnlyCollection<IComponent> Components => ((IReadOnlyCollection<IComponent>)this.iComponents);

        public IReadOnlyCollection<IPeripheral> Peripherals => ((IReadOnlyCollection<IPeripheral>)this.iPeripherals);

        public void AddComponent(IComponent component)
        {


            var alreadyExists = iComponents.Any(x => x.GetType().Name == component.GetType().Name);

            if (alreadyExists)
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.Price += component.Price;

            this.iComponents.Add(component);

        }

        public IComponent RemoveComponent(string componentType)
        {


            var checkIfItemExists = iComponents.Any(x => x.GetType().Name == componentType);

            IComponent toReturn = null;

            if (this.iComponents.Count == 0 || !checkIfItemExists)
            {
                throw new ArgumentException(
                    $"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            foreach (var product in this.iComponents)
            {
                if (product.GetType().Name == componentType)
                {
                    toReturn = product;

                    this.iComponents.Remove(product);
                    break;
                }
            }

            this.Price -= toReturn.Price;

            return toReturn;

        }

        public void AddPeripheral(IPeripheral peripheral)
        {


            var alreadyExists = iPeripherals.Any(x => x.GetType().Name == peripheral.GetType().Name);

            if (alreadyExists)
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.price += peripheral.Price;

            this.iPeripherals.Add(peripheral);

        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {

            var checkIfItemExists = iPeripherals.Any(x => x.GetType().Name == peripheralType);

            IPeripheral toReturn = null;

            if (this.iPeripherals.Count == 0 || !checkIfItemExists)
            {
                throw new ArgumentException(
                    $"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            foreach (var product in this.iPeripherals)
            {
                if (product.GetType().Name == peripheralType)
                {
                    toReturn = product;

                    this.iPeripherals.Remove(product);
                    break;
                }
            }

            this.Price -= toReturn.Price;

            return toReturn;

        }

        public  override double OverallPerformance
        {
            get
            {
                if (iComponents.Count == 0)
                {
                    return this.overallPreform;

                }

                var average = this.iComponents.Average(c => c.OverallPerformance);

                return this.overallPreform  + average;


            }
            protected set
            {



                this.overallPreform = value;
            }


        }

        public  override decimal Price
        {
            get
            {

                return this.price;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can not be less or equal than 0.");
                }

                this.price = value;
            }




        }


        public override string ToString()
        {


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {this.OverallPerformance:F2}. Price: {this.Price:F2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.Components.Count}):");

            if (iComponents.Count != 0)
            {
                foreach (var component in this.Components)
                {
                    sb.AppendLine($"  {component.ToString()}");


                }
            }
            else if (iComponents.Count == 0)
            {
                sb.AppendLine(
                    $" Components (0); Average Overall Performance (0.00):");
            }



            if (iPeripherals.Count != 0)
            {
                sb.AppendLine(
                    $" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.iPeripherals.Average(p => p.OverallPerformance):f2}):");


                foreach (var peropheral in iPeripherals)
                {
                    sb.AppendLine($"  {peropheral.ToString()}");
                }

            }
            else
            {
                sb.AppendLine(
                    $" Peripherals (0); Average Overall Performance (0.00):");

            }



            return sb.ToString().TrimEnd();

        }

       
    }
}
