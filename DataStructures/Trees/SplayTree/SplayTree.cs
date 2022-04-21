#region Readme about code
/*
Author      :   Parakh Singhal
Description :   Splay tree is a roughly balanced binary search tree. Unlike an AVL tree, which is a strictly
                balanced tree, a splay tree is roughly balanced and it is achieved on the basis of left 
                and right rotations, colloquially called zig and zag rotations respectively. Depending upon 
                the circumstances, the rotations are applied individually or in pairs. The activity of applying 
                appropriate rotations is called splaying, hence the name splay tree. The rotations only roughly 
                balance the underlying BST and the time for operations like insert, search and delete comes 
                to be O(log(n)) on an amortized basis.
Important   :   1. Splaying operations can be applied to a splay tree in three ways:
                    a) Top to bottom operation leveraging the left and right child relationships.
                    b) Bottom to top operation
                        i)  Done recursively where the path from bottom to top is stored on a call stack and 
                            splay method is called recursively.
                        ii) Done leveraging parent and left-right child relationhip. 
                    A node in addition to left and right relationship also stores an additional node called parent
                    and leverages it to simplify the process of rotations. It does make more passes than the 
                    top-down approach, but is simple to understand and is commonly found in lietrature on the 
                    subject matter. This code deploys the 1-b-ii method of splaying.
                2. The insert operation is carried out normally as would be in a binary search tree, with the
                    exception of a splaying operation at the end of the insert.
                3. The search operation is carried out normally as would be in a binary search tree, with the 
                    exception of a splaying operation at the end of the search, effectively returning the root of
                    the tree. Note, that if a value is not found in the splay tree, then the value closest to the 
                    searched value is splayed and put into the root position.
                4. The delete operation is carried out normally as would be in a binary search tree, with the 
                    exception of a splaying operation at the end of the deletion. Note, that if the value desired to be 
                    deleted is not available in the tree, then the value closest to it, is splayed and put into
                    the root position.
                5. Any type of traversal (BFS or DFS) does not have any impact on the positions of the nodes in a splay tree.
 */
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Trees.SplayTree
{
    /// <summary>
    /// Splay tree class to create an object of splay tree.
    /// </summary>
    /// <typeparam name="T">The base data type of the class e.g. int, char or a user defined type.</typeparam>
    public class SplayTree<T>
    {
        /// <summary>
        /// The root or the starting point of the splay tree.
        /// </summary>
        public Node<T> Root { get; private set; }

        int leftHeight = 0, rightHeight = 0;

        Queue<Node<T>> queue;

        public SplayTree()
        {
            queue = new Queue<Node<T>>();
        }

        /// <summary>
        /// The insert operation inserts the provided value in the splay tree.
        /// If a tree doesn't have a root to begin with, then a root is automatically
        /// created. If the root is already populated then the tree is populated as per the
        /// insertion rules applicable to a binary search tree. Once insertion is performed,
        /// splaying operation is carried put.
        /// </summary>
        /// <param name="value">The value desired to be inserted in the splay tree.</param>
        public void Insert(T value)
        {
            try
            {
                if (value is null)
                {
                    throw new ArgumentNullException(Err.SplayTree_Insert_NullValue);
                }

                // If the root is null then create a new root.
                // No need to splay as root is the only node in the tree.
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
                            // Current node's value is less than the value that needs to be inserted.
                            // Move to the right child or create a right child.
                            // Once created, splay the tree and put the newly inserted value at root position.
                            case < 0:
                                if (current.RightChild is null)
                                {
                                    current.RightChild = new Node<T>(value);
                                    current.RightChild.Parent = current;
                                    Splay(current.RightChild);
                                    return;
                                }
                                else
                                {
                                    current = current.RightChild;
                                }
                                break;

                            // Current node's value is more than the value that needs to be inserted
                            // Move to the left child or create a left child.
                            // Once created, splay the tree and put the newly inserted value at root position.
                            case > 0:
                                if (current.LeftChild is null)
                                {
                                    current.LeftChild = new Node<T>(value);
                                    current.LeftChild.Parent = current;
                                    Splay(current.LeftChild);
                                    return;
                                }
                                else
                                {
                                    current = current.LeftChild;
                                }
                                break;

                            // The current and the value to be inserted are equal.
                            // Insertion of duplicate values is not allowed.
                            default:
                                throw new ArgumentException(Err.SplayTree_Insert_EqualValue);
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
        /// The search method searches for the value desired in the splay tree.
        /// If the value is found, it is splayed and put in the root position and returned thereafter.
        /// If the value is not found, then the value closest to the searched value is splayed
        /// and put in the root position and returned thereafter. The search method uses iterative
        /// while loop method to search for the desired value.
        /// </summary>
        /// <param name="value">The value that needs to be searched.</param>
        /// <returns>Returns the node with the value if found, null otherwise.</returns>
        public Node<T> Search(T value)
        {
            try
            {
                // The approach is to keep two tabs on the whereabouts in the path down the tree.
                // Current node starts at the root and parent stays one step behind in the while loop.
                Node<T> current = Root;
                Node<T> parent = current;

                if (Root is null)
                {
                    throw new InvalidOperationException(Err.SplayTree_Search_EmptyTree);
                }
                else
                {
                    while (!current.Value.Equals(value))
                    {
                        switch (Comparer<T>.Default.Compare(current.Value, value))
                        {
                            // Current node's value is less than the value that needs to be searched
                            // Move to the right child. If the value is not found, then splay the 
                            // parent node and return null.
                            case < 0:
                                parent = current;
                                current = current.RightChild;
                                if (current is null)
                                {
                                    Splay(parent);
                                    return null;
                                }
                                break;

                            // Current node's value is more than the value that needs to be searched
                            // Move to the left child. If the value is not found, then splay the 
                            // parent node and return null.
                            case > 0:
                                parent = current;
                                current = current.LeftChild;
                                if (current is null)
                                {
                                    Splay(parent);
                                    return null;
                                }
                                break;

                            // Current node's value is equal to the value that needs to be searched.
                            default:
                                break;
                        }
                    }

                    // If we have broken out of the while loop, it means that we found the value.
                    // Splay the found value. it will become root and then return the root.
                    Splay(current);
                }

                return Root;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The standard in-order traversal as is implemented in a binary search tree.
        /// Popular use of the in-order traversal is to put the contents of a BST
        /// in ascending order.
        /// </summary>
        /// <param name="rootNode">Provide the root node of the tree.</param>
        /// <param name="action">An action that needs to be performed when the control comes back to the
        /// starting node after depth traversal of the left subtree. If nothing needs to be done, leave blank.</param>
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
        /// The standard pre-order traversal as is implemented in a binary search tree.
        /// </summary>
        /// <param name="rootNode">The root node of the tree.</param>
        /// <param name="action">An action that needs to be performed on the starting node
        /// before the depth traversal of the left subtree. If nothing needs to be done, leave blank. </param>
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
        /// The standard post-order traversal as is implemented in a binary search tree.
        /// </summary>
        /// <param name="rootNode">The root node of the tree.</param>
        /// <param name="action">An action that needs to be performed on the starting node
        /// after the depth traversal of the left subtree. If nothing needs to be done, leave blank. </param>
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
        /// The standard breadth first traversal as is implemented in a binary search tree.
        /// </summary>
        /// <param name="rootNode">The root node of the tree.</param>
        /// <param name="action">An action that needs to be performed on every node on a given level. 
        /// If nothing needs to be done, leave blank. </param>
        public void BreadthFirstTraversal(Node<T> rootNode, Action<T> action)
        {
            if (rootNode is not null)
            {
                action(rootNode.Value);

                if (rootNode.LeftChild is not null)
                {
                    queue.Enqueue(rootNode.LeftChild);
                }

                if (rootNode.RightChild is not null)
                {
                    queue.Enqueue(rootNode.RightChild);
                }

                if (queue.Count > 0)
                {
                    BreadthFirstTraversal(queue.Dequeue(), action);
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// The standard delete method as is implemented in a binary search tree with the exception
        /// that after the deletion of the value, spalying is performed on parent of the value. In case
        /// the value to be deleted is not found, splaying is performed on the value closest to the 
        /// value desired to be deleted.
        /// </summary>
        /// <param name="value">The value desired to be deleted.</param>
        /// <exception cref="InvalidOperationException">InvalidOperationException is thrown if 
        /// a value is attempted to be deleted from an empty tree.</exception>
        public void Delete(T value)
        {
            /*
                Pseudocode:
                There are following scenarios that we need to code for:
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
                Find out the node that we need to delete and then figure out if the node has two children.
                In this case we need to figure out the in-order successor i.e. the node that is the successor in
                the in-order sequence to the node to be deleted and then change the references accordingly. This
                case could also be performed using the in-order predecessor, but I have specifically chosen
                to go with the in-order successor, as that is majorly covered in the available lietrature.

                In all the aforementioned cases, perform the splaying operation as desired.
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

            #region Deletion of a node with no child

            while (Comparer<T>.Default.Compare(current.Value, value) != 0)
            {
                switch (Comparer<T>.Default.Compare(current.Value, value))
                {
                    // Current node's value is less than the value that needs to be searched
                    // Move to the right child. If the value is not found, then splay the 
                    // parent node and return null.
                    case < 0:
                        parent = current;
                        isRightChild = true;
                        isLeftChild = false;
                        current = current.RightChild;
                        if (current is null)
                        {
                            Splay(parent);
                            return;
                        }
                        break;

                    // Current node's value is more than the value that needs to be searched
                    // Move to the left child. If the value is not found, then splay the 
                    // parent node and return null.
                    case > 0:
                        parent = current;
                        isLeftChild = true;
                        isRightChild = false;
                        current = current.LeftChild;
                        if (current is null)
                        {
                            Splay(parent);
                            return;
                        }
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
                    Splay(parent);
                }
                else if (isRightChild)
                {
                    parent.RightChild = null;
                    Splay(parent);
                }
            }

            #endregion

            #region Deletion of a node with a single child

            else if (current.RightChild is null)
            {
                if (isLeftChild)    // Case 1: Where the node to be deleted has a left or right child.
                {
                    parent.LeftChild = current.LeftChild;
                    Splay(parent);
                }
                else if (isRightChild)
                {
                    parent.RightChild = current.LeftChild;
                    Splay(parent);
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
                    Splay(parent);
                }
                else if (isRightChild)
                {
                    parent.RightChild = current.RightChild;
                    Splay(parent);
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
                    Splay(parent);
                }
                else if (isRightChild)
                {
                    parent.RightChild = successor;
                    Splay(parent);
                }

                successor.LeftChild = current.LeftChild;
            }

            #endregion
        }

        /// <summary>
        /// Clears the content of the tree.
        /// </summary>
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
        /// The method finds the successor to the node to be deleted in the in-order sequence.
        /// </summary>
        /// <param name="nodeToBeDeleted">The node to be deleted and for which the in-order
        /// successor needs to be found out.</param>
        /// <returns>The node that is the in-order successor.</returns>
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

        /// <summary>
        /// Standard splay method implemented using the bottom to top traversal 
        /// leveraging the parent and left-right child relationships.
        /// </summary>
        /// <param name="nodeToBeSplayed">The node to be splayed, i.e. put into root position.</param>
        private void Splay(Node<T> nodeToBeSplayed)
        {
            try
            {
                if (nodeToBeSplayed == null || nodeToBeSplayed.Equals(Root))
                {
                    return;
                }

                while (!nodeToBeSplayed.Equals(Root))
                {
                    if (nodeToBeSplayed.Parent.Equals(Root))
                    {
                        if (nodeToBeSplayed.Parent.LeftChild is not null && nodeToBeSplayed.Parent.LeftChild.Equals(nodeToBeSplayed))
                        {
                            RotateRight(nodeToBeSplayed.Parent);
                        }
                        else if (nodeToBeSplayed.Parent.RightChild is not null && nodeToBeSplayed.Parent.RightChild.Equals(nodeToBeSplayed))
                        {
                            RotateLeft(nodeToBeSplayed.Parent);
                        }
                    }
                    else if (nodeToBeSplayed == nodeToBeSplayed.Parent.LeftChild && nodeToBeSplayed.Parent == nodeToBeSplayed.Parent.Parent.LeftChild)
                    {
                        RotateRight(nodeToBeSplayed.Parent.Parent);
                        RotateRight(nodeToBeSplayed.Parent);
                    }
                    else if (nodeToBeSplayed == nodeToBeSplayed.Parent.RightChild && nodeToBeSplayed.Parent == nodeToBeSplayed.Parent.Parent.RightChild)
                    {
                        RotateLeft(nodeToBeSplayed.Parent.Parent);
                        RotateLeft(nodeToBeSplayed.Parent);
                    }
                    else if (nodeToBeSplayed == nodeToBeSplayed.Parent.LeftChild && nodeToBeSplayed.Parent == nodeToBeSplayed.Parent.Parent.RightChild)
                    {
                        RotateRight(nodeToBeSplayed.Parent);
                        RotateLeft(nodeToBeSplayed.Parent);
                    }
                    else
                    {
                        RotateLeft(nodeToBeSplayed.Parent);
                        RotateRight(nodeToBeSplayed.Parent);
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
        /// The method RotateRight rotates a node to the right effectively bringing the 
        /// child node up in it's place.
        /// </summary>
        /// <param name="parent">The parent of the node to be rotated.</param>
        private void RotateRight(Node<T> parent)
        {
            /*
                Pseudocode: 
            
             */

            try
            {
                Node<T> childToBeRotated = parent.LeftChild;
                if (childToBeRotated is null)
                {
                    return;
                }

                parent.LeftChild = childToBeRotated.RightChild;
                if (childToBeRotated.RightChild is not null)
                {
                    childToBeRotated.RightChild.Parent = parent;
                }

                childToBeRotated.Parent = parent.Parent;
                if (parent.Equals(Root))
                {
                    Root = childToBeRotated;
                }
                else if (parent == parent.Parent.LeftChild)
                {
                    parent.Parent.LeftChild = childToBeRotated;
                }
                else
                {
                    parent.Parent.RightChild = childToBeRotated;
                }

                childToBeRotated.RightChild = parent;
                parent.Parent = childToBeRotated;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
           
        }

        /// <summary>
        /// The method RotateLeft rotates a node to the left effectively bringing the 
        /// child node up in it's place.
        /// </summary>
        /// <param name="parent">The parent of the node to be rotated.</param>
        private void RotateLeft(Node<T> parent)
        {
            /*
                Pseudocode: 
                
             */

            try
            {
                Node<T> childToBeRotated = parent.RightChild;
                if (childToBeRotated is null)
                {
                    return;
                }

                parent.RightChild = childToBeRotated.LeftChild;
                if (childToBeRotated.LeftChild is not null)
                {
                    childToBeRotated.LeftChild.Parent = parent;
                }

                childToBeRotated.Parent = parent.Parent;

                if (parent.Equals(Root))
                {
                    Root = childToBeRotated;
                }
                else if (parent == parent.Parent.LeftChild)
                {
                    parent.Parent.LeftChild = childToBeRotated;
                }
                else
                {
                    parent.Parent.RightChild = childToBeRotated;
                }

                childToBeRotated.LeftChild = parent;
                parent.Parent = childToBeRotated;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }            
        }
    }
}
