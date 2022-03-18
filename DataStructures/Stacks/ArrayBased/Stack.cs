using System;
using System.Collections;
using System.Collections.Generic;
using ErrMsgs = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Stacks.ArrayBased
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] backingArray;
        public int Count { get; private set; }

        public Stack()
        {
            backingArray = new T[Array.MaxLength];
            Count = 0;
        }

        public T Peek()
        {
            return backingArray[Count];
        }

        public void Push(T value)
        {
            if (value != null)
            {
                Count++;
                backingArray[Count] = value;
            }
            else
            {
                throw new ArgumentNullException(ErrMsgs.Array_Push_IsValid);
            }
        }

        public T Pop()
        {
            T result = backingArray[Count];
            Count--;
            return result;
        }

        public void Clear()
        {
            backingArray = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= Count; i++)
            {
                yield return backingArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }
    }
}
