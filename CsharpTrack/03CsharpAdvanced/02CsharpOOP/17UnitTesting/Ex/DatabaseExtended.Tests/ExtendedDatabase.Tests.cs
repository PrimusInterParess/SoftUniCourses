using System;

using NUnit.Framework;


namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person person;
        private int id;
        private string userName;
        private int exceededCapacity = 17;
        private int inRange = 10;


        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase();
            person = new Person(id, userName);

        }

        [Test]
        public void When_InitializedWithAnArr_CountShuldBeCorrect()
        {
            Person[] testArray = GeneratePersonArray(inRange);

            database = new ExtendedDatabase(testArray);

            Assert.AreEqual(testArray.Length, database.Count);

        }

        [Test]
        public void When_InitializingDatabase_Should_ThrowArgEx_IfInitializedWithArrWithBigerRange()
        {
            Person[] testArray = GeneratePersonArray(exceededCapacity);

            Assert.Throws<ArgumentException>(() => database = new ExtendedDatabase(testArray));

            //Assert.That(() =>
            //{
            //    database = new ExtendedDatabase(testArray);
            //}, Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void Add_Should_IncreaceCount()
        {

            for (int i = 0; i < inRange; i++)
            {
                database.Add(GeneratePerson());
            }

            Assert.AreEqual(inRange, database.Count);
        }

        [Test]
        public void Add_Should_ThrowInvalidOperationExeption_When_IdsAreDuplicated()
        {
            //database.Add(new Person(12, "Pesho1"));
            //database.Add(new Person(12, "Pesho12"));


            Assert.That(() =>
            {
                this.database.Add(new Person(12, "Pesho1"));
                this.database.Add(new Person(12, "Pesho12"));
            }, Throws.InvalidOperationException);

        }

        [Test]
        public void Add_Should_ThrowInvalidOperationExeption_When_UserNamesAreDuplicated()
        {
            Assert.That(() =>
            {
                this.database.Add(new Person(11, "Pesho12"));
                this.database.Add(new Person(12, "Pesho12"));
            }, Throws.InvalidOperationException);

        }

        [Test]
        public void Add_Should_ThrowInvalidOperationExIfCapacityExceeded()
        {

            Assert.That(() =>
            {
                for (int i = 0; i < exceededCapacity; i++)
                {
                    database.Add(GeneratePerson());
                }
            }, Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_Should_ThrowArgNullEx_When_TriedWithNullOrEmptyString(string userName)
        {
            database = new ExtendedDatabase(GeneratePersonArray(inRange));

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(userName));

        }

        [Test]
        public void FindingByUsername_Should_Throw_InvalidOperationExeption_WhenNoMatch()
        {
            database = new ExtendedDatabase(GeneratePersonArray(inRange));
            userName = "Pesho";

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(userName));
        }

        [Test]
        public void FindingByUserName_Should_ReturnCorrenctUsername()
        {
            Person newPerson = new Person(12, "Pesho");

            database.Add(newPerson);

            Person getPerson = database.FindByUsername("Pesho");

            Assert.AreEqual(newPerson,getPerson);

            
        }

        [Test]
        public void FindUserById_Should_ThrowInvalidOprEx_When_UserDoesntExist()
        {
            int wrongId = 2;

            database.Add(new Person(1,"dve"));

            Assert.Throws<InvalidOperationException>(() => database.FindById(wrongId));
        }

        [Test]
        [TestCase(-25)]
        [TestCase(-1)]
        public void FindWithId_Should_ThrowArgOutOfRangeEx_WhenIdIsZeroOrLess(int id)
        {
            database = new ExtendedDatabase(GeneratePersonArray(inRange));


            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }

        [Test]
        public void FindById_ShouldReturnExpectedUser()
        {
            int id = 1;

            person = new Person(id, "gogo");

            database.Add(person);

            Person newPersong = database.FindById(id);

            Assert.AreEqual(person,newPersong);

        }
       

        private Person GeneratePerson()
        {
            Person person = new Person(GenerateId(), GenerateUserName());

            return person;
        }

        private int GenerateId()
        {
            Random random = new Random();

            int num = random.Next(1000);

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    for (int k = 0; k < i; k++)
                    {
                        num += i + j + k;

                    }

                }


            }

            return num;
        }

        private string GenerateUserName()
        {


            Random r = new Random();
            int len = r.Next(50);
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        private Person[] GeneratePersonArray(int capacity)
        {
            Person[] toReturn = new Person[capacity];

            for (int i = 0; i < capacity; i++)
            {
                toReturn[i] = GeneratePerson();
            }

            return toReturn;
        }
    }
}