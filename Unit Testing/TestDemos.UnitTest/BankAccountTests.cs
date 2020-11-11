using NUnit.Framework;
using FluentAssertions;
using Shouldly;

namespace TestDemos.UnitTest
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void CreatingBankAccountShouldSetInitialAmount()
        {
            const int amount = 2000;

            var bankAccount = new BankAccount(2000);

            bankAccount.Amount.Should().Be(amount);//FluentAssertions
            bankAccount.Amount.ShouldBe(amount);//Shouldly

            Assert.AreEqual(2000, bankAccount.Amount);
            Assert.That(bankAccount.Amount, Is.EqualTo(amount));
        }
    }
}