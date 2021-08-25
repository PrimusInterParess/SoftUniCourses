using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly List<IDriver> drivers;


        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.InvalidName, value, "5"));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.InvalidNumberOfLaps, 1));
                }

                this.laps = value;
            }

        }
        public IReadOnlyCollection<IDriver> Drivers { get => this.drivers.AsReadOnly(); }
        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(Utilities.Messages.ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(Utilities.Messages.ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }

        public override bool Equals(object? obj)
        {
            var other = (IRace) obj;

            return this.Name == other.Name;
        }
    }
}
