using DataStructures.Trees.SplayTree;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.DataStructures.Trees.SplayTreeTests
{
    [TestClass]
    public class SplayTreeTests
    {
        #region Local fields, test initialization and test clean up setup

        SplayTree<int> intTree;
        SplayTree<int> negativeIntTree;
        SplayTree<uint> uintTree;
        SplayTree<char> charTree;
        SplayTree<string> stringTree;

        private readonly IConfiguration splayTreeSection;

        private List<int> intRange;
        private List<int> negativeIntRange;
        private List<uint> uintRange;
        private List<char> charRange;
        private List<string> stringRange;
        private List<string> fruits;

        public SplayTreeTests()
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("TestData.json").Build();

            splayTreeSection = configuration.GetSection("SplayTree");

            intRange = new List<int>();
            negativeIntRange = new List<int>();
            uintRange = new List<uint>();
            charRange = new List<char>();
            stringRange = new List<string>();
            fruits = new List<string>();

            intTree = new SplayTree<int>();
            negativeIntTree = new SplayTree<int>();
            uintTree = new SplayTree<uint>();
            charTree = new SplayTree<char>();
            stringTree = new SplayTree<string>();
        }

        [TestInitialize]
        public void InitializeLocalFields()
        {
            fruits = splayTreeSection["Fruits"].Split(',').ToList<string>();
            stringRange = splayTreeSection["Names"].Split(',').ToList<string>();

            var tempCharRange = splayTreeSection["Characters"].Split(',').ToList<string>();
            charRange.AddRange(tempCharRange.Select(item => Convert.ToChar(item)));

            var tempIntRange = splayTreeSection["RandomInts"].Split(',').ToList<string>();
            intRange.AddRange(tempIntRange.Select(item => Convert.ToInt32(item)));

            var tempNegativeIntRange = splayTreeSection["RandomNegativeInts"].Split(',').ToList<string>();
            negativeIntRange.AddRange(tempNegativeIntRange.Select(item => Convert.ToInt32(item)));

            var tempUIntRange = splayTreeSection["RandomUInts"].Split(',').ToList<string>();
            uintRange.AddRange(tempUIntRange.Select(item => Convert.ToUInt32(item)));
        }

        [TestCleanup]
        public void CleanUpLocalFields()
        {
            intRange.Clear();
            fruits.Clear();
            intTree.Clear();
            negativeIntTree.Clear();
            uintTree.Clear();
            charTree.Clear();
            stringTree.Clear();
        }

        #endregion

        #region Unit tests

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertNullValue_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => stringTree.Insert(null));
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
            intTree.Insert(intToBeInserted);
            negativeIntTree.Insert(negativeIntToBeInserted);
            stringTree.Insert(stringToBeInserted);
            charTree.Insert(charToBeInserted);
            uintTree.Insert(UintToBeInserted);

            //Assert
            Assert.IsNotNull(intTree.Root);
            Assert.IsTrue(intTree.Root.Value > 0);
            Assert.IsNotNull(negativeIntTree.Root);
            Assert.IsTrue(negativeIntTree.Root.Value < 0);
            Assert.IsNotNull(stringTree.Root);
            Assert.IsNotNull(charTree.Root);
            Assert.IsNotNull(uintTree.Root);
            Assert.IsTrue(uintTree.Root.Value > 0);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertIntValues_IsSuccessful()
        {
            //Arrange           

            //Act
            for (int i = 0; i < 10; i++)
            {
                intTree.Insert(intRange[i]);
            }

            //Assert
            Assert.IsNotNull(intTree.Root);
            Assert.IsTrue(intTree.Root.Value > 0);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertNegativeIntValues_IsSuccessful()
        {
            //Arrange

            //Act
            for (int i = 0; i < 10; i++)
            {
                negativeIntTree.Insert(negativeIntRange[i]);
            }

            //Assert
            Assert.IsNotNull(negativeIntTree.Root);
            Assert.IsTrue(negativeIntTree.Root.Value < 0);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertUintValues_IsSuccessful()
        {
            //Arrange

            //Act
            for (int i = 0; i < 10; i++)
            {
                uintTree.Insert(uintRange[i]);
            }

            //Assert
            Assert.IsNotNull(uintTree.Root);
            Assert.IsTrue(uintTree.Root.Value > 0);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertCharValues_IsSuccessful()
        {
            //Arrange

            //Act
            foreach (char item in charRange)
            {
                charTree.Insert(item);
            }

            //Assert
            Assert.IsNotNull(charTree.Root);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertStringValues_IsSuccessful()
        {
            //Arrange

            //Act
            foreach (string item in stringRange)
            {
                stringTree.Insert(item);
            }

            //Assert
            Assert.IsNotNull(stringTree.Root);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateIntValues_ThrowsException()
        {
            //Arrange

            //Act
            intTree.Insert(intRange.FirstOrDefault<int>());

            //Assert
            Assert.ThrowsException<ArgumentException>(() => intTree.Insert(intRange.FirstOrDefault<int>()));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateUintValues_ThrowsException()
        {
            //Arrange

            //Act
            uintTree.Insert(uintRange.FirstOrDefault<uint>());

            //Assert
            Assert.ThrowsException<ArgumentException>(() => uintTree.Insert(uintRange.FirstOrDefault<uint>()));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateCharValues_ThrowsException()
        {
            //Arrange

            //Act
            charTree.Insert(charRange.FirstOrDefault<char>());

            //Assert
            Assert.ThrowsException<ArgumentException>(() => charTree.Insert(charRange.FirstOrDefault<char>()));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateStringValues_ThrowsException()
        {
            //Arrange

            //Act
            stringTree.Insert(stringRange.FirstOrDefault<string>());

            //Assert
            Assert.ThrowsException<ArgumentException>(() => stringTree.Insert(stringRange.FirstOrDefault<string>()));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_EmptyTree_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => intTree.Search(intRange.FirstOrDefault<int>()));
            Assert.ThrowsException<InvalidOperationException>(() => stringTree.Search(stringRange.FirstOrDefault<string>()));
            Assert.ThrowsException<InvalidOperationException>(() => negativeIntTree.Search(negativeIntRange.FirstOrDefault<int>()));
            Assert.ThrowsException<InvalidOperationException>(() => charTree.Search(charRange.FirstOrDefault<char>()));
            Assert.ThrowsException<InvalidOperationException>(() => uintTree.Search(uintRange.FirstOrDefault<uint>()));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_HighValueAvailable_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < intRange.Count; i++)
            {
                intTree.Insert(intRange[i]);
            }

            for (int i = 0; i < negativeIntRange.Count; i++)
            {
                negativeIntTree.Insert(negativeIntRange[i]);
            }

            //Act             
            Node<int> intResult = intTree.Search(intRange.Max());
            Node<int> negativeIntResult = negativeIntTree.Search(negativeIntRange.Max());

            //Assert
            Assert.IsNotNull(intResult);
            Assert.IsTrue(intResult.Value > 0);
            Assert.IsNotNull(negativeIntResult);
            Assert.IsTrue(negativeIntResult.Value < 0);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_HigherValueNotAvailable_ReturnsNull()
        {
            //Arrange
            for (int i = 0; i < intRange.Count; i++)
            {
                intTree.Insert(intRange[i]);
            }

            for (int i = 0; i < negativeIntRange.Count; i++)
            {
                negativeIntTree.Insert(negativeIntRange[i]);
            }

            //Act             

            //Assert
            Assert.IsNull(intTree.Search(int.MaxValue));
            Assert.IsNull(negativeIntTree.Search(int.MinValue));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_HigherValueNotAvailable_SplaysTree()
        {
            //Arrange
            for (int i = 0; i < intRange.Count; i++)
            {
                intTree.Insert(intRange[i]);
            }

            for (int i = 0; i < negativeIntRange.Count; i++)
            {
                negativeIntTree.Insert(negativeIntRange[i]);
            }

            //Act             
            intTree.Search(int.MaxValue);
            negativeIntTree.Search(int.MaxValue);
            int expectedIntResult = intRange.Max();
            int expectedNegativeIntResult = negativeIntRange.Max();
            int actualIntResult = intTree.Root.Value;
            int actualNegativeIntResult = negativeIntTree.Root.Value;

            //Assert
            Assert.IsNotNull(actualIntResult);
            Assert.IsNotNull(actualNegativeIntResult);
            Assert.AreEqual(expectedIntResult, actualIntResult);
            Assert.AreEqual(expectedNegativeIntResult, actualNegativeIntResult);            
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_LesserValueAvailable_IsSuccesful()
        {
            //Arrange
            for (int i = 0; i < intRange.Count; i++)
            {
                intTree.Insert(intRange[i]);
            }

            for (int i = 0; i < negativeIntRange.Count; i++)
            {
                negativeIntTree.Insert(negativeIntRange[i]);
            }

            //Act             
            Node<int> intResult = intTree.Search(intRange.Min());
            Node<int> negativeIntResult = negativeIntTree.Search(negativeIntRange.Min());

            //Assert
            Assert.IsNotNull(intResult);
            Assert.IsTrue(intResult.Value > 0);
            Assert.AreEqual(intRange.Min<int>(), intResult.Value);
            Assert.IsNotNull(negativeIntResult);
            Assert.IsTrue(negativeIntResult.Value < 0);
            Assert.AreEqual(negativeIntRange.Min<int>(), negativeIntResult.Value);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_LesserValueNotAvailable_IsNull()
        {
            for (int i = 0; i < intRange.Count; i++)
            {
                intTree.Insert(intRange[i]);
            }

            for (int i = 0; i < negativeIntRange.Count; i++)
            {
                negativeIntTree.Insert(negativeIntRange[i]);
            }

            //Act

            //Assert
            Assert.IsNull(intTree.Search(int.MinValue));
            Assert.IsNull(negativeIntTree.Search(int.MinValue));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_LesserValueNotAvailable_SplaysTree()
        {
            //Arrange
            for (int i = 0; i < intRange.Count; i++)
            {
                intTree.Insert(intRange[i]);
            }

            for (int i = 0; i < negativeIntRange.Count; i++)
            {
                negativeIntTree.Insert(negativeIntRange[i]);
            }

            //Act             
            intTree.Search(int.MinValue);
            negativeIntTree.Search(int.MinValue);
            int expectedIntResult = intRange.Min();
            int expectedNegativeIntResult = negativeIntRange.Min();
            int actualIntResult = intTree.Root.Value;
            int actualNegativeIntResult = negativeIntTree.Root.Value;

            //Assert
            Assert.IsNotNull(actualIntResult);
            Assert.IsNotNull(actualNegativeIntResult);
            Assert.AreEqual(expectedIntResult, actualIntResult);
            Assert.AreEqual(expectedNegativeIntResult, actualNegativeIntResult);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void InOrderTraversal_IntTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < intRange.Count; i++)
            {
                intTree.Insert(intRange[i]);
            }

            //Act 
            List<int> intList = new List<int>();
            intTree.InOrderTraversal(intTree.Root, (item) => { intList.Add(item); });
            intRange.Sort();
            bool result = intList.SequenceEqual<int>(intRange);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void InOrderTraversal_UintTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < uintRange.Count; i++)
            {
                uintTree.Insert(uintRange[i]);
            }

            //Act
            List<uint> uintList = new List<uint>();
            uintTree.InOrderTraversal(uintTree.Root, (item) => { uintList.Add(item); });
            uintRange.Sort();
            bool result = uintList.SequenceEqual<uint>(uintRange);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void InOrderTraversal_CharTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < charRange.Count; i++)
            {
                charTree.Insert(charRange[i]);
            }

            //Act
            List<char> charList = new List<char>();
            charTree.InOrderTraversal(charTree.Root, (item) => { charList.Add(item); });
            charRange.Sort();
            bool result = charList.SequenceEqual<char>(charRange);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void InOrderTraversal_StringTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < stringRange.Count; i++)
            {
                stringTree.Insert(stringRange[i]);
            }

            //Act
            List<string> stringList = new List<string>();
            stringTree.InOrderTraversal(stringTree.Root, (item) => { stringList.Add(item); });
            stringRange.Sort();
            bool result = stringList.SequenceEqual<string>(stringRange);

            //Assert
            Assert.IsTrue(result);
        }

        //[TestMethod, TestCategory("Core functionality")]
        //public void InOrderTraversal_UserDefinedObjectTreeTraversal_IsSuccessful()
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}

        [TestMethod, TestCategory("Core functionality")]
        public void PreOrderTraversal_IntTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < intRange.Count; i++)
            {
                intTree.Insert(intRange[i]);
            }
            var tempPreOrderInts = splayTreeSection["PreOrderInts"].Split(',').ToList<string>();
            List<int> expectedPreOrderInts = new List<int>();
            expectedPreOrderInts.AddRange(tempPreOrderInts.Select(item => Convert.ToInt32(item)));

            //Act  
            List<int> actualPreOrderInt = new List<int>();
            intTree.PreOrderTraversal(intTree.Root, (item) => { actualPreOrderInt.Add(item); });
            bool result = actualPreOrderInt.SequenceEqual<int>(expectedPreOrderInts);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PreOrderTraversal_UintTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < uintRange.Count; i++)
            {
                uintTree.Insert(uintRange[i]);
            }

            var tempPreOrderUInts = splayTreeSection["PreOrderUInts"].Split(',').ToList<string>();
            List<uint> expectedPreOrderUInts = new List<uint>();
            expectedPreOrderUInts.AddRange(tempPreOrderUInts.Select(item => Convert.ToUInt32(item)));

            //Act  
            List<uint> actualPreOrderUInts = new List<uint>();
            uintTree.PreOrderTraversal(uintTree.Root, (item) => { actualPreOrderUInts.Add(item); });
            bool result = actualPreOrderUInts.SequenceEqual<uint>(expectedPreOrderUInts);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PreOrderTraversal_CharTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < charRange.Count; i++)
            {
                charTree.Insert(charRange[i]);
            }

            var tempPreOrderChars = splayTreeSection["PreOrderChars"].Split(',').ToList<string>();
            List<char> expectedPreOrderChars = new List<char>();
            expectedPreOrderChars.AddRange(tempPreOrderChars.Select(item => Convert.ToChar(item)));

            //Act  
            List<char> actualPreOrderChars = new List<char>();
            charTree.PreOrderTraversal(charTree.Root, (item) => { actualPreOrderChars.Add(item); });
            bool result = actualPreOrderChars.SequenceEqual<char>(expectedPreOrderChars);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PreOrderTraversal_StringTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < stringRange.Count; i++)
            {
                stringTree.Insert(stringRange[i]);
            }

            var tempPreOrderString = splayTreeSection["PreOrderString"].Split(',').ToList<string>();
            List<string> expectedPreOrderString = new List<string>();
            expectedPreOrderString.AddRange(tempPreOrderString.Select(item => item));

            //Act  
            List<string> actualPreOrderString = new List<string>();
            stringTree.PreOrderTraversal(stringTree.Root, (item) => { actualPreOrderString.Add(item); });
            bool result = actualPreOrderString.SequenceEqual<string>(expectedPreOrderString);

            //Assert
            Assert.IsTrue(result);
        }

        //[TestMethod, TestCategory("Core functionality")]
        //public void PreOrderTraversal_UserDefinedObjectTreeTraversal_IsSuccessful()
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}

        [TestMethod, TestCategory("Core functionality")]
        public void PostOrderTraversal_IntTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < intRange.Count; i++)
            {
                intTree.Insert(intRange[i]);
            }

            var tempPostOrderInts = splayTreeSection["PostOrderInts"].Split(',').ToList<string>();
            List<int> expectedPostOrderInts = new List<int>();
            expectedPostOrderInts.AddRange(tempPostOrderInts.Select(item => Convert.ToInt32(item)));

            //Act  
            List<int> actualPostOrderInt = new List<int>();
            intTree.PostOrderTraversal(intTree.Root, (item) => { actualPostOrderInt.Add(item); });
            bool result = actualPostOrderInt.SequenceEqual<int>(expectedPostOrderInts);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod, TestCategory("Core functionality")]
        public void PostOrderTraversal_UintTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < uintRange.Count; i++)
            {
                uintTree.Insert(uintRange[i]);
            }

            var tempPostOrderUInts = splayTreeSection["PostOrderUInts"].Split(',').ToList<string>();
            List<uint> expectedPostOrderUInts = new List<uint>();
            expectedPostOrderUInts.AddRange(tempPostOrderUInts.Select(item => Convert.ToUInt32(item)));

            //Act  
            List<uint> actualPostOrderUInts = new List<uint>();
            uintTree.PostOrderTraversal(uintTree.Root, (item) => { actualPostOrderUInts.Add(item); });
            bool result = actualPostOrderUInts.SequenceEqual<uint>(expectedPostOrderUInts);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PostOrderTraversal_CharTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < charRange.Count; i++)
            {
                charTree.Insert(charRange[i]);
            }

            var tempPostOrderChars = splayTreeSection["PostOrderChars"].Split(',').ToList<string>();
            List<char> expectedPostOrderChars = new List<char>();
            expectedPostOrderChars.AddRange(tempPostOrderChars.Select(item => Convert.ToChar(item)));

            //Act  
            List<char> actualPostOrderChars = new List<char>();
            charTree.PostOrderTraversal(charTree.Root, (item) => { actualPostOrderChars.Add(item); });
            bool result = actualPostOrderChars.SequenceEqual<char>(expectedPostOrderChars);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PostOrderTraversal_StringTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < stringRange.Count; i++)
            {
                stringTree.Insert(stringRange[i]);
            }

            var tempPostOrderString = splayTreeSection["PostOrderString"].Split(',').ToList<string>();
            List<string> expectedPostOrderString = new List<string>();
            expectedPostOrderString.AddRange(tempPostOrderString.Select(item => item));

            //Act  
            List<string> actualPostOrderString = new List<string>();
            stringTree.PostOrderTraversal(stringTree.Root, (item) => { actualPostOrderString.Add(item); });
            bool result = actualPostOrderString.SequenceEqual<string>(expectedPostOrderString);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void BreadthFirstTraversal_IntTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < intRange.Count; i++)
            {
                intTree.Insert(intRange[i]);
            }

            var tempBFSInts = splayTreeSection["BreadthFirstInts"].Split(',').ToList<string>();
            List<int> expectedBFSInts = new List<int>();
            expectedBFSInts.AddRange(tempBFSInts.Select(item => Convert.ToInt32(item)));

            //Act  
            List<int> actualBFSInt = new List<int>();
            intTree.BreadthFirstTraversal(intTree.Root, (item) => { actualBFSInt.Add(item); });
            bool result = actualBFSInt.SequenceEqual<int>(expectedBFSInts);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void BreadthFirstTraversal_UIntTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < uintRange.Count; i++)
            {
                uintTree.Insert(uintRange[i]);
            }

            var tempBFSUInts = splayTreeSection["BreadthFirstUInts"].Split(',').ToList<string>();
            List<uint> expectedBFSUInts = new List<uint>();
            expectedBFSUInts.AddRange(tempBFSUInts.Select(item => Convert.ToUInt32(item)));

            //Act  
            List<uint> actualBFSUInts = new List<uint>();
            uintTree.BreadthFirstTraversal(uintTree.Root, (item) => { actualBFSUInts.Add(item); });
            bool result = actualBFSUInts.SequenceEqual<uint>(expectedBFSUInts);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void BreadthFirstTraversal_CharTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < charRange.Count; i++)
            {
                charTree.Insert(charRange[i]);
            }

            var tempBFSChars = splayTreeSection["BreadthFirstChars"].Split(',').ToList<string>();
            List<char> expectedBFSChars = new List<char>();
            expectedBFSChars.AddRange(tempBFSChars.Select(item => Convert.ToChar(item)));

            //Act  
            List<char> actualBFSChars = new List<char>();
            charTree.BreadthFirstTraversal(charTree.Root, (item) => { actualBFSChars.Add(item); });
            bool result = actualBFSChars.SequenceEqual<char>(expectedBFSChars);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void BreadthFirstTraversal_StringTreeTraversal_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < stringRange.Count; i++)
            {
                stringTree.Insert(stringRange[i]);
            }

            var tempBFSString = splayTreeSection["BreadthFirstString"].Split(',').ToList<string>();
            List<string> expectedBFSString = new List<string>();
            expectedBFSString.AddRange(tempBFSString.Select(item => item));

            //Act  
            List<string> actualBFSString = new List<string>();
            stringTree.BreadthFirstTraversal(stringTree.Root, (item) => { actualBFSString.Add(item); });
            bool result = actualBFSString.SequenceEqual<string>(expectedBFSString);

            //Assert
            Assert.IsTrue(result);
        }

        //[TestMethod, TestCategory("Core functionality")]
        //public void BreadthFirstTraversal_UserDefinedObjectTreeTraversal_IsSuccessful()
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}

       
        //[TestMethod, TestCategory("Core functionality")]
        //public void PostOrderTraversal_UserDefinedObjectTreeTraversal_IsSuccessful()
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_RootIsNull_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => stringTree.Delete(null));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_NullTree_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => intTree.Delete(intRange.FirstOrDefault<int>()));
            Assert.ThrowsException<InvalidOperationException>(() => uintTree.Delete(uintRange.FirstOrDefault<uint>()));
            Assert.ThrowsException<InvalidOperationException>(() => stringTree.Delete(stringRange.FirstOrDefault<string>()));
            Assert.ThrowsException<InvalidOperationException>(() => negativeIntTree.Delete(negativeIntRange.FirstOrDefault<int>()));
            Assert.ThrowsException<InvalidOperationException>(() => charTree.Delete(charRange.FirstOrDefault<char>()));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_NodeToBeDeletedDoesNotHaveChild_IsSuccessful()
        {
            //Arrange
            intTree.Insert(50);
            intTree.Insert(30);
            intTree.Insert(20);
            intTree.Insert(35);
            intTree.Insert(60);
            intTree.Insert(55);
            intTree.Insert(70);
            intTree.Insert(65);
            intTree.Insert(80);

            intTree.Delete(80);

            int[] actualArray = new int[8] { 20, 30, 35, 50, 55, 60, 65, 70 };
            List<int> resultList = new List<int>();

            //Act
            intTree.InOrderTraversal(intTree.Root, (item) => { resultList.Add(item); });
            bool result = actualArray.SequenceEqual<int>(resultList);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_RightSkewedTreeNodeToBeDeletedHasARightChild_IsSuccessful()
        {
            //Arrange
            intTree.Insert(50);
            intTree.Insert(60);
            intTree.Insert(70);
            intTree.Insert(80);
            intTree.Insert(90);

            intTree.Delete(70);

            int[] actualArray = new int[4] { 50, 60, 80, 90 };
            List<int> resultList = new List<int>();

            //Act
            intTree.InOrderTraversal(intTree.Root, (item) => { resultList.Add(item); });
            bool result = actualArray.SequenceEqual<int>(resultList);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_LeftSkewedTreeNodeToBeDeletedHasARightChild_IsSuccessful()
        {
            //Arrange
            intTree.Insert(50);
            intTree.Insert(40);
            intTree.Insert(30);
            intTree.Insert(20);
            intTree.Insert(10);

            intTree.Delete(30);

            int[] actualArray = new int[4] { 10, 20, 40, 50 };
            List<int> resultList = new List<int>();

            //Act
            intTree.InOrderTraversal(intTree.Root, (item) => { resultList.Add(item); });
            bool result = actualArray.SequenceEqual<int>(resultList);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_NodeToBeDeletedHasARightChild_IsSuccessful()
        {
            //Arrange
            intTree.Insert(50);
            intTree.Insert(30);
            intTree.Insert(20);
            intTree.Insert(35);
            intTree.Insert(60);
            intTree.Insert(70);
            intTree.Insert(65);
            intTree.Insert(80);
            intTree.Insert(75);
            intTree.Insert(85);

            intTree.Delete(60);

            //Act
            int[] actualArray = new int[9] { 20, 30, 35, 50, 65, 70, 75, 80, 85 };
            List<int> resultList = new List<int>();

            intTree.InOrderTraversal(intTree.Root, (item) => { resultList.Add(item); });
            bool result = actualArray.SequenceEqual<int>(resultList);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_NodeToBeDeletedHasALeftChild_IsSuccessful()
        {
            //Arrange
            intTree.Insert(50);
            intTree.Insert(40);
            intTree.Insert(60);
            intTree.Insert(70);
            intTree.Insert(55);
            intTree.Insert(45);
            intTree.Insert(42);
            intTree.Insert(48);

            intTree.Delete(55);

            //Act
            int[] actualArray = new int[7] { 40, 42, 45, 48, 50, 60, 70 };
            List<int> resultList = new List<int>();

            intTree.InOrderTraversal(intTree.Root, (item) => { resultList.Add(item); });
            bool result = actualArray.SequenceEqual<int>(resultList);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_NodeToBeDeletedHasTwoChildren_IsSuccessful()
        {
            //Arrange
            intTree.Insert(50);
            intTree.Insert(40);
            intTree.Insert(30);
            intTree.Insert(20);
            intTree.Insert(60);
            intTree.Insert(55);
            intTree.Insert(45);
            intTree.Insert(70);
            intTree.Insert(80);

            intTree.Delete(60);

            //Act
            int[] actualArray = new int[8] { 20, 30, 40, 45, 50, 55, 70, 80 };
            List<int> resultList = new List<int>();

            intTree.InOrderTraversal(intTree.Root, (item) => { resultList.Add(item); });
            bool result = actualArray.SequenceEqual<int>(resultList);

            //Assert
            Assert.IsTrue(result);
        }

        #endregion
    }
}
