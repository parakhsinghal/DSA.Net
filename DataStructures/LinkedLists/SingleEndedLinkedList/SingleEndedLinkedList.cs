using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ErrMsgs = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.LinkedLists.SingleEndedLinkedList
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleEndedLinkedList<T> : ICollection<T>
    {
        public Node<T> Head { get; set; }
        public int Count { get; private set; }

        public SingleEndedLinkedList()
        {
            Head = null;
            Count = 0;
        }

        /// <summary>
        /// Add method is a standard method available on a linked list and creates a node in a linked list.
        /// The node is created in position of a new head, if the list is empty, or in place of an existing one, if 
        /// the list is not empty.
        /// </summary>
        /// <param name="item">The value of the node to be added as a head.</param>
        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);

            try
            {
                Node<T> node = new Node<T>(item);
                if (node.IsValid)
                {
                    if (Count == 0)
                    {
                        Head = node;    // Make the node the new Head
                        Count++;        // Increase the node count
                    }
                    else
                    {
                        node.Next = Head;   // Make the new node point to old head
                        Head = node;        // Make the new node the new Head
                        Count++;            // Increase the node count
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
        /// Peek is a standard method available on a linked list and returns the value of the head node.
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

        /// <summary>
        /// RemoveHead method is a standard method available on a linked list and removes the top node i.e. head.
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
                            if (Count == 1)
                            {
                                Head = null;
                            }
                            // If the value happens to be part of the last node then
                            // create a temporary node that will become the second to last node
                            // and release the last node
                            else if (currentNode.Next == null)
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

                            Count--;
                            return true;
                        }

                        currentNode = currentNode.Next;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Clear is a method implementation of the Clear method declared in the ICollection interface.
        /// /// The methods clears the members of the underlying collection.
        /// </summary>
        public void Clear()
        {
            try
            {
                Head = null;
                Count = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

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
            try
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

    }
}
