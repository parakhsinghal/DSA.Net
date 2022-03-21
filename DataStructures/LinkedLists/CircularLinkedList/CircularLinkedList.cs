using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ErrMsgs = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.LinkedLists.CircularLinkedList
{
    /// <summary>
    /// The double ended linked list is a variation of the normal linked list.
    /// The variation is the additional reference to the Tail node available separately, which may be helpful in 
    /// certain scenarios.
    /// </summary>
    /// <typeparam name="T">The data type defined by the user at runtime.</typeparam>
    public class CircularLinkedList<T> : ICollection<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; private set; }

        #region Standard linked list functionality

        /// <summary>
        /// Add method is a standard method available on a linked list and creates a node in a linked list.
        /// The node is created in position of a new head, if the list is empty, or in place of an existing one, if 
        /// the list is not empty. The tail node is appropriately pointed to the new node.<br />
        /// Time complexity: O(1)
        /// </summary>
        /// <param name="item">The </param>
        public void Add(T item)
        {
            try
            {
                Node<T> node = new Node<T>(item);

                if (node.IsValid)
                {
                    if (Count == 0)
                    {
                        Head = node;            // Make the node the new Head
                        Tail = node;            // Tail also need to point to the node
                        Head.Next = Tail;       // Make the linked list circular - head references tail
                        Tail.Next = Head;       // Make the linked list circular - tail references head
                    }
                    else
                    {
                        node.Next = Head;       // Make the new node point to old head  
                        Head = node;            // Make the new node the new Head
                        Tail.Next = Head;       // Make the tail point to the new node
                    }

                    Count++;                    // Increase the node count
                }
                else
                {
                    throw new ArgumentNullException(ErrMsgs.Node_IsValid_IsNotValid);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// RemoveHead method is a standard method available on a linked list and removes the top node i.e. head.
        /// The tail node in the circular linked list is appropriately pointed to the next node available.<br />
        /// Time complexity: O(1)
        /// </summary>
        public void RemoveHead()
        {
            try
            {
                if (Count == 0) //If the linked list is empty, throw an error message
                {
                    throw new InvalidOperationException(ErrMsgs.LinkedList_RemoveHead_EmptyList);
                }
                else
                {
                    if (Count == 1)
                    {
                        Head = null;
                        Tail = null;
                    }
                    else
                    {
                        // If the count is greater than 1, point the head to the next node
                        // If the count is equal to 1, i.e. only Head exists, point the Head to null (given by Next property)
                        Head = Head.Next;
                        Tail.Next = Head;
                    }

                    Count--;        // Decrement the counter
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// GetHead is a standard method available on a linked list and returns the value of the head node.<br />
        /// Time complexity: O(1)
        /// </summary>
        /// <returns>The value of the head node.</returns>
        public T GetHead()
        {
            if (Count == 0) //If the linked list is empty, throw an error message
            {
                throw new InvalidOperationException(ErrMsgs.LinkedList_Peek_EmptyList);
            }
            else
            {
                return Head.Value;
            }
        }

        #endregion

        #region Additional linked list functionality

        /// <summary>
        /// AddTail is an additional method available in this implementation of a circular linked list.
        /// The method adds a node at the tail position, pushing the existing tail reference up in the linked list.<br />
        /// Time complexity: O(1)
        /// </summary>
        /// <param name="value">The value of the node that needs to be added as a tail.</param>
        public void AddTail(T value)
        {
            AddTail(new Node<T>() { Value = value });
        }

        /// <summary>
        /// AddTail is an additional method available in this implementation of a circular linked list.
        /// The method adds a node at the tail position, pushing the existing tail reference up in the linked list.<br />
        /// Time complexity: O(1)
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
                    }
                    else // If the list is not empty then point existing tail's next pointer to the node and make node the new tail.
                    {
                        Tail.Next = node;
                        Tail = node;
                    }

                    Count++;
                }
                else
                {
                    throw new ArgumentNullException(ErrMsgs.Node_IsValid_IsNotValid);
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
        /// in the linked list.<br />
        /// Time complexity: O(n)
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
                        Tail.Next = Head;
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
        /// the neighbour to the left of the node to be added.<br />
        /// Time complexitY: O(n)
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
                    for (int i = 0; i < Count; i++)
                    {
                        if (currentNode.Value.Equals(neighborToLeft.Value))
                        {
                            break;
                        }

                        currentNode = currentNode.Next;
                    }

                    if (currentNode == Tail)
                    {
                        Tail.Next = nodeToBeAdded;
                        Tail = nodeToBeAdded;
                        Tail.Next = Head;
                    }
                    else
                    {
                        nodeToBeAdded.Next = currentNode.Next;
                        currentNode.Next = nodeToBeAdded;
                    }

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
        /// The method provides information is the underlying collection is read-only in nature or not.<br />
        /// Time complexity: O(1)
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Clear is a method implementation of the Clear method declared in the ICollection interface.
        /// The methods clears the members of the underlying collection.<br />
        /// Time comlpexity: O(1)
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
        /// The method returns a boolean response if the value supplied as an argument is found in the linked list.<br />
        /// Time complexity: O(n)
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
                    for (int i = 0; i < Count; i++)
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
        /// The method is used to copy over the values of the underlying collection to the supplied array from the index desired.<br />
        /// Time complexity: O(n)
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
        /// Remove eliminates the supplied value from the linked list and arranges the references accordingly.<br />
        /// Time complexity: O(n)
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
                else if (Count > 0 && Contains(item))
                {
                    if (Count == 1)
                    {
                        Head = null;
                        Tail = null;
                    }
                    else
                    {
                        //Parse the nodes will we reach the penultimate node to the node to be removed.

                        Node<T> currentNode = Head;

                        for (int i = 0; i < Count; i++)
                        {
                            if (currentNode.Next.Value.Equals(item))
                            {
                                break;
                            }
                            currentNode = currentNode.Next;
                        }

                        Node<T> penultimateNode = currentNode;
                        penultimateNode.Next = currentNode.Next;
                    }

                    Count--;
                    return true;
                }

                return false;
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// GetEnumerator is the method implementation of the GetEnumerator method in the ICollection interface.
        /// The method provides all the values in the underlying collection.<br />
        /// Time complexity: O(n)
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;

            for (int i = 0; i < Count; i++)
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
            return GetEnumerator();
        }

        #endregion
    }
}
