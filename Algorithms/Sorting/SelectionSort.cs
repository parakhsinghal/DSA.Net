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
    /// <typeparam name="T"></typeparam>
    public class SelectionSort<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public T[] Sort(T[] inputArray)
        {
            int length = inputArray.Length;
            for (uint i = 0; i < length-1; i++)
            {
                uint minIndex = i;
                for (uint j = i + 1; j < length; j++)
                {
                    switch (Comparer<T>.Default.Compare(inputArray[minIndex], inputArray[j]))
                    {
                        case > 0:                           // If the element at minIndex > element at j then record index j in as minIndex.
                           minIndex = j;
                            break;

                        case < 0:                           // If the element at minIndex < element at j then do nothing and break out of the comparison.
                            break;

                        default:                            // If both elements are equal then do nothing and break out of the comparison.
                            break;
                    }                    
                }

                // Process to replace the value index minIndex 

                T temp = inputArray[minIndex];
                inputArray[minIndex] = inputArray[i];
                inputArray[i] = temp;
            }

            return inputArray;
        }
    }
}
