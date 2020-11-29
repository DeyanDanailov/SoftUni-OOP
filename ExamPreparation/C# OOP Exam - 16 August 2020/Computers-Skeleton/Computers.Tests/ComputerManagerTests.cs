using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private const string CanNotBeNullMessage = "Can not be null!";
        private ComputerManager manager;
        private Computer computer;
        [SetUp]
        public void Setup()
        {
            manager = new ComputerManager();
            computer = new Computer("Lenovo", "Legion", 2500);
        }

        [Test]
        public void TestConstructor()
        {
            var expected = 0;
            var actual = this.manager.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestComputersPropertyAndAddMethod()
        {
            this.manager.AddComputer(computer);
            var expected = 1;
            var actual = this.manager.Computers.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddComputerShouldThrowExcIfNull()
        {
            Computer nullComputer = null;
            Assert.Throws<ArgumentNullException>(() =>
            this.manager.AddComputer(nullComputer), nameof(nullComputer), CanNotBeNullMessage);
        }

        [Test]
        public void AddComputerShouldThrowExcIfComputerExists()
        {
            this.manager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() =>
            this.manager.AddComputer(computer), "This computer already exists.");
        }

        [Test]
        public void GetComputerShouldThrowExcIfMissingManufacturer()
        {
            this.manager.AddComputer(computer);
           
            Assert.Throws<ArgumentNullException>(() =>
            this.manager.GetComputer(null, "Legion"), "manufacturer", CanNotBeNullMessage);
        }

        [Test]
        public void GetComputerShouldThrowExcIfMissingModel()
        {
            this.manager.AddComputer(computer);
          
            Assert.Throws<ArgumentNullException>(() =>
            this.manager.GetComputer("Lenovo", null), "model", CanNotBeNullMessage);
        }

        [Test]
        public void GetComputerShouldThrowExcIfComputerDoesNotExist()
        {
            this.manager.AddComputer(computer);
            
            Assert.Throws<ArgumentException>(() =>
            this.manager.GetComputer("Asus", "ROG"), "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldReturnComputer()
        {
            this.manager.AddComputer(computer);

            var expected = computer;
            var actual = this.manager.GetComputer("Lenovo", "Legion");
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetComputerByManufacturerShouldThrowExcIfMissingManufacturer()
        {
            this.manager.AddComputer(computer);
            var lenovo = new Computer("Lenovo", "ThinkPad", 3000);
            var asus = new Computer("Asus", "ROG", 3800);
            this.manager.AddComputer(lenovo);
            this.manager.AddComputer(asus);
            var expected = new List<Computer>() { this.computer, lenovo };

            var actual = this.manager.GetComputersByManufacturer("Lenovo");
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetComputersByManufacturerShouldReturnEmptyCollectionWhenNoMatchesFound()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            var collection = computerManager.GetComputersByManufacturer("Asus").ToList();

            CollectionAssert.IsEmpty(collection);
        }

        [Test]
        public void RemoveComputerShouldRemove()
        {
            this.manager.AddComputer(computer);
            var lenovo = new Computer("Lenovo", "ThinkPad", 3000);
            var asus = new Computer("Asus", "ROG", 3800);
            this.manager.AddComputer(lenovo);
            this.manager.AddComputer(asus);
            var expected = asus;
            var actual = this.manager.RemoveComputer("Asus", "ROG");
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(2, this.manager.Count);
        }
       
        [Test]
        public void RemoveShouldThrowExceptionWhenManufacturerNull()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var computer = computerManager.RemoveComputer(null, "Model");
            });
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenNullModel()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                var computer = computerManager.RemoveComputer(this.computer.Manufacturer, null);
            });
        }
    }
}