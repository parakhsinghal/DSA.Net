using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Trees.BinaryHeap
{
    public abstract class BinaryHeap<T>
    {
        /// <summary>
        /// The backing data store that would accommodate the elements meant to be stored
        /// in the heap.
        /// </summary>
        /// <remarks>The reason for using a list rather than an array is rooted in the 
        /// fact that the user does not have to bother to declare the size of the collection
        /// and a list can dynamically expand itself only to the extent to accommodate newer 
        /// element(s) without pre-emptive over-expansion.</remarks>
        protected List<T> dataStore;
        public T Root
        {
            get
            {
                if (dataStore.Count > 0)
                {
                    return dataStore[0];
                }
                else
                {
                    throw new InvalidOperationException(Err.BinaryHeap_Root_EmptyHeap);
                }

            }
        }
        public int Count { get { return dataStore.Count; } }

        public BinaryHeap()
        {
            dataStore = new List<T>();
        }

        public bool Insert(T element)
        {
            try
            {
                if (dataStore.Contains(element))
                {
                    throw new ArgumentException(Err.BinaryHeap_Insert_DuplicateElement);
                }

                dataStore.Add(element);
                int indexOfInsertedElement = Count - 1;
                HeapifyUp(indexOfInsertedElement);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

        }

        public void Remove(T element)
        {
            /*
                Pseudocode:
                1. Search for the element in the list if it is available. Get the index of the element
                   and if the element is greater than 1, then proceed, otherwise throw exception.
                2. Since this is a heap we always remove the root and repalce the last element in the 
                   data store with it. Becasue we have to maintain the heap property (min/max) we do the
                   heapifydown or heapifyup operations from there, till things achieve an equilibrium.
                   
             */

            try
            {
                if (Count == 0)
                {
                    throw new InvalidOperationException(Err.BinaryHeap_Remove_EmptyHeap);
                }

                int indexOfElementToBeDeleted = dataStore.IndexOf(element);
                if (indexOfElementToBeDeleted < 0)
                {
                    throw new ArgumentException(Err.BinaryHeap_Remove_ElementNotFound);
                }

                int indexOfLastElement = Count - 1;

                Swap(indexOfElementToBeDeleted, indexOfLastElement);

                dataStore.RemoveAt(indexOfLastElement);

                HeapifyDown(indexOfElementToBeDeleted);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        protected void Swap(int toBeSwapped, int swappedWith)
        {
            try
            {
                if (toBeSwapped < 0 || swappedWith < 0 || toBeSwapped > Count || swappedWith > Count)
                {
                    throw new IndexOutOfRangeException(Err.BinaryHeap_Swap_IndexOutOfRange);
                }

                T temp = dataStore[toBeSwapped];
                dataStore[toBeSwapped] = dataStore[swappedWith];
                dataStore[swappedWith] = temp;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

        }

        protected virtual void HeapifyUp(int indexOfElement)
        {
            throw new NotImplementedException();
        }

        protected virtual void HeapifyDown(int indexOfElement)
        {
            throw new NotImplementedException();
        }
    }
}
