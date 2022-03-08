using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Arrays.SimpleArray
{
    /// <summary>
    /// The SimpleArray class offers the functionality of a simple un-ordered array.
    /// </summary>
    /// <typeparam name="T">The type of which the array is desired.</typeparam>
    public class SimpleArray<T>
    {
        T[] array;
        uint noOfElements;

        /// <summary>
        /// Parameterized constructor that allows instantiate an array of a given size.
        /// </summary>
        /// <param name="arraySize">Array size as a valid positive integral number.</param>
        public SimpleArray(uint arraySize)
        {
            array = new T[arraySize];
            noOfElements = 0;
        }

        public bool Add(T item)
        {
            // Addition can only happen in an instantiated array
            // and there needs to be space in the array for an item to be inserted.
            if (array.Length > 0 && noOfElements <= array.Length)
            {
                array[noOfElements] = item;
                noOfElements++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(T item)
        {
            // Removal of an item can take place on an instantiated array.            
            if (array.Length > 0)
            {
                int itemIndex = Find(item);

                if (itemIndex > 0)
                {
                    for (int index = itemIndex; index < noOfElements; index++)
                    {
                        if (index == noOfElements - 1)
                        {
                            break;
                        }
                        array[index] = array[index + 1];
                    }
                    // Reduce the count by 1
                    // Note that the value in the last cell is still there but not accessible 
                    // via find, as the noOfElements has been reduced by 1.
                    noOfElements--;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int Find(T item)
        {
            // Search needs to be carried out on an instantiated array
            if (array.Length > 0)
            {
                // Simple search
                for (int index = 0; index < noOfElements; index++)
                {
                    if (array[index].Equals(item))
                    {
                        return index;
                    }
                }
                return -1;
            }
            else
            {
                return -1;
            }
        }
    }
}
