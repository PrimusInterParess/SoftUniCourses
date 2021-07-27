using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {

        private Database database;


        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [Test]
        public void Ctor_InitializedWithArray()
        {
            int[] dataToInitialize = new[] {1, 2, 3, 4, 5};

            this.database= new Database(dataToInitialize);

            Assert.IsTrue(database.Count==dataToInitialize.Length);
        }

        [Test]
        public void Ctor_InitializedWithArray_ShouldAddElementsCorrectly()
        {
            int[] dataToInitialize = new[] { 1, 2, 3, 4, 5 };

            this.database = new Database(dataToInitialize);

            Assert.That(database.Fetch(),Is.EquivalentTo(dataToInitialize));
        }

        [Test]
        public void When_InitilizedCount_ShoudBeZero()
        {
            int zero = 0;

            Assert.AreEqual(zero,this.database.Count);
        }

        [Test]
        public void Add_ThrowsExeption_WhenCapacityExeeded()
        {
            int exeededCapacity = 17;

            Assert.That(() =>
            {
                for (int i = 0; i < exeededCapacity; i++)
                {
                    database.Add(i);
                }


            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
            
            
        }

        [Test]
        public void When_DataBaseInitialized_ShouldAddArrayCorrectly()
        {
            int[] dataToAdd = new[] {1, 2, 3, 4};

            this.database = new Database(dataToAdd);

            Assert.AreEqual(dataToAdd.Length,database.Count);

        }

        [Test]
        public void Add_ShouldIncreaseCount()
        {

            int count = 5;

            for (int i = 0; i < count; i++)
            {
                this.database.Add(i);
            }

            Assert.AreEqual(count,database.Count);
           
        }


        [Test]
        public void Add_ElementToDatabaseCorrectly()
        {
            int element = 5;

           this.database.Add(element);

           int[] elements = this.database.Fetch();

            Assert.IsTrue(elements.Contains(element));

        }

        [Test]
        public void Fetch_ShouldReturnNewArray()
        {
            int[] dataToadd = new[] {1, 2, 3, 4, 5, 6};

            this.database = new Database(dataToadd);

            int[] arrToFetch = database.Fetch();

            Assert.AreNotSame(arrToFetch,database);

        }

        [Test]
        public void Remove_ShouldThrowInvalidOperationExWhenDatabaseEmpty()
        {
            this.database = new Database();

            Assert.That(() =>
            {
                database.Remove();
            },Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));


        }

        [Test]
        public void Remove_ShouldDecreaseCountWhenElementsIsRemoved()
        {
            this.database = new Database(new []{1,2,3,4});

            int decreasedCount = database.Count-1;

            database.Remove();

            Assert.AreEqual(decreasedCount,database.Count);
        }

        [Test]
        public void Remove_ElementFromDatabaseCorrectly()
        {
            int elementToSeek = 4;

            this.database = new Database(new[] { 1, 2, 3, elementToSeek });

            database.Remove();

            int[] checkForExistance = database.Fetch();

            Assert.IsFalse(checkForExistance.Contains(elementToSeek));


        }
    }
}