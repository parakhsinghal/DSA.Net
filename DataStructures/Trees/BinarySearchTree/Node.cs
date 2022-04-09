namespace DataStructures.Trees.BinarySearchTree
{
    public sealed class Node<T>
    {
        public T Value { get; private set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }

        /// <summary>
        /// Private constructor to force a user to initialize a node
        /// by providing the value at initialization.
        /// </summary>
        private Node() { }

        /// <summary>
        /// Constructor to initialize a node with a value.
        /// </summary>
        /// <param name="value">The data with which the Value property needs to be initialized.</param>
        public Node(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Provides a boolean result based on the Value being null or otherwise.
        /// </summary>
        /// <returns>True if Value property is null. Fase otherwise.</returns>
        public bool IsValid()
        {
            return Value == null;
        }
    }
}
