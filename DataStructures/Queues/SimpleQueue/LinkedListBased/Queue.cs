using System;
using System.Collections;
using System.Collections.Generic;
using DSA = DataStructures.LinkedLists.DoubleEndedLinkedList;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Queues.SimpleQueue.LinkedListBased
{
    public class Queue<T> : IEnumerable<T>
    {
        private DSA.DoubleEndedLinkedList<T> backingLinkedList;
        public int Count { get { return backingLinkedList.Count; } set { } }

        public Queue()
        {
            backingLinkedList = new DSA.DoubleEndedLinkedList<T>();
        }

        public T Peek()
        {
            return backingLinkedList.GetHead();
        }

        public void Enqueue(T value)
        {
            if (value != null)
            {
                backingLinkedList.AddTail(value);
            }
            else
            {
                throw new ArgumentNullException(Err.Queue_Enqueue_ValueIsNotValid);
            }
        }

        public void Dequeue()
        {
            backingLinkedList.RemoveHead();
        }

        public void Clear()
        {
            backingLinkedList.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in backingLinkedList)
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
