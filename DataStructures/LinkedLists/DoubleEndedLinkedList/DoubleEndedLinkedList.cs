using System;
using System.Collections;
using System.Collections.Generic;
using ErrMsgs = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.LinkedLists.DoubleEndedLinkedList
{
    public class DoubleEndedLinkedList<T> : ICollection<T>
    {

        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
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
                        node.Next = Head;       // Make the new node point to old head
                        Head.Previous = node;   // Make the existing head's previous pointer point to the new node
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

        public void AddTail(T value)
        {
            AddTail(new Node<T>() { Value = value });
        }

        public void AddTail(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public void RemoveHead()
        {
            throw new NotImplementedException();
        }

        public void RemoveTail()
        {
            throw new NotImplementedException();
        }

        public bool AddAfter(T item)
        {
            return AddAfter(new Node<T>() { Value = item });
        }

        public bool AddAfter(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public bool AddBefore(T item)
        {
            return AddBefore(new Node<T>() { Value = item });
        }

        public bool AddBefore(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }        

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
