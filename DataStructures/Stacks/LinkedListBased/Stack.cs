using System;
using System.Collections;
using System.Collections.Generic;
using DSA = DataStructures.LinkedLists.SingleEndedLinkedList;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Stacks.LinkedListBased
{
    public class Stack<T> : IEnumerable<T>
    {
        private DSA.SingleEndedLinkedList<T> backingLinkedList;

        public Stack()
        {
            backingLinkedList = new DSA.SingleEndedLinkedList<T>();
        }

        public T Peek()
        {
            return backingLinkedList.GetHead();
        }

        public void Push(T value)
        {
            if (value!= null)
            {
                backingLinkedList.Add(value);
            }
            else
            {
                throw new ArgumentNullException(Err.Array_Push_IsValid);
            }
        }

        public T Pop()
        {
            T result = backingLinkedList.GetHead();
            backingLinkedList.RemoveHead();
            return result;
        }

        public int Count()
        {
            return backingLinkedList.Count;
        }

        public void Clear()
        {
            backingLinkedList.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in backingLinkedList)
            { 
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }
    }
}
