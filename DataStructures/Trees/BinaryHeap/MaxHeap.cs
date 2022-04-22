using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Trees.BinaryHeap
{
    public class MaxHeap<T> : BinaryHeap<T>
    {
        protected override void HeapifyUp(int indexOfElement)
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

        protected override void HeapifyDown(int indexOfElement)
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
                            HeapifyDown(indexOfLargerChild);
                            break;
                        default:       // If that is not the case then just come out of the switch without any swap
                            break;
                    }
                }
            }
        }
    }
}
