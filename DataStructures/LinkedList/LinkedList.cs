using System;
using System.Collections;
using System.Collections.Generic;
using Err_Msgs = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.LinkedList
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

        public void RemoveHead()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException(Err_Msgs.LinkedList_RemoveHead_EmptyList);
            }
            else
            {
                Head = Head.Next;
                Count--;
            }
        }       

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            Node<T> nodeToBeAdded = new Node<T>() { Value = item };

            if (Count == 0)
            {
                Head = nodeToBeAdded;                
            }
            else
            {
                Node<T> currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = nodeToBeAdded;               
            }

            Count++;
        }        

        public void Clear()
        {
            Head = null;
        }

        public bool Contains(T item)
        {
            if (Count == 0)
            {
                throw new InvalidOperationException(Err_Msgs.LinkedList_Contains_EmptyList);
            }
            else
            {
                Node<T> currentNode = Head;
                while (currentNode != null)
                {
                    if (currentNode.Value.Equals(item))
                    {
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
                return false;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (Count == 0)
            {
                throw new InvalidOperationException(Err_Msgs.LinkedList_Remove_EmptyList);
            }
            else
            {
                Node<T> currentNode = Head;
                
                while (currentNode != null)
                {
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
