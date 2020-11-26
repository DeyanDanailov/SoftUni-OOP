using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
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
        public void AddShouldThrowExcIfUnitDriverAddExistingDriver()
        {
            //Arrange
            UnitDriver captivaDriver = new UnitDriver("Sudjuka", new UnitCar("Captiva", 185, 2000));
            this.raceEntry.AddDriver(captivaDriver);
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
                    this.raceEntry.AddDriver(captivaDriver), "Driver {0} added in race.", captivaDriver.Name);

        }
    }
}