using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    /// <summary>
    /// 
    /// </summary>
    public class MergeSort<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputArray"></param>
        public void Sort(int[] inputArray)
        {
            if (inputArray.Length == 1)
            {
                return;
            }

            int midIndex = inputArray.Length / 2 + inputArray.Length % 2;
            int[] listFirstHalf = new int[midIndex];
            int[] listSecondHalf = new int[inputArray.Length - midIndex];
            Split(inputArray, listFirstHalf, listSecondHalf);

            Sort(listFirstHalf);
            Sort(listSecondHalf);

            Merge(inputArray, listFirstHalf, listSecondHalf);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="listFirstHalf"></param>
        /// <param name="listSecondHalf"></param>
        private void Split(int[] inputArray, int[] listFirstHalf, int[] listSecondHalf)
        {
            int index = 0;
            int secondHalfStartIndex = listFirstHalf.Length;
            for (int elements = 0; elements < inputArray.Length; elements++)
            {
                if (index < secondHalfStartIndex)
                {
                    listFirstHalf[index] = inputArray[index];
                }
                else
                {
                    listSecondHalf[index - secondHalfStartIndex] = inputArray[index];
                }
                index++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="listFirstHalf"></param>
        /// <param name="listSecondHalf"></param>
        private void Merge(int[] inputArray, int[] listFirstHalf, int[] listSecondHalf)
        {
            int mergeIndex = 0;
            int firstHalfIndex = 0;
            int secondHalfIndex = 0;

            while (firstHalfIndex < listFirstHalf.Length && secondHalfIndex < listSecondHalf.Length)
            {
                if (listFirstHalf[firstHalfIndex] < listSecondHalf[secondHalfIndex])
                {
                    inputArray[mergeIndex] = listFirstHalf[firstHalfIndex];
                    firstHalfIndex++;
                }
                else if (secondHalfIndex < listSecondHalf.Length)
                {
                    inputArray[mergeIndex] = listSecondHalf[secondHalfIndex];
                    secondHalfIndex++;
                }
                mergeIndex++;
            }

            if (firstHalfIndex < listFirstHalf.Length)
            {
                while (mergeIndex < inputArray.Length)
                {
                    inputArray[mergeIndex++] = listFirstHalf[firstHalfIndex++];
                }
            }
            if (secondHalfIndex < listSecondHalf.Length)
            {
                while (mergeIndex < inputArray.Length)
                {
                    inputArray[mergeIndex++] = listSecondHalf[secondHalfIndex++];
                }
            }
        }
    }
}
