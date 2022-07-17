using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class SelectionSort<T>
    {
        /// <summary>
        /// The selection sort algorithm sorts the array in an ascending order with the smallest element
        /// placed at the beginning of the array and the biggest at the end.
        /// </summary>
        /// <param name="inputArray">The array that needs to be sprted.</param>
        /// <returns>A sorted array with elements arranged in ascending order.</returns>
        /// <remarks>
        /// The selection sort algorithm is a sorting algorithm that sorts elements in an array in an ascending order.
        /// The algorithm does that by traversing through all the elements in the array in two nested passes and placing the 
        /// elements appropriately. The crux of the algorithm lies in the second pass in which the location of the smallest 
        /// element in the sub-array is noted and then at the end of the second loop the element is appropriately
        /// placed in the array. <br />
        /// Time complexity: O(n^2)
        /// Space complexity: O(1) (In-place sort, non-stable sort i.e. order of elements of equal value may change their position)
        /// </remarks>
        public T[] Sort(T[] inputArray)
        {
            int length = inputArray.Length;
            for (uint i = 0; i < length; i++)
            {
                for (uint j = i + 1; j < length; j++)
                {
                    switch (Comparer<T>.Default.Compare(inputArray[i], inputArray[j]))
                    {
                        case > 0:           // If the element at minIndex > element at j then record index j in as minIndex.
                            T temp = inputArray[i];
                            inputArray[i] = inputArray[j];
                            inputArray[j] = temp;
                            break;

                        case < 0:           // If the element at minIndex < element at j then do nothing and break out of the comparison.
                            break;

                        default:            // If both elements are equal then do nothing and break out of the comparison.
                            break;
                    }                    
                }                
            }

            return inputArray;
        }
    }
}
