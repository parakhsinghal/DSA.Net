using System;
using System.Collections.Generic;
using System.Diagnostics;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Trees.BinarySearchTree
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public Node<T> Root { get; private set; }

        int leftHeight = 0, rightHeight = 0;

        public int Height(Node<T> node)
        {
            if (node is null)
            {
                return 0;
            }

            int leftHeight = Height(node.LeftChild);
            int rightHeight = Height(node.RightChild);

            int result = Math.Max(leftHeight, rightHeight) +1;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Insert(T value)
        {
            try
            {
                if (value is null)
                {
                    throw new ArgumentNullException(Err.BinarySearchTree_Insert_NullValue);
                }

                // If the root is null then create a new root
                if (Root is null)
                {
                    Root = new Node<T>(value);
                    return;
                }
                else
                {
                    // If the root is not null then traverse in the tree and insert the value
                    // at an appropriate location.
                    Node<T> current = Root;

                    while (true)
                    {
                        switch (Comparer<T>.Default.Compare(current.Value, value))
                        {
                            // Current node's value is less than the value that needs to be inserted
                            // Move to the right child or create a right child.
                            case < 0:
                                if (current.RightChild is null)
                                {
                                    current.RightChild = new Node<T>(value);
                                    return;
                                }
                                else
                                {
                                    current = current.RightChild;
                                }
                                break;

                            // Current node's value is more than the value that needs to be inserted
                            // Move to the left child or create a left child.
                            case > 0:
                                if (current.LeftChild is null)
                                {
                                    current.LeftChild = new Node<T>(value);
                                    return;
                                }
                                else
                                {
                                    current = current.LeftChild;
                                }
                                break;

                            // The current and the value to be inserted are equal.
                            default:
                                throw new ArgumentException(Err.BinarySearchTree_Insert_EqualValue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> Search(T value)
        {
            try
            {
                if (Root is null)
                {
                    throw new InvalidOperationException(Err.BinarySearchTree_Search_EmptyTree);
                }
                else
                {
                    Node<T> current = Root;
                    while (!current.Value.Equals(value))
                    {
                        switch (Comparer<T>.Default.Compare(current.Value, value))
                        {
                            // Current node's value is less than the value that needs to be searched
                            // Move to the right child.
                            case < 0:
                                current = current.RightChild;
                                if (current is null)
                                {
                                    return null;
                                }
                                break;

                            // Current node's value is more than the value that needs to be searched
                            // Move to the left child.
                            case > 0:
                                current = current.LeftChild;
                                if (current is null)
                                {
                                    return null;
                                }
                                break;

                            // Current node's value is equal to the value that needs to be searched.
                            default:
                                break;
                        }
                    }

                    return current;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="action"></param>
        public void InOrderTraversal(Node<T> rootNode, Action<T> action)
        {
            if (rootNode is null || Root is null)
            {
                return;
            }
            else
            {
                InOrderTraversal(rootNode.LeftChild, action);

                action(rootNode.Value);

                InOrderTraversal(rootNode.RightChild, action);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="action"></param>
        public void PreOrderTraversal(Node<T> rootNode, Action<T> action)
        {
            if (rootNode is null || Root is null)
            {
                return;
            }
            else
            {
                action(rootNode.Value);

                PreOrderTraversal(rootNode.LeftChild, action);

                PreOrderTraversal(rootNode.RightChild, action);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="action"></param>
        public void PostOrderTraversal(Node<T> rootNode, Action<T> action)
        {
            if (rootNode is null || Root is null)
            {
                return;
            }
            else
            {
                PostOrderTraversal(rootNode.LeftChild, action);

                PostOrderTraversal(rootNode.RightChild, action);

                action(rootNode.Value);
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Delete(T value)
        {
            /*
                Pseudocode:
                There are following scenarios thaht we need to code for:
                1. Deletion of a node with no children
                2. Deletion of a node with a single child
                3. Deletion of a node with two children
                
                1. Deletion of a node with no children
                Find out the node that we need to delete and then figure out whether the node has any children. 
                If not, nullify the parent's reference to the child and it is done.

                2. Deletion of a node with a single child
                Find out the node that we need to delete and then figure out whether the node has any children.
                Case 1: If there is one child, we need to identify if the child is the left or the right child.
                Case 2: If the node to be deleted is the root node, then we need to put the left subtree appropriately.
                
                3. Deletion of a node with both left and right children
                Find out the node that we need to delete adn then figure out if the node has two children.
                In this case we need to figure out eh in-order successor i.e. the node that is the successor in
                the in-order sequence to the node to be deleted adn then change the references accordingly.
             */

            // Variable declaration
            Node<T> parent = new Node<T>(default);
            Node<T> current = Root;
            bool isLeftChild = false, isRightChild = false;

            // Throw an exception if the tree is empty.
            if (Root is null)
            {
                throw new InvalidOperationException(Err.BinarySearchTree_Deletion_Empty);
            }

            if (Search(value) is null)
            {
                throw new InvalidOperationException(Err.BinarySearchTree_Deletion_NodeNotFound);
            }

            #region Deletion of a node with no child

            while (Comparer<T>.Default.Compare(current.Value, value) != 0)
            {
                switch (Comparer<T>.Default.Compare(current.Value, value))
                {
                    // Current node's value is less than the value that needs to be searched
                    // Move to the right child.
                    case < 0:
                        parent = current;
                        isRightChild = true;
                        isLeftChild = false;
                        current = current.RightChild;
                        break;

                    // Current node's value is more than the value that needs to be searched
                    // Move to the left child.
                    case > 0:
                        parent = current;
                        isLeftChild = true;
                        isRightChild = false;
                        current = current.LeftChild;
                        break;

                    // Current node's value is equal to the value that needs to be searched.
                    default:
                        break;
                }
            }

            if (current.LeftChild is null && current.RightChild is null)
            {
                if (current == Root)
                {
                    Root = null;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = null;
                }
                else if (isRightChild)
                {
                    parent.RightChild = null;
                }
            }

            #endregion

            #region Deletion of a node with a single child
            
            else if (current.RightChild is null)
            {
                if (isLeftChild)    // Case 1: Where the node to be deleted has a left or right child.
                {
                    parent.LeftChild = current.LeftChild;
                }
                else if (isRightChild)
                {
                    parent.RightChild = current.LeftChild;
                }
                else if (current == Root)    // Case 2: Where the node to be deleted is a root node.
                {
                    Root = current.LeftChild;
                }
            }
            else if (current.LeftChild is null)
            {
                if (isLeftChild)    // Case 1: Where the node to be deleted has a left or right child.
                {
                    parent.LeftChild = current.RightChild;
                }
                else if (isRightChild)
                {
                    parent.RightChild = current.RightChild;
                }
                else if (current == Root)    // Case 2: Where the node to be deleted is a root node.
                {
                    Root = current.LeftChild;
                }
            }
            #endregion

            #region Deletion of a node with both left and right children
            /*
                The code for deletion of the node when it has two children has been sourced from the 
                book "Data Structures And Algorithms In Java" by Robert Lafore (Chapter 8, Page 393)
             */
            else
            {
                Node<T> successor = FindInOrderSuccessor(current);

                if (current == Root)
                {
                    Root = successor;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = successor;
                }
                else if (isRightChild)
                {
                    parent.RightChild = successor;
                }

                successor.LeftChild = current.LeftChild;
            }

            #endregion
        }

        public void Clear()
        {
            try
            {
                Root = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeToBeDeleted"></param>
        /// <returns></returns>
        private Node<T> FindInOrderSuccessor(Node<T> nodeToBeDeleted)
        {
            Node<T> successorParent = nodeToBeDeleted;
            Node<T> successor = nodeToBeDeleted;
            Node<T> current = nodeToBeDeleted.RightChild;


            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.LeftChild;
            }

            if (successor != nodeToBeDeleted.RightChild)
            {
                successorParent.LeftChild = successor.RightChild;
                successor.RightChild = nodeToBeDeleted.RightChild;
            }

            return successor;
        }
    }
}
