using NUnit.Framework;
using System;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private StoreManager store;
        private Product myProduct;
        private const string NotPositiveQuantityExceptionMessage = "Product count can't be below or equal to zero.";
        private const string NoSuchProductExceptionMessage = "There is no such product.";
        private const string NotEnoughQuantityExceptionMessage = "There is not enough quantity of this product.";
        [SetUp]
        public void Setup()
        {
            store = new StoreManager();
            myProduct = new Product("watermelon", 3, 20);
        }

        [Test]
        public void TestConstructor()
        {
            var expected = 0;
            var actual = this.store.Products.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddProductShouldThrowExceptionIfProductIsNull()
        {
            Product nullProduct = null;
            Assert.Throws<ArgumentNullException>(() =>
            this.store.AddProduct(nullProduct), nameof(nullProduct));          
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void AddProductShouldThrowExceptionIfProductQuantityIsZeroOrNegative(int quantity)
        {
            Product product = new Product("tomato", quantity, 10);

            Assert.Throws<ArgumentException>(() =>
            this.store.AddProduct(product), NotPositiveQuantityExceptionMessage);
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            this.store.AddProduct(this.myProduct);
            var expected = 1;
            var actual = this.store.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddShouldIncreaseCollectionCount()
        {
            this.store.AddProduct(this.myProduct);
            var expected = 1;
            var actual = this.store.Products.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BuyProductShouldThrowExceptionIfProductNameNotExist()
        {
            this.store.AddProduct(this.myProduct);
            var product = new Product("melon", 3, 15);
            Assert.Throws<ArgumentNullException>(() =>
            this.store.BuyProduct("melon", 3), nameof(product), NoSuchProductExceptionMessage);
        }

        [Test]
        public void BuyProductShouldThrowExceptionIfNotEnoughQuantity()
        {
            this.store.AddProduct(this.myProduct);

            Assert.Throws<ArgumentException>(() =>
            this.store.BuyProduct("watermelon", 4), NotEnoughQuantityExceptionMessage);
        }

        [Test]
        public void BuyProductShouldReturnFinalPrice()
        {
            this.store.AddProduct(this.myProduct);
            var expected = 60;
            var actual = this.store.BuyProduct("watermelon", 3);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckGetMostExpensive()
        {
            this.store.AddProduct(this.myProduct);
            var product = new Product("melon", 3, 15);
            this.store.AddProduct(product);
            var expected = myProduct;
            var actual = this.store.GetTheMostExpensiveProduct();
            Assert.AreEqual(expected, actual);
        }
    }
}