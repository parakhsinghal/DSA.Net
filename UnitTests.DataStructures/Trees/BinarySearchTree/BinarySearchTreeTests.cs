using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Trees.BinarySearchTree;

namespace UnitTests.DataStructures.Trees.BinarySearchTree
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        #region Local fields, test initialization and test clean up setup

        BinarySearchTree<int> intTree;
        BinarySearchTree<uint> uintTree;
        BinarySearchTree<char> charTree;
        BinarySearchTree<string> stringTree;

        private readonly IConfiguration generalSection;

        private List<int> intRange;
        private List<int> negativeIntRange;
        private List<uint> uintRange;
        private List<char> charRange;
        private List<string> stringRange;
        private List<string> fruits;

        Random random;

        [TestInitialize]
        public void InitializeLocalFields()
        {           
            fruits = generalSection["Fruits"].Split(',').ToList<string>();
            stringRange = generalSection["Names"].Split(',').ToList<string>();

            var tempCharRange = generalSection["Characters"].Split(',').ToList<string>();
            charRange.AddRange(tempCharRange.Select(x => Convert.ToChar(x)));
            
            // Add 10 random numbers in array between 1 and 200
            random = new Random();
            for (int i = 0; i < 10; i++)
            {
                intRange.Add(random.Next(1, 200));
                uintRange.Add(Convert.ToUInt32(random.Next(1, 200)));
                negativeIntRange.Add(random.Next(-500, -1));
            }
        }

        [TestCleanup]
        public void CleanUpLocalFields()
        {
            intRange.Clear();
            fruits.Clear();
            intTree.Clear();
            uintTree.Clear();
            charTree.Clear();
            stringTree.Clear();
        }
        #endregion

        #region Unit tests

        [TestMethod,TestCategory("Core functionality")]
        public void Insert_InsertNullValue_ThrowsException()
        { 
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertValidRoot_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertIntValues_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertUintValues_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertCharValues_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_LoopInsertStringValues_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateIntValues_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateUintValues_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateCharValues_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Insert_InsertDuplicateStringValues_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_EmptyTree_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_HigherValueNotAvailable_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_LesserValueNotAvailable_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_HighValueAvailable_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Search_LesserValueAvailable_IsSuccesful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void InOrderTraversal_ProvideNullNodeAsStartingPoint_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void InOrderTraversal_ProvideNullRoot_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void InOrderTraversal_IntTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void InOrderTraversal_UintTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void InOrderTraversal_CharTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void InOrderTraversal_StringTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void InOrderTraversal_UserDefinedObjectTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PreOrderTraversal_ProvideNullNodeAsStartingPoint_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PreOrderTraversal_ProvideNullRoot_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PreOrderTraversal_IntTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PreOrderTraversal_UintTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PreOrderTraversal_CharTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PreOrderTraversal_StringTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PreOrderTraversal_UserDefinedObjectTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PostOrderTraversal_ProvideNullNodeAsStartingPoint_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PostOrderTraversal_ProvideNullRoot_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PostOrderTraversal_IntTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PostOrderTraversal_UintTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PostOrderTraversal_CharTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PostOrderTraversal_StringTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void PostOrderTraversal_UserDefinedObjectTreeTraversal_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_RootIsNull_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_ValueIsNotAvailableInTree_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_NodeToBeDeletedDoesNotHaveChild_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_NodeToBeDeletedHasARightChild_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_NodeToBeDeletedHasALeftChild_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Delete_NodeToBeDeletedHasTwoChildren_IsSuccessful()
        {
            //Arrange

            //Act

            //Assert
        }

        #endregion
    }
}
