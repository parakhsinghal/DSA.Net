using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Algorithms.Sorting
{
    public class QuickSort<T>
    {
        public void Sort(T[] input, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int pivotIndex = Partition(input, lowIndex, highIndex);
                Sort(input, lowIndex, pivotIndex - 1);
                Sort(input, pivotIndex + 1, highIndex);
            }
        }

        private int Partition(T[] input, int lowerBound, int upperBound)
        {
            T pivot = input[lowerBound]; // Pick a pivot point based on the low index provided.

            int startIndex = lowerBound, endIndex = upperBound;

            while (startIndex < endIndex)
            {
                while (Comparer.Default.Compare(input[startIndex], pivot) <= 0 && startIndex < endIndex)
                {
                    startIndex++;
                }

                while (Comparer.Default.Compare(input[endIndex], pivot) > 0)
                {
                    endIndex--;
                }

                if (startIndex < endIndex)
                {
                    Swap(input, startIndex, endIndex);
                }
            }

            Swap(input, lowerBound, endIndex);
            return endIndex;
        }

        private void Swap(T[] input, int toBeSwappedIndex, int swappedWithIndex)
        {
            T temp = input[toBeSwappedIndex];
            input[toBeSwappedIndex] = input[swappedWithIndex];
            input[swappedWithIndex] = temp;
        }

    }
}
