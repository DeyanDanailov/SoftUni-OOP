

namespace Chainblock.Tests
{
    using Chainblock.Common;
    using Chainblock.Contracts;
    using Chainblock.Models;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            Assert.AreEqual(id, transaction.Id);
            Assert.AreEqual(ts, transaction.Status);
            Assert.AreEqual(from, transaction.From);
            Assert.AreEqual(to, transaction.To);
            Assert.AreEqual(amount, transaction.Amount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-2)]
        public void ConstructorShouldThrowExcIfIDIsInvalid(int id)
        {
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;

            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException
                    .With.Message
                    .EqualTo(ExceptionMessages.InvalidIdMessage));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("       ")]
        public void ConstructorShouldThrowExcIfSenderIsInvalid(string from)
        {
            TransactionStatus ts = TransactionStatus.Successfull;
            int id = 1;
            string to = "Gosho";
            double amount = 15;

            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException
                    .With.Message
                    .EqualTo(ExceptionMessages.InvalidSenderMessage));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("       ")]
        public void ConstructorShouldThrowExcIfReceiverIsInvalid(string to)
        {
            TransactionStatus ts = TransactionStatus.Successfull;
            int id = 1;
            string from = "Gosho";
            double amount = 15;

            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException
                    .With.Message
                    .EqualTo(ExceptionMessages.InvalidReceiverMessage));
        }

        [Test]
        [TestCase(0.0)]
        [TestCase(-2.0)]
        [TestCase(-0.000001)]
        public void ConstructorShouldThrowExcIfAmountIsZeroOrNegative(double amount)
        {
            TransactionStatus ts = TransactionStatus.Successfull;
            int id = 1;
            string from = "Pesho";
            string to = "Gosho";

            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException
                    .With.Message
                    .EqualTo(ExceptionMessages.InvalidAmountMessage));
        }

    }
}
