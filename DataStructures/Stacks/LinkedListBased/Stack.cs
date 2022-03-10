using System;
using System.Collections;
using System.Collections.Generic;
using DSA = DataStructures.LinkedLists.SingleEndedLinkedList;

namespace DataStructures.Stacks.LinkedListBased
{
    public class Stack<T> : IEnumerable<T>
    {
        private DSA.SingleEndedLinkedList<T> stack;

        public Stack()
        {
            stack = new DSA.SingleEndedLinkedList<T>();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public void Push(T value)
        {
            throw new NotImplementedException();
        }

        public void Pop()
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
