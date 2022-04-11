using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees.AVLTree
{
    public class Node<T>
    {
        public T Value { get; private set; }
        public int BalanceFactor { get; private set; }
        public int Height { get; private set; }
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

        /// <summary>
        /// Update the node's height and balance factor.
        /// </summary>
        public void UpdateHeightAndBalanceFactor()
        {
            if (LeftChild is null && RightChild is null)
            {
                Height = 0;
                BalanceFactor = 0;
            }
            else if (LeftChild is null)
            {
                Height = RightChild!.Height + 1;
                BalanceFactor = -RightChild.Height;
            }
            else if (RightChild is null)
            {
                Height = LeftChild!.Height + 1;
                BalanceFactor = -LeftChild.Height;
            }
            else
            {
                Height = Math.Max(LeftChild.Height, RightChild.Height) + 1;
                BalanceFactor = LeftChild.Height - RightChild.Height;
            }
        }
    }
}
