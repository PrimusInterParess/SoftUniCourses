using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private const string invalidCell = "invalidCell";
        private const string owner = "PeshoOnera";
        private const string owner2 = "GoshoOwnera";
        private const string ownerId = "gotinia";
        private const string ownerId2 = "smotania";

        private const string validCell1 = "A1";
        private const string validCell2 = "A2";
        private const string validCell3 = "A3";
        private const string validCell4 = "A4";

        private BankVault bank;
        private Item item;
        private Item item2;




        [SetUp]
        public void Setup()
        {

            this.bank = new BankVault();
            this.item = new Item(owner, ownerId);
            this.item2 = new Item(owner2, ownerId2);

        }

        [Test]
        public void WhenAddItemOnInexistingCell_ShouldThrowEx()
        {
            Assert.Throws<ArgumentException>(() => this.bank.AddItem(invalidCell, this.item));
        }

        [Test]
        public void WhenAddOnOccupiedCell_ShouldThrowEx()
        {
            this.bank.AddItem(validCell1, this.item);

            Assert.Throws<ArgumentException>(() => this.bank.AddItem(validCell1, item2));
        }

        [Test]
        public void WhenAddExistingItem_ShouldThrowEx()
        {
            this.bank.AddItem(validCell1, this.item);
            Assert.Throws<InvalidOperationException>(() => this.bank.AddItem(validCell2, item));

        }

        [Test]
        public void AddWorksCorreclty()
        {
            string expected = $"Item:{this.item.ItemId} saved successfully!";

            string result = this.bank.AddItem(validCell1, this.item);

            Assert.AreEqual(expected,result);

        }

        [Test]
        public void Remove_ThrowEx_WithIncorectCell()
        {
            Assert.Throws<ArgumentException>(() => this.bank.RemoveItem(invalidCell, this.item));
        }

        [Test]
        public void Remove_ThrowsExWhenInvalidItemOnCorrecCell()
        {
            this.bank.AddItem(validCell1, this.item);

            Assert.Throws<ArgumentException>(() => this.bank.RemoveItem(validCell1, this.item2));
        }

        [Test]
        public void RemoveWoksCorrectly()
        {
            this.bank.AddItem(validCell1, this.item);

            string expected = $"Remove item:{this.item.ItemId} successfully!";

            string result = this.bank.RemoveItem(validCell1, this.item);

            Assert.AreEqual(expected,result);
        }
    }
}