using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Err = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.Trees.BinaryHeap
{
    public class MinHeap<T>:BinaryHeap<T>
    {
        protected override void HeapifyUp(int indexOfElement)
        {
            base.HeapifyUp(indexOfElement);
        }

        protected override void HeapifyDown(int indexOfElement)
        {
            base.HeapifyDown(indexOfElement);
        }
    }
}
