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
        private ICollection<IComponent> iComponents;
        private ICollection<IPeripheral> iPeripherals;



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

        }

        public IReadOnlyCollection<IComponent> Components => ((IReadOnlyCollection<IComponent>)this.iComponents);

        public IReadOnlyCollection<IPeripheral> Peripherals => ((IReadOnlyCollection<IPeripheral>)this.iPeripherals);

        public void AddComponent(IComponent component)
        {
            //If the components collection contains a component with the same component type,
            //throw an ArgumentException with the message "Component {component type} already exists in {computer type} with Id {id}."
            //Otherwise add the component in the components collection.

            var alreadyExists = iComponents.Any(x => x.GetType().Name == component.GetType().Name);

            if (alreadyExists)
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.iComponents.Add(component);

        }

        public IComponent RemoveComponent(string componentType)
        {
            //If the components collection is empty or does not have a component of that type,
            //throw an ArgumentException with the message "Component {component type} does not exist in {computer type} with Id {id}."
            //Otherwise remove the component of that type and return it.

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

            return toReturn;

        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            //If the peripherals collection contains a peripheral with the same peripheral type,
            //throw an ArgumentException with the message "Peripheral {peripheral type} already exists in {computer type} with Id {id}."
            //Otherwise add the peripheral in peripherals collection.

            var alreadyExists = iPeripherals.Any(x => x.GetType().Name == peripheral.GetType().Name);

            if (alreadyExists)
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.iPeripherals.Add(peripheral);

        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {

            var checkIfItemExists = iPeripherals.Any(x => x.GetType().Name == peripheralType);

            IPeripheral toReturn = null;

            if (this.iComponents.Count == 0 || !checkIfItemExists)
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

            return toReturn;

        }

        public override double OverallPerformance
        {
            get
            {
                if (this.iComponents.Count == 0)
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance + this.iComponents.Average(x => x.OverallPerformance);
            }
        }

        public override decimal Price =>
            base.Price + this.iComponents.Sum(c => c.Price)
                      + this.iPeripherals.Sum(p => p.Price);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.Components.Count}):");

            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component.ToString()}");


            }

            sb.AppendLine(
                $" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.iPeripherals.Average(p => p.OverallPerformance):f2}):");

            foreach (var peropheral in iPeripherals)
            {
                sb.AppendLine($"  {peropheral.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
