using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private const int zero = 0;
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
        }

        [Test]
        public void CtorOfCompShouldWorkCorrectly()
        {
            Computer computer = new Computer("dani", "mani", 122m);

            Assert.AreEqual(computer.Manufacturer, "dani");
            Assert.AreEqual(computer.Model, "mani");
            Assert.AreEqual(computer.Price, 122m);
        }

        [Test]
        public void When_InitializingCompManager_ItsCompRepoCount_ShouldbeZero()
        {
            Assert.That(computerManager.Computers.Count.Equals(zero));
        }

        [Test]
        public void When_AddNullComp_ShouldThrowArgumentNullEx()
        {

            Computer computer = null;

            // Exception ex = Assert.Throws<ArgumentNullException>(() => this.computerManager.AddComputer(computer));

            Assert.That(() => this.computerManager.AddComputer(computer), Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'computer')"));

        }

        [Test]
        public void When_AddCount_ShouldIncrease()
        {
            int expectedCount = 3;

            List<Computer> comps = new List<Computer>()
            {
                new Computer("DaniComps", "Nebesna", 1240m),
                new Computer("DaniCo", "Estelle", 1111m),
                new Computer("Dani", "Krum", 1000m)
            };

            for (int i = 0; i < expectedCount; i++)
            {
                this.computerManager.AddComputer(comps[i]);
            }

            Assert.AreEqual(expectedCount, this.computerManager.Count);
        }

        [Test]
        public void When_AddSameValues_ShouldThrownArgumentEx()
        {
            Computer comp1 = new Computer("DaniComps", "Nebesna", 1240m);
            Computer comp2 = new Computer("DaniComps", "Nebesna", 1240m);

            this.computerManager.AddComputer(comp1);

            Exception exception = Assert.Throws<ArgumentException>(() => this.computerManager.AddComputer(comp2));


            Assert.AreEqual(exception.Message, "This computer already exists.");
        }

        [Test]
        public void When_RemovingComp_CountShouldDecrease()
        {

            int expectedCount = 2;
            int Count = 3;

            List<Computer> comps = new List<Computer>()
            {
                new Computer("DaniComps", "Nebesna", 1240m),
                new Computer("DaniCo", "Estelle", 1111m),
                new Computer("Dani", "Krum", 1000m)
            };

            for (int i = 0; i < Count; i++)
            {
                this.computerManager.AddComputer(comps[i]);
            }

            this.computerManager.RemoveComputer("DaniComps", "Nebesna");

            Assert.AreEqual(expectedCount, this.computerManager.Count);

        }

        [Test]
        public void When_RemovingComp_ShouldReturnCorrectData()
        {

            int expectedCount = 2;
            int Count = 3;

            List<Computer> comps = new List<Computer>()
            {
                new Computer("DaniComps", "Nebesna", 1240m),
                new Computer("DaniCo", "Estelle", 1111m),
                new Computer("Dani", "Krum", 1000m)
            };

            for (int i = 0; i < Count; i++)
            {
                this.computerManager.AddComputer(comps[i]);
            }

            var returned = this.computerManager.RemoveComputer("DaniComps", "Nebesna");

            Assert.AreEqual(comps[0], returned);

        }

        [Test]

        public void GetComputerShould_ThrownNullArgEx_WhenInitializedWithNull_WhiteSpaceStr()
        {
            string manufacturer = null;
            string model = "null";

            Exception ex = Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer(manufacturer, model));

            Assert.AreEqual(ex.Message, "Can not be null! (Parameter 'manufacturer')");

        }

        [Test]

        public void GetComputerShould_ThrownNullArgEx_WhenInitializedWithNull()
        {
            string manufacturer = "null";
            string model = null;

            Exception ex = Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer(manufacturer, model));

            Assert.AreEqual(ex.Message, "Can not be null! (Parameter 'model')");

        }

        [Test]
        public void GetComputer_ShouldReturnCorrectComputer()
        {
            int Count = 3;

            List<Computer> comps = new List<Computer>()
            {
                new Computer("DaniComps", "Nebesna", 1240m),
                new Computer("DaniCo", "Estelle", 1111m),
                new Computer("Dani", "Krum", 1000m)
            };

            for (int i = 0; i < Count; i++)
            {
                this.computerManager.AddComputer(comps[i]);
            }

            Assert.AreEqual(comps[0], this.computerManager.GetComputer("DaniComps", "Nebesna"));
        }

        [Test]
        public void GetCompShouldThrowArgExIfNotExistingComp()
        {
            Assert.Throws<ArgumentException>(() => this.computerManager.GetComputer("null", "null"));
        }

        [Test]
        public void GetCompsByPredicate_ShouldThrownArgNullEx_When_InitializedWithNullStr()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComps_ShouldReturnCorectData()
        {
            int Count = 3;
            int expectedCount = 2;
            string manufacturer = "DaniComps";

            List<Computer> comps = new List<Computer>()
            {
                new Computer("DaniComps", "Nebesna", 1240m),
                new Computer("DaniComps", "Estelle", 1111m),
                new Computer("Dani", "Krum", 1000m)
            };

            for (int i = 0; i < Count; i++)
            {
                this.computerManager.AddComputer(comps[i]);
            }

            var sorted = this.computerManager.GetComputersByManufacturer(manufacturer);

            Assert.AreEqual(expectedCount, sorted.Count);

            Assert.True(sorted.Contains(comps[0]));
        }
    }

}