using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ErrMsgs = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Arrays.OrderedArray
{
    public class OrderedArray<T>
    {
        T[] array;

        public OrderedArray(int arraySize)
        {
            T[] array = new T[arraySize];

        }

        public bool Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Find(T item)
        {
            throw new NotImplementedException(); // Implement binary search
        }
    }
}
