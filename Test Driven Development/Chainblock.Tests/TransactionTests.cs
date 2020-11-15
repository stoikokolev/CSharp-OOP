using Chainblock.Common;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private const int Id = 1;
        private const TransactionStatus TransactionStatus = Chainblock.TransactionStatus.Successfull;
        private const string From = "Pesho";
        private const string To = "Gosho";
        private const double Amount = 15;

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            var transaction = new Transaction(Id,TransactionStatus,To,From,Amount);

            Assert.AreEqual(Id,transaction.Id);
            Assert.AreEqual(TransactionStatus,transaction.Status);
            Assert.AreEqual(From,transaction.From);
            Assert.AreEqual(To,transaction.To);
            Assert.AreEqual(Amount,transaction.Amount);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void TestWithLikeInvalidId(int testId)
        {
            Assert.That(() =>
            {
                var transaction = new Transaction(testId, TransactionStatus, To, From, Amount);
            }, Throws.ArgumentException
                .With.Message.EqualTo(ExceptionMessages.InvalidIdMessage));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("      ")]
        public void TestWithLikeInvalidSenderName(string testFrom)
        {
            Assert.That(() =>
            {
                var transaction = new Transaction(Id, TransactionStatus, To, testFrom, Amount);
            }, Throws.ArgumentException
                .With.Message.EqualTo(ExceptionMessages.InvalidSenderUsernameMessage));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("      ")]
        public void TestWithLikeInvalidReceiverName(string testTo)
        {
            Assert.That(() =>
            {
                var transaction = new Transaction(Id, TransactionStatus, testTo, From, Amount);
            }, Throws.ArgumentException
                .With.Message.EqualTo(ExceptionMessages.InvalidReceiverUsernameMessage));
        }

        [TestCase(-2.0)]
        [TestCase(0.0)]
        [TestCase(-0.00001)]
        public void TestWithLikeInvalidAmount(double testAmount)
        {
            Assert.That(() =>
            {
                var transaction = new Transaction(Id, TransactionStatus, To, From, testAmount);
            }, Throws.ArgumentException
                .With.Message.EqualTo(ExceptionMessages.InvalidAmountMessage));
        }
    }
}
