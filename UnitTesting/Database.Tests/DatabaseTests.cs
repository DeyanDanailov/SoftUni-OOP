using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] initialdata = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(initialdata);
        }

        [TestCase(new int[] { 1,2,3})]
        [TestCase(new int[] { })]
        public void ConstructorShouldTakeIntegersAndStoreThemInAnArray(int[] data)
        {
            //Arrange
            //int[] data = new int[] {1,2,3 };

            //Act
            var database = new Database.Database (data);

            //Assert
            Assert.AreEqual(data.Length, database.Count);
        }
        [Test]
        public void ConstructorShouldThrowExceptionWhenPassLongerArray()
        {
            //Arrange
            int[] data = new int[17];

            //Assert
            Assert.That(() => this.database = new Database.Database(data),
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void AddShouldIncreaseCountWhenAdded()
        {
            //Arrange
            int element = 4;
            //Action
            this.database.Add(element);
            int expextedCount = 3;

            //Assert
            Assert.AreEqual(expextedCount, this.database.Count);
        }
        [Test]
        public void AddShouldThrowExceptionWhenDatabaseIsFull()
        {
            for (int i = 3; i < 17; i++)
            {
                this.database.Add(i); 
            }
            //collection is full

            //Assert
            Assert.That(() => this.database.Add(17),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
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
                Throws.InvalidOperationException
                .With.Message.EqualTo("The collection is empty!"));
        }
        [TestCase(new int[3] { 1,2,3})]
        [TestCase(new int[0])]
        [TestCase(new int[16] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 })]
        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            this.database = new Database.Database(expectedData);
            int[] actualData = this.database.Fetch();

            //Assert
            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}