namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        private Computer computer;
        private Part part;
        [SetUp]
        public void Setup()
        {
            computer = new Computer("Lenovo");
            part = new Part("mouse", 20);
        }

        [Test]
        public void TestConstructor()
        {
            CollectionAssert.IsEmpty(this.computer.Parts);
            Assert.AreEqual("Lenovo", computer.Name);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("         ")]
        public void NameSetterShouldThrowExc(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            new Computer(name), name, "Name cannot be null or empty!");
        }

        [Test]
        public void AddNullPartShouldThrowExc()
        {
            Part nullPart = null;
            Assert.Throws<InvalidOperationException>(() => 
            computer.AddPart(nullPart), "Cannot add null!");
        }

        [Test]
        public void AddPartShouldIncreaseCount()
        {
            this.computer.AddPart(this.part);
            var expected = 1;
            var actual = this.computer.Parts.Count;
            Assert.AreEqual(expected, actual );
        }

        [Test]
        public void TotalPriceShouldSumPrices()
        {
            var part2 = new Part("monitor", 30);
            this.computer.AddPart(part);
            this.computer.AddPart(part2);
            var expected = 50;
            var actual = this.computer.TotalPrice;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPArtShouldreturnPart()
        {
            this.computer.AddPart(part);
            var expected = part;
            var actual = this.computer.GetPart("mouse");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemovePartShouldRemoveCorrectly()
        {
            this.computer.AddPart(part);
            Assert.IsTrue(this.computer.RemovePart(part));
            var expectedCount = 0;
            var actualCount = this.computer.Parts.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemovePartShouldReturnFalse()
        {
            this.computer.AddPart(part);
            var part2 = new Part("monitor", 30);
            Assert.IsFalse(this.computer.RemovePart(part2));
            var expectedCount = 1;
            var actualCount = this.computer.Parts.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}