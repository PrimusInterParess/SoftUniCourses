using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IPeripheral> Peripherals
        {
            get => ((IReadOnlyCollection<IPeripheral>)this.peripherals);
            private set => this.peripherals = ((ICollection<IPeripheral>)value);
        }

        public IReadOnlyCollection<IComputer> Computers
        {
            get => ((IReadOnlyCollection<IComputer>)this.computers);
            private set => this.computers = ((ICollection<IComputer>)value);
        }

        public IReadOnlyCollection<IComponent> Components
        {
            get => ((IReadOnlyCollection<IComponent>)this.components);
            private set => this.components = ((ICollection<IComponent>)value);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer newComp = null;

            bool compAlreadyExists = this.computers.Any(c => c.Id == id);

            if (compAlreadyExists)
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            if (computerType == nameof(Laptop))
            {
                newComp = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == nameof(DesktopComputer))
            {
                newComp = new DesktopComputer(id, manufacturer, model, price);
            }

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            IPeripheral compToAdd = null;


            bool checksForExistingComputer = this.computers.Any(c => c.Id == computerId);

            if (!checksForExistingComputer)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            bool peripheralAlreadyExists = this.peripherals.Any(c => c.Id == id);


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
                throw new ArgumentException("Peripheral type is invalid.");
            }


            this.peripherals.Add(compToAdd);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            bool checksForExistingComputer = this.computers.Any(c => c.Id == computerId);

            if (!checksForExistingComputer)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IPeripheral toRemove =
                this.peripherals.FirstOrDefault(c =>
                    c.GetType().Name == peripheralType);

            if (toRemove != null)
            {

                this.peripherals.Remove(toRemove);
            }

            return $"Successfully removed {peripheralType} with id {toRemove.Id}.";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            IComponent compToAdd = null;

            bool compAlreadyExists = this.components.Any(c => c.Id == id);

            bool checksForExistingComputer = this.computers.Any(c => c.Id == computerId);

            if (!checksForExistingComputer)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }


            if (compAlreadyExists)
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            if (componentType == nameof(CentralProcessingUnit))
            {
                compToAdd = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(Motherboard))
            {
                compToAdd = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(PowerSupply))
            {
                compToAdd = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                compToAdd = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(SolidStateDrive))
            {
                compToAdd = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(VideoCard))
            {
                compToAdd = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }


            this.components.Add(compToAdd);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";

        }

        public string RemoveComponent(string componentType, int computerId)
        {
            bool checksForExistingComputer = this.computers.Any(c => c.Id == computerId);

            if (!checksForExistingComputer)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComponent toRemove =
                this.components.FirstOrDefault(c =>
                    c.GetType().Name == componentType);

            if (toRemove != null)
            {

                this.components.Remove(toRemove);
            }

            return $"Successfully removed {componentType} with id {toRemove.Id}.";

        }

        public string BuyComputer(int id)
        {
            var compToRemove = this.computers.FirstOrDefault(c => c.Id == id);

            if (compToRemove == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            this.computers.Remove(compToRemove);

            return compToRemove.ToString();

        }

        public string BuyBest(decimal budget)
        {
            IComputer toReturnn = null;

            if (this.computers.Count == 0)
            {
                throw new ArgumentException($" Can't buy a computer with a budget of ${budget}.");
            }

            foreach (var computer in computers.OrderByDescending(c => c.OverallPerformance))
            {
                if (computer.Price <= budget)
                {
                    toReturnn = computer;
                    computers.Remove(computer);
                }
            }

            if (toReturnn != null)
            {
                return toReturnn.ToString();

            }

            else
            {
                throw new ArgumentException($" Can't buy a computer with a budget of ${budget}.");
            }
        }

        public string GetComputerData(int id)
        {
            IComputer checksForExistingComputer = this.computers.FirstOrDefault(c => c.Id == id);

            if (checksForExistingComputer!=null)
            {
                return checksForExistingComputer.ToString();
            }

            throw new ArgumentException("Computer with this id does not exist.");
        }

        public void Close()
        {
            Environment.Exit(1);
        }
    }
}