using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            var expectedName = "Pesho";
            var expectedDmg = 50;
            var expectedHP = 100;

            var warrior = new Warrior(expectedName, expectedDmg, expectedHP);

            var actualName = warrior.Name;
            var actualDmg = warrior.Damage;
            var actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedHP, expectedHP);
            Assert.AreEqual(expectedDmg, expectedDmg);
        }

        [Test]
        public void TestWithLikeNullName()
        {
            string name = null;
            var dmg = 50;
            var hp = 100;

            Assert.Throws<ArgumentException>(() => { var warrior = new Warrior(name, dmg, hp); });
        }

        [Test]
        public void TestWithLikeEmptyName()
        {
            var name = String.Empty;
            var dmg = 50;
            var hp = 100;

            Assert.Throws<ArgumentException>(() => { var warrior = new Warrior(name, dmg, hp); });
        }

        [Test]
        public void TestWithLikeWhiteSpaceName()
        {
            var name = " ";
            var dmg = 50;
            var hp = 100;

            Assert.Throws<ArgumentException>(() => { var warrior = new Warrior(name, dmg, hp); });
        }

        [Test]
        public void TestIfNegativeDmgThrowsException()
        {
            var expectedName = "Pesho";
            var expectedDmg = -50;
            var expectedHP = 30;

            Assert.Throws<ArgumentException>(() => { var warrior = new Warrior(expectedName, expectedDmg, expectedHP); });
        }

        [Test]
        public void TestIfZeroDmgThrowsException()
        {
            var expectedName = "Pesho";
            var expectedDmg = 0;
            var expectedHP = 30;

            Assert.Throws<ArgumentException>(() => { var warrior = new Warrior(expectedName, expectedDmg, expectedHP); });
        }

        [Test]
        public void TestIfNegativeHpThrowsException()
        {

            var expectedName = "Pesho";
            var expectedDmg = 50;
            var expectedHP = -1;


            Assert.Throws<ArgumentException>(() => { var warrior = new Warrior(expectedName, expectedDmg, expectedHP); });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemyWhenLowHpShouldThrowException(int attackerHp)
        {
            var attackerName = "Pesho";
            var attackerDmg = 10;

            var defenderName = "Gosho";
            var defenderDmg = 10;
            var defenderHp = 40;

            var attacker = new Warrior(attackerName,attackerDmg,attackerHp);
            var defender = new Warrior(defenderName,defenderDmg,defenderHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemyWithLowHpShouldThrowException(int defenderHp)
        {
            var attackerName = "Pesho";
            var attackerDmg = 10;
            var attackerHp = 100;

            var defenderName = "Gosho";
            var defenderDmg = 10;

            var attacker = new Warrior(attackerName, attackerDmg, attackerHp);
            var defender = new Warrior(defenderName, defenderDmg, defenderHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttackingEnemyWhenHpLowerThenEnemyDmgThrowsException()
        {
            var attackerName = "Pesho";
            var attackerDmg = 10;
            var attackerHp = 50;
            
            var defenderName = "Gosho";
            var defenderDmg = 60;
            var defenderHp = 50;

            var attacker = new Warrior(attackerName, attackerDmg, attackerHp);
            var defender = new Warrior(defenderName, defenderDmg, defenderHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttackingShouldDecreaseHpWhenAttackIsSuccessful()
        {
            var aName = "Pesho";
            var aDmg = 10;
            var aHp = 40;

            var dName = "Gosho";
            var dDmg = 5;
            var dHp = 50;

            var attacker = new Warrior(aName,aDmg,aHp);
            var defender = new Warrior(dName,dDmg,dHp);

            var expectedAttackerHp = aHp - dDmg;
            var expectedDefenderHp = dHp - aDmg;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHp,attacker.HP);
            Assert.AreEqual(expectedDefenderHp,defender.HP);
        }

        [Test]
        public void AttackingShouldKillEnemyWIthLowHp()
        {
            var aName = "Pesho";
            var aDmg = 80;
            var aHp = 100;

            var dName = "Gosho";
            var dDmg = 10;
            var dHp = 60;

            var attacker = new Warrior(aName, aDmg, aHp);
            var defender = new Warrior(dName, dDmg, dHp);

            var expectedAttackerHP = aHp - dDmg;
            var expectedDefenderHp = 0;

            attacker.Attack(defender);
            
            Assert.AreEqual(expectedAttackerHP,attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }



    }
}