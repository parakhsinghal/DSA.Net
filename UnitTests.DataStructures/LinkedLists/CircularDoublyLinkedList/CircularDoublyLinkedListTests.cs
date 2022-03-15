using DataStructures.LinkedLists.CircularDoublyLinkedList;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.DataStructures.LinkedLists.CircularDoublyLinkedList
{
    [TestClass]
    public class CircularDoublyLinkedListTests
    {
        #region Local fields, test initialization and test clean up setup

        //Variables declaration
        private CircularDoublyLinkedList<int> intLinkedList;
        private CircularDoublyLinkedList<string> stringLinkedList;

        private readonly IConfiguration generalSection, linkedlistSection;

        List<int> range;
        List<string> names, fruits;

        //Constructor to pick up the data from the JSON file from the right sections.
        public CircularDoublyLinkedListTests()
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("TestData.json").Build();

            generalSection = configuration.GetSection("General");
            linkedlistSection = configuration.GetSection("LinkedList");

            intLinkedList = new CircularDoublyLinkedList<int>();
            stringLinkedList = new CircularDoublyLinkedList<string>();
        }

        //Test initialization with data
        [TestInitialize]
        public void InitializeLocalFields()
        {
            range = Enumerable.Range(1, 5).ToList<int>();
            fruits = generalSection["Fruits"].Split(',').ToList<string>();
            names = linkedlistSection["Names"].Split(',').ToList<string>();
        }

        //Test clean up after running of the tests
        [TestCleanup]
        public void CleanUpLocalFields()
        {
            range.Clear();
            fruits.Clear();
            names.Clear();
            intLinkedList.Clear();
            stringLinkedList.Clear();
        }

        #endregion

        #region Unit tests

        #region Core functionality

        [TestMethod, TestCategory("Core functionality")]
        public void Node_Instantiation_ShouldReturnValidNode()
        {
            //Arrange
            Node<int> intNode = new Node<int>() { Value = 1 };

            //Act
            bool result = intNode.IsValid;

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Constructor_Instantiation_ShouldReturnAnInstanceOfSingleEndedLinkedList()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsNotNull(intLinkedList);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Constructor_Instantiation_HeadIsNullCountZero()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsNull(intLinkedList.Head);
            Assert.IsTrue(intLinkedList.Count == 0);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Add_PassedANullItem_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => stringLinkedList.Add(null));
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Add_PassedAValidValue_AddsInLinkedList()
        {
            //Arrange           
            intLinkedList.Add(1);

            //Act
            bool headValueResult = intLinkedList.Head.Value > 0;
            bool getHeadResult = intLinkedList.GetHead() > 0;
            bool countResult = intLinkedList.Count > 0;

            //Assert
            Assert.IsTrue(headValueResult);
            Assert.IsTrue(getHeadResult);
            Assert.IsTrue(countResult);
        }


        [TestMethod, TestCategory("Core functionality")]
        public void Add_PassedASetOfValidValues_AddsInLinkedList()
        {
            //Arrange            
            for (int i = 0; i < range.Count; i++)
            {
                intLinkedList.Add(range[i]);
            }

            //Act
            bool countResult = intLinkedList.Count > 0;
            bool getHeadResult = intLinkedList.GetHead() > 0;

            //Assert
            Assert.IsTrue(countResult);
            Assert.IsTrue(getHeadResult);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void GetHead_Executed_ProvidesValueOfHead()
        {
            //Arrange
            intLinkedList.Add(range.FirstOrDefault<int>());
            stringLinkedList.Add(fruits.FirstOrDefault<string>());

            //Act
            bool intGetHeadResult = intLinkedList.GetHead() > 0;  
            bool stringGetHeadResult = stringLinkedList.GetHead() == "apple";

            //Assert
            Assert.IsTrue(intGetHeadResult);
            Assert.IsNotNull(stringGetHeadResult);
        }


        [TestMethod, TestCategory("Core functionality")]
        public void GetHead_ExecutedOnEmptyLinkedList_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => intLinkedList.GetHead());
        }

        [TestMethod, TestCategory("Core functionality")]
        public void RemoveHead_ExecutedOnEmptyLinkedList_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => intLinkedList.RemoveHead());
            Assert.ThrowsException<InvalidOperationException>(() => stringLinkedList.RemoveHead());
        }


        [TestMethod, TestCategory("Core functionality")]
        public void RemoveHead_ExecutedOnLinkedListWithOneNode_ProvidesResult()
        {
            //Arrange
            intLinkedList.Add(range[0]);
            stringLinkedList.Add(names[0]);

            //Act
            bool intCountResult = intLinkedList.Count == 1;
            bool stringCountResult = stringLinkedList.Count == 1;

            //Assert
            Assert.IsTrue(intCountResult);
            Assert.IsTrue(stringCountResult);
        }


        [TestMethod, TestCategory("Core functionality")]
        public void Count_OfAnEmptyLinkedList_IsZero()
        {
            //Arrange

            //Act
            bool intCountResult = intLinkedList.Count == 0;
            bool stringCountResult = stringLinkedList.Count == 0;

            //Assert
            Assert.IsTrue(intCountResult);
            Assert.IsTrue(stringCountResult);
        }

        [TestMethod, TestCategory("Core functionality")]
        public void Count_OfALinkedListWithOneElement_IsOne()
        {
            //Arrange
            intLinkedList.Add(range[0]);
            stringLinkedList.Add(fruits[0]);

            //Act
            bool intCountResult = intLinkedList.Count == 1;
            bool stringCountResult = stringLinkedList.Count == 1;

            //Assert
            Assert.IsTrue(intCountResult);
            Assert.IsTrue(stringCountResult);
        }

        #endregion

        #region Additional linked list functionality

        [TestMethod, TestCategory("Additional linked list functionality")]
        public void AddTail_AddAnInvalidNode_ThrowsException()
        {
            //Arrange            
            Node<string> nodeToBeAdded = new Node<string>();
            nodeToBeAdded.Value = null;

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(()=>stringLinkedList.AddTail(nodeToBeAdded));
        }


        [TestMethod, TestCategory("Additional linked list functionality")]
        public void AddTail_AddingATailToAnEmptyList_IsSuccessful()
        {
            //Arrange
            intLinkedList.AddTail(10);
            stringLinkedList.AddTail("plum");

            //Act
            bool intCountResult = intLinkedList.Count > 0;
            bool stringCountResult = stringLinkedList.Count > 0;
            bool intTailResult = intLinkedList.Tail.Value == 10;
            bool stringTailResult = stringLinkedList.Tail.Value == "plum";

            //Assert
            Assert.IsTrue(intCountResult);
            Assert.IsTrue(stringCountResult);
            Assert.IsTrue(intTailResult);
            Assert.IsTrue(stringTailResult);
        }

        [TestMethod, TestCategory("Additional linked list functionality")]
        public void AddTail_AddingATailToANonEmptyLinkedList_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intLinkedList.Add(range[i]);
                stringLinkedList.Add(fruits[i]);
            }

            intLinkedList.AddTail(10);
            stringLinkedList.AddTail("plum");

            //Act
            bool intCountResult = intLinkedList.Count > 0;
            bool stringCountResult = stringLinkedList.Count > 0;
            bool intTailResult = intLinkedList.Tail.Value == 10;
            bool stringTailResult = stringLinkedList.Tail.Value == "plum";

            //Assert
            Assert.IsTrue(intCountResult);
            Assert.IsTrue(stringCountResult);
            Assert.IsTrue(intTailResult);
            Assert.IsTrue(stringTailResult);
        }

        [TestMethod, TestCategory("Additional linked list functionality")]
        public void AddAfter_AddingItemInAnEmptyList_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(()=>intLinkedList.AddAfter(10,11));
            Assert.ThrowsException<InvalidOperationException>(() => stringLinkedList.AddAfter("plum", "grapefruit"));
        }

        [TestMethod, TestCategory("Additional linked list functionality")]
        public void AddAfter_AddAnItemAfterHead_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intLinkedList.Add(range[i]);
                stringLinkedList.Add(fruits[i]);
            }
            
            intLinkedList.AddAfter(intLinkedList.Head.Value, 10);
            stringLinkedList.AddAfter(stringLinkedList.Head.Value, "plum");

            //Act
            bool intContainsResult = intLinkedList.Contains(10);
            bool intHeadNextResult = intLinkedList.Head.Next.Value == 10;
            bool stringContainsResult = stringLinkedList.Contains("plum");
            bool stringHeadNextResult = stringLinkedList.Head.Next.Value == "plum";

            //Assert
            Assert.IsTrue(intContainsResult);
            Assert.IsTrue(intHeadNextResult);
            Assert.IsTrue(stringContainsResult);
            Assert.IsTrue(stringHeadNextResult);
        }

        [TestMethod, TestCategory("Additional linked list functionality")]
        public void AddAfter_AddAnItemAfterTail_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intLinkedList.Add(range[i]);
                stringLinkedList.Add(fruits[i]);
            }

            intLinkedList.AddAfter(intLinkedList.Tail.Value, 10);
            stringLinkedList.AddAfter(stringLinkedList.Tail.Value, "plum");

            //Act
            bool intContainsResult = intLinkedList.Contains(10);
            bool intTailResult = intLinkedList.Tail.Value == 10;
            bool stringContainsResult = stringLinkedList.Contains("plum");
            bool stringTailResult = stringLinkedList.Tail.Value == "plum";

            //Assert
            Assert.IsTrue(intContainsResult);
            Assert.IsTrue(intTailResult);
            Assert.IsTrue(stringContainsResult);
            Assert.IsTrue(stringTailResult);
        }

        [TestMethod, TestCategory("Additional linked list functionality")]
        public void AddAfter_AddAnItemInTheMiddle_IsSuccessFul()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intLinkedList.Add(range[i]);
                stringLinkedList.Add(fruits[i]);
            }

            intLinkedList.AddAfter(3, 10);
            stringLinkedList.AddAfter("pomegranate", "plum");

            //Act
            bool intContainsResult = intLinkedList.Contains(10);
            bool stringContainsResult = stringLinkedList.Contains("plum");                      

            //Assert
            Assert.IsTrue(intContainsResult);           
            Assert.IsTrue(stringContainsResult);
        }

        [TestMethod, TestCategory("Additional linked list functionality")]
        public void AddAfter_AddAnItemNextToNonExistingNeighbor_ThrowsException()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intLinkedList.Add(range[i]);
                stringLinkedList.Add(fruits[i]);
            }

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(()=>intLinkedList.AddAfter(100,10)); ;
            Assert.ThrowsException<InvalidOperationException>(()=>stringLinkedList.AddAfter("plum","dragonfruit"));
        }

        #endregion

        #region ICollection functionality

        [TestMethod, TestCategory("ICollection functionality")]
        public void IsReadOnlyProperty_Probed_ReturnsFalse()
        {
            //Arrange

            //Act
            bool isReadOnlyResult = intLinkedList.IsReadOnly == false;

            //Assert
            Assert.IsTrue(isReadOnlyResult);
        }

        [TestMethod, TestCategory("ICollection functionality")]
        public void Add_NullAdded_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => stringLinkedList.Add(null));
        }

        [TestMethod, TestCategory("ICollection functionality")]
        public void Add_ItemAdded_AffectsCount()
        {
            //Arrange
            intLinkedList.Add(range[0]);
            stringLinkedList.Add(fruits[0]);

            //Act
            bool intCountResult = intLinkedList.Count > 0;
            bool stringCountResult = stringLinkedList.Count > 0;

            //Assert
            Assert.IsTrue(intCountResult);
            Assert.IsTrue(stringCountResult);
        }

        [TestMethod, TestCategory("ICollection functionality")]
        public void Remove_RemovalOfItemFromEmptyList_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => intLinkedList.Remove(range[0]));
            Assert.ThrowsException<InvalidOperationException>(() => stringLinkedList.Remove(fruits[0]));
        }

        [TestMethod, TestCategory("ICollection functionality")]
        public void Remove_RemovalOfItemNotAvailable_ReturnsFalse()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intLinkedList.Add(range[i]);
                stringLinkedList.Add(fruits[i]);
            }

            //Act
            bool intRemoveResult = intLinkedList.Remove(10);
            bool stringRemoveResult = stringLinkedList.Remove("plum");

            //Assert
            Assert.IsFalse(intRemoveResult);
            Assert.IsFalse(stringRemoveResult);
        }

        [TestMethod, TestCategory("ICollection functionality")]
        public void Remove_RemovalOfTheOnlyItemFromList_IsSuccessful()
        {
            //Arrange
            intLinkedList.Add(range[0]);

            //Act
            bool intRemoveResult = intLinkedList.Remove(1);
            bool intCountResult = intLinkedList.Count == 0;
            bool intHeadResult = intLinkedList.Head == null;

            //Assert
            Assert.IsTrue(intRemoveResult);
            Assert.IsTrue(intCountResult);
            Assert.IsTrue(intHeadResult);
        }

        [TestMethod, TestCategory("ICollection functionality")]
        public void Remove_RemovalOfItemFromInBetween_IsSuccessful()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intLinkedList.Add(range[i]);
                stringLinkedList.Add(fruits[i]);
            }

            //Act
            bool intRemoveResult = intLinkedList.Remove(range.Where<int>(item => item == 3).First<int>());
            bool intCountResult = intLinkedList.Count == 4;
            bool stringRemoveResult = stringLinkedList.Remove(fruits.Where<string>(fruit => fruit == "grapes").First<string>());
            bool stringCountResult = stringLinkedList.Count == 4;

            //Assert
            Assert.IsTrue(intRemoveResult);
            Assert.IsTrue(intCountResult);
            Assert.IsTrue(stringRemoveResult);            
            Assert.IsTrue(stringCountResult);
        }

        [TestMethod, TestCategory("ICollection functionality")]
        public void Clear_Executed_ClearsLinkedLIst()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intLinkedList.Add(range[i]);
                stringLinkedList.Add(fruits[i]);
            }

            //Act
            intLinkedList.Clear();
            stringLinkedList.Clear();
            bool intCountResult = intLinkedList.Count == 0;
            bool stringCountResult = stringLinkedList.Count == 0;

            //Assert
            Assert.IsTrue(intCountResult);
            Assert.IsTrue(stringCountResult);
        }

        [TestMethod, TestCategory("ICollection functionality")]
        public void Contains_SearchEMptyList_ThrowsException()
        {
            //Arrange

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => intLinkedList.Contains(10));
            Assert.ThrowsException<InvalidOperationException>(()=>stringLinkedList.Contains("plum"));
        }

        [TestMethod, TestCategory("ICollection functionality")]
        public void Contains_SearchLinkedListWithASingleItem_ReturnsValidResult()
        {
            //Arrange
            intLinkedList.Add(range[0]);
            stringLinkedList.Add(names[0]);

            //Act
            bool intContainsResult = intLinkedList.Contains(range[0]);
            bool stringContainsResult = stringLinkedList.Contains(names[0]);

            //Assert
            Assert.IsTrue(intContainsResult);
            Assert.IsTrue(stringContainsResult);
        }

        [TestMethod, TestCategory("ICollection functionality")]
        public void Contains_SearchLinkedListWithMultipleItems_ReturnsValidResult()
        {
            //Arrange
            for (int i = 0; i < range.Count; i++)
            {
                intLinkedList.Add(range[i]);
                stringLinkedList.Add(fruits[i]);
            }

            //Act
            bool intContainsResult = intLinkedList.Contains(range[3]);
            bool stringContainsResult = stringLinkedList.Contains(fruits[3]);

            //Assert
            Assert.IsTrue(intContainsResult);
            Assert.IsTrue(stringContainsResult);
        }
        
        #endregion

        #endregion
    }
}
