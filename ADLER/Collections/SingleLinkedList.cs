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
            if (!this._readOnly)
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
        /// Clears the contents of the list and resets size to zero.
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
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _size; }
        }

        public bool IsReadOnly
        {
            get { return this._readOnly; }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
