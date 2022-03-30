using System;
using System.Collections.Generic;
using System.Diagnostics;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Trees.BinarySearchTree
{
    public class BinarySearchTree<T>
    {
        public Node<T> Root { get; private set; }

        public void Insert(T value)
        {
            try
            {
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
                                break;

                            // Current node's value is more than the value that needs to be searched
                            // Move to the left child.
                            case > 0:
                                current = current.LeftChild;
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

        public void InOrderTraversal(Node<T> rootNode, Action<T> action)
        {
            if (rootNode is null || rootNode != Root|| Root is null)
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

        public void PreOrderTraversal(Node<T> rootNode, Action<T> action)
        {
            if (rootNode is null || rootNode != Root || Root is null)
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

        public void PostOrderTraversal(Node<T> rootNode, Action<T> action)
        {
            if (rootNode is null || rootNode != Root || Root is null)
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
                
                
                
             */
            throw new NotImplementedException();
        }
    }
}
