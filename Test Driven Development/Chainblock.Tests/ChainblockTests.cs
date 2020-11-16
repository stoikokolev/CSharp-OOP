using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;



namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction testTransaction;
        private const TransactionStatus Ts = TransactionStatus.Successfull;
        private const string To = "Pesho";
        private const string From = "Gosho";
        private const double Amount = 10;
        private const int Id = 1;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Core.Chainblock();
            testTransaction = new Transaction(Id, Ts, To, From, Amount);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            var expectedInitialCount = 0;
            var chainblock1 = new Core.Chainblock();

            Assert.AreEqual(expectedInitialCount, chainblock1.Count);
        }

        [Test]
        public void AddShouldIncreaseCountWhenSuccess()
        {
            var expectedCount = 1;

            this.chainblock.Add(testTransaction);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void AddingSameTransactionWithAnotherIdShouldPass()
        {
            var expectedCount = 2;
            var transaction = new Transaction(2, Ts, To, From, Amount);

            this.chainblock.Add(testTransaction);
            this.chainblock.Add(transaction);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void AddingExistingTransactionShouldThrowAnException()
        {
            this.chainblock.Add(testTransaction);

            Assert.That(() => { this.chainblock.Add(testTransaction); },
                Throws.InvalidOperationException.With.Message
                    .EqualTo(ExceptionMessages.ExistingTransactionMessage));
        }

        [Test]
        public void ContainsShouldReturnTrueWithExistingTransaction()
        {
            this.chainblock.Add(testTransaction);

            Assert.IsTrue(this.chainblock.Contains(testTransaction));
        }

        [Test]
        public void ContainsShouldReturnFalseWithNotExistingTransaction()
        {
            Assert.IsFalse(this.chainblock.Contains(testTransaction));
        }

        [Test]
        public void ContainsShouldReturnTrueWithExistingId()
        {
            this.chainblock.Add(testTransaction);

            Assert.IsTrue(this.chainblock.Contains(1));
        }

        [Test]
        public void ContainsShouldReturnFalseWithNotExistingId()
        {
            Assert.IsFalse(this.chainblock.Contains(1));
        }

        [Test]
        public void TestChangingTransactionStatusOfExistingTransaction()
        {
            this.chainblock.Add(testTransaction);
            var testStatus = TransactionStatus.Failed;

            this.chainblock.ChangeTransactionStatus(Id,testStatus);

            Assert.AreEqual(testStatus,testTransaction.Status);
        }

        [Test]
        public void ChangingStatusOfNotExistingTransactionShouldThrowException()
        {
            var testStatus = TransactionStatus.Failed;

            Assert.That(() => {
                this.chainblock.ChangeTransactionStatus(1, testStatus);
            },Throws.ArgumentException
                .With.Message.EqualTo(ExceptionMessages.NotExistingTransactionMessage));
        }
    }
}
