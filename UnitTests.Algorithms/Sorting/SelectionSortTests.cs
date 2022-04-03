using Algorithms.Sorting;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTests.Algorithms.Sorting
{
    [TestClass]
    public class SelectionSortTests
    {
        #region Local fields, test initialization and test clean up setup

        IConfiguration sortSection;

        private int[] intRange, negativeIntRange, mixedIntRange;
        private char[] charRange;
        private string[] stringRange;

        private SelectionSort<int> intSort;
        private SelectionSort<char> charSort;
        private SelectionSort<string> stringSort;

        public SelectionSortTests()
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("TestData.json").Build();
            sortSection = configuration.GetSection("Sort");

            intRange = new int[10];
            negativeIntRange = new int[10];
            mixedIntRange = new int[10];
            charRange = new char[10];
            stringRange = new string[6];
        }

        [TestInitialize]
        public void InitializeLocalFields()
        {
            var tempIntRange = sortSection["RandomInts"].Split(',').ToList<string>();
            intRange = tempIntRange.Select(item => Convert.ToInt32(item)).ToArray<int>();

            var tempNegativeIntRange = sortSection["RandomNegativeInts"].Split(',').ToList<string>();
            negativeIntRange = tempNegativeIntRange.Select(item => Convert.ToInt32(item)).ToArray<int>();

            var tempMixedIntRange = sortSection["RandomMixedInts"].Split(',').ToList<string>();
            mixedIntRange = tempMixedIntRange.Select(item => Convert.ToInt32(item)).ToArray<int>();

            var tempCharRange = sortSection["RandomCharacters"].Split(',').ToList<string>();
            charRange = tempCharRange.Select(item => Convert.ToChar(item)).ToArray<char>();

            var tempStringRange = sortSection["Names"].Split(',').ToList<string>();
            stringRange = tempStringRange.Select(item => Convert.ToString(item)).ToArray<string>();

            intSort = new SelectionSort<int>();
            charSort = new SelectionSort<char>();
            stringSort = new SelectionSort<string>();
        }

        [TestCleanup]
        public void CleanUpLocalFields()
        {

            intRange = null;
            mixedIntRange = null;
            negativeIntRange = null;
            charRange = null;
            stringRange = null;

            intSort = null;
            charSort = null;
            stringSort = null;
        }

        #endregion

        #region Unit Tests

        [TestMethod, TestCategory("Core Functionality")]
        public void InsertionSort_PositiveIntArray_SortsSuccessfully()
        {
            //Arrange
            var tempSortedInts = sortSection["SortedInts"].Split(',').ToArray<string>();
            int[] expectedSortedIntArray = Array.ConvertAll(tempSortedInts, new Converter<string, int>(item => Convert.ToInt32(item)));

            //Act
            int[] resultSortedIntArray = intSort.Sort(intRange);

            //Assert
            Assert.IsNotNull(resultSortedIntArray);
            Assert.IsTrue(resultSortedIntArray.SequenceEqual(expectedSortedIntArray));
            Assert.AreEqual(expectedSortedIntArray.Length, resultSortedIntArray.Length);
        }

        [TestMethod, TestCategory("Core Functionality")]
        public void InsertionSort_NegativeIntArray_SortsSuccessfully()
        {
            //Arrange
            var tempSortedNegativeInts = sortSection["SortNegativeInts"].Split(',').ToArray<string>();
            int[] expectedSortedNegativeIntArray = Array.ConvertAll(tempSortedNegativeInts, new Converter<string, int>(item => Convert.ToInt32(item)));

            //Act
            int[] resultSortedNegativeIntArray = intSort.Sort(negativeIntRange);

            //Assert
            Assert.IsNotNull(resultSortedNegativeIntArray);
            Assert.IsTrue(resultSortedNegativeIntArray.SequenceEqual(expectedSortedNegativeIntArray));
            Assert.AreEqual(expectedSortedNegativeIntArray.Length, resultSortedNegativeIntArray.Length);
        }

        [TestMethod, TestCategory("Core Functionality")]
        public void InsertionSort_RandomMixedIntArray_SortsSuccessfully()
        {
            //Arrange
            var tempSortedMixedInts = sortSection["SortedMixedInts"].Split(',').ToArray<string>();
            int[] expectedSortedMixedIntArray = Array.ConvertAll(tempSortedMixedInts, new Converter<string, int>(item => Convert.ToInt32(item)));

            //Act
            int[] resultSortedMixedIntArray = intSort.Sort(mixedIntRange);

            //Assert
            Assert.IsNotNull(resultSortedMixedIntArray);
            Assert.IsTrue(resultSortedMixedIntArray.SequenceEqual(expectedSortedMixedIntArray));
            Assert.AreEqual(expectedSortedMixedIntArray.Length, resultSortedMixedIntArray.Length);
        }

        [TestMethod, TestCategory("Core Functionality")]
        public void InsertionSort_CharArray_SortsSuccessfully()
        {
            //Arrange
            var tempSortedChars = sortSection["SortedChars"].Split(',').ToArray<string>();
            char[] expectedSortedCharArray = Array.ConvertAll(tempSortedChars, new Converter<string, char>(item => Convert.ToChar(item)));

            //Act
            char[] resultSortedCharArray = charSort.Sort(charRange);

            //Assert
            Assert.IsNotNull(resultSortedCharArray);
            Assert.IsTrue(resultSortedCharArray.SequenceEqual(expectedSortedCharArray));
            Assert.AreEqual(resultSortedCharArray.Length, expectedSortedCharArray.Length);
        }

        [TestMethod, TestCategory("Core Functionality")]
        public void InsertionSprt_StringArray_SortsSuccessfully()
        {
            //Arrange
            string[] expectedSortedStringArray = sortSection["SortedString"].Split(',');

            //Act
            string[] resultSorteStringArray = stringSort.Sort(stringRange);

            //Assert
            Assert.IsNotNull(resultSorteStringArray);
            Assert.IsTrue(resultSorteStringArray.SequenceEqual(expectedSortedStringArray));
            Assert.AreEqual(resultSorteStringArray.Length, expectedSortedStringArray.Length);
        }

        #endregion
    }
}
