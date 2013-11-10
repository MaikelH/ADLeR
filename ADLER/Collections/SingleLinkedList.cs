using System;
using System.Collections.Generic;

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
                SingleLinkedNode<T> temp = _startNode;
                
                for (int i = 0; i < index; i++)
                {
                    temp = _startNode.Next;
                }

                return temp.Value;
            }
            set
            {
                Insert(0, value);
            }
        }

        /// <summary>
        /// Insert an item at the end of the list.
        /// </summary>
        /// <param name="item">Item of type T to insert</param>
        public void Add(T item)
        {
            if(!_readOnly)
            {
                // Check of root Node !=  null
                // if null insert as root node
                if (_startNode == null)
                {
                    _startNode = new SingleLinkedNode<T>(item);
                }
                else
                {
                    SingleLinkedNode<T> temp = _startNode;

                    // ReSharper disable once PossibleNullReferenceException
                    while (temp.Next != null)
                    {
                        temp = temp.Next;
                    }

                    // End of list found insert element 
                    temp.Next = new SingleLinkedNode<T>(item);
                }

                _size++;
            }
        }

        /// <summary>
        /// Clears the contents of the list and resets size of the collection to zero.
        /// </summary>
        public void Clear()
        {
            if (!_readOnly)
            {
                _startNode = null;
                _size = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            SingleLinkedNode<T> temp = _startNode;

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
            get { return _readOnly; }
        }

        /// <summary>
        /// Removes the specified element from the collection.
        /// </summary>
        /// <param name="item">Element to remove</param>
        /// <returns>True if element is removed</returns>
        public bool Remove(T item)
        {

            bool returnVal = false;
            if (!_readOnly)
            { 
                if (_startNode.Value.Equals(item))
                {
                    _startNode = _startNode.Next;
                    returnVal = true;
                }
                else
                {
                    SingleLinkedNode<T> temp = _startNode;
                    while (temp.Next != null)
                    {
                        if (temp.Next.Value.Equals(item))
                        {
                            returnVal = removeAfter(temp);
                            // Break is used here because there should be only one place for return.
                            // This because the size decrement can always be guaranteed
                            break;
                        }

                        temp = temp.Next;
                    }    
                }
            }

            if (returnVal)
            {
                _size--;
            }
            return returnVal;
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
