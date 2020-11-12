using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior w1;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.w1 = new Warrior("Pesho", 50, 50);
            this.attacker = new Warrior("Peshka", 10, 80);
            this.defender = new Warrior("Gosho", 5, 60);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollShouldPhysicallyAddTheWarriorToTheArena()
        {
            this.arena.Enroll(this.w1);

            Assert.That(this.arena.Warriors, Has.Member(this.w1));
        }

        [Test]
        public void EnrollShouldIncreaseCount()
        {
            this.arena.Enroll(this.w1);
            this.arena.Enroll(new Warrior("Gosho", 5, 60));

            var expectedCount = 2;
            var actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EnrollDuplicateWarriorShouldThrowException()
        {
            this.arena.Enroll(this.w1);

            Assert.Throws<InvalidOperationException>(() => { this.arena.Enroll(this.w1); });
        }

        [Test]
        public void EnrollTwoWarriorsWithSameNameShouldThrowException()
        {
            this.arena.Enroll(w1);

            var w2 = new Warrior("Pesho", 50, 50);

            Assert.Throws<InvalidOperationException>(() => { this.arena.Enroll(w2); });
        }

        [Test]
        public void TestFightingWithMissingAttacker()
        {
            this.arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => { this.arena.Fight(this.attacker.Name, this.defender.Name); });
        }

        [Test]
        public void TestFightingWithMissingDefender()
        {
            this.arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => { this.arena.Fight(this.attacker.Name, this.defender.Name); });
        }

        [Test]
        public void TestFightingWithMissingAttackerAndDefender()
        {
            Assert.Throws<InvalidOperationException>(() => { this.arena.Fight(this.attacker.Name, this.defender.Name); });
        }

        [Test]
        public void TestFightBetweenTwoWarriors()
        {
            var expectedAttHp = this.attacker.HP - this.defender.Damage;
            var expectedDefHp = this.defender.HP - this.attacker.Damage;

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttHp, this.attacker.HP);
            Assert.AreEqual(expectedDefHp, this.defender.HP);
        }

    }
}
