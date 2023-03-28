using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computers;


        public Controller()
        {
            this.computers = new List<IComputer>();
        }



        public IReadOnlyCollection<IComputer> Computers
        {
            get => ((IReadOnlyCollection<IComputer>)this.computers);
            private set => this.computers = ((ICollection<IComputer>)value);
        }



        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer newComp = null;

            bool compAlreadyExists = this.computers.Any(c => c.Id == id);

            if (compAlreadyExists)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (computerType == nameof(Laptop))
            {
                newComp = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == nameof(DesktopComputer))
            {
                newComp = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            this.computers.Add(newComp);

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            IPeripheral compToAdd = null;

            var comp = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (comp == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            bool peripheralAlreadyExists = comp.Peripherals.Any(c => c.Id == id);


            if (peripheralAlreadyExists)
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            if (peripheralType == nameof(Headset))
            {
                compToAdd = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Keyboard))
            {
                compToAdd = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Monitor))
            {
                compToAdd = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Mouse))
            {
                compToAdd = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }


            comp.AddPeripheral(compToAdd);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var comp = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (comp == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var toRemove = comp.RemovePeripheral(peripheralType);

            return $"Successfully removed {peripheralType} with id {toRemove.Id}.";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            var comp = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (comp == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            bool componentExcistence = comp.Components.Any(c => c.Id == id);


            if (componentExcistence)
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            if (componentType == nameof(CentralProcessingUnit))
            {
                comp.AddComponent(new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation));
            }
            else if (componentType == nameof(Motherboard))
            {
                comp.AddComponent(new Motherboard(id, manufacturer, model, price, overallPerformance, generation));

            }
            else if (componentType == nameof(PowerSupply))
            {
                comp.AddComponent(new PowerSupply(id, manufacturer, model, price, overallPerformance, generation));

            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                comp.AddComponent(new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation));

            }
            else if (componentType == nameof(SolidStateDrive))
            {
                comp.AddComponent(new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation));

            }
            else if (componentType == nameof(VideoCard))
            {
                comp.AddComponent(new VideoCard(id, manufacturer, model, price, overallPerformance, generation));

            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }


            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";

        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var comp = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (comp == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var toRemove = comp.RemoveComponent(componentType);

            return $"Successfully removed {componentType} with id {toRemove.Id}.";

        }

        public string BuyComputer(int id)
        {
            var compToRemove = this.computers.FirstOrDefault(c => c.Id == id);

            if (compToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);

            }

            this.computers.Remove(compToRemove);

            return compToRemove.ToString();

        }

        public string BuyBest(decimal budget)
        {
            IComputer toReturnn = null;

            if (this.computers.Count == 0)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            foreach (var computer in computers.OrderByDescending(c => c.OverallPerformance))
            {
                if (computer.Price <= budget)
                {
                    toReturnn = computer;
                    computers.Remove(computer);
                    break;
                }
            }

            if (toReturnn != null)
            {
                return toReturnn.ToString();

            }

            throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
        }

        public string GetComputerData(int id)
        {
            IComputer checksForExistingComputer = this.computers.FirstOrDefault(c => c.Id == id);

            if (checksForExistingComputer != null)
            {
                return checksForExistingComputer.ToString();
            }

            throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
        }

        public void Close()
        {
            Environment.Exit(1);
        }
    }
}