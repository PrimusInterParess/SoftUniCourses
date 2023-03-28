using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        private const string driverName = "Smotlio";
        private const string driverName2 = "Zaluhavia";
        private const string carName = "Pasati";
        private const int horsePower = 180;
        private const double cubic = 15;

        private RaceEntry raceEntry;
        private UnitDriver driver;
        private UnitDriver driver2;
        private UnitCar car;

        [SetUp]
        public void Setup()
        {
            this.car = new UnitCar(carName, horsePower, cubic);
            this.driver = new UnitDriver(driverName, car);
            this.driver2 = new UnitDriver(driverName2, car);
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void WhenCreatingDriverWithEmptyName_ShouldThrowEx()
        {
            string expectedMessege = "Name cannot be null! (Parameter 'Name')";


            Exception ex = Assert.Throws<ArgumentNullException>(() => driver = new UnitDriver(null, this.car));

            Assert.AreEqual(expectedMessege, ex.Message);


        }

        [Test]
        public void WhenCreatingCarShouldSetItProperly()
        {
            Assert.AreEqual(this.car.Model, carName);
            Assert.AreEqual(this.car.CubicCentimeters, cubic);
            Assert.AreEqual(this.car.HorsePower, horsePower);
        }

        [Test]
        public void WhenCreatingDriverShouldSetItProperly()
        {
            Assert.AreEqual(this.driver.Name, driverName);
            Assert.AreEqual(this.driver.Car, this.car);
        }

        [Test]
        public void WhenInitializingRaceEntry_CountShouldBeZero()
        {
            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void WhenAddNullDriverShouldThrowEx()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(null));

        }

        [Test]
        public void WhenAddNullDriverShouldThrowExWithMessege()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(null));


            Assert.AreEqual("Driver cannot be null.", ex.Message);
        }

        [Test]
        public void AddDriverWithSameKey_ShoulThrowEx()
        {
            this.raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriverWithSameKey_ShoulThrowExWithMessege()
        {
            this.raceEntry.AddDriver(driver);

            Exception ex = Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(driver));

            Assert.AreEqual($"Driver {driver.Name} is already added.", ex.Message);
        }

        [Test]
        public void WhenAddDriver_ShouldIncreaceCount()
        {
            this.raceEntry.AddDriver(driver);

            Assert.AreEqual(1, this.raceEntry.Counter);

        }

        [Test]
        public void AddDriver_ShouldReturnCorrectMassege()
        {
            string expectedMessege = $"Driver {driver.Name} added in race.";

            string actual = this.raceEntry.AddDriver(driver);

            Assert.AreEqual(expectedMessege, actual);
        }

        [Test]
        public void CalculatePower_ShouldThrowExIfNotEnoughParcitipants()
        {
            this.raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateShouldReturnCorrectValues()
        {
            this.raceEntry.AddDriver(driver);
            this.raceEntry.AddDriver(driver2);

            double averageExpected = (180 + 180) / 2;

            Assert.AreEqual(averageExpected,this.raceEntry.CalculateAverageHorsePower());


        }
    }
}