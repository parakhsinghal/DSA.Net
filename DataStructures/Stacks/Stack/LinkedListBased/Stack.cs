using System;
using System.Collections;
using System.Collections.Generic;
using DSA = DataStructures.LinkedLists.LinkedList;

namespace DataStructures.Stack.LinkedListBased
{
    public class Stack<T> : IEnumerable<T>
    {
        private DSA.LinkedList<T> stack;

        public Stack()
        {
            stack = new DSA.LinkedList<T>();
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
