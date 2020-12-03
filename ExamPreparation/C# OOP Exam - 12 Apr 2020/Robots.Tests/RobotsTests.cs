namespace Robots.Tests

{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;
        [SetUp]
        public void Setup()
        {
            this.robot = new Robot("Racho", 100);
            this.manager = new RobotManager(2);
        }

        [Test]
        public void TestConstructor()
        {
            var expected = 0;
            var actual = this.manager.Count;
            Assert.AreEqual(expected, actual);
            var expectedCapacity = 2;
            var actualCapacity = this.manager.Capacity;
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void CapacitySetterShouldThrowExcIfBelowZero()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-2), "Invalid capacity!");
        }

        [Test]
        public void AddShouldThrowExcIfAddingContainingRobot()
        {
            this.manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => this.manager.Add(robot),
                $"There is already a robot with name {robot.Name}!");
        }

        [Test]
        public void AddShouldThrowExcIfNotEnoughCapacity()
        {
            this.manager.Add(robot);
            this.manager.Add(new Robot("Mincho", 20));
            Assert.Throws<InvalidOperationException>(() => this.manager.Add(new Robot("Pencho", 67)),
                $"There is already a robot with name {robot.Name}!");
        }

        [Test]
        public void RemoveShouldThrowExcIfRobotNotExist()
        {
            this.manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => this.manager.Remove("Pencho"),
                $"Robot with the name Pencho doesn't exist!");
        }

        [Test]
        public void RemoveShouldRemoveExistingRobot()
        {
            this.manager.Add(robot);
            this.manager.Remove("Racho");
            var expected = 0;
            var actual = this.manager.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WorkShouldThrowExcIfRobotNotExist()
        {
            this.manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => this.manager.Work("Pencho", "play", 20),
                "Robot with the name Pencho doesn't exist!");
        }

        [Test]
        public void WorkShouldThrowExcIfBatteryUsageISBigger()
        {
            this.manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => this.manager.Work("Racho", "play", 120),
                $"{robot.Name} doesn't have enough battery!");
        }

        [Test]
        public void WorkShouldDecreaseRobotBattery()
        {
            this.manager.Add(robot);
            var expected = 80;
            this.manager.Work(robot.Name, "run", 20);
            var actual = this.robot.Battery;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ChargeShouldThrowExcIfRobotNotExist()
        {
            this.manager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => this.manager.Charge("Pencho"),
                "Robot with the name Pencho doesn't exist!");
        }

        [Test]
        public void ChargeShouldSetRobotBatteryToMaximum()
        {
            this.manager.Add(robot);
            var expected = 100;
            this.manager.Work(robot.Name, "run", 20);
            this.manager.Charge(robot.Name);
            var actual = this.robot.Battery;
            Assert.AreEqual(expected, actual);
        }
    }
}
