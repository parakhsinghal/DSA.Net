using System;
using System.Collections;
using System.Collections.Generic;
using DSA = DataStructures.Arrays.SimpleArray;

namespace DataStructures.Queues.SimpleQueue.ArrayBased
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] queue;

        public Queue()
        {

        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T value)
        {
            throw new NotImplementedException();
        }

        public void Dequeue()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
