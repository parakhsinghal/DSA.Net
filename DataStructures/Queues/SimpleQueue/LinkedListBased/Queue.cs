using System;
using System.Collections;
using System.Collections.Generic;
using DSA = DataStructures.LinkedLists.SingleEndedLinkedList;

namespace DataStructures.Queues.SimpleQueue.LinkedListBased
{
    public class Queue<T> : IEnumerable<T>
    {
        private DSA.SingleEndedLinkedList<T> queue;

        public Queue()
        {
            queue = new DSA.SingleEndedLinkedList<T>();
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
