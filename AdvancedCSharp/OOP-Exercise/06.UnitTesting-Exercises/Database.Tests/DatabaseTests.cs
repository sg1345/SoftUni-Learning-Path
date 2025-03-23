namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private const int arrayLengthLimit = 16;
        [Test]
        public void Test_ArrayLengthValidation()
        {
            int[] numbers = new int[arrayLengthLimit];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            Database database = new Database(numbers);

            Assert.AreEqual(16, database.Count);
        }

        [TestCase(1), TestCase(8), TestCase(16)]
        public void Test_CountAddRemoveMethods(int length)
        {
            int[] numbers = new int[arrayLengthLimit];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            Database database = new Database(numbers);

            int count = database.Count-1;

            for (int i = 0; i < count; i++)
            {
                database.Remove();
                
            }

            for (int i = 0; i < length-1; i++)
            {                
                database.Add(numbers[i]);
            }

            Assert.AreEqual(length, database.Count);
        }

        [Test]
        public void Test_ThrowAddException()
        {
            int[] numbers = new int[arrayLengthLimit];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            Database database = new Database(numbers);



            Assert.Throws<InvalidOperationException>(() => database.Add(1), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Test_ThrowRemoveException()
        {
            int[] numbers = new int[arrayLengthLimit];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            Database database = new Database(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove(), "The collection is empty!");
        }

        [Test]
        public void Test_Fetch()
        {
            int[] numbers = new int[arrayLengthLimit];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            Database database = new Database(numbers);

            int[] testResult = database.Fetch();

            Assert.AreEqual(numbers, testResult);
        }
    }
}
