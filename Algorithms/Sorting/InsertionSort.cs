﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class InsertionSort<T>
    {
        /// <summary>
        /// The insertion sort algorithm sorts the elements in an ascending order with the smallest element
        /// placed at the start of the array and the biggest at the end.<br />
        /// Time complexity: O(n^2)
        /// </summary>
        /// <param name="inputArray">The array that needs to be sorted.</param>
        /// <returns>A sorted array in which the elements are arranged in ascending order.</returns>
        /// <remarks>
        /// Insertion sort algorithm sorts an array in an ascending order starting from the start of the array.
        /// The algorithm does so by creating sub-arrays from the main array. While the main array is traversed
        /// from left to right the sub-arrays are traversed from right to left and in the process the 
        /// elements are swapped so that the sub-arrays will always have the smallest element to the left and
        /// the biggest element in the right. The algo uses two loops - an outer one used to traverse through
        /// the entire set of elements and an inner one used to traverse the sub-arrays.
        /// Time complexity: O(n^2)
        /// Space complexity: O(1) (In place sort, stable sort i.e. does not changes the order of the elements bearing the same value.)
        /// </remarks>
        public T[] Sort(T[] inputArray)
        {
            int length = inputArray.Length;

            //The first loop to interate over all the elements of the array from left to right.
            for (uint i = 0; i < length - 1; i++)
            {
                // The second loop to iterate over the sub-array from right to left.
                for (uint j = i + 1; j > 0; j--)
                {
                    switch (Comparer<T>.Default.Compare(inputArray[j - 1], inputArray[j]))
                    {
                        // If the left-hand element is greater then right-hand element, then move it one index value to right.
                        case > 0:
                            T temp = inputArray[j];
                            inputArray[j] = inputArray[j - 1];
                            inputArray[j - 1] = temp;
                            break;

                        // In case the left-hand element is less than the left-hand element then do nothing. 
                        case < 0:
                            break;

                        // In case both the right-hand and left-hand element are equal then do nothing. This also preserves the 
                        // order of elements and makes the insertion sort stable.
                        default:
                            break;
                    }
                }
            }

            return inputArray;

        }
    }
}
