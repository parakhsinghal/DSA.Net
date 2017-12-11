using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ErrMsgs = DataStructures.ErrorMessages.ErrorMessages_US_en;

namespace DataStructures.BinaryTree
{
    public class BinaryTree<T>
    {
        public Node<T> Root { get; set; }

        public bool Insert(Node<T> node)
        {
            throw new NotImplementedException();
        }

        public bool Find(T value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T value)
        {
            throw new NotImplementedException();
        }

        public void TraverseInOrder()
        {
            throw new NotImplementedException();
        }

        public void TraversePreOrder()
        {
            throw new NotImplementedException();
        }

        public void TraversePostOrder()
        {
            throw new NotImplementedException();
        }
    }
}
