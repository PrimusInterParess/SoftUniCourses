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
        private List<IDriver> drivers;


        public Race(string name,int laps)
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
                if (string.IsNullOrEmpty(value) && value.Length < 5)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidName);
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
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidNumberOfLaps);
                }

                this.laps = value;
            }

        }
        public IReadOnlyCollection<IDriver> Drivers { get => this.drivers.AsReadOnly(); }
        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.DriverNotParticipate);
            }

            if (this.drivers.Contains(driver))
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.DriverAlreadyAdded);
            }

            this.drivers.Add(driver);
        }
    }
}
