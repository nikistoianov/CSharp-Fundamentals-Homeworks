using System;

namespace UnitTests
{
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using _02.ExtendedDatabase;

    [TestFixture]
    class ExtendedDatabaseTests
    {
        [Test]
        public void Constructor_ValidState()
        {
            var firstPerson = new Person(123, "Niki");
            var secondPerson = new Person(55, "Pepi");
            var args = new Person[] { firstPerson,  secondPerson };
            var db = new PeopleDatabase(args);

            FieldInfo fieldinfo = typeof(PeopleDatabase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(x => x.FieldType.IsEquivalentTo(typeof(Person[])));

            var values = ((Person[])fieldinfo.GetValue(db)).Take(args.Length);

            Assert.That(values, Is.EquivalentTo(args));
        }

        [TestCase(123, "Niki", 55, "Niki")]
        [TestCase(11, "Niki2", 11, "Niki")]
        public void Construstor_DublicatedUsers(long firstPersonId, string firstPersonUsername, long secondPersonId, string secondPersonUsername)
        {
            var firstPerson = new Person(firstPersonId, firstPersonUsername);
            var secondPerson = new Person(secondPersonId, secondPersonUsername);
            var args = new Person[] { firstPerson, secondPerson };

            Assert.That(() => new PeopleDatabase(args), Throws.InvalidOperationException.With.Message.EqualTo("Existing user!"));
        }

        [TestCase(123, "Niki", 55, "Niki")]
        [TestCase(11, "Niki2", 11, "Niki")]
        public void Add_DublicatedUser(long firstPersonId, string firstPersonUsername, long secondPersonId, string secondPersonUsername)
        {
            var firstPerson = new Person(firstPersonId, firstPersonUsername);
            var secondPerson = new Person(secondPersonId, secondPersonUsername);
            var args = new Person[] { firstPerson };
            var db = new PeopleDatabase(args);

            Assert.That(() => db.Add(secondPerson), Throws.InvalidOperationException.With.Message.EqualTo("Existing user!"));
        }

        [Test]
        public void FindById_MissingId()
        {
            var firstPerson = new Person(123, "Niki");
            var secondPerson = new Person(55, "Pesho");
            var args = new Person[] { firstPerson };
            var db = new PeopleDatabase(args);

            Assert.That(() => db.FindById(0), Throws.InvalidOperationException);
        }

        [Test]
        public void FindById_InvalidId()
        {
            var firstPerson = new Person(123, "Niki");
            var secondPerson = new Person(55, "Pesho");
            var args = new Person[] { firstPerson };
            var db = new PeopleDatabase(args);

            //Assert.That(() => db.FindById(-8), Throws.ArgumentOutOfRangeException);
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-8));
        }

        [Test]
        public void FindById_ValidFind()
        {
            var firstPerson = new Person(123, "Niki");
            var secondPerson = new Person(55, "Pesho");
            var args = new Person[] { firstPerson };
            var db = new PeopleDatabase(args);
            var foundPerson = db.FindById(123);

            Assert.That(foundPerson, Is.EqualTo(firstPerson));
        }

        [Test]
        public void FindByUsername_MissingUsername()
        {
            var firstPerson = new Person(123, "Niki");
            var secondPerson = new Person(55, "Pesho");
            var args = new Person[] { firstPerson };
            var db = new PeopleDatabase(args);

            Assert.That(() => db.FindByUsername("Gosho"), Throws.InvalidOperationException);
        }
    }
}
