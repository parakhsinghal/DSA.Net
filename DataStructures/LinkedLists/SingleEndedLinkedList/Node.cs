namespace DataStructures.LinkedLists.SingleEndedLinkedList
{
    /// <summary>
    /// This node class represents a node used in a generic linked list.
    /// </summary>
    /// <typeparam name="T">The type to be provided bt the user at runtime.</typeparam>
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
