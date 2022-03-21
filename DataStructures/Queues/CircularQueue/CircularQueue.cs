using DataStructures.LinkedLists.CircularLinkedList;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queues.CircularQueue
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        private CircularLinkedList<T> backingCircularLinkedList;
        public int Count { get { return backingCircularLinkedList.Count; } private set { } }

        public CircularQueue()
        {
            backingCircularLinkedList = new CircularLinkedList<T>();
        }

        public void Enqueue(T value)
        {
            backingCircularLinkedList.AddTail(value);
        }

        public T Peek()
        {
            return backingCircularLinkedList.GetHead();
        }

        public void Dequeue()
        {
            backingCircularLinkedList.RemoveHead();
        }

        public void Clear()
        {
            backingCircularLinkedList.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in backingCircularLinkedList)
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
