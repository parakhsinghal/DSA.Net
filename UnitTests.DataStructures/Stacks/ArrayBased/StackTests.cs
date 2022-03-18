using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DSA = DataStructures.Stacks.ArrayBased;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace UnitTests.DataStructures.ArrayBased.Stack
{
    [TestClass]
    public class StackTests
    {
        #region Local fields, test initialization and test cleanup setup

        //Variables declaration
        private DSA.Stack<int> intStack;
        private DSA.Stack<string> stringStack;

        private readonly IConfiguration generalSection;

        List<int> range;
        List<string> fruits;

        //Constructor to pick up the data from the JSON file from the right sections.
        public StackTests()
        {
            var configuration = new ConfigurationBuilder()
                                            .AddJsonFile("TestData.json").Build();

            generalSection = configuration.GetSection("General");
            intStack = new DSA.Stack<int>();
            stringStack = new DSA.Stack<string>();
        }

        //Data initialization before running any test
        [TestInitialize]
        public void TestInitialize()
        {
            range = Enumerable.Range(1, 10).ToList<int>();
            fruits = generalSection["Fruits"].Split(',').ToList<string>();
        }

        //Clean up after running every test
        [TestCleanup]
        public void TestCleanUp()
        {
            range.Clear();
            fruits.Clear();
            intStack.Clear();
            stringStack.Clear();
        }

        #endregion

        #region Unit Tests

        [TestMethod, TestCategory("Core functionality")]
        public void Push_PassedANullValue_ThrowsAnException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<ArgumentNullException>(()=>stringStack.Push(null));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Push_PassedAValidValue_IsSuccessful()
        {
            //Arrange
            intStack.Push(range[0]);
            stringStack.Push(fruits[0]);

            //Act
            int intResult = intStack.Peek();
            string stringResult = stringStack.Peek();

            //Assert
            Assert.IsNotNull(intResult);
            Assert.IsNotNull(stringResult);
            Assert.AreEqual(range[0], intResult);
            Assert.AreEqual(fruits[0], stringResult);
            Assert.IsTrue(intStack.Count > 0);
            Assert.IsTrue(stringStack.Count > 0);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Peek_Executed_ReceiveNonNullValue()
        {
            //Arrange
            intStack.Push(range[0]);
            stringStack.Push(fruits[0]);

            //Act

            //Assert
            Assert.IsTrue(intStack.Peek() > 0);
            Assert.AreEqual(fruits[0], stringStack.Peek());
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Clear_Executed_ClearsStack()
        {
            //Arrange
            for (int i = 0; i < 5; i++)
            {
                intStack.Push(range[i]);
                stringStack.Push(fruits[i]);
            }

            //Act
            intStack.Clear();
            stringStack.Clear();
            int intCount = intStack.Count;
            int stringCount = stringStack.Count;

            //Assert
            Assert.AreEqual(0, intCount);
            Assert.AreEqual(0, stringCount);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Pop_PopOneElement_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < 5; i++)
            {
                intStack.Push(range[i]);
                stringStack.Push(fruits[i]);
            }

            //Act
            intStack.Pop();
            stringStack.Pop();

            //Assert
            Assert.AreEqual(4, intStack.Count);
            Assert.AreEqual(4, stringStack.Count);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Pop_PopAnElement_IsNotNull()
        {
            //Arrange
            for (int i = 0; i < 5; i++)
            {
                intStack.Push(range[i]);
                stringStack.Push(fruits[i]);
            }

            //Act
            int intResult = intStack.Pop();
            string stringResult = stringStack.Pop();

            //Assert
            Assert.IsNotNull(intResult);
            Assert.IsNotNull(stringResult);
        }       

        #endregion
    }
}
