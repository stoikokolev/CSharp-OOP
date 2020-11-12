using System;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] initialData = new[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(initialData);
        }

        [Test]
        public void TestIfTheConstructorWorksCorrectly()
        {
            var data = new int[] { 1, 2, 3 };
            this.database = new Database.Database(data);

            var expectedCount = data.Length;
            var actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestIfTheConstructorThrowsExceptionWhenBiggerCollection()
        {
            var data = new[] { 1, 2, 3, 3, 2, 1, 1, 2, 3, 3, 2, 1, 1, 2, 3, 3, 2 };

            Assert.Throws<InvalidOperationException>(() =>
           {
               this.database = new Database.Database(data);
           });
        }

        [Test]
        public void AddShouldIncreaseCountWhenAddedSuccessfully()
        {
            this.database.Add(3);

            var expectedCount = 3;
            var actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowExceptionWhenDatabaseIsFull()
        {
            for (var i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            
            Assert.Throws<InvalidOperationException>(() => { this.database.Add(17);});
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            var data = new int[0];
            this.database=new Database.Database(data);


            Assert.Throws<InvalidOperationException>(() => { this.database.Remove(); });
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            this.database.Remove();

            var expectedCount = 1;
            var actualCount = this.database.Count;

            Assert.AreEqual(expectedCount,actualCount);
        }

        [TestCase(new[] {1,2,3})]
        [TestCase(new int[] {})]
        [TestCase(new[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16})]
        public void FetchShouldReturnCopyOfData(int[] expectedData)
        {
            this.database=new Database.Database(expectedData);

            var actualData = this.database.Fetch();

            CollectionAssert.AreEqual(expectedData,actualData);
            
        }
    }
}