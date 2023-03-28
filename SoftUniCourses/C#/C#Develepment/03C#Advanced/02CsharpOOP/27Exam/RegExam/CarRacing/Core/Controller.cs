using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException("Invalid car type!");
            }

            ICar car = null;

            switch (type)
            {
                case "SuperCar":
                    car = new SuperCar(make, model, VIN, horsePower);
                    break;
                case "TunedCar":
                    car = new TunedCar(make, model, VIN, horsePower);
                    break;
            }

            this.cars.Add(car);

            return string.Format(Utilities.Messages.OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidRacerType);
            }

            ICar car = this.cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer = null;

            switch (type)
            {
                case "ProfessionalRacer":
                    racer = new ProfessionalRacer(username, car);
                    break;
                case "StreetRacer":
                    racer = new StreetRacer(username, car);
                    break;
            }

            this.racers.Add(racer);

            return string.Format(Utilities.Messages.OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer raceOne = this.racers.FindBy(racerOneUsername);

            if (raceOne == null)
            {
                throw new ArgumentException(string
                    .Format(Utilities.Messages.ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerTwo == null)
            {
                throw new ArgumentException(string
                    .Format(Utilities.Messages.ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(raceOne, racerTwo);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            List<IRacer> racersToDisplay = this.racers.Models.ToList().OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username).ToList();

            foreach (var racer in racersToDisplay)
            {
                sb.AppendLine(racer.ToString());
              
            }

            return sb.ToString().TrimEnd();
        }
    }
}
