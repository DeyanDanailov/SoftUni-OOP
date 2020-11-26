using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver captivaDriver;
        private const int MIN_PARTICIPANTS_COUNT = 2;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            captivaDriver = new UnitDriver("Sudjuka", new UnitCar("Captiva", 190, 2000));
        }

        [Test]
        public void ConstructorShouldInitializeDriverCollection()
        {
            //Arrange
            var expected = 0;

            //Act          
            var actual = this.raceEntry.Counter;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddShouldThrowExcIfUnitDriverIsNull()
        {
            //Arrange
            UnitDriver nullDriver = null;

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
                    this.raceEntry.AddDriver(nullDriver), "Driver cannot be null.");

        }
        [Test]
        public void AddShouldThrowExcIfUnitDriverAddExistingDriver()
        {           
           //Arrange
            this.raceEntry.AddDriver(this.captivaDriver);

            //Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                    this.raceEntry.AddDriver(this.captivaDriver), "Driver {0} added in race.", this.captivaDriver.Name);

        }

        [Test]
        public void AddShouldThrowExcIfUnitDriverAddDriverWithExistingName()
        {
            //Arrange
            UnitDriver alfaDriver = new UnitDriver("Sudjuka", new UnitCar("Alfa", 140, 1900));
            this.raceEntry.AddDriver(this.captivaDriver);

            //Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                    this.raceEntry.AddDriver(this.captivaDriver), "Driver {0} added in race.", this.captivaDriver.Name);

        }
        [Test]
        public void AddShouldIncreaseDriverCount()
        {
            //Arrange
            var expectedCount = 1;

            //Act
            this.raceEntry.AddDriver(this.captivaDriver);
            var actual = this.raceEntry.Counter;

            //Assert
            Assert.AreEqual(expectedCount, actual);

        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExcIfCounterLessThanMin()
        {
            //Arrange
            this.raceEntry.AddDriver(this.captivaDriver);

            //Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                   this.raceEntry.CalculateAverageHorsePower(),
                   "The race cannot start with less than {0} participants.", MIN_PARTICIPANTS_COUNT);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldreturnCorrectAverageHorsePower()
        {
            //Arrange
            UnitDriver alfaDriver = new UnitDriver("Giugiaro", new UnitCar("Alfa", 140, 1900));
            this.raceEntry.AddDriver(this.captivaDriver);
            this.raceEntry.AddDriver(alfaDriver);
            var expected = 165;

            //Act
            var actual = this.raceEntry.CalculateAverageHorsePower();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}