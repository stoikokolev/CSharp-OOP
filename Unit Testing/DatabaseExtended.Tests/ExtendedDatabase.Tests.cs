using System;
using ExtendedDatabase;
using NUnit.Framework;



namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;
        private global::ExtendedDatabase.ExtendedDatabase database;
        private readonly Person[] people = new[]
                {new Person(1, "Pesho"),
                new Person(2, "Ivan"),
                new Person(3, "Dimitrichko")};

        [SetUp]
        public void Setup()
        {
            person = new Person(111,"Pesho");
            var data = new[]
            {
                new Person(1,"Pesho1"),
                new Person(2,"Pesho2"),
                new Person(3,"Pesho3"),
                new Person(4,"Pesho4"),
                new Person(5,"Pesho5"),
                new Person(6,"Pesho6"),
                new Person(7,"Pesho7"),
                new Person(8,"Pesho8"),
                new Person(9,"Pesho9"),
                new Person(10,"Pesho10"),
                new Person(11,"Pesho11"),
                new Person(12,"Pesho12"),
                new Person(13,"Pesho13"),
                new Person(14,"Pesho14"),
                new Person(15,"Pesho15")
                };
            this.database = new global::ExtendedDatabase.ExtendedDatabase(data);
        }

        [Test]
        public void TestIfPersonConstructorWorksCorrectly()
        {
            var expectedName = "Pesho";
            var expectedId = (long) 1;

            person=new Person(1,"Pesho");

            Assert.AreEqual(expectedName,this.person.UserName);
            Assert.AreEqual(expectedId,this.person.Id);
        }

        [Test]
        public void TestIfDatabaseConstructorWorksCorrectly()
        {
            var expectedCount = 3;

            this.database=new global::ExtendedDatabase.ExtendedDatabase(people);

            Assert.AreEqual(expectedCount,this.database.Count);
        }

        [Test]
        public void TestIfAddRangeThrowsExceptionWhenDatabaseIsFull()
        {
            var data = new Person[17];
            
            Assert.Throws<ArgumentException>(() =>
            {
                this.database = new global::ExtendedDatabase.ExtendedDatabase(data);
            });
        }

        [Test]
        public void TestIfAddThrowsExceptionWhenDatabaseIsFull()
        {
                this.database.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(123,"sto"));
            });
        }

        [Test]
        public void TestIfAddThrowsExceptionWhenDuplicateUsername()
        {
            var duplicateNamePerson = new Person(11111, "Pesho1");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(duplicateNamePerson);
            });
        }

        [Test]
        public void TestIfAddThrowsExceptionWhenDuplicateId()
        {
            var duplicateIdPerson = new Person(1, "Pesho321");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(duplicateIdPerson);
            });
        }

        [Test]
        public void TestIfCountDecreasesWhenRemove()
        {
            var expectedCount = 14;

            this.database.Remove();

            Assert.AreEqual(expectedCount,this.database.Count);
        }

        [Test]
        public void TestIfRemoveThrowsExceptionWhenDatabaseIsEmpty()
        {
            this.database=new global::ExtendedDatabase.ExtendedDatabase(people);

            this.database.Remove();
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestIfFindByUsernameThrowsExceptionWhenNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => { this.database.FindByUsername(name); });
        }

        [TestCase("Dimitrichko")]
        [TestCase("Asen")]
        public void TestIfFindByUsernameThrowsExceptionWhenNameDoesntExist(string name)
        {
            Assert.Throws<InvalidOperationException>(() => { this.database.FindByUsername(name); });
        }

        [Test]
        public void TestIfFindByUsernameReturnsCorrectly()
        {
            this.database.Add(person);

            var expectedPerson = this.database.FindByUsername("Pesho");

            Assert.AreEqual(expectedPerson,person);
        }

        [Test]
        public void TestIfFindByIdThrowsExceptionWhenNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { this.database.FindById(-1); });
        }

        [Test]
        public void TestIfFindByIdThrowsExceptionWhenIdDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => { this.database.FindById(11122); });
        }

        [Test]
        public void TestIfFindByIdReturnsCorrectly()
        {
            this.database.Add(person);

            var expectedPerson = this.database.FindById(111);

            Assert.AreEqual(expectedPerson, person);
        }
    }
}