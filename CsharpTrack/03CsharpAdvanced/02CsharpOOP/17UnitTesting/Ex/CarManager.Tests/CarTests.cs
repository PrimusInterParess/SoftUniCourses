using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {

        [Test]
        [TestCase("", "model", 5, 45)]
        [TestCase(null, "model", 5, 45)]
        [TestCase("make", "", 5, 45)]
        [TestCase("make", null, 5, 45)]
        [TestCase("make", "model", 0, 45)]
        [TestCase("make", "model", -5, 45)]
        [TestCase("make", "model", 5, 0)]
        [TestCase("make", "model", 5, -5)]
        public void When(string make, string model, double fuelConsumption, double tankCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, tankCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-4)]
        public void When_RefuelWithZeroOrNegative_ShouldThrowEx(double fuel)
        {
            Car newCar = new Car("make", "model", 5, 45);

            Assert.Throws<ArgumentException>(() => newCar.Refuel(fuel));
        }

        [Test]
        public void When_Refuel_ShouldIncreaseFuelAmount()
        {
            Car newCar = new Car("make", "model", 5, 45);

            double amountToRefuel = 10;

            newCar.Refuel(amountToRefuel);

            Assert.That(() => newCar.FuelAmount.Equals(amountToRefuel));

        }


        [Test]
        public void When_RefuelWithExeededAmount_Should_SetFuelAmountAsTankCapacity()
        {
            Car newCar = new Car("make", "model", 5, 45);

            double amountToRefuel = 50;

            newCar.Refuel(amountToRefuel);

            Assert.That(() => newCar.FuelAmount.Equals(newCar.FuelCapacity));

        }

        [Test]
        public void When_DrivingLongerDistanceWithInsufficientAmountOfFuel_ShouldThrowEx()
        {
            Car newCar = new Car("make", "model", 5, 45);

            double distance = 5000;
            newCar.Refuel(10);

            Assert.Throws<InvalidOperationException>(() => newCar.Drive(distance)); 
        }

        [Test]
        public void When_Driving_ShouldReduceFuelAmount()
        {
            Car newCar = new Car("make", "model", 5, 45);

            double distance = 50;
            double refuelAmount = 10;


            double neededFuel = (distance / 100) * newCar.FuelConsumption;

            double expectedFuel = refuelAmount - neededFuel;

            newCar.Refuel(refuelAmount);
            newCar.Drive(distance);

            Assert.AreEqual(expectedFuel, newCar.FuelAmount);
        }
    }
}