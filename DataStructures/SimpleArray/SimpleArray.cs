using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ErrMsgs = DataStructures.ErrorMessages.ErrorMessages_US_en;


namespace DataStructures.SimpleArray
{
    public class SimpleArray<T>
    {
        T[] array;
        int noOfElements;

        public SimpleArray(int arraySize)
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
                    for (int i = itemIndex; i < noOfElements; i++)
                    {
                        if (i == noOfElements-1)
                        {
                            break;
                        }
                        array[i] = array[i + 1];
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
                for (int i = 0; i < noOfElements; i++)
                {
                    if (array[i].Equals(item))
                    {
                        return i;
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
