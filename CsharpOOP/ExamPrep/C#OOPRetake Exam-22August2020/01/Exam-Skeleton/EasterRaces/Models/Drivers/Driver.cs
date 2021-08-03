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

        private bool canParicipate;

        public Driver(string name)
        {
            this.name = name;


        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) && value.Length < 5)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidName);
                }
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
                throw new ArgumentNullException(Utilities.Messages.ExceptionMessages.CarInvalid);
            }
            //// ??????????????????????
            this.Car = car;
        }
    }
}
