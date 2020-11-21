
using System;
using System.Linq;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        private Person person;
        private Person[] persons = new Person[] { new Person(1111, "Pesho"), new Person(1234, "Gosho") };

        [SetUp]
        public void Setup()
        {
            this.database = new ExtendedDatabase.ExtendedDatabase(persons);
            this.person = new Person(19, "Misho");
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenPassLongerArray()
        {
            //Arrange
            Person[] data = new Person[17];

            //Assert
            Assert.That(() => this.database = new ExtendedDatabase.ExtendedDatabase(data),
                Throws.ArgumentException
                .With.Message
                .EqualTo("Provided data length should be in range [0..16]!"));
        }
        [Test]
        public void AddRangeShouldThrowExceptionWhenDatabaseIsFull()
        {
            Person[] data = new Person[] {
            new Person(1, "a"),
            new Person(2, "b"),
            new Person(3, "c"),
            new Person(4, "d"),
            new Person(5, "e"),
            new Person(6, "f"),
            new Person(7, "g"),
            new Person(8, "h"),
            new Person(9, "i"),
            new Person(10, "j"),
            new Person(11, "k"),
            new Person(12, "l"),
            new Person(13, "m"),
            new Person(14, "n"),
            new Person(15, "o"),
            new Person(16, "p"),
            };
            var newDatabase = new ExtendedDatabase.ExtendedDatabase(data);

            //Assert
            Assert.That(() => newDatabase.Add(this.person),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void AddShouldIncreaseCountWhenAdded()
        {
            //Action
            this.database.Add(this.person);
            int expextedCount = 3;

            //Assert
            Assert.AreEqual(expextedCount, this.database.Count);
        }
        [Test]
        public void AddShouldThrowExceptionWhenHaveSamePersonUsername()
        {
            Assert.That(() => this.database.Add(new Person(1000, "Pesho")),
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }
        [Test]
        public void AddShouldThrowExceptionWhenHaveSamePersonId()
        {
            Assert.That(() => this.database.Add(new Person(1111, "Misho")),
                Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }
        [Test]
        public void RemoveShouldDecreaseCountWhenSuccess()
        {
            //Arrange
            var expectedCount = 1;

            //Action
            this.database.Remove();

            //Assert
            Assert.AreEqual(expectedCount, this.database.Count);
        }
        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            //Action
            this.database.Remove();
            this.database.Remove();

            //Assert
            Assert.That(() => this.database.Remove(),
                Throws.InvalidOperationException);
        }
        [TestCase("")]
        [TestCase(null)]
        public void FindByUserNameShouldThrowNullExceptionWhenStringIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            { database.FindByUsername(name); },
            "Username parameter is null!", name);
        }
        [TestCase("Gruyu")]
        public void FindByUserNameShouldThrowInvalidOperationExcWhenNameIsNotInTheList(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            { database.FindByUsername(name); },
            "No user is present by this username!", name);
        }
        [TestCase("Pesho")]
        public void FindByUserNameShouldReturnPersonIfNameIsInTheCollection(string name)
        {
            //Arrrange
            var expected = this.persons.First(p => p.UserName == name);

            //Act
            var actual = database.FindByUsername(name);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(-1)]
        public void FindByUserIdShouldThrowArgumentRangeExceptionWhenIdIsLessThanNull(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            { database.FindById(id); },
            "Id should be a positive number!", id);
        }
        [TestCase(1112)]
        public void FindByUserIdShouldThrowInvaliOperationExceptionWhenIdIsNotPresent(long id)
        {
            Assert.Throws<InvalidOperationException>(() =>
            { database.FindById(id); },
            "No user is present by this ID!", id);
        }
        [TestCase(1111)]
        public void FindByUserIdShouldReturnPersonIfIdIsInTheCollection(long id)
        {
            //Arrange
            var expected = this.persons.First(p => p.Id == id);

            //Act
            var actual = database.FindById(id);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}