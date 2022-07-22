using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class MergeSort<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Time complexity: O(nlogn)
        /// Space complexity: O(n) (non-in place sort, stable sort i.e. maintains the order of elements of equal value)
        /// </remarks>
        /// <param name="inputArray"></param>
        public void Sort(T[] inputArray)
        {
            if (inputArray.Length == 1)
            {
                return;
            }

            int midIndex = inputArray.Length / 2 + inputArray.Length % 2;
            T[] firstHalfArray = new T[midIndex];
            T[] secondHalfArray = new T[inputArray.Length - midIndex];
            Split(inputArray, firstHalfArray, secondHalfArray);

            Sort(firstHalfArray);
            Sort(secondHalfArray);

            Merge(inputArray, firstHalfArray, secondHalfArray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="firstHalfArray"></param>
        /// <param name="secondHalfArray"></param>
        private void Split(T[] inputArray, T[] firstHalfArray, T[] secondHalfArray)
        {
            int index = 0;
            int secondHalfStartIndex = firstHalfArray.Length;
            for (int elements = 0; elements < inputArray.Length; elements++)
            {
                if (index < secondHalfStartIndex)
                {
                    firstHalfArray[index] = inputArray[index];
                }
                else
                {
                    secondHalfArray[index - secondHalfStartIndex] = inputArray[index];
                }
                index++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="firstHalfArray"></param>
        /// <param name="secondHalfArray"></param>
        private void Merge(T[] inputArray, T[] firstHalfArray, T[] secondHalfArray)
        {
            int mergeIndex = 0;
            int firstHalfIndex = 0;
            int secondHalfIndex = 0;

            while (firstHalfIndex < firstHalfArray.Length && secondHalfIndex < secondHalfArray.Length)
            {
                if (Comparer.Default.Compare(firstHalfArray[firstHalfIndex], secondHalfArray[secondHalfIndex]) < 0)
                {
                    inputArray[mergeIndex] = firstHalfArray[firstHalfIndex];
                    firstHalfIndex++;
                }
                else if (secondHalfIndex < secondHalfArray.Length)
                {
                    inputArray[mergeIndex] = secondHalfArray[secondHalfIndex];
                    secondHalfIndex++;
                }
                mergeIndex++;                
            }

            if (firstHalfIndex < firstHalfArray.Length)
            {
                while (mergeIndex < inputArray.Length)
                {
                    inputArray[mergeIndex++] = firstHalfArray[firstHalfIndex++];
                }
            }
            if (secondHalfIndex < secondHalfArray.Length)
            {
                while (mergeIndex < inputArray.Length)
                {
                    inputArray[mergeIndex++] = secondHalfArray[secondHalfIndex++];
                }
            }
        }
    }
}
