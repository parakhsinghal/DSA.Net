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
        private List<T> dataStore;
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

        public T Remove(T element)
        {
            throw new NotImplementedException();
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            try
            {
                if (firstIndex < 0 || secondIndex < 0 || firstIndex > Count || secondIndex > Count)
                {
                    throw new IndexOutOfRangeException(Err.BinaryHeap_Swap_IndexOutOfRange);
                }

                T temp = dataStore[firstIndex];
                dataStore[firstIndex] = dataStore[secondIndex];
                dataStore[secondIndex] = temp;

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
