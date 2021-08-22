using NUnit.Framework;

namespace Robots.Tests
{
    using System;
    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private Robot robot2;
        private RobotManager robotManager;

        private const int initialCapacity = 10;
        private const int invalidCapacity = -3;
        private const int invalidCapacity2 = -10;

        private const string validRobotName = "RobiRobota";
        private const string validRobotName2 = "Robi";
        private const int validBatery = 30;
        private const int validBatery2 = 25;


        [SetUp]
        public void SetUp()
        {
            this.robot = new Robot(validRobotName, validBatery);
            this.robot2 = new Robot(validRobotName2, validBatery2);
        }

        [Test]
        [TestCase(invalidCapacity)]
        [TestCase(invalidCapacity2)]
        public void When_InitializingRobotManagerWithvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
        }


        [Test]
        [TestCase(invalidCapacity)]

        public void When_InitializingRobotManagerWithvalidCapacity_Messege(int capacity)
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new RobotManager(capacity));

            string expected = $"Invalid capacity!";

            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void When_InitializeWithValidCapacity()
        {
            robotManager = new RobotManager(initialCapacity);

            Assert.AreEqual(robotManager.Capacity, initialCapacity);
        }

        [Test]
        public void WhenAddRobbotWithSameName_ShoulThrowEx()
        {
            this.robotManager = new RobotManager(initialCapacity);

            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(this.robot));
        }

        [Test]
        public void WhenAddRobbotWithSameName_ShoulThrowEx_Messege()
        {
            this.robotManager = new RobotManager(initialCapacity);

            this.robotManager.Add(this.robot);

            Exception ex = Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(this.robot));

            string expected = $"There is already a robot with name {this.robot.Name}!";

            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void WhenAdd_WithNotEnpughCapacity_ShouldThrowEx()
        {
            int capacity = 1;

            this.robotManager = new RobotManager(capacity);

            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(this.robot2));
        }

        [Test]
        public void WhenAddRobot_CountShouldIncrease()
        {

            int expected = 2;
            this.robotManager = new RobotManager(initialCapacity);

            this.robotManager.Add(robot);
            this.robotManager.Add(robot2);
            Assert.AreEqual(expected,this.robotManager.Count);

        }

        [Test]
        public void Remove_ShouldThrowEx_When_RobotNotFound()
        {
            this.robotManager = new RobotManager(initialCapacity);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove("null"));
        }

        [Test]
        public void Remove_ShouldDecreasseCount()
        {

            int expectedCount = 1;
            this.robotManager = new RobotManager(initialCapacity);
            this.robotManager.Add(robot);
            this.robotManager.Add(robot2);

            this.robotManager.Remove(robot.Name);

            Assert.AreEqual(expectedCount,this.robotManager.Count);

        }

        [Test]
        public void Work_ShouldThrowEx_WhenRobotNotFound()
        {
            this.robotManager = new RobotManager(initialCapacity);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("misho", "cheshe", 10));

        }

        [Test]
        public void Work_ShouldThrowExIfRobotsDoesntHaveEnoughBattery()
        {
            this.robotManager = new RobotManager(initialCapacity);
            this.robotManager.Add(robot);
            this.robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("RobiRobota", "ticha", 500));
        }

        [Test]
        public void Work_ShouldWork_Working_Correctly_Work()
        {
            this.robotManager = new RobotManager(initialCapacity);

            this.robotManager.Add(robot);
            this.robotManager.Add(robot2);
            int expected = this.robot.Battery - 14;
            
            this.robotManager.Work("RobiRobota","takovata",14);


            Assert.AreEqual(expected,this.robot.Battery);
        }

        [Test]
        public void Charge_ShouldThrowExWithNullRobot()
        {
            this.robotManager = new RobotManager(initialCapacity);
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Charge("nema go"));
        }

        [Test]
        public void Charge_ShouldWorkCorrectly()
        {
            this.robotManager = new RobotManager(initialCapacity);

            this.robotManager.Add(robot);

            int expected = validBatery;
            this.robotManager.Work(robot.Name,"dig",15);
            this.robotManager.Charge(robot.Name);

            Assert.AreEqual(robot.Battery,robot.MaximumBattery);


        }
    }
}
