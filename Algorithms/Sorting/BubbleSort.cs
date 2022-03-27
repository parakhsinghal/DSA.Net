using System.Collections.Generic;

namespace Algorithms.Sorting
{
    /// <summary>
    /// Bubble sort is the most simplest way of sorting elements in an array. It compares an element 
    /// with the rest of the elements in the array, and accordingly arranges the elements in an ascending 
    /// order. The smallest element appears at the lowest index value in the sorted array. <br />
    /// Time complexitY: O(n^2)
    /// </summary>
    /// <typeparam name="T">The data type of the array.</typeparam>
    public class BubbleSort<T>
    {
        /// <summary>
        /// Sorts the array in a naive fashion by comparing each element with the rest of the elements in the 
        /// array in an ascending order. The smallest element in the array is placed at the left most position 
        /// and the biggest the right-most position.
        /// </summary>
        /// <param name="inputArray">The array that needs to be sorted.</param>
        /// <returns>A sorted array.</returns>
        public T[] Sort(T[] inputArray)
        {
            int length = inputArray.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    switch (Comparer<T>.Default.Compare(inputArray[j], inputArray[j + 1]))
                    {
                        case > 0:                           // If the j > j+1 then shift j+1 to one index left.
                            T temp = inputArray[j];
                            inputArray[j] = inputArray[j + 1];
                            inputArray[j + 1] = temp;
                            break;

                        case < 0:                           // If the j < j+1 then do nothing and break out of the comparison
                            break;

                        default:                            // If both j and j+1 are equal then do nothing and break out of the comparison
                            break;
                    }
                }
            }

            return inputArray;
        }
    }
}
