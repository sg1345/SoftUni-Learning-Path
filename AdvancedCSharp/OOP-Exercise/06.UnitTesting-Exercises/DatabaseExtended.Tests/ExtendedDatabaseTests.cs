namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCase(0), TestCase(1), TestCase(8), TestCase(15)]
        public void Test_Constructor(int rangeLength)
        {
            // Random random = new Random();
            //char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            //for(int j=0; j < 16; j++)
            //{
            //    char letter = alphabet[random.Next(alphabet.Length)];
            //    name += letter;
            //}

            Database database = CreateTestDatabase(rangeLength);

            Assert.AreEqual(rangeLength, database.Count);
        }

        [Test]
        public void Test_ConstructorAddRange_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => CreateTestDatabase(17));
        }

        [Test]
        public void Test_Remove()
        {
            Database database = CreateTestDatabase(16);

            database.Remove();
            database.Remove();
            database.Remove();

            //Person[] comparedTo = new Person[13];
            //for (int i = 0; i < comparedTo.Length; i++)
            //{
            //    long id = 000000 + i;

            //    string name = "string.Empty" + i;

            //    Person person = new(id, name);
            //    comparedTo[i] = person;
            //}

            //Database comparedToDatabase = new Database(comparedTo);

            Assert.AreEqual(13, database.Count);
        }


        [Test]
        public void Test_Remove_InvalidOperationException()
        {

            Database database = CreateTestDatabase(1);

            database.Remove();

            Assert.Throws<InvalidOperationException>
                (
                    () => database.Remove(),
                    "Provided data length should be in range [0..16]!"
                );
        }

        [Test]
        public void Test_Add()
        {
            Database database = CreateTestDatabase(0);
            Person person = new(9999, "TestPerson");
            database.Add(person);

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void Test_Add_CapacityOver16_InvalidOperationException()
        {
            Database db = CreateTestDatabase(16);
            Person person = new(9999, "TestPerson");

            Assert.Throws<InvalidOperationException>
                (
                    () => db.Add(person),
                    "Array's capacity must be exactly 16 integers!"
                );
        }

        [Test]
        public void Test_Add_SameName_InvalidOperationException()
        {
            Database database = CreateTestDatabase(0);

            Person personName = new(9999, "TestPerson");
            Person samePersonName = new(9998, "TestPerson");

            database.Add(personName);
            Assert.Throws<InvalidOperationException>
                (
                    ()=>database.Add(samePersonName),
                    "There is already user with this username!"
                );
        }

        [Test]
        public void Test_Add_SameId_InvalidOperationException()
        {
            Database database = CreateTestDatabase(0);

            Person personId = new(9999, "TestPersonOne");
            Person samePersonId = new(9999, "TestPersonTwo");
            database.Add(personId);

            Assert.Throws<InvalidOperationException>
                (
                    () => database.Add(samePersonId),
                    "There is already user with this Id!"
                );
        }

        [Test]
        public void Test_FindByUsername()
        {
            Database database = CreateTestDatabase(1);
            Person person = new(9999, "TestPerson");
            database.Add(person);

            Assert.AreEqual(person, database.FindByUsername(person.UserName));
        }

        [Test]
        public void Test_FindByUsername_SearchNameIsNullOrEmpty_ArgumentNullException()
        {
            Database db = CreateTestDatabase(1);

            Assert.Throws<ArgumentNullException>
                (
                    () => db.FindByUsername(""),
                    "Username parameter is null!"
                );
        }

        [Test]
        public void Test_FindByUsername_NoSuchName_InvalidOperationException()
        {
            Database database = CreateTestDatabase(1);

            Assert.Throws<InvalidOperationException>
                (
                    () => database.FindByUsername("ThereIsNoSuchName"),
                    "No user is present by this username!"
                );
        }

        [Test]
        public void Test_FindById()
        {
            Database database = CreateTestDatabase(1);
            Person person = new(9999, "TestPerson");
            database.Add(person);

            Assert.AreEqual(person,database.FindById(person.Id));
        }

        [Test]
        public void Test_FindById_SearchIdIsNegative_ArgumentOutOfRangeException()
        {
            Database database = CreateTestDatabase(1);

            Assert.Throws<ArgumentOutOfRangeException>
                (
                    () => database.FindById(-1),
                    "Id should be a positive number!"
                );
        }

        [Test]
        public void Test_FindById_SearchIdDoesNotExist_InvalidOperationException()
        {
            Database database = CreateTestDatabase(1);
            long fakeIdNumber = 6969;

            Assert.Throws<InvalidOperationException>
                (
                    ()=>database.FindById(fakeIdNumber),
                    "No user is present by this ID!"
                );

        }

        private static Database CreateTestDatabase(int length)
        {
            Person[] people = new Person[length];

            for (int i = 0; i < people.Length; i++)
            {
                long id = 1 + i;

                string name = "string.Empty" + i;

                Person person = new(id, name);
                people[i] = person;
            }

            Database database = new Database(people);
            return database;
        }
    }
}