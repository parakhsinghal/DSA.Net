using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using DSA = DataStructures.Queues.SimpleQueue.ArrayBased;

namespace UnitTests.DataStructures.Queues.SimpleQueue.ArrayBased
{
    [TestClass]
    public class ArrayBasedQueueTests
    {
        #region Local fields, test initialization and test clean up setup

        private DSA.Queue<int> intQueue;
        private DSA.Queue<string> stringQueue;

        private readonly IConfiguration generalSection;

        List<int> range;
        List<string> fruits;

        //Constructor to pick up the data from the JSON file from the right sections.
        public ArrayBasedQueueTests()
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("TestData.json").Build();

            generalSection = configuration.GetSection("General");

            intQueue = new DSA.Queue<int>(10);
            stringQueue = new DSA.Queue<string>(10);
        }

        //Test initialization with data
        [TestInitialize]
        public void InitializeLocalFields()
        {
            range = Enumerable.Range(1, 5).ToList<int>();
            fruits = generalSection["Fruits"].Split(',').ToList<string>();
        }

        //Test clean up after running of the tests
        [TestCleanup]
        public void CleanUpLocalFields()
        {
            range.Clear();
            fruits.Clear();
            intQueue.Clear();
            stringQueue.Clear();
        }

        #endregion

        #region Unit tests

        [TestMethod, TestCategory("Core functionality")]
        public void Constructor_Initialize_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsNotNull(intQueue);
            Assert.IsNotNull(stringQueue);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Enqueue_IsPassedANullValue_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => stringQueue.Enqueue(null));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Enqueue_PassedMoreValuesThanCapacity_ThrowsException()
        {
            //Arrange
            for (int i = 0; i < 10; i++)
            {
                intQueue.Enqueue(i);
            }

            //Act

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => intQueue.Enqueue(11));

        }

        [TestMethod, TestCategory("Core functionality")]
        public void Enqueue_IsPassedAValidValue_ExecutesSuccessfully()
        {
            //Arrange

            //Act
            intQueue.Enqueue(range[0]);
            stringQueue.Enqueue(fruits[0]);

            //Assert
            Assert.IsTrue(intQueue.Peek() != 0);
            Assert.IsNotNull(stringQueue.Peek() != null);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Enqueue_IsPassesValidValues_IncrementsCounter()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intQueue.Enqueue(range[i]);
            }

            for (int i = 0; i < fruits.Count; i++)
            {
                stringQueue.Enqueue(fruits[i]);
            }

            //Act
            int intCounterResult = range.Count;
            int stringCounterResult = fruits.Count;

            //Assert
            Assert.IsTrue(intQueue.Count > 0);
            Assert.IsTrue(stringQueue.Count > 0);
            Assert.AreEqual<int>(intCounterResult, intQueue.Count);
            Assert.AreEqual<int>(stringCounterResult, stringQueue.Count);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Peek_Executes_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intQueue.Enqueue(range[i]);
            }

            for (int i = 0; i < fruits.Count; i++)
            {
                stringQueue.Enqueue(fruits[i]);
            }

            //Act
            int intPeekResult = intQueue.Peek();
            string stringPeekResult = stringQueue.Peek();

            //Assert
            Assert.IsNotNull(stringPeekResult);
            Assert.IsTrue(intPeekResult > 0);
            Assert.AreEqual(stringPeekResult, fruits[0]);
            Assert.AreEqual(intPeekResult, range[0]);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Dequeue_Executes_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intQueue.Enqueue(range[i]);
            }

            for (int i = 0; i < fruits.Count; i++)
            {
                stringQueue.Enqueue(fruits[i]);
            }

            //Act
            intQueue.Dequeue();
            stringQueue.Dequeue();
            int intPeekResult = intQueue.Peek();
            string stringPeekResult = stringQueue.Peek();

            //Assert
            Assert.IsTrue(intQueue.Count > 0);
            Assert.IsTrue(stringQueue.Count > 0);
            Assert.AreEqual(intPeekResult, range[1]);
            Assert.AreEqual(stringPeekResult, fruits[1]);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Dequeue_Executes_DecrementsCounter()
        {
            for (int i = 0; i < range.Count; i++)
            {
                intQueue.Enqueue(range[i]);
            }

            for (int i = 0; i < fruits.Count; i++)
            {
                stringQueue.Enqueue(fruits[i]);
            }

            //Act
            intQueue.Dequeue();
            stringQueue.Dequeue();
            int intCountResult = intQueue.Count;
            int stringCountResult = stringQueue.Count;

            //Assert
            Assert.IsTrue(intQueue.Count > 0);
            Assert.IsTrue(stringQueue.Count > 0);
            Assert.AreEqual(intCountResult, range.Count - 1);
            Assert.AreEqual(stringCountResult, fruits.Count - 1);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void GetEnumerator_Executes_PassesBackValues()
        {
            for (int i = 0; i < range.Count; i++)
            {
                intQueue.Enqueue(range[i]);
            }

            for (int i = 0; i < fruits.Count; i++)
            {
                stringQueue.Enqueue(fruits[i]);
            }

            //Act
            List<int> intGetEnumeratorResult = new List<int>();
            List<string> stringGetEnumeratorResult = new List<string>();
            intGetEnumeratorResult.AddRange(intQueue);
            stringGetEnumeratorResult.AddRange(stringQueue);

            //Assert
            Assert.IsNotNull(intGetEnumeratorResult);
            Assert.IsNotNull(intGetEnumeratorResult);
            Assert.IsTrue(intGetEnumeratorResult.Count > 0);
            Assert.IsTrue(stringGetEnumeratorResult.Count > 0);
        }

        #endregion
    }
}
