using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
            Item item = new Item("Dido", "1234");
            //Item item2 = new Item("Misho", "1235");
            //Item item3 = new Item("Gosho", "1236");
        }

        [Test]
        public void CheckItemConstructorAndProp()
        {
            Item item = new Item("Dido", "1234");
            var expected = "Dido";
            var actual = item.Owner;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckItemConstructorAndPropID()
        {
            Item item = new Item("Dido", "1234");
            var expected = "1234";
            var actual = item.ItemId;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CheckBankVaultConstructor()
        {
            var bankVault = new BankVault();
            CollectionAssert.IsNotEmpty(bankVault.VaultCells);
        }

        [Test]
        public void AddItemShouldThrowExcIfNoSuchCell()
        {
            Item item = new Item("Dido", "1234");
            var bankVault = new BankVault();
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("G3", item), "Cell doesn't exists!");
        }
        [Test]
        public void AddItemShouldThrowExcIfCellIsNotEmpty()
        {
            Item item = new Item("Dido", "1234");
            var bankVault = new BankVault();
            bankVault.AddItem("A1", item);
            Item item2 = new Item("Misho", "1235");

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", item2), "Cell is already taken!");
        }
        [Test]
        public void AddItemShouldThrowExcIfItemExists()
        {
            Item item = new Item("Dido", "1234");
            var bankVault = new BankVault();
            bankVault.AddItem("A1", item);
            Item item2 = new Item("Misho", "1235");

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("B1", item), "Item is already in cell!");
        }
        [Test]
        public void RemoveItemShouldThrowExcIfNoSuchCell()
        {
            Item item = new Item("Dido", "1234");
            var bankVault = new BankVault();
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("G3", item), "Cell doesn't exists!");
        }
        [Test]
        public void RemoveItemShouldThrowExcIfNoSuchItem()
        {
            Item item = new Item("Dido", "1234");
            var bankVault = new BankVault();
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A3", item), $"Item in that cell doesn't exists!");
        }
        [Test]
        public void RemoveItemShouldRemoveSuccessfully()
        {
            Item item = new Item("Dido", "1234");
            var bankVault = new BankVault();
            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);
            bankVault.AddItem("A1", item);
        }
    }
}