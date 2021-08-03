using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            this.Name = name;

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(Utilities.Messages.ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }

        }

        public ICar Car
        {
            get;
            private set;

        }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Car != null;

        public void WinRace()
        {
            this.NumberOfWins += 1;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(string.Format(Utilities.Messages.ExceptionMessages.CarInvalid));
            }
            //// ??????????????????????
            this.Car = car;
        }

        public override bool Equals(object? obj)
        {
            var other = (IDriver)obj;

            return this.Name == other.Name;
        }
    }

}
