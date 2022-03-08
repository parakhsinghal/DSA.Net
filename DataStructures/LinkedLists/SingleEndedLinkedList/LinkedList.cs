using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ErrMsgs = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.LinkedLists.SingleEndedLinkedList
{
    public class LinkedList<T> : ICollection<T>
    {

        public Node<T> Head { get; set; }
        public int Count { get; private set; }

        public void AddHead(T value)
        {
            AddHead(new Node<T>() { Value = value });
        }

        public void AddHead(Node<T> node)
        {
            try
            {
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
                    // If the count is greater than 1, point the head to he next node
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public void Add(T item)
        {
            AddHead(new Node<T>() { Value = item });
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
                else
                {
                    Node<T> currentNode = Head;

                    while (currentNode != null)
                    {
                        // If the value happens to be part of the last node then
                        // create a temporary node that will become the second to last node
                        // and release the last node
                        if (currentNode.Value.Equals(item))
                        {
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

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }        
    }
}
