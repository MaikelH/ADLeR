using System;
using System.Collections;
using System.Collections.Generic;

namespace ADLER.Collections.Geometric
{
    public class KdTree<T> : ICollection<T>
    {
        private readonly Func<T, T, int, int> _compareFunction;
        private KdTreeNode<T> _root; 

        public KdTree(int dimensionality, Func<T,T, int, int> compareFunction)
        {
            _compareFunction = compareFunction;
            Dimensionality = dimensionality;
            IsReadOnly = false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the tree
        /// </summary>
        /// <param name="item">Value to add to the tree.</param>
        public void Add(T item)
        {
            Add(item, ref _root, 1);
        }

        private void Add(T item, ref KdTreeNode<T> node, int depth)
        {
            if (node == null)
            {
                node = new KdTreeNode<T>(item);
                Count++;
            }
            else
            {
                int Dimen = depth%Dimensionality;
                int compareValue = _compareFunction(node.Value, item, depth % Dimensionality);

                // Current value in the node is smaller than in item. So use right node.
                if(compareValue <= 0)
                {
                    if(node.RightNode == null)
                    {
                        node.RightNode = new KdTreeNode<T>(item) {ParentNode = node};
                        Count++;
                    }
                    else
                    {
                        KdTreeNode<T> kdTreeNode = (node.RightNode);
                        Add(item, ref kdTreeNode, depth + 1);
                    }
                }
                else
                {
                    if (node.LeftNode == null)
                    {
                        node.LeftNode = new KdTreeNode<T>(item) { ParentNode = node };
                        Count++;
                    }
                    else
                    {
                        KdTreeNode<T> kdTreeNode = (node.LeftNode);
                        Add(item, ref kdTreeNode, depth + 1);
                    }    
                }
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }
        public int Dimensionality { get; private set; }
    }
}
