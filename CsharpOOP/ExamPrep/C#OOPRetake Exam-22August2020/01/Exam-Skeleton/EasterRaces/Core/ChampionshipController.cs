using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Core
{
    public class ChampionshipController : IChampionshipController
    {

        private readonly IRepository<ICar> carsRepository;
        private readonly IRepository<IRace> raceRepository;
        private readonly IRepository<IDriver> driverRepository;


        public ChampionshipController()
        {
            this.carsRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
            this.driverRepository = new DriverRepository();
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            this.driverRepository.Add(driver);

            return string.Format(Utilities.Messages.OutputMessages.DriverCreated, driverName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            type = type + "Car";

            ICar car = null;

            switch (type)
            {
                case nameof(SportsCar):
                    car = new SportsCar(model, horsePower);
                    break;
                case nameof(MuscleCar):
                    car = new MuscleCar(model, horsePower);
                    break;

            }

            this.carsRepository.Add(car);

            return string.Format(Utilities.Messages.OutputMessages.CarCreated, type, model);




        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);

            this.raceRepository.Add(race);

            return string.Format(Utilities.Messages.OutputMessages.RaceCreated, name);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.RaceNotFound,
                    raceName));
            }

            IDriver driver = this.driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.DriverNotFound,
                    driverName));
            }

            race.AddDriver(driver);

            return string.Format(Utilities.Messages.OutputMessages.DriverAdded, driverName, raceName);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.DriverNotFound,
                    driverName));
            }

            ICar car = this.carsRepository.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.CarNotFound,
                    carModel));
            }

            driver.AddCar(car);

            return string.Format(Utilities.Messages.OutputMessages.CarAdded, driverName, carModel);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.RaceNotFound,
                    raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(Utilities.Messages.ExceptionMessages.RaceInvalid,
                    raceName, 3));
            }

            List<IDriver> result = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(Utilities.Messages.OutputMessages.DriverFirstPosition, result[0].Name, raceName));
            sb.AppendLine(string.Format(Utilities.Messages.OutputMessages.DriverSecondPosition, result[1].Name, raceName));
            sb.AppendLine(string.Format(Utilities.Messages.OutputMessages.DriverThirdPosition, result[2].Name, raceName));

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }       
    }
}
