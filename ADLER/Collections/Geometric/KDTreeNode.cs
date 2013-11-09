using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADLER.Collections.Geometric
{
    internal class KdTreeNode<T>
    {
        private KdTreeNode<T> _leftNode;
        private KdTreeNode<T> _rightNode;
        private KdTreeNode<T> _parentNode;
        private T _value;

        public KdTreeNode(T value)
        {
            _value = value;
        }

        public KdTreeNode<T> LeftNode
        {
            get { return _leftNode; }
            set { _leftNode = value; }
        }

        public KdTreeNode<T> RightNode
        {
            get { return _rightNode; }
            set { _rightNode = value; }
        }

        public KdTreeNode<T> ParentNode
        {
            get { return _parentNode; }
            set { _parentNode = value; }
        }

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
