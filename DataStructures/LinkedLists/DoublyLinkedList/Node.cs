﻿namespace DataStructures.LinkedLists.DoublyLinkedList
{
    /// <summary>
    /// This node class represents a node used in a generic linked list.
    /// </summary>
    /// <typeparam name="T">The type to be provided bt the user at runtime.</typeparam>
    public sealed class Node<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
        public T Value { get; set; }
        public bool IsValid { get { return Value != null; } }

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
