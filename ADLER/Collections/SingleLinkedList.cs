using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLER.Collections
{
    public class SingleLinkedList<T> : IList<T>
    {
        private SingleLinkedNode<T> _startNode;
        private int _size;
        private bool _readOnly = false;

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Insert an item at the end of the list.
        /// </summary>
        /// <param name="item">Item of type T to insert</param>
        public void Add(T item)
        {
            if(!this._readOnly)
            {
                // Check of root Node !=  null
                // if null insert as root node
                if (this._startNode == null)
                {
                    this._startNode = new SingleLinkedNode<T>(item);
                }
                else
                {
                    SingleLinkedNode<T> temp = _startNode;

                    while (temp.Next == null)
                    {
                        temp = temp.Next;
                    }

                    // End of list found insert element 
                    temp.Next = new SingleLinkedNode<T>(item);
                }

                this._size++;
            }
        }

        /// <summary>
        /// Clears the contents of the list and resets size of the collection to zero.
        /// </summary>
        public void Clear()
        {
            if (!this._readOnly)
            {
                this._startNode = null;
                this._size = 0;
            }
        }

        public bool Contains(T item)
        {
            SingleLinkedNode<T> temp = this._startNode;

            while (temp.Next != null)
            {
                if (temp.Equals(item))
                {
                    return true;
                }
                
                temp = temp.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the number of elements in this collection.
        /// </summary>
        public int Count
        {
            get { return _size; }
        }

        /// <summary>
        /// Returns whether this collection is read-only. If the collection is read-only this elements of this 
        /// collection cannot be modified, removed or added.
        /// </summary>
        public bool IsReadOnly
        {
            get { return this._readOnly; }
        }

        /// <summary>
        /// Removes the specified element from the collection.
        /// </summary>
        /// <param name="item">Element to remove</param>
        /// <returns>True if element is removed</returns>
        public bool Remove(T item)
        {
            if (!_readOnly)
            {
                SingleLinkedNode<T> temp = this._startNode;

                if (temp.Equals(item))
                {
                    return removeAfter(temp);
                }
                else
                {
                    while (temp.Next != null)
                    {
                        if (temp.Next.Equals(item))
                        {
                            return removeAfter(temp);
                        }
                    }
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private bool removeAfter(SingleLinkedNode<T> node)
        {
            if (node.Next == null)
            {
                return false;
            }

            node.Next = node.Next.Next;

            return true;
        }
    }
}
