using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ErrMsgs = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.LinkedLists.CircularDoublyLinkedList
{
    public class CircularDoublyLinkedList<T> : ICollection<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; private set; }

        #region Standard linked list functionality

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);

            try
            {
                if (node.IsValid)
                {
                    if (Count == 0)
                    {
                        Head = node;    // Make the node the new Head                        
                        Tail = node;
                        Head.Next = Head.Previous = Tail.Next = Tail.Previous = node;   //make the linked list circular
                    }
                    else
                    {
                        node.Next = Head;       // Make the new node point to old head
                        Head.Previous = node;   // Make the existing head's previous pointer point to the new node
                        Head = node;            // Make the new node the new Head                        
                    }

                    Count++;        // Increase the node count
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

        public void RemoveHead()
        {
            try
            {
                if (Count == 0) // If the linked list is empty, throw an error message
                {
                    throw new InvalidOperationException(ErrMsgs.LinkedList_RemoveHead_EmptyList);
                }
                else
                {
                    if (Count == 1)
                    {
                        Head = Tail = null;
                    }
                    else
                    {
                        // If the count is greater than 1, point the head to the next node
                        // If the count is equal to 1, i.e. only Head exists, point the Head to null (given by Next property)
                        // Since this is a doubly linked list, we need to make the previous reference of the newly created head
                        // point to null.
                        Head = Head.Next;
                        Head.Previous = Tail;
                    }

                    Count--;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

        }

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

        public void AddTail(T value)
        {
            AddTail(new Node<T>() { Value = value });
        }

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
                        node.Previous = Tail;
                        Tail = node;
                        Tail.Next = Head;
                    }

                    Count++;
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
                    if (Count == 1) // If there's only one node then make both the head and tail null
                    {
                        Head = null;
                        Tail = null;
                    }
                    else // If the count is greater than 1 and there are elements in the linked list
                    {
                        Node<T> tempNode = Tail.Previous;
                        Tail.Previous = null;
                        tempNode.Next = null;
                        Tail = tempNode;
                        Tail.Next = Head;
                    }

                    Count--; // Decrement the counter.
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public void AddAfter(T neighborToLeft, T itemToBeAdded)
        {
            AddAfter(new Node<T>() { Value = neighborToLeft }, new Node<T>() { Value = itemToBeAdded });
        }

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
                        nodeToBeAdded.Previous = Tail;
                        Tail = nodeToBeAdded;
                        Tail.Next = Head;
                    }
                    else
                    {
                        currentNode.Next.Previous = nodeToBeAdded; // Changing the Previous reference of neighbour to right
                        nodeToBeAdded.Next = currentNode.Next;     // Changing the Next reference of the node to be added to the current node
                        nodeToBeAdded.Previous = currentNode;      // Changing the Previous reference of the node to be added to the current node
                        currentNode.Next = nodeToBeAdded;          // Changing the Next reference of the current node to the node to be added
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

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

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
                        // If the count  = 1 and the item is cound, then implicitly we are referring to the head/tail and 
                        // need it to be removed.
                        Head = null;
                        Tail = null;
                    }
                    else
                    {
                        // If we are here then the count is greater then 1 and we need to figure out the item to be removed
                        // from the list.
                        Node<T> currentNode = Head;

                        for (int i = 0; i < Count; i++)
                        {
                            if (currentNode.Next.Value.Equals(item))
                            {
                                // If the value found happens to be in the between the Head and the Tail node
                                // then create two temporary node that will form neighbours to the node that needs to be deleted.
                                // They will refer each other appropriately.

                                Node<T> neighborToLeft = currentNode.Previous;
                                Node<T> neighborToRight = currentNode.Next;

                                neighborToLeft.Next = neighborToRight;
                                neighborToRight.Previous = neighborToLeft;
                                break;
                            }
                            currentNode = currentNode.Next;
                        }
                    }

                    Count--;
                    return true;
                }

                return false; // If we have reached here, that means that the value to be removed was not .ound

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;

            for (int i = 0; i < Count; i++)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }

        #endregion
    }
}
