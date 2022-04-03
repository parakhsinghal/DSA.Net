using Algorithms.Sorting;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Algorithms.Sorting
{
    [TestClass]
    public class BubbleSortTests
    {
        #region Local fields, test initialization and test clean up setup

        IConfiguration bubbleSortSection;

        private int[] intRange, negativeIntRange, mixedIntRange;
        private char[] charRange;
        private string[] stringRange;

        private BubbleSort<int> intBubbleSort;
        private BubbleSort<char> charBubbleSort;
        private BubbleSort<string> stringBubbleSort;

        public BubbleSortTests()
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("TestData.json").Build();
            bubbleSortSection = configuration.GetSection("BubbleSort");

            intRange = new int[10];
            negativeIntRange = new int[10];
            mixedIntRange = new int[10];
            charRange = new char[10];
            stringRange = new string[6];
        }

        [TestInitialize]
        public void InitializeLocalFields()
        {
            var tempIntRange = bubbleSortSection["RandomInts"].Split(',').ToList<string>();
            intRange = tempIntRange.Select(item => Convert.ToInt32(item)).ToArray<int>();

            var tempNegativeIntRange = bubbleSortSection["RandomNegativeInts"].Split(',').ToList<string>();
            negativeIntRange = tempNegativeIntRange.Select(item => Convert.ToInt32(item)).ToArray<int>();

            var tempMixedIntRange = bubbleSortSection["RandomMixedInts"].Split(',').ToList<string>();
            mixedIntRange = tempMixedIntRange.Select(item => Convert.ToInt32(item)).ToArray<int>();

            var tempCharRange = bubbleSortSection["RandomCharacters"].Split(',').ToList<string>();
            charRange = tempCharRange.Select(item => Convert.ToChar(item)).ToArray<char>();

            var tempStringRange = bubbleSortSection["Names"].Split(',').ToList<string>();
            stringRange = tempStringRange.Select(item => Convert.ToString(item)).ToArray<string>();

            intBubbleSort = new BubbleSort<int>();
            charBubbleSort = new BubbleSort<char>();
            stringBubbleSort = new BubbleSort<string>();
        }

        [TestCleanup]
        public void CleanUpLocalFields()
        {

            intRange = null;
            mixedIntRange = null;
            negativeIntRange = null;
            charRange = null;
            stringRange = null;

            intBubbleSort = null;
            charBubbleSort = null;
            stringBubbleSort = null;
        }

        #endregion

        #region Unit Tests

        [TestMethod, TestCategory("Core Functionality")]
        public void BubbleSort_PositiveIntArray_SortsSuccessfully()
        {
            //Arrange
            var tempSortedInts = bubbleSortSection["SortedInts"].Split(',').ToArray<string>();
            int[] expectedSortedIntArray = Array.ConvertAll(tempSortedInts, new Converter<string, int>(item => Convert.ToInt32(item)));

            //Act
            int[] resultSortedIntArray = intBubbleSort.Sort(intRange);

            //Assert
            Assert.IsNotNull(resultSortedIntArray);
            Assert.IsTrue(resultSortedIntArray.SequenceEqual(expectedSortedIntArray));
            Assert.AreEqual(expectedSortedIntArray.Length, resultSortedIntArray.Length);
        }

        [TestMethod, TestCategory("Core Functionality")]
        public void BubbleSort_NegativeIntArray_SortsSuccessfully()
        {
            //Arrange
            var tempSortedNegativeInts = bubbleSortSection["SortNegativeInts"].Split(',').ToArray<string>();
            int[] expectedSortedNegativeIntArray = Array.ConvertAll(tempSortedNegativeInts, new Converter<string, int>(item => Convert.ToInt32(item)));

            //Act
            int[] resultSortedNegativeIntArray = intBubbleSort.Sort(negativeIntRange);

            //Assert
            Assert.IsNotNull(resultSortedNegativeIntArray);
            Assert.IsTrue(resultSortedNegativeIntArray.SequenceEqual(expectedSortedNegativeIntArray));
            Assert.AreEqual(expectedSortedNegativeIntArray.Length, resultSortedNegativeIntArray.Length);
        }

        [TestMethod, TestCategory("Core Functionality")]
        public void BubbleSort_RandomMixedIntArray_SortsSuccessfully()
        {
            //Arrange
            var tempSortedMixedInts = bubbleSortSection["SortedMixedInts"].Split(',').ToArray<string>();
            int[] expectedSortedMixedIntArray = Array.ConvertAll(tempSortedMixedInts, new Converter<string, int>(item => Convert.ToInt32(item)));

            //Act
            int[] resultSortedMixedIntArray = intBubbleSort.Sort(mixedIntRange);

            //Assert
            Assert.IsNotNull(resultSortedMixedIntArray);
            Assert.IsTrue(resultSortedMixedIntArray.SequenceEqual(expectedSortedMixedIntArray));
            Assert.AreEqual(expectedSortedMixedIntArray.Length, resultSortedMixedIntArray.Length);
        }

        [TestMethod, TestCategory("Core Functionality")]
        public void BubbleSort_CharArray_SortsSuccessfully()
        {
            //Arrange
            var tempSortedChars = bubbleSortSection["SortedChars"].Split(',').ToArray<string>();
            char[] expectedSortedCharArray = Array.ConvertAll(tempSortedChars, new Converter<string, char>(item => Convert.ToChar(item)));

            //Act
            char[] resultSortedCharArray = charBubbleSort.Sort(charRange);

            //Assert
            Assert.IsNotNull(resultSortedCharArray);
            Assert.IsTrue(resultSortedCharArray.SequenceEqual(expectedSortedCharArray));
            Assert.AreEqual(resultSortedCharArray.Length, expectedSortedCharArray.Length);
        }

        [TestMethod, TestCategory("Core Functionality")]
        public void BubbleSprt_StringArray_SortsSuccessfully()
        {
            //Arrange
            string[] expectedSortedStringArray = bubbleSortSection["SortedString"].Split(',');

            //Act
            string[] resultSorteStringArray = stringBubbleSort.Sort(stringRange);

            //Assert
            Assert.IsNotNull(resultSorteStringArray);
            Assert.IsTrue(resultSorteStringArray.SequenceEqual(expectedSortedStringArray));
            Assert.AreEqual(resultSorteStringArray.Length, expectedSortedStringArray.Length);
        }

        #endregion 
    }
}
