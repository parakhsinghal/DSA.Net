using System;
using System.Collections.Generic;
using System.Diagnostics;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Trees.BinaryHeap
{
    /// <summary>
    /// The BinaryHeap class is an abstrat class encapsulating methods common to both Max and Min heaps.
    /// The class implements the template pattern by implementing most of the common functionality
    /// in the form of methods such as insert and remove, while leaving the heap specific
    /// functionality (HeapifyDown, HeapifyUp, Min and Max Properties etc.) depending on the 
    /// heap property (Max or Min Heaps), on the derived classes.
    /// </summary>
    /// <typeparam name="T">The data type of the Binary class. E.g. int, char or a user defined type.</typeparam>
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

        /// <summary>
        /// Default constructor which initializes the underlying data store.
        /// </summary>
        public BinaryHeap()
        {
            dataStore = new List<T>();
        }

        /// <summary>
        /// Heap is conceptually represented as a binary tree. Root 
        /// provides a convinient way to access the first element in the 
        /// binary tree, here the first element in the underlying data store.
        /// </summary>
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

        /// <summary>
        /// Count of the number of elements in the underlying data store.
        /// </summary>
        public int Count { get { return dataStore.Count; } }

        /// <summary>
        /// Provides the minimum element in the heap.
        /// </summary>
        protected virtual T Minimum { get; set; }

        /// <summary>
        /// Provides the maximum element in the heap.
        /// </summary>
        protected virtual T Maximum { get; set; }

        /// <summary>
        /// Inserts an element into the underlying datastore.
        /// </summary>
        /// <param name="element">The element that is desired to be inserted into the data store.</param>
        /// <returns>A boolean result. True is successful and false otherwisse.</returns>
        /// <exception cref="ArgumentException">Throws an ArgumentException if an attepmt is made to insert a duplicate element. </exception>
        public bool Insert(T element)
        {
            try
            {
                if (element is null)
                {
                    throw new ArgumentNullException(Err.BinaryHeap_Insert_NullElement);
                }

                if (dataStore.Contains(element))
                {
                    throw new ArgumentException(Err.BinaryHeap_Insert_DuplicateElement);
                }

                dataStore.Add(element);
                int indexOfInsertedElement = Count - 1;
                HeapifyUpIterative(indexOfInsertedElement);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Removes a desired element from the heap.
        /// </summary>
        /// <remarks>The value removed is replaced with the last value in the heap 
        /// and is then placed to follow the heap property (min or max heap)
        /// and the shape property (complete binary tree)</remarks>
        /// <param name="element">The element desired to be removed.</param>
        /// <exception cref="InvalidOperationException">Throws InvalidOperationException
        /// is an attempt is made to remove an element from an empty heap.</exception>
        /// <exception cref="ArgumentException">Throws an ArgumentException if an 
        /// attempt is made to remove an element not availble in the heap.</exception>
        public void Remove(T element)
        {
            /*
                Pseudocode:
                1. Test if the underlying data store is empty. If yes, throw an InvalidOperationException.
                2. Search for the element in the list if it is available. Get the index of the element
                   and if the element is greater than 1, then proceed, otherwise throw 
                   an argumentexception.
                3. Since this is a heap we always remove the root and repalce the last element in the 
                   data store with it. Because we have to maintain the heap property (min/max) we do the
                   heapifydown operations from there, till the heap achieve the heap property.
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

                // Calculate the index of the element to be deleted
                // and swap it with the last element in the heap.
                // Remove the last element from the data store.
                int indexOfLastElement = Count - 1;
                Swap(indexOfElementToBeDeleted, indexOfLastElement);
                dataStore.RemoveAt(indexOfLastElement);

                HeapifyDownIterative(indexOfElementToBeDeleted);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Clears the contents of the heap.
        /// </summary>
        public void Clear()
        {
            if (dataStore.Count > 0)
            {
                dataStore.Clear();
            }
        }

        /// <summary>
        /// Swaps the two elements located at the provided index values.
        /// </summary>
        /// <param name="toBeSwapped">The element to be swapped.</param>
        /// <param name="swappedWith">The element to be swapped with.</param>
        /// <exception cref="IndexOutOfRangeException">Throws an IndexOutOfRange
        /// exception if the provided index values are negitive or greater than 
        /// the count of the number of elements in the underlying data store.</exception>
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

        /// <summary>
        /// HeapifyUp method re-arranges the elements in a heap after the insertion 
        /// of an element restoring the heap property (min or max heap) and the 
        /// shape property. This method does it iteratively.
        /// </summary>
        /// <remarks>The newly inserted element is inserted at the last of the data store
        /// and from there moved up depending upon the heap property.</remarks>
        /// <param name="indexOfElement">Index of the element that's been inserted and needs
        /// to be appropriately placed in the heap to restore the heap property.</param>
        protected virtual void HeapifyUpIterative(int indexOfElement)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// HeapifyUp method re-arranges the elements in a heap after the insertion 
        /// of an element restoring the heap property (min or max heap) and the 
        /// shape propertyof the heap (complete binary tree). 
        /// This method does it recursively.
        /// </summary>
        /// <remarks>The newly inserted element is inserted at the last of the data store
        /// and from there moved up depending upon the heap property.</remarks>
        /// <param name="indexOfElement">Index of the element that's been inserted and needs
        /// to be appropriately placed in the heap to restore the heap property.</param>
        protected virtual void HeapifyUpRecursive(int indexOfElement)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// HeapifyDown method re-arranges the elements in a heap after the deletion
        /// of an element, restoring the heap property (min or max heap) and the 
        /// shape property of the heap (complete binary tree).
        /// This method does it iteratively.
        /// </summary>
        /// <remarks>The element intended to be deleted is replaced with the last element
        /// in the heap. Then this newly replaced element's index is passed to the
        /// HeapifyDown method, to have the elements be re-arranged in order to 
        /// restore the heap property and shape property.</remarks>
        /// <param name="indexOfElement">Index of the element that's been deleted
        /// and needs to be appropriately </param>
        protected virtual void HeapifyDownIterative(int indexOfElement)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// HeapifyDown method re-arranges the elements in a heap after the deletion
        /// of an element, restoring the heap property (min or max heap) and the 
        /// shape property of the heap (complete binary tree).
        /// This method does it recursively.
        /// </summary>
        /// <remarks>The element intended to be deleted is replaced with the last element
        /// in the heap. Then this newly replaced element's index is passed to the
        /// HeapifyDown method, to have the elements be re-arranged in order to 
        /// restore the heap property and shape property.</remarks>
        /// <param name="indexOfElement">Index of the element that's been deleted
        /// and needs to be appropriately </param>
        protected virtual void HeapifyDownRecursive(int indexOfElement)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetElementsSorted method sorts elements available in a heap in the desired
        /// order - ascending or desending.                 
        /// </summary>
        /// <remarks>*** PLEASE NOTE THAT THE HEAP GETS ELIMINATED AS PART OF THE HEAPSORT ACTIVITY. ***</remarks>
        /// <param name="orderType">The order type - Ascending or Descending.</param>
        /// <returns>A list of all the sorted elemets in the desired order.</returns>        
        public virtual List<T> GetElementsSorted(OrderType orderType)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// The order type enum - Asecnding or Descending.
    /// </summary>
    public enum OrderType
    {
        Ascending,
        Descending
    }
}
