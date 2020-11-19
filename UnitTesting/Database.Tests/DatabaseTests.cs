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
    }
}