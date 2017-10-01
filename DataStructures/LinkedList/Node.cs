using System;

namespace DataStructures.LinkedList
{
    public sealed class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }
        public bool IsValid { get { return this == null; } }

        public Node()
        {
            Next = null;
        }

        public Node(T value)
        {
            Value = value;
        }
    }
}
