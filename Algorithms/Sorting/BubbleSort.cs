using System.Collections.Generic;

namespace Algorithms.Sorting
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BubbleSort<T> 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
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
