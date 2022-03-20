using System;
using System.Collections;
using System.Collections.Generic;
using DSA = DataStructures.Arrays.SimpleArray;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Queues.SimpleQueue.ArrayBased
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] backingArray;
        public int Count { get; private set; }

        public Queue(int length)
        {
            backingArray = new T[length];
            Count = 0;
        }

        private Queue() { }

        public T Peek()
        {
            return backingArray[0];
        }

        public void Enqueue(T value)
        {
            if (value != null)
            {
                if ( backingArray.Length > Count)
                {
                    backingArray[Count] = value;
                    Count++; 
                }
                else
                {
                    throw new ArgumentOutOfRangeException(Err.Queue_Enqueue_IndexOutOfRange);
                }
            }
            else
            {
                throw new ArgumentNullException(Err.Queue_Enqueue_ValueIsNotValid);
            }
        }

        public void Dequeue()
        {
            // If the count is equal to 1, then the queue is empty.
            if (Count == 0)
            {
                throw new InvalidOperationException(Err.Queue_Dequeue_EmptyQueue);
            }
            else
            {
                //backingArray[0] = default(T);
                Count--;
                for (int i = 0; i < Count; i++)
                {
                    backingArray[i] = backingArray[i + 1];
                }
            }
        }

        public void Clear()
        {
            Array.Clear(backingArray);
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in backingArray)
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
