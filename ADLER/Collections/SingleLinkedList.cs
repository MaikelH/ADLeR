﻿using System;
using System.Collections.Generic;
using ADLER.Collections.Enumerators;

namespace ADLER.Collections
{
    public class SingleLinkedList<T> : IList<T>
    {
        private SingleLinkedNode<T> _startNode;
        private int _size;
        private bool _readOnly = false;

        public int IndexOf(T item)
        {
            SingleLinkedNode<T> temp = _startNode;

            for (int i = 0; i < _size; i++)
            {
                if (temp.Value.Equals(item))
                {
                    return i;
                }

                temp = temp.Next;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (_readOnly) return;
            
            if (index <= _size)
            {
                SingleLinkedNode<T> temp = _startNode;

                if (index == 0)
                {
                    _startNode = _startNode.Next;
                    _size--; 
                }
                else
                {
                    for (int i = 1; i < index; i++)
                    {
                        temp = temp.Next;
                    }

                    removeAfter(temp);
                    _size--;   
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
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

            for(int i = 0; i < _size; i++)
            {
                if (temp.Value.Equals(item))
                {
                    return true;
                }
                
                temp = temp.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < _size)
            {
                throw new ArgumentException("The collection is bigger than the available space in the array");   
            }

            SingleLinkedNode<T> temp = _startNode;
            for (int i = 0; i < _size; i++)
            {
                array[i + arrayIndex] = temp.Value;
                temp = temp.Next;
            }
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
            return new SingleLinkedListEnumerator<T>(_startNode);
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
