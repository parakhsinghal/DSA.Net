using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.DoubleEndedLinkedList
{
    public class DoubleEndedLinkedList<T> : ICollection<T>
    {

        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; private set; }

        public void AddHead(T value)
        {
            AddHead(new Node<T>() { Value = value });
        }

        public void AddHead(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public void AddTail(T value)
        {
            AddTail(new Node<T>() { Value = value });
        }

        public void AddTail(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public void RemoveHead()
        {
            throw new NotImplementedException();
        }

        public void RemoveTail()
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }        

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
