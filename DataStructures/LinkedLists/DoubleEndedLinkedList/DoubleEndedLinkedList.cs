using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ErrMsgs = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.LinkedLists.DoubleEndedLinkedList
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleEndedLinkedList<T> : ICollection<T>
    {

        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        { 
            AddHead(item);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Pop()
        { 
            RemoveHead();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return Head.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void AddHead(T value)
        {
            AddHead(new Node<T>() { Value = value });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public void AddHead(Node<T> node)
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
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void AddTail(T value)
        {
            AddTail(new Node<T>() { Value = value });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
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
        /// 
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveHead()
        {
            if (Count == 0) // If the linked list is empty, throw an error message
            {
                throw new InvalidOperationException(ErrMsgs.LinkedList_RemoveHead_EmptyList);
            }
            else
            {
                // If the count is equal to 1 then, point both the Head and Tail to null and decrement the counter.
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else // If the count is greater than 1, point the head to the next node and decrement the counter.
                {
                    Head = Head.Next;
                }

                // Decrement the counter
                Count--;
            }
        }

        /// <summary>
        /// 
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
                        // If the count is greater than 1 and there are elements in the linked list
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
        /// 
        /// </summary>
        /// <param name="neighborToLeft"></param>
        /// <param name="itemToBeAdded"></param>
        public void AddAfter(T neighborToLeft, T itemToBeAdded)
        {
            AddAfter(new Node<T>() { Value = neighborToLeft }, new Node<T>() { Value = itemToBeAdded });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="neighborToLeft"></param>
        /// <param name="nodeToBeAdded"></param>
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
        /// 
        /// </summary>
        /// <param name="neighborToRight"></param>
        /// <param name="itemToBeAdded"></param>
        public void AddBefore(T neighborToRight, T itemToBeAdded)
        {
            AddBefore(new Node<T>() { Value = neighborToRight }, new Node<T>() { Value = itemToBeAdded });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="neighborToRight"></param>
        /// <param name="nodeToBeAdded"></param>
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

        /// <summary>
        /// 
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Node<T> nodeToBeAdded = new Node<T>() { Value = item };

            if (Count == 0)
            {
                Head = nodeToBeAdded;
                Tail = nodeToBeAdded;
            }
            else
            {
                nodeToBeAdded.Next = Head;
                Head = nodeToBeAdded;
            }

            Count++;
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
        /// 
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
