
using System.Linq;

namespace UnitTests
{
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using _01.Database;

    public class DatabaseTests
    {
        [TestCase(17)]
        [TestCase(99)]
        public void Constructor_ElementsOverload(int lenght)
        {
            var args = new int[lenght];
            Assert.That(() => new Database(args), Throws.InvalidOperationException);
        }

        [Test]
        public void Constructor_ValidState()
        {
            var args = new int[]{1, 2, 3, 40};
            var database = new Database(args);

            FieldInfo fieldinfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(x => x.FieldType.IsEquivalentTo(typeof(int[])));

            var values = ((int[])fieldinfo.GetValue(database)).Take(args.Length);

            Assert.That(values, Is.EquivalentTo(args));
        }

        [Test]
        public void Add_Overload()
        {
            var args = new int[16];
            var database = new Database(args);
            Assert.That(() => database.Add(1), Throws.InvalidOperationException.With.Message.EqualTo("Database is full!"));
        }

        [Test]
        public void Remove_FromEmptyDatabase()
        {
            //var args = new int[16];
            var database = new Database();
            Assert.That(() => database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("Database is empty!"));
        }

        [Test]
        public void Fetch_ValidState()
        {
            //var args = new int[16];
            var database = new Database();
            database.Add(10);
            database.Add(2);
            database.Add(5);
            database.Remove();
            database.Add(6);
            Assert.That(database.Fetch(), Is.EqualTo(new int[]{10, 2, 6}));
        }

        [Test]
        public void Fetch_ValidState_ReturnEmptyArray()
        {
            //var args = new int[16];
            var database = new Database();
            database.Add(10);
            database.Add(2);
            database.Add(5);
            database.Remove();
            database.Add(6);
            database.Remove();
            database.Remove();
            database.Remove();
            Assert.That(database.Fetch(), Is.EquivalentTo(new int[0]));
        }

    }
}
