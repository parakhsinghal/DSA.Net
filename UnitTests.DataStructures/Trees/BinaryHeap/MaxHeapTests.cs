using DataStructures.Trees.BinaryHeap;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.DataStructures.Trees.BinaryHeap
{
    [TestClass]
    public class MaxHeapTests
    {
        #region Local fields, test initialization and test clean up setup

        MaxHeap<int> intHeap;
        MaxHeap<int> negativeIntHeap;
        MaxHeap<uint> uintHeap;
        MaxHeap<char> charHeap;
        MaxHeap<string> stringHeap;

        private readonly IConfiguration maxHeapSection;

        private List<int> intRange;
        private List<int> negativeIntRange;
        private List<uint> uintRange;
        private List<char> charRange;
        private List<string> stringRange;

        public MaxHeapTests()
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("TestData.json").Build();

            maxHeapSection = configuration.GetSection("MaxHeap");

            intRange = new List<int>();
            negativeIntRange = new List<int>();
            uintRange = new List<uint>();
            charRange = new List<char>();
            stringRange = new List<string>();

            intHeap = new MaxHeap<int>();
            negativeIntHeap = new MaxHeap<int>();
            uintHeap = new MaxHeap<uint>();
            charHeap = new MaxHeap<char>();
            stringHeap = new MaxHeap<string>();
        }

        [TestInitialize]
        public void InitializeLocalFields()
        {            
            stringRange = maxHeapSection["Names"].Split(',').ToList<string>();

            var tempCharRange = maxHeapSection["Characters"].Split(',').ToList<string>();
            charRange.AddRange(tempCharRange.Select(item => Convert.ToChar(item)));

            var tempIntRange = maxHeapSection["RandomInts"].Split(',').ToList<string>();
            intRange.AddRange(tempIntRange.Select(item => Convert.ToInt32(item)));

            var tempNegativeIntRange = maxHeapSection["RandomNegativeInts"].Split(',').ToList<string>();
            negativeIntRange.AddRange(tempNegativeIntRange.Select(item => Convert.ToInt32(item)));

            var tempUIntRange = maxHeapSection["RandomUInts"].Split(',').ToList<string>();
            uintRange.AddRange(tempUIntRange.Select(item => Convert.ToUInt32(item)));
        }

        [TestCleanup]
        public void CleanUpLocalFields()
        {
            intRange.Clear();           
            intHeap.Clear();
            negativeIntHeap.Clear();
            uintHeap.Clear();
            charHeap.Clear();
            stringHeap.Clear();
        }

        #endregion

        #region Unit tests

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertNullValue_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => stringHeap.Insert(null));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertValidRoot_IsSuccessful()
        {
            //Arrange
            int intToBeInserted = intRange.FirstOrDefault<int>();
            string stringToBeInserted = stringRange.FirstOrDefault<string>();
            char charToBeInserted = charRange.FirstOrDefault<char>();
            int negativeIntToBeInserted = negativeIntRange.FirstOrDefault<int>();
            uint UintToBeInserted = uintRange.FirstOrDefault<uint>();

            //Act
            intHeap.Insert(intToBeInserted);
            negativeIntHeap.Insert(negativeIntToBeInserted);
            stringHeap.Insert(stringToBeInserted);
            charHeap.Insert(charToBeInserted);
            uintHeap.Insert(UintToBeInserted);

            //Assert
            Assert.IsNotNull(intHeap.Root);
            Assert.IsTrue(intHeap.Root > 0);
            Assert.IsNotNull(negativeIntHeap.Root);
            Assert.IsTrue(negativeIntHeap.Root < 0);
            Assert.IsNotNull(stringHeap.Root);
            Assert.IsNotNull(charHeap.Root);
            Assert.IsNotNull(uintHeap.Root);
            Assert.IsTrue(uintHeap.Root > 0);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertIntValues_IsSuccessful()
        {
            //Arrange           

            //Act
            for (int i = 0; i < 10; i++)
            {
                intHeap.Insert(intRange[i]);
            }

            //Assert
            Assert.IsNotNull(intHeap.Root);
            Assert.IsTrue(intHeap.Root > 0);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertNegativeIntValues_IsSuccessful()
        {
            //Arrange

            //Act
            for (int i = 0; i < 10; i++)
            {
                negativeIntHeap.Insert(negativeIntRange[i]);
            }

            //Assert
            Assert.IsNotNull(negativeIntHeap.Root);
            Assert.IsTrue(negativeIntHeap.Root < 0);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertUintValues_IsSuccessful()
        {
            //Arrange

            //Act
            for (int i = 0; i < 10; i++)
            {
                uintHeap.Insert(uintRange[i]);
            }

            //Assert
            Assert.IsNotNull(uintHeap.Root);
            Assert.IsTrue(uintHeap.Root > 0);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertCharValues_IsSuccessful()
        {
            //Arrange

            //Act
            foreach (char item in charRange)
            {
                charHeap.Insert(item);
            }

            //Assert
            Assert.IsNotNull(charHeap.Root);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertStringValues_IsSuccessful()
        {
            //Arrange

            //Act
            foreach (string item in stringRange)
            {
                stringHeap.Insert(item);
            }

            //Assert
            Assert.IsNotNull(stringHeap.Root);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateIntValues_ThrowsException()
        {
            //Arrange

            //Act
            intHeap.Insert(intRange.FirstOrDefault<int>());

            //Assert
            Assert.ThrowsException<ArgumentException>(() => intHeap.Insert(intRange.FirstOrDefault<int>()));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateUintValues_ThrowsException()
        {
            //Arrange

            //Act
            uintHeap.Insert(uintRange.FirstOrDefault<uint>());

            //Assert
            Assert.ThrowsException<ArgumentException>(() => uintHeap.Insert(uintRange.FirstOrDefault<uint>()));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateCharValues_ThrowsException()
        {
            //Arrange

            //Act
            charHeap.Insert(charRange.FirstOrDefault<char>());

            //Assert
            Assert.ThrowsException<ArgumentException>(() => charHeap.Insert(charRange.FirstOrDefault<char>()));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateStringValues_ThrowsException()
        {
            //Arrange

            //Act
            stringHeap.Insert(stringRange.FirstOrDefault<string>());

            //Assert
            Assert.ThrowsException<ArgumentException>(() => stringHeap.Insert(stringRange.FirstOrDefault<string>()));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_RootIsNull_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => stringHeap.Remove(null));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_ValueIsNotAvailableInTree_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => intHeap.Remove(intRange.FirstOrDefault<int>()));
            Assert.ThrowsException<InvalidOperationException>(() => uintHeap.Remove(uintRange.FirstOrDefault<uint>()));
            Assert.ThrowsException<InvalidOperationException>(() => stringHeap.Remove(stringRange.FirstOrDefault<string>()));
            Assert.ThrowsException<InvalidOperationException>(() => negativeIntHeap.Remove(negativeIntRange.FirstOrDefault<int>()));
            Assert.ThrowsException<InvalidOperationException>(() => charHeap.Remove(charRange.FirstOrDefault<char>()));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_IntRoot_IsSuccessful()
        {
            //Arrange           
            for (int i = 0; i < intRange.Count; i++)
            {
                intHeap.Insert(intRange[i]);
            }

            intHeap.Remove(intHeap.Root);      
           
            int actualRoot = intHeap.Root;
            int expectedRoot = Convert.ToInt32(maxHeapSection["ExpectedDeleteIntRoot"].ToString());

            //Act

            //Assert
            Assert.IsNotNull(actualRoot);
            Assert.IsTrue(actualRoot > 0);
            Assert.AreEqual(expectedRoot, actualRoot);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_UIntRoot_IsSuccessful()
        {
            //Arrange           
            for (int i = 0; i < uintRange.Count; i++)
            {
                uintHeap.Insert(uintRange[i]);
            }

            uintHeap.Remove(uintHeap.Root);

            uint actualRoot = uintHeap.Root;
            uint expectedRoot = Convert.ToUInt32(maxHeapSection["ExpectedDeleteUIntRoot"].ToString());

            //Act

            //Assert
            Assert.IsNotNull(actualRoot);
            Assert.IsTrue(actualRoot > 0);
            Assert.AreEqual(expectedRoot, actualRoot);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_CharRoot_IsSuccessful()
        {
            //Arrange           
            for (int i = 0; i < charRange.Count; i++)
            {
                charHeap.Insert(charRange[i]);
            }

            charHeap.Remove(charHeap.Root);

            char actualRoot = charHeap.Root;
            char expectedRoot = Convert.ToChar(maxHeapSection["ExpectedDeleteCharRoot"].ToString());

            //Act

            //Assert
            Assert.IsNotNull(actualRoot);
            Assert.AreEqual(expectedRoot, actualRoot);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_StringRoot_IsSuccessful()
        {
            //Arrange           
            for (int i = 0; i < stringRange.Count; i++)
            {
                stringHeap.Insert(stringRange[i]);
            }

            stringHeap.Remove(stringHeap.Root);

            string actualRoot = stringHeap.Root;
            string expectedRoot = maxHeapSection["ExpectedDeleteStringRoot"].ToString();

            //Act

            //Assert
            Assert.IsNotNull(actualRoot);
            Assert.AreEqual(expectedRoot, actualRoot);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_NegativeIntRoot_IsSuccessful()
        {
            //Arrange           
            for (int i = 0; i < negativeIntRange.Count; i++)
            {
                negativeIntHeap.Insert(negativeIntRange[i]);
            }

            negativeIntHeap.Remove(negativeIntHeap.Root);

            int actualRoot = negativeIntHeap.Root;
            int expectedRoot = Convert.ToInt32(maxHeapSection["ExpectedDeleteNegativeRoot"].ToString());

            //Act

            //Assert
            Assert.IsNotNull(actualRoot);
            Assert.IsTrue(actualRoot < 0);
            Assert.AreEqual(expectedRoot, actualRoot);
        }

        #endregion
    }
}
