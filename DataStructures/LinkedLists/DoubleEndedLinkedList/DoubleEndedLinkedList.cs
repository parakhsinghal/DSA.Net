using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ErrMsgs = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.LinkedLists.DoubleEndedLinkedList
{
    /// <summary>
    /// The double ended linked list is a variation of the normal linked list.
    /// The variation is the additional reference to the Tail node available separately, which may be helpful in 
    /// certain scenarios.
    /// </summary>
    /// <typeparam name="T">The data type defined by the user at runtime.</typeparam>
    public class DoubleEndedLinkedList<T> : ICollection<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; private set; }

        #region Standard linked list functionality

        /// <summary>
        /// Push method is a standard method available on a linked list and creates a node in a linked list.
        /// The node is created in position of a new head, if the list is empty, or in place of an existing one, if 
        /// the list is not empty.
        /// </summary>
        /// <param name="item">The </param>
        public void Push(T item)
        { 
            AddHead(item);
        }

        /// <summary>
        /// Pop method is a standard method available on a linked list and removes the top node i.e. head.
        /// </summary>
        public void Pop()
        {
            try
            {
                if (Count == 0) //If the linked list is empty, throw an error message
                {
                    throw new InvalidOperationException(ErrMsgs.LinkedList_RemoveHead_EmptyList);
                }
                else
                {
                    // If the count is greater than 1, point the head to the next node
                    // If the count is equal to 1, i.e. only Head exists, point the Head to null (given by Next property)
                    Head = Head.Next;
                    Count--;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Peek is a standard method available on a linked list and returns the value of the head node.
        /// </summary>
        /// <returns>The value of the head node.</returns>
        public T Peek()
        {
            return Head.Value;
        }

        #endregion

        #region Additional linked list functionality

        /// <summary>
        /// AddHead is an additional method available in this implementation of a double ended linked list.
        /// The method adds a node at the head position, pushing the existing head node down in the linked list.
        /// </summary>
        /// <param name="value">The value of the node that needs to be added as a head.</param>
        private void AddHead(T value)
        {
            AddHead(new Node<T>() { Value = value });
        }

        /// <summary>
        /// AddHead is a method available in this implementation of a double ended linked list.
        /// The method adds a node at the head position, pushing the existing head node down in the linked list.
        /// </summary>
        /// <param name="node">The node that needs to be added as a head.</param>
        private void AddHead(Node<T> node)
        {
            try
            {
                if (node.IsValid)
                {
                    if (Count == 0)
                    {
                        Head = node;    // Make the node the new Head
                        Tail = node;    // Tail also need to point to the node
                        Count++;        // Increase the node count
                    }
                    else
                    {
                        node.Next = Head;       // Make the new node point to old head                        
                        Head = node;            // Make the new node the new Head
                        Count++;                // Increase the node count
                    }
                }
                else
                {
                    throw new InvalidOperationException(ErrMsgs.Node_IsValid_IsNotValid);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// AddTail is an additional method available in this implementation of a double ended linked list.
        /// The method adds a node at the tail position, pushing the existing tail node up in the linked list.
        /// </summary>
        /// <param name="value">The value of the node that needs to be added as a tail.</param>
        public void AddTail(T value)
        {
            AddTail(new Node<T>() { Value = value });
        }

        /// <summary>
        /// AddTail is an additional method available in this implementation of a double ended linked list.
        /// The method adds a node at the tail position, pushing the existing tail node up in the linked list.
        /// </summary>
        /// <param name="value">The node that needs to be added as a tail.</param>
        public void AddTail(Node<T> node)
        {
            try
            {
                if (node.IsValid)
                {
                    if (Count == 0) // If the linked list happens to be empty, then both head and tail will be the same.
                    {
                        Head = node;
                        Tail = node;
                        Count++;
                    }
                    else // If the list is not empty then point existing tail's next pointer to the node and make node the new tail.
                    {
                        Tail.Next = node;
                        Tail = node;
                        Count++;
                    }
                }
                else
                {
                    throw new InvalidOperationException(ErrMsgs.Node_IsValid_IsNotValid);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }        

        /// <summary>
        /// RemoveTail is an additional method available in this implementation of a double ended linked list.
        /// The method removes the node referenced as tail, and pusing the reference the penultimate node available 
        /// in the linked list.
        /// </summary>
        public void RemoveTail()
        {
            try
            {
                if (Count == 0) // if the list is empty then throw an appropriate exception
                {
                    throw new InvalidOperationException(ErrMsgs.LinkedList_RemoveTail_EmptyList);
                }
                else // If the list is not empty
                {
                    // If there's only one node then make both the head and tail null
                    if (Count == 1)
                    {
                        Head = null;
                        Tail = null;
                    }
                    else
                    {
                        // If the count is greater than 1 and there are nodes in the linked list
                        // Traverse till the penultimate node and then change the Tail to point to the penultimate
                        // node.
                        Node<T> penultimateNode = Head;
                        while (penultimateNode.Next != Tail)
                        {
                            penultimateNode = penultimateNode.Next;
                        }
                        Tail = penultimateNode;
                    }

                    // Decrement the counter
                    Count--;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// AddAfter is an additional method available in this implementation of a double ended linked list.
        /// The method is used to add a node adjacent to the provided node. The adjacent node can be thought of as
        /// the neighbour to the left of the node to be added.
        /// </summary>
        /// <param name="neighborToLeft">The value of the adjacent node after which a node is required to be added.</param>
        /// <param name="itemToBeAdded">The value of the node that needs to be added.</param>
        public void AddAfter(T neighborToLeft, T itemToBeAdded)
        {
            AddAfter(new Node<T>() { Value = neighborToLeft }, new Node<T>() { Value = itemToBeAdded });
        }

        /// <summary>
        /// AddAfter is an additional method available in this implementation of a double ended linked list.
        /// The method is used to add a node adjacent to the provided node. The adjacent node can be thought of as
        /// the neighbour to the left of the node to be added.
        /// </summary>
        /// <param name="neighborToLeft">The value of the adjacent node after which a node is required to be added.</param>
        /// <param name="itemToBeAdded">The value of the node that needs to be added.</param>
        public void AddAfter(Node<T> neighborToLeft, Node<T> nodeToBeAdded)
        {
            try
            {
                if (Count == 0) // If the list is empty throw an appropriate exception
                {
                    throw new InvalidOperationException(ErrMsgs.LinkedList_AddAfter_EmptyList);
                }
                else if (!this.Contains(neighborToLeft.Value)) // If the list does not contain the neighbour node, throw an appropriate exception
                {
                    throw new InvalidOperationException(ErrMsgs.LinkedList_AddAfter_NeighborNodeNotFound);
                }
                else // If every condition is met then parse nodes all the way to the neighbour node and then add the new node and point appropriately
                {
                    Node<T> currentNode = Head;

                    while (currentNode.Value.Equals(neighborToLeft.Value))
                    {
                        currentNode = currentNode.Next;
                    }

                    nodeToBeAdded.Next = currentNode.Next;
                    currentNode.Next = nodeToBeAdded;
                    Count++;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// AddAfter is an additional method available in this implementation of a double ended linked list.
        /// The method is used to add a node adjacent to the provided node. The adjacent node can be thought of as
        /// the neighbour to the right of the node to be added.
        /// </summary>
        /// <param name="neighborToLeft">The value of the adjacent node before which a node is required to be added.</param>
        /// <param name="itemToBeAdded">The value of the node that needs to be added.</param>
        public void AddBefore(T neighborToRight, T itemToBeAdded)
        {
            AddBefore(new Node<T>() { Value = neighborToRight }, new Node<T>() { Value = itemToBeAdded });
        }

        /// <summary>
        /// AddAfter is an additional method available in this implementation of a double ended linked list.
        /// The method is used to add a node adjacent to the provided node. The adjacent node can be thought of as
        /// the neighbour to the right of the node to be added.
        /// </summary>
        /// <param name="neighborToLeft">The value of the adjacent node before which a node is required to be added.</param>
        /// <param name="itemToBeAdded">The value of the node that needs to be added.</param>
        public void AddBefore(Node<T> neighborToRight, Node<T> nodeToBeAdded)
        {
            try
            {
                if (Count == 0) // If the list is empty throw an appropriate exception
                {
                    throw new InvalidOperationException(ErrMsgs.LinkedList_AddAfter_EmptyList);
                }
                else if (!this.Contains(neighborToRight.Value)) // If the list does not contain the neighbour node, throw an appropriate exception
                {
                    throw new InvalidOperationException(ErrMsgs.LinkedList_AddAfter_NeighborNodeNotFound);
                }
                else // If every condition is met then parse nodes all the way to the neighbour node and then add the new node and point appropriately
                {
                    Node<T> currentNode = Head;

                    while (currentNode.Next.Equals(neighborToRight))
                    {
                        currentNode = currentNode.Next;
                    }

                    nodeToBeAdded.Next = currentNode.Next;
                    currentNode.Next = nodeToBeAdded;
                    Count++;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        #endregion

        #region ICollection implementation
        /// <summary>
        /// IsReadOnly is then method implementation of the IsReadOnly method declared in the ICollection interface.
        /// The method provides information is the underlying collection is read-only in nature or not.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Add is the method implemention of the Add method declared in the ICollection interface. 
        /// The implementation simply calls the Push method which adds a node at the head position.
        /// </summary>
        /// <param name="item">The value of the node to be added as a head.</param>
        public void Add(T item)
        {
            Push(item);
        }

        /// <summary>
        /// Clear is a method implementation of the Clear method declared in the ICollection interface.
        /// The methods clears the members of the underlying collection.
        /// </summary>
        public void Clear()
        {
            try
            {
                Head = null;
                Tail = null;
                Count = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Contains is a method implementation of the Contains method declared in the ICollection interface.
        /// The method returns a boolean response if the value supplied as an argument is found in the linked list.
        /// </summary>
        /// <param name="item">The value of the node to be searched.</param>
        /// <returns>Returns a boolean response with true if the value is found in the underlying collection.</returns>
        public bool Contains(T item)
        {
            try
            {
                if (Count == 0)
                {
                    throw new InvalidOperationException(ErrMsgs.LinkedList_Contains_EmptyList);
                }
                else
                {
                    Node<T> currentNode = Head;
                    while (currentNode != null)
                    {
                        if (currentNode.Value.Equals(item))
                        {
                            return true; // If the value is found, return true and exit the loop
                        }
                        currentNode = currentNode.Next;
                    }
                    return false; // If we have reached here, the value was not found. Return false
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The CopyTo method is the method implementation of the CopyTo method declared in the ICollection interface.
        /// The method is used to copy over the values of the underlying collection to the supplied array from the index desired.
        /// </summary>
        /// <param name="array">The array to which the values of all the nodes need to be copied to.</param>
        /// <param name="arrayIndex">The starting value against which the values in the linkedlist needs to be copied to the supplied array.</param>
        /// <exception cref="ArgumentOutOfRangeException">The ArgumentOutOfRangeException is thrown if the length of the underlying collection
        /// is a negative number or the sum of the index and the total number of values exceed the length of the array.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex + Count > array.Length)
            {
                throw new ArgumentOutOfRangeException(ErrMsgs.LinkedList_CopyTo_InvalidArguments);
            }
            else
            {
                foreach (T item in this)
                {
                    array.SetValue(item, arrayIndex++);
                }
            }
        }

        /// <summary>
        /// Remove is a method implementation of the Remove method declaration in the ICollection interface.
        /// Remove eliminates the supplied value from the linked list and arranges the references accordingly.
        /// </summary>
        /// <param name="item">The value of the node to be removed.</param>
        /// <returns>Returns a boolean response of true if the removal was successful and false otherwise.</returns>
        public bool Remove(T item)
        {
            try
            {
                if (Count == 0)
                {
                    // If dealing with an empty list, throw an error message
                    throw new InvalidOperationException(ErrMsgs.LinkedList_Remove_EmptyList);
                }
                else
                {
                    Node<T> currentNode = Head;

                    while (currentNode != null)
                    {
                        if (currentNode.Value.Equals(item))
                        {
                            // If the value happens to be part of the last node then
                            // create a temporary node that will become the second to last node
                            // and release the last node
                            if (currentNode.Next == null)
                            {
                                Node<T> penultimateNode = Head;
                                while (penultimateNode.Next != currentNode)
                                {
                                    penultimateNode = penultimateNode.Next;
                                }
                                penultimateNode.Next = null;
                            }
                            else
                            {
                                // If the value found happens to be in the between the Head and the last node
                                // then create a temporary node that will become node that occurs before the 
                                // node that contains the value. Then change the references appropriately
                                Node<T> previousNode = Head;
                                while (previousNode.Next == currentNode)
                                {
                                    previousNode = previousNode.Next;
                                }
                                previousNode.Next = currentNode.Next;
                            }
                        }

                        currentNode = currentNode.Next;
                    }

                    Count--;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// GetEnumerator is the method implementation of the GetEnumerator method in the ICollection interface.
        /// The method provides all the values in the underlying collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        #endregion
    }
}
