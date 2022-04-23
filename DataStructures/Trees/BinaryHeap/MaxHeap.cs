using System;
using System.Collections.Generic;
using System.Diagnostics;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Trees.BinaryHeap
{
    public class MaxHeap<T> : BinaryHeap<T>
    {
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

        protected override T Maximum { get { return Root; } }

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

        protected override void HeapifyDownIterative(int indexOfElement)
        {
            try
            {
                for (int i = indexOfElement; (2 * i) + 2 < Count; i++)
                {
                    int indexOfLeftChild = 2 * i + 1;
                    int indexOfRightChild = 2 * i + 2;

                    int indexOfLargerChild = 0;

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
                        default:       // If that is not the case then just come out of the switch without any swap
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

        protected override void HeapifyDownRecursive(int indexOfElement)
        {
            try
            {
                if (indexOfElement < Count)
                {
                    int indexOfLeftChild = 2 * indexOfElement + 1;
                    int indexOfRightChild = 2 * indexOfElement + 2;

                    int indexOfLargerChild = 0;

                    if (indexOfLeftChild < Count && indexOfRightChild < Count)
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
                            default:       // If that is not the case then just come out of the switch without any swap
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
    }
}
