using System;
using System.Collections.Generic;
using System.Diagnostics;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Trees.BinaryHeap
{
    /// <summary>
    /// MaxHeap is a class derived from the BinaryHeap class. It focuses on
    /// implementing a heap with the maximum heap property thereby, arranging 
    /// the elements in such a way that the parents are always greater than the 
    /// children.
    /// </summary>
    /// <typeparam name="T">The data type of the MaxHeap class. E.g. int, char or a user defined type.</typeparam>
    public class MaxHeap<T> : BinaryHeap<T>
    {
        /// <summary>
        /// Provides the minimum element in the heap.
        /// </summary>
        protected override T Minimum
        {
            get
            {
                if (dataStore.Count > 0)
                {
                    return dataStore[Count - 1];
                }
                else
                {
                    throw new InvalidOperationException(Err.BinaryHeap_Min_EmptyHeap);
                }
            }
        }

        /// <summary>
        /// Provides the maximum element in the heap.
        /// </summary>
        protected override T Maximum { get { return Root; } }

        /// <summary>
        /// HeapifyUp method re-arranges the elements in a heap after the insertion 
        /// of an element restoring the heap property (min or max heap) and the 
        /// shape property. This method does it iteratively.
        /// </summary>
        /// <remarks>The newly inserted element is inserted at the last of the data store
        /// and from there moved up depending upon the heap property.</remarks>
        /// <param name="indexOfElement">Index of the element that's been inserted and needs
        /// to be appropriately placed in the heap to restore the heap property.</param>
        protected override void HeapifyUpIterative(int indexOfElement)
        {
            // Parent's index = (index of element inserted - 1 )/2
            try
            {
                for (int i = indexOfElement; i >= 0; i--)
                {
                    // Compare the element inserted and the parent
                    switch (Comparer<T>.Default.Compare(dataStore[i], dataStore[(i - 1) / 2]))
                    {
                        case > 0:       // The element is greater than parent and thus needs to be pushed up
                            Swap(toBeSwapped: i, swappedWith: (i - 1) / 2);
                            break;
                        default:
                            break;
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
        /// HeapifyUp method re-arranges the elements in a heap after the insertion 
        /// of an element restoring the heap property (min or max heap) and the 
        /// shape propertyof the heap (complete binary tree). 
        /// This method does it recursively.
        /// </summary>
        /// <remarks>The newly inserted element is inserted at the last of the data store
        /// and from there moved up depending upon the heap property.</remarks>
        /// <param name="indexOfElement">Index of the element that's been inserted and needs
        /// to be appropriately placed in the heap to restore the heap property.</param>
        protected override void HeapifyUpRecursive(int indexOfElement)
        {
            // Parent's index = (index of element inserted - 1 )/2
            try
            {
                int indexOfParent = (indexOfElement - 1) / 2;

                if (indexOfParent >= 0)
                {
                    switch (Comparer<T>.Default.Compare(dataStore[indexOfElement], dataStore[indexOfParent]))
                    {
                        case > 0:       // The element needs to be pushed up
                            Swap(indexOfElement, indexOfParent);
                            HeapifyUpRecursive(indexOfParent);
                            break;
                        default:
                            break;
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
        protected override void HeapifyDownIterative(int indexOfElement)
        {
            /*
                Pseudocode:
                1. Take the index of the element and retrieve the left and the right children.
                2. Compare the left and the right children and pick the max of the two.
                3. Compare the aforementioned max child with the parent and if the parent is less than the
                   child, shift the parent down and child up. 
                4. When there will only be two elements present in the heap, the shape property will kick in
                   i.e. the binary tree will be complete hence there will be no holes or spaces in between 
                   the elements in underlying indexed data store. This will ensure that there will be a 
                   root and it's left child as the only surviving members. In such condition, 
                   compare the two and accordingly shift the larger entity up.                   
             */
            try
            {
                for (int i = indexOfElement; (2 * i) + 1 < Count; i++)
                {
                    int indexOfLeftChild = 2 * i + 1;
                    int indexOfRightChild = 2 * i + 2;

                    int indexOfLargerChild = 0;

                    // When there's a left and a right child.
                    if (indexOfLeftChild < Count && indexOfRightChild < Count &&
                        dataStore[indexOfLeftChild] is not null && dataStore[indexOfRightChild] is not null)
                    {
                        switch (Comparer<T>.Default.Compare(dataStore[indexOfLeftChild], dataStore[indexOfRightChild]))
                        {
                            case < 0:       // Select right child to move up
                                indexOfLargerChild = indexOfRightChild;
                                break;
                            default:        // Select left child to move up
                                indexOfLargerChild = indexOfLeftChild;
                                break;
                        }

                        switch (Comparer<T>.Default.Compare(dataStore[i], dataStore[indexOfLargerChild]))
                        {
                            case < 0:       // Swap the child selected above with parent
                                Swap(i, indexOfLargerChild);
                                break;
                            default:       // If that is not the case, come out of the switch without any swap
                                break;
                        }
                    }
                    // When there's only one child that remains - left child due to shape property. 
                    // Double confirmation in the form of Count being less than the index of the left child
                    // and greater than the index of the right child.
                    else if (indexOfLeftChild < Count && indexOfRightChild >= Count && dataStore[indexOfLeftChild] is not null)
                    {
                        switch (Comparer<T>.Default.Compare(dataStore[i], dataStore[indexOfLeftChild]))
                        {
                            case < 0:       // Swap the left child with parent
                                Swap(i, indexOfLeftChild);
                                break;
                            default:       // If that is not the case, come out of the switch without any swap
                                break;

                        }
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
        protected override void HeapifyDownRecursive(int indexOfElement)
        {
            try
            {
                int indexOfLeftChild = 2 * indexOfElement + 1;
                int indexOfRightChild = 2 * indexOfElement + 2;

                int indexOfLargerChild = 0;

                // When there's a left and a right child.
                if (indexOfLeftChild < Count && indexOfRightChild < Count &&
                    dataStore[indexOfLeftChild] is not null && dataStore[indexOfRightChild] is not null)
                {
                    switch (Comparer<T>.Default.Compare(dataStore[indexOfLeftChild], dataStore[indexOfRightChild]))
                    {
                        case < 0:       // Select right child to move up
                            indexOfLargerChild = indexOfRightChild;
                            break;
                        default:        // Select left child to move up
                            indexOfLargerChild = indexOfLeftChild;
                            break;
                    }

                    switch (Comparer<T>.Default.Compare(dataStore[indexOfElement], dataStore[indexOfLargerChild]))
                    {
                        case < 0:       // Swap the child selected above with parent
                            Swap(indexOfElement, indexOfLargerChild);
                            HeapifyDownRecursive(indexOfLargerChild);
                            break;
                        default:       // If that is not the case, come out of the switch without any swap
                            break;
                    }
                }
                // When there's only one child that remains - left child due to shape property. 
                // Double confirmation in the form of Count being less than the index of the left child
                // and greater than the index of the right child.
                // Note that we will not require any further recursive call the HeapifyDown method.
                else if (indexOfLeftChild < Count && indexOfRightChild >= Count && dataStore[indexOfLeftChild] is not null)
                {
                    switch (Comparer<T>.Default.Compare(dataStore[indexOfElement], dataStore[indexOfLeftChild]))
                    {
                        case < 0:       // Swap the left child with parent
                            Swap(indexOfElement, indexOfLeftChild);
                            break;
                        default:       // If that is not the case, come out of the switch without any swap
                            break;
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
        /// The GetElementsSorted method sorts elements available in a heap in the desired
        /// order - ascending or desending.                 
        /// </summary>
        /// <remarks>*** PLEASE NOTE THAT THE HEAP GETS ELIMINATED AS PART OF THE HEAPSORT ACTIVITY. ***</remarks>
        /// <param name="orderType">The order type - Ascending or Descending.</param>
        /// <returns>A list of all the sorted elemets in the desired order.</returns>
        public override List<T> GetElementsSorted(OrderType orderType)
        {
            try
            {
                if (Count == 0)
                {
                    throw new InvalidOperationException(Err.BinaryHeap_GetElementsInOrder_EmptyHeap);
                }

                List<T> result = new List<T>();

                int elementCount = Count;

                for (int i = 0; i < elementCount; i++)
                {
                    result.Add(Root);
                    this.Remove(Root);
                }

                // Since minheap by default produces a ascending order of elements
                // we need to explicitly reverse the order of elements to descending 
                // order.
                if (orderType == OrderType.Ascending)
                {
                    result.Reverse();
                }

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
