
using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        private const string STRING_NULL_OR_EMPTY = "{0} cannot be null or empty!";
        private const string FUEL_ZERO_OR_NEGATIVE = "Fuel {0} cannot be zero or negative!";
        private const string FUEL_AMOUNT__NEGATIVE = "Fuel amount cannot be negative!";
        private const string NOT_ENOUGH_FUEL_TO_DRIVE = "You don't have enough fuel to drive!";
        [SetUp]
        public void Setup()
        {
            this.car = new Car("Alfa Romeo", "156", 9.0, 60.0);
        }

        [TestCase(null, "Captiva", 15.0, 60.0)]
        [TestCase("", "Captiva", 15.0, 60.0)]
        public void CheckMakeSetter(string make, string model, double fuelConsumption, double fuelCapacity)
        {           
            Assert.Throws<ArgumentException>(() => 
            new Car(make, model, fuelConsumption, fuelCapacity), 
            String.Format(STRING_NULL_OR_EMPTY, "Make"), make);
        }

        [Test]
        public void CheckMakeGetter()
        {
            //Arrange
            var expected = "Alfa Romeo";

            //Act
            var actual = car.Make;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Chevrolet", "", 15.0, 60.0)]
        [TestCase("Chevrolet", null, 15.0, 60.0)]
        public void CheckModelSetter(string make, string model, double fuelConsumption, double fuelCapacity)
        {           
            Assert.Throws<ArgumentException>(() => 
            new Car(make, model, fuelConsumption, fuelCapacity), 
            String.Format(STRING_NULL_OR_EMPTY, "Model"), model);
        }
        
        [Test]
        public void CheckModelGetter()
        {
            //Arrange
            var expected = "156";

            //Act
            var actual = car.Model;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Chevrolet", "Capiva", 0.0, 60.0)]
        [TestCase("Chevrolet", "Capiva", -100.0, 60.0)]
        public void CheckFuelConsumpSetter(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity),
            String.Format(FUEL_ZERO_OR_NEGATIVE, "consumption"), fuelConsumption);
        }

        [Test]
        public void CheckFuelAmount()
        {
            var expected = 0.0;
            var actual = car.FuelAmount;
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void CheckFuelConsumptionGetter()
        {
            //Arrange
            var expected = 9.0;

            //Act
            var actual = car.FuelConsumption;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase("Chevrolet", "Capiva", 8.0, 0.0)]
        [TestCase("Chevrolet", "Capiva", 8.0, -21.0)]
        public void CheckFuelCapacitySetterForNegative(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(make, model, fuelConsumption, fuelCapacity),
            String.Format(FUEL_AMOUNT__NEGATIVE, "capacity"), fuelCapacity);
        }
        
        [Test]
        public void CheckFuelCapacityGetter()
        {
            //Arrange
            var expected = 60.0;

            //Act
            var actual = car.FuelCapacity;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(0.0)]
        [TestCase(-89)]
        public void RefuelShouldThrowExcIfZeroOrNegative(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            car.Refuel(fuelToRefuel), String.Format(FUEL_ZERO_OR_NEGATIVE, "amount"), fuelToRefuel);
        }
        
        [TestCase(10)]
        public void FuelShouldRefuelIfNotMoreThanCapacity(double fuelToRefuel)
        {
            //Arrange
            var expected = 10.0;

            //Act
            car.Refuel(10);
            var actual = car.FuelAmount;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(10)]
        public void FuelShouldRefuelEqualToCapacityIfMore(double fuelToRefuel)
        {
            //Arrange
            var expected = car.FuelCapacity;

            //Act
            car.Refuel(80);
            var actual = car.FuelAmount;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(200)]
        public void DriveShouldThrowExcIfNotEnoughFuel(double distance)
        {
            //Arrange
            car.Refuel(10);

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance), //Act
            NOT_ENOUGH_FUEL_TO_DRIVE, distance);
        }
        
        [TestCase(100)]
        public void DriveShouldDecreaseFuelAmmount(double distance)
        {
            //Arrange
            car.Refuel(10);
            //Act
            car.Drive(distance);
            var expected = 1.0;
            var actual = car.FuelAmount;
            Assert.AreEqual(expected, actual);
        }
    }
}