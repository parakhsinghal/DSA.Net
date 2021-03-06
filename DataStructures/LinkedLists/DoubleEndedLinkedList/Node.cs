using System;

namespace DataStructures.LinkedLists.DoubleEndedLinkedList
{
    public sealed class Node<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
        public T Value { get; set; }
        public bool IsValid { get { return this == null; } }

        public Node()
        {
            Next = null;
            Previous = null;
        }

        public Node(T value)
        {
            Value = value;
        }
    }
}
