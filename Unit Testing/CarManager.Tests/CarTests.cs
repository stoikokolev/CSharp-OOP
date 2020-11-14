using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        private Car testCar;

        [SetUp]
        public void Setup()
        {
            testCar = new Car("VW", "Golf", 10.1, 55.5);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            var expectedMake = "Mercedes";
            var expectedModel = "G";
            var expectedFuelConsumpion = 11.2;
            var expectedFuelCapacity = 70.5;
            var expectedFuelAmount = 0;

            this.car = new Car("Mercedes", "G", 11.2, 70.5);

            Assert.AreEqual(expectedMake, this.car.Make);
            Assert.AreEqual(expectedModel, this.car.Model);
            Assert.AreEqual(expectedFuelConsumpion, this.car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, this.car.FuelCapacity);
            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestIfMakeIsNullOrEmptyThrowsException(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car = new Car(make, "G", 11.2, 70.5);
            });
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestIfModelIsNullOrEmptyThrowsException(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car = new Car("Mercedes", model, 11.2, 70.5);
            });
        }

        [TestCase(0)]
        [TestCase(-100.2)]
        public void TestIfZeroOrNegativeConsumptionThrowsException(double consumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car = new Car("Mercedes", "G", consumption, 70.5);
            });
        }

        [TestCase(0)]
        [TestCase(-100.2)]
        public void TestIfZeroOrNegativeCapacityThrowsException(double capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car = new Car("Mercedes", "G", 11.2, capacity);
            });
        }

        [TestCase(0)]
        [TestCase(-11)]
        public void TestIfRefuelWithZeroOrNegativeFuelThrowsException(double fuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(fuel);
            });
        }

        [Test]
        public void TestIRefuelWithBigAmountOfFuelWorksCorrect()
        {
            var expectedFuel = 55.5;

            testCar.Refuel(100);

            Assert.AreEqual(expectedFuel, testCar.FuelAmount);
        }

        [Test]
        public void TestIRefuelWorksCorrect()
        {
            var expectedFuel = 20;

            testCar.Refuel(20);

            Assert.AreEqual(expectedFuel, testCar.FuelAmount);
        }

        [Test]
        public void TestIfDriveWoksCorrect()
        {
            testCar.Refuel(20);
            var expectedFuel = 17.98;

            testCar.Drive(20);

            Assert.AreEqual(expectedFuel, testCar.FuelAmount);
        }

        [TestCase(2000)]
        [TestCase(4000)]
        public void TestIfDriveThrowsExceptionWhenFuelNotEnough(double distance)
        {
            testCar.Refuel(20);

            Assert.Throws<InvalidOperationException>(() => { testCar.Drive(distance); });
        }
    }
}